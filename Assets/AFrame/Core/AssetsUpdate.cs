//
// AssetsUpdate.cs
//
// Author:
//       fjy <jiyuan.feng@live.com>
//
// Copyright (c) 2019 fjy
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XLua;

namespace XAsset
{
	[LuaCallCSharp]
	public class AssetsUpdate : MonoBehaviour
	{
		public enum State
		{
			Wait,
			Checking,
			WaitDownload,
			Downloading,
			Completed,
			Error,
		}

		public State state;

		public Action completed;

		public Action updateNeed;

		public Action<string, float> progress;

		public Action<string> onError;

		private Dictionary<string, string> _versions = new Dictionary<string, string> ();
		private Dictionary<string, string> _serverVersions = new Dictionary<string, string> ();
		public readonly List<Download> _downloads = new List<Download> ();
		public int _downloadIndex;

		[SerializeField] string versionsTxt = "versions.txt";

		private void OnError (string e)
		{
			if (onError != null) {
				onError (e);
			}
			state = State.Error;
		}

		void OnProgress (string arg1, float arg2)
		{
			Debug.Log(string.Format ("{0:F0}%:{1}({2}/{3})", arg2 * 100, arg1, _downloadIndex, _downloads.Count));
		}

		void Clear ()
		{
			var dir = Path.GetDirectoryName (Utility.updatePath);
			if (Directory.Exists (dir)) {
				Directory.Delete (dir, true);
			}

			_downloads.Clear ();
			_downloadIndex = 0;
			_versions.Clear ();
			_serverVersions.Clear ();
			state = State.Wait;

			Versions.Clear (); 

			var path = Utility.updatePath + Versions.versionFile;
			if (File.Exists (path))
				File.Delete (path);
		}

		public void Check ()
		{
			Assets.Initialize (delegate {
				var path = Utility.GetRelativePath4Update (versionsTxt);
				if (!File.Exists (path)) {
					var asset = Assets.LoadAsync (Utility.GetWebUrlFromDataPath (versionsTxt), typeof(TextAsset));
					asset.completed += delegate {
						if (asset.error != null) {
							LoadVersions (string.Empty);
							return;
						}
						// Path4Update不存在就创建一个
						var dir = Path.GetDirectoryName (path);
						if (!Directory.Exists (dir))
							Directory.CreateDirectory (dir);
						File.WriteAllText (path, asset.text);
						LoadVersions (asset.text);
						asset.Release ();
					};
				} else {
					LoadVersions (File.ReadAllText (path));
				}
			}, delegate(string error) {
				// 本地没有文件，直接更新
				LoadVersions (string.Empty);
			});
			progress += OnProgress;
			state = State.Checking;
		}

		private void Awake()
		{
			DontDestroyOnLoad(gameObject);
		}

		private void Start ()
		{
			state = State.Wait;
			Versions.Load (); 
		}

		private void Update ()
		{
			if (state == State.Downloading) {
				if (_downloadIndex < _downloads.Count) {
					var download = _downloads [_downloadIndex];
					download.Update ();
					if (download.isDone) {
						_downloadIndex = _downloadIndex + 1;
						if (_downloadIndex == _downloads.Count) {
							Complete ();
						} else {
							_downloads [_downloadIndex].Start ();
						}
					} else {
						if (progress != null) {
							progress.Invoke (download.url, download.progress);
						}
					}
				}
			}
		}
			
		private void Complete ()
		{
			Versions.Save ();

			if (_downloads.Count > 0) {
				for (int i = 0; i < _downloads.Count; i++) {
					var item = _downloads [i];
					if (!item.isDone) {
						break;
					} else {
						if (_serverVersions.ContainsKey (item.path)) {
							_versions [item.path] = _serverVersions [item.path];
						}
					}
				}

				StringBuilder sb = new StringBuilder ();
				foreach (var item in _versions) {
					sb.AppendLine (string.Format ("{0}:{1}", item.Key, item.Value));
				}

				var path = Utility.GetRelativePath4Update (versionsTxt);
				if (File.Exists (path)) {
					File.Delete (path);
				}

				File.WriteAllText (path, sb.ToString ());
				Assets.Initialize (delegate {
					if (completed != null) {
						completed ();
					}
				}, OnError);
				state = State.Completed;

				Debug.Log(string.Format ("{0} files has update.", _downloads.Count));
				return;
			}

			if (completed != null) {
				completed ();
			}

			state = State.Completed;
		}

		public void Download ()
		{
			_downloadIndex = 0;
			_downloads [_downloadIndex].Start ();
			state = State.Downloading;
		}

		private void LoadVersions (string text)
		{
			LoadText2Map (text, ref _versions);
			var asset = Assets.LoadAsync (Utility.GetDownloadURL (versionsTxt), typeof(TextAsset));
			asset.completed += delegate {
				if (asset.error != null) {
					OnError (asset.error);
					return;
				}

				LoadText2Map (asset.text, ref _serverVersions);
				foreach (var item in _serverVersions) {
					string ver;
					if (!_versions.TryGetValue (item.Key, out ver) || !ver.Equals (item.Value)) {
						var downloader = new Download ();
						downloader.url = Utility.GetDownloadURL (item.Key);
						downloader.path = item.Key;
						downloader.version = item.Value;
						downloader.savePath = Utility.GetRelativePath4Update (item.Key);
						_downloads.Add (downloader);
					}
				}

				if (_downloads.Count == 0) {
					Complete ();
				} else {
					var downloader = new Download ();
					downloader.url = Utility.GetDownloadURL (Utility.GetPlatform ());
					downloader.path = Utility.GetPlatform ();
					downloader.savePath = Utility.GetRelativePath4Update (Utility.GetPlatform ());
					_downloads.Add (downloader);
					state = State.WaitDownload;
					Debug.Log(string.Format ("检查到有 {0} 个文件需要更新", _downloads.Count));

					if (updateNeed != null){
						updateNeed();
					}
				}
			};
		}

		private static void LoadText2Map (string text, ref Dictionary<string, string> map)
		{
			map.Clear ();
			using (var reader = new StringReader (text)) {
				string line;
				while ((line = reader.ReadLine ()) != null) {
					var fields = line.Split (':');
					if (fields.Length > 1) {
						map.Add (fields [0], fields [1]);
					}
				}
			}
		}
	}
}
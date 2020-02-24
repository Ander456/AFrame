# ==============================================
# This tool is for Create iOS test ipa
# ==============================================
#!/bin/sh

echo "
		打包参数
	unity_path="${unity_path}"
	project_path="${project_path}"
	git_branch="${git_branch}"
	bundleVersion="${bundleVersion}"
	"

timestamp=$(date +"%Y%m%d%H%M%S")

# sh ${project_path}/Tools/build/git.sh ${project_path} 

target=ios_${timestamp}_${branch}.ipa
output_path=$project_path/IOS

cd $project_path

echo "将Unity导出成Xcode工程"

${unity_path} -projectPath $project_path -logFile /tmp/ios_debug_${timestamp}.log -executeMethod UnityBuild.BuildIOS -${companyName}-${productName}-${bundleVersion}-${build_type}-${bundleIdentifier} -quit -batchmode

cd $output_path || { echo "build xcode proj failed, error log:"; tail -n 400 /tmp/ios_debug_${timestamp}.log; exit 1; }

echo "Xcode工程生成完毕"

rm -rf *.ipa

rm -rf *.xcarchive

echo "xcodebuild clean"

xcodebuild clean -quiet

echo "xcodebuild archive"

xcodebuild archive -quiet -project Unity-iPhone.xcodeproj -scheme Unity-iPhone -archivePath Unity-iPhone.xcarchive  CODE_SIGN_STYLE="Manual" CODE_SIGN_IDENTITY="$CODE_SIGN_IDENTITY" PROVISIONING_PROFILE_SPECIFIER="$PROVISIONING_PROFILE_NAME"

echo "++++++++++++++ xcodebuild export +++++++++++++++++++"

xcodebuild -quiet -exportArchive -archivePath Unity-iPhone.xcarchive -exportPath ${output_path}/ipa  -exportOptionsPlist ${PLIST_PATH}

OUTPUT=${output_path}/ipa

if [ ! -d "$OUTPUT" ]; then  
	echo "not found build folfer, sorry"
	exit 1
fi

cd ipa

mv Unity-iPhone.ipa ${target}

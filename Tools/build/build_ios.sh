# ==============================================
# This tool is for Create iOS test ipa
# ==============================================
#!/bin/sh

echo "
	打包参数
	unity_path="${unity_path}"
	project_path="${project_path}"
	build_path="${build_path}"
	git_branch="${git_branch}"
	identifier="${identifier}"
	bundleVersion="${bundleVersion}"
	channel=${channel}
	build_type=${build_type}
	"

# sh ${project_path}/Tools/build/git.sh ${project_path} 

timestamp=$(date +"%Y%m%d%H%M%S")

log_path=$project_path/Publish/logs/iOS/${timestamp}.log

echo "将Unity导出成Xcode工程"

rm -rf ${build_path}

${unity_path} -projectPath $project_path -quit -batchmode -logFile $log_path -executeMethod UnityBuild.BuildIOS companyName=${companyName} productName=${productName} bundleVersion=${bundleVersion} build_type=${build_type} identifier="${identifier}" channel=${channel} build_path="${build_path}"

if [ $? -ne 0 ]; then
	echo "打包失败"
    cat $log_path
    exit 1
fi

echo "Xcode工程生成完毕"

cd $build_path

rm -rf ${build_path}/build

target=ios_${timestamp}_${git_branch}.ipa

echo "xcodebuild clean"

xcodebuild clean -quiet

echo "xcodebuild archive"

xcodebuild archive -quiet -project Unity-iPhone.xcodeproj -scheme Unity-iPhone -configuration $build_type -archivePath Unity-iPhone.xcarchive CODE_SIGN_STYLE="Manual" CODE_SIGN_IDENTITY="$CODE_SIGN_IDENTITY" PROVISIONING_PROFILE_SPECIFIER="$PROVISIONING_PROFILE_NAME"

echo "++++++++++++++ xcodebuild export +++++++++++++++++++"

xcodebuild -quiet -exportArchive -archivePath Unity-iPhone.xcarchive -exportPath ${build_path}/ipa  -exportOptionsPlist ${PLIST_PATH}

OUTPUT=${build_path}/ipa

if [ ! -d "$OUTPUT" ]; then  
	echo "not found build folfer, sorry"
	exit 1
fi

cd ipa

mv Unity-iPhone.ipa ${target}

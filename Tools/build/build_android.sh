# ==============================================
# This tool is for Create android apk
# ==============================================
#!/bin/bash

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

timestamp=$(date +"%Y%m%d%H%M%S")

log_path=$project_path/Publish/logs/Android/${timestamp}.log

target=android_${timestamp}_${git_branch}.apk

# sh ${project_path}/Tools/build/git.sh ${project_path} 

echo "开始打包Android"

${unity_path} -projectPath $project_path -quit -batchmode -logFile $log_path -executeMethod UnityBuild.BuildAndroid companyName=${companyName} productName=${productName} bundleVersion=${bundleVersion} build_type=${build_type} identifier="${identifier}" channel=${channel} build_path="${build_path}/${target}"

if [ $? -ne 0 ]; then
	echo "打包失败"
    cat $log_path
    exit 1
fi

echo "打包Android完毕"

 #!/bin/sh

echo "
    unity_path="${unity_path}"
    project_path="${project_path}"
    git_branch="${git_branch}"
    platform="${platform}"
    "

function gitopt() {
    git clean -dfq
    git checkout .
    git fetch -p
    git checkout ${git_branch}
    git pull -q
    git log -1
}

log_path=$project_path/Publish/logs/AB/${timestamp}.log

######################### androids ###########################

echo "****************** android **********************"

echo "android git 还原环境，拉到最新"

cd ${project_path}

# gitopt

echo "\n开始生成Android 补丁，请耐心等待..."

${unity_path} -projectPath $project_path -quit -batchmode -logFile $log_path -executeMethod Builder.Build

if [ $? -ne 0 ];then
    echo "error Build android ab " | cat $log_path
    exit 2
fi

echo "Android 补丁生成完毕"

echo "\n\n"


######################### ios ###########################

echo "******************* ios ***********************"

echo "iOS git 还原环境，拉到最新"

cd ${project_path}

gitopt

echo "\n开始生成iOS补丁，请耐心等待..."

${unity_path} -projectPath $project_path -quit -batchmode -logFile $log_path -executeMethod Builder.Build

if [ $? -ne 0 ];then
    echo "error Build ios ab " | cat $log_path
    exit 2
fi

echo "iOS 补丁生成完毕"

echo "\n\n*******************************************"


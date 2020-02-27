 #!/bin/sh

echo "
    unity_path="${unity_path}"
    project_path="${project_path}"
    git_branch="${git_branch}"
    git_commit="${git_commit}"
    platform="${platform}"
    "

function gitopt() {
    git clean -dfq
    git checkout .
    git fetch -p
    if [ $git_commit -ne "" ]; then
        git checkout ${git_commit}
    else
        git pull -q
        git checkout ${git_branch}
    fi
    git log -1
}

log_path=$project_path/Publish/logs/AB/${timestamp}.log

function android() {
    echo "****************** android **********************"
    echo "android git 还原环境，拉到最新"
    cd ${project_path}
    # gitopt
    echo "\n开始生成Android 补丁，请耐心等待..."
    ${unity_path} -projectPath $project_path -quit -batchmode -logFile $log_path -executeMethod UnityBuild.BuildAndroidAB
    if [ $? -ne 0 ];then
        echo "error Build android ab " | cat $log_path
        exit 2
    fi
    echo "Android 补丁生成完毕"
    echo "\n\n"
}

function ios() {
    echo "******************* ios ***********************"
    echo "iOS git 还原环境，拉到最新"
    cd ${project_path}
    # gitopt
    echo "\n开始生成iOS补丁，请耐心等待..."
    ${unity_path} -projectPath $project_path -quit -batchmode -logFile $log_path -executeMethod UnityBuild.BuildIOSAB
    if [ $? -ne 0 ];then
        echo "error Build ios ab " | cat $log_path
        exit 2
    fi
    echo "iOS 补丁生成完毕"
    echo "\n\n*******************************************"
}

if [ $platform == "Android" ]; then
    android
else
    ios
fi







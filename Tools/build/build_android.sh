# ==============================================
# This tool is for Create android apk
# ==============================================
#!/bin/bash

echo "打包参数 uid is:"${uid}" branch is:"${branch}" build:"${BUILD_NUMBER}" email:"${email}"

#游戏工程目录#
PROJPATH=/Users/Alex/AFrame/

TARGET_PRE=aframe.apk

TARGET=android_${uid}_${branch}.apk

cd `dirname $0`

sh git.sh ${PROJPATH} 

cd ${PROJPATH}

rm -rf *.apk

$UNITY -quit -batchmode -projectPath $PROJPATH -logFile /tmp/android_debug_${uid}.log -executeMethod UnityBuild.BuildAndroid 

if [ $? -ne 0 ]; then
	echo "打包失败"
    cat /tmp/android_debug_${uid}.log
    exit 1
fi

cd ${PROJPATH}

mv ${TARGET_PRE} ${TARGET} || { echo "not found build apk, Sorry!"; exit 1; }

cd `dirname $0`

sh upload.sh ${PROJPATH} ${TARGET}

sh sendmail.sh ${TARGET} 

sh qrcode.sh ${TARGET}

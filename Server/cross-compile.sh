#!/bin/bash

# variables
PI_IP=192.168.0.7
TARGET=/home/root/API
CONNECTION=root@${PI_IP}

echo ${CONNECTION}

./run.publish.sh && cd ./API/bin/Release/net6.0

# copy files to raspberrypi
scp -r ./linux-arm/* ${CONNECTION}:${TARGET}
echo "Files copied ..."
# connect
ssh ${CONNECTION}

#rm -r *
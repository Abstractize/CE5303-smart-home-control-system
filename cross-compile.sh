cd ./Server
./run.publish.sh
cd ./API/bin/Release/net6.0
scp -r ./linux-arm/* pi@192.168.0.10:/home/pi/deployment-location/
ssh pi@192.168.0.10

#rm -r *
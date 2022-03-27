#!/bin/bash
cd ./API
export SYS_PATH="/sys/class/gpio"
dotnet restore -r linux-arm
dotnet publish -c Release -r linux-arm --self-contained false
cd ..
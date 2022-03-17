#!/bin/bash
cd ./API
export SYS_PATH="./bin/Debug/nte6.0/linux-x64/gpio"
dotnet restore -r linux-arm
dotnet publish -c Release -r linux-arm --self-contained false
cd ..
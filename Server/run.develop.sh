#!/bin/bash
cd ./API
export SYS_PATH="./bin/Debug/net6.0/linux-x64/gpio"
dotnet restore -r linux-x64 --no-self-contained
dotnet build -c Debug -r linux-x64 --no-self-contained
dotnet run -c Debug -r linux-x64 --no-self-contained
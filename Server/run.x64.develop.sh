#!/bin/bash
cd ./API
export SYS_PATH="./bin/Debug/net6.0/gpio"
dotnet restore
dotnet build -c Debug --no-self-contained
dotnet run -c Debug --no-self-contained
cd ..
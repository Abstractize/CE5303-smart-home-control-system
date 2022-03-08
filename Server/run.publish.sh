# Compile C lib
cd ./HardwareController
cmake --build "./build" --config Release --target all -j 10 --
cd ../API

dotnet restore
dotnet publish -r linux-arm
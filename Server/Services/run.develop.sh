# Compile C lib
cd ./HardwareController
cmake --build "./build" --config Debug --target all -j 10 --
cd ../API

dotnet restore
dotnet build
dotnet run
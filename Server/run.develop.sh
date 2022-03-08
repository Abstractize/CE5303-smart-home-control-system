cd ./API

dotnet restore -r linux-x64 --self-contained false
dotnet build -r linux-x64 --self-contained false
dotnet run -r linux-x64 --self-contained false
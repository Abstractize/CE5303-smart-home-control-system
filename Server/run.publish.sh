cd ./API

dotnet restore -r linux-arm --self-contained false
dotnet publish -r linux-arm --self-contained false
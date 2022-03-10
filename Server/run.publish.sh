cd ./API

dotnet restore -r linux-arm --self-contained false
dotnet publish -c Release -r linux-arm --self-contained false
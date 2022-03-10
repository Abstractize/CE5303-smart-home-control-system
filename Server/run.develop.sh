cd ./API

dotnet restore -r linux-x64 --no-self-contained
dotnet build -c Debug -r linux-x64 --no-self-contained
dotnet run -c Debug -r linux-x64 --no-self-contained
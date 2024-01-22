FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app

COPY . .

COPY . /app/

COPY ./bin/Release/net6.0 ./

ENTRYPOINT ["dotnet", "test", "BasicEshopCrud.Api.IntegrationTests.dll"]
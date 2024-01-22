#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base

WORKDIR /app
EXPOSE 5001

COPY ./bin/Release/net6.0/publish ./

ENTRYPOINT ["dotnet", "BasicEshopCrud.Api.dll"]
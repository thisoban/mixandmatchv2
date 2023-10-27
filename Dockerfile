#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM ubuntu:20.04

# Install required dependencies
RUN apt-get update && apt-get install -y software-properties-common
RUN add-apt-repository universe
RUN apt-get update && apt-get install -y wget apt-transport-https

# Download and install the .NET SDK
RUN wget -q https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN apt-get update
RUN apt-get install -y dotnet-sdk-7.0


FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["mixandmatchv2.csproj", "."]
RUN dotnet restore "./mixandmatchv2.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "mixandmatchv2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mixandmatchv2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "obj/Debug/net7.0/mixandmatchv2.dll"]
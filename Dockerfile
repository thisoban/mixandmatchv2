#
#
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "mixandmatchv2.csproj"
RUN dotnet build "mixandmatchv2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mixandmatchv2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
 ENTRYPOINT ["dotnet", "mixandmatchv2.dll"]


#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
#WORKDIR /app
#
#COPY mixandmatchv2.csproj ./
#RUN dotnet restore
#
#COPY . ./
#RUN dotnet publish -c Release 
#FROM mcr.microsoft.com/dotnet/sdk:7.0
#WORKDIR /app
#EXPOSE 5010/tcp
#ENV ASPNETCORE_URLS http://*:5010
#COPY — from=build-env /app/out .
#ENTRYPOINT [“dotnet”, “mixandmatchv2.dll”]
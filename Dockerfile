#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /app
#COPY ["mixandmatchv2.csproj", "."]
#RUN dotnet restore "./mixandmatchv2.csproj"
#COPY . .
#WORKDIR "/app"
#RUN dotnet build "mixandmatchv2.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "mixandmatchv2.csproj" -c Release -o /app 
#
#FROM base AS final
#WORKDIR /app
#cmd ["dotnet", "mixandmatchv2.dll"]

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore "./mixandmatchv2.csproj"
#run dotnet restore ".DTO/DTO.csproj"
# Build and publish a release
RUN dotnet publish "./mixandmatchv2.csproj" -c Release -o out


# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
#EXPOSE 443
#EXPOSE 80
ENTRYPOINT ["dotnet", "mixandmatchv2.dll"]
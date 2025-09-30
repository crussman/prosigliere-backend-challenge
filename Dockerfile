FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /src

COPY . .

RUN dotnet restore ./Prosigliere.Challenge.WebApi/Prosigliere.Challenge.WebApi.csproj

WORKDIR /src/Prosigliere.Challenge.WebApi

EXPOSE 8080
EXPOSE 8081

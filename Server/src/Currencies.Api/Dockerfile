FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /Server/src
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /Server/src
COPY ["Server/src/Currencies.Api/Currencies.Api.csproj", "Server/src/Currencies.Api/"]

RUN dotnet restore "Server/src/Currencies.Api/Currencies.Api.csproj"
COPY . .
WORKDIR "Server/src/Currencies.Api"
RUN dotnet build "Currencies.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Currencies.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /Server/src
COPY --from=publish /app/publish .
USER root
RUN apt-get update
RUN apt-get install -y dos2unix
COPY ["Server/src/Currencies.Api/wait-for-it.sh", "."]
RUN dos2unix ./wait-for-it.sh
RUN chmod +x ./wait-for-it.sh
ENTRYPOINT ["./wait-for-it.sh", "database:1433", "-t", "20","--", "dotnet", "Currencies.Api.dll"]
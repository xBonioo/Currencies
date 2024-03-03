FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /src
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Currencies.Api/Currencies.Api.csproj", "src/Currencies.Api/"]

RUN dotnet restore "src/Currencies.Api/Currencies.Api.csproj"
COPY . .
WORKDIR "/src/src/Currencies.Api"
RUN dotnet build "Currencies.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Currencies.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /src
COPY --from=publish /app/publish .
USER root
RUN apt-get update
RUN apt-get install -y dos2unix
COPY ["src/Currencies.Api/wait-for-it.sh", "."]
RUN dos2unix ./wait-for-it.sh
RUN chmod +x ./wait-for-it.sh
ENTRYPOINT ["./wait-for-it.sh", "database:1433", "-t", "20","--", "dotnet", "Currencies.Api.dll"]
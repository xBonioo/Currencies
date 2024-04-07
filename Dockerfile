FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /Server/src

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /Server/src
COPY ["Server/src/Currencies.Api/Currencies.Api.csproj", "Server/src/Currencies.Api/"]
COPY ["Server/src/Currencies.Common/Currencies.Common.csproj", "Server/src/Currencies.Common/"]
COPY ["Server/src/Currencies.Contracts/Currencies.Contracts.csproj", "Server/src/Currencies.Contracts/"]
COPY ["Server/src/Currencies.DataAccess/Currencies.DataAccess.csproj", "Server/src/Currencies.DataAccess/"]
COPY ["Server/src/Currencies.Models/Currencies.Models.csproj", "Server/src/Currencies.Models/"]


RUN dotnet restore "Server/src/Currencies.Api/Currencies.Api.csproj"
COPY . .

WORKDIR "/Server/src/Currencies.Api"
RUN dotnet build "Currencies.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Currencies.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /Server/src
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Currencies.Api.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Currencies.Api.dll

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["POC/POC.csproj", "POC/"]
RUN dotnet restore "POC/POC.csproj"
COPY . .
WORKDIR "/src/POC"
RUN dotnet build "POC.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "POC.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "POC.dll"]
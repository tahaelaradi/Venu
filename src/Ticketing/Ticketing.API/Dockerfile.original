FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Ticketing/Ticketing.API/Ticketing.API.csproj", "Ticketing/Ticketing.API/"]
RUN dotnet restore "Ticketing/Ticketing.API/Ticketing.API.csproj"
COPY . .
WORKDIR "/src/Ticketing/Ticketing.API"
RUN dotnet build "Ticketing.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ticketing.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ticketing.API.dll"]
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["shopping_ui/shopping_ui.csproj", "shopping_ui/"]
RUN dotnet restore "shopping_ui/shopping_ui.csproj"
COPY . .
WORKDIR "/src/shopping_ui"
RUN dotnet build "shopping_ui.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "shopping_ui.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "shopping_ui.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Masny.Bot.csproj", "Masny.Bot/"]
RUN dotnet restore "Masny.Bot/Masny.Bot.csproj"
WORKDIR "/src/Masny.Bot"
COPY . .
RUN dotnet build "Masny.Bot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Masny.Bot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Masny.Bot.dll
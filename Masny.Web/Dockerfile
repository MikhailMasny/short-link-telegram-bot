#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Masny.Web/Masny.Web.csproj", "Masny.Web/"]
RUN dotnet restore "Masny.Web/Masny.Web.csproj"
COPY . .
WORKDIR "/src/Masny.Web"
RUN dotnet build "Masny.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Masny.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Masny.Web.dll"]
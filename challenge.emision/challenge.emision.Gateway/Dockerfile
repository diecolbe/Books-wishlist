#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["challenge.emision.Gateway/challenge.emision.Gateway.csproj", "challenge.emision.Gateway/"]
COPY ["challenge.emision.Domain/challenge.emision.domain.csproj", "challenge.emision.Domain/"]
RUN dotnet restore "challenge.emision.Gateway/challenge.emision.Gateway.csproj"
COPY . .
WORKDIR "/src/challenge.emision.Gateway"
RUN dotnet build "challenge.emision.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "challenge.emision.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "challenge.emision.Gateway.dll"]
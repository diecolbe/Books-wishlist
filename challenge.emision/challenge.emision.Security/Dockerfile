#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR ./app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR ./src
COPY ["challenge.emision.Security/challenge.emision.SecurityApi.csproj", "challenge.emision.Security/"]
COPY ["challenge.emision.Presenters/challenge.emision.presenters.csproj", "challenge.emision.Presenters/"]
COPY ["challenge.emision.Ports/challenge.emision.ports.csproj", "challenge.emision.Ports/"]
COPY ["challenge.emision.DTOs/challenge.emision.dtos.csproj", "challenge.emision.DTOs/"]
COPY ["challenge.emision.shared/challenge.emision.shared.csproj", "challenge.emision.shared/"]
COPY ["challenge.emision.Domain/challenge.emision.domain.csproj", "challenge.emision.Domain/"]
COPY ["challenge.emision.IoC/challenge.emision.IoC.csproj", "challenge.emision.IoC/"]
COPY ["challenge.emision.UseCases/challenge.emision.UseCases.csproj", "challenge.emision.UseCases/"]
COPY ["challenge.emision.MongoDb/challenge.emision.mongodb.csproj", "challenge.emision.MongoDb/"]
COPY ["challenge.emision.EF/challenge.emision.EF.csproj", "challenge.emision.EF/"]
COPY ["challenge.emision.GoogleIntegrations/challenge.emision.GoogleIntegrations.csproj", "challenge.emision.GoogleIntegrations/"]
RUN dotnet restore "challenge.emision.Security/challenge.emision.SecurityApi.csproj"
COPY . .
WORKDIR "/src/challenge.emision.Security"
RUN dotnet build "challenge.emision.SecurityApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "challenge.emision.SecurityApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "challenge.emision.SecurityApi.dll"]
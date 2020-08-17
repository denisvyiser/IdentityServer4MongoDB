#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Project.identityserver.Api/Project.identityserver.Api.csproj", "Project.identityserver.Api/"]
COPY ["Project.identityserver.Application/Project.identityserver.Application.csproj", "Project.identityserver.Application/"]
COPY ["Project.identityserver.Domain/Project.identityserver.Domain.csproj", "Project.identityserver.Domain/"]
COPY ["Project.identityserver.Domain.Core/Project.identityserver.Domain.Core.csproj", "Project.identityserver.Domain.Core/"]
COPY ["Project.identityserver.IoC/Project.identityserver.IoC.csproj", "Project.identityserver.IoC/"]
COPY ["Project.identityserver.Infrastructure/Project.identityserver.Infrastructure.csproj", "Project.identityserver.Infrastructure/"]
RUN dotnet restore "Project.identityserver.Api/Project.identityserver.Api.csproj"
COPY . .
WORKDIR "/src/Project.identityserver.Api"
RUN dotnet build "Project.identityserver.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project.identityserver.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project.identityserver.Api.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src

COPY ["src/2-Services/ToDo.Api/ToDo.Api.csproj", "src/2-Services/ToDo.Api/"]
COPY ["src/4-Domain/ToDo.Domain/ToDo.Domain.csproj", "src/4-Domain/ToDo.Domain/"]
COPY ["src/5-Infra/ToDo.Infrastructure.IoC/ToDo.Infrastructure.IoC.csproj", "src/5-Infra/ToDo.Infrastructure.IoC/"]
COPY ["src/5-Infra/ToDo.Infrastructure.Data/ToDo.Infrastructure.Data.csproj", "src/5-Infra/ToDo.Infrastructure.Data/"]
COPY ["src/3-Aplication/ToDo.Application/ToDo.Application.csproj", "src/3-Aplication/ToDo.Application/"]
RUN dotnet restore "src/2-Services/ToDo.Api/ToDo.Api.csproj"

COPY . .
WORKDIR "/src/src/2-Services/ToDo.Api"
RUN dotnet build "ToDo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDo.Api.dll"]

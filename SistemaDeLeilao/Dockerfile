#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SistemaDeLeilao/SistemaDeLeilao.csproj", "src/SistemaDeLeilao/"]
RUN dotnet restore "src/SistemaDeLeilao/SistemaDeLeilao.csproj"
COPY . .
WORKDIR "/src/src/SistemaDeLeilao"
RUN dotnet build "SistemaDeLeilao.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SistemaDeLeilao.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SistemaDeLeilao.dll"]
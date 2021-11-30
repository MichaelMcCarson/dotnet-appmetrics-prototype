#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 10000
EXPOSE 10001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DotnetAppMetricsPrototype/DotnetAppMetricsPrototype.csproj", "DotnetAppMetricsPrototype/"]
RUN dotnet restore "DotnetAppMetricsPrototype/DotnetAppMetricsPrototype.csproj"
COPY . .
WORKDIR "/src/DotnetAppMetricsPrototype"
RUN dotnet build "DotnetAppMetricsPrototype.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotnetAppMetricsPrototype.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetAppMetricsPrototype.dll"]

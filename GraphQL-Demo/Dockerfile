FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GraphQL-Demo/GraphQL-Demo.csproj", "GraphQL-Demo/"]
RUN dotnet restore "GraphQL-Demo/GraphQL-Demo.csproj"
COPY . .
WORKDIR "/src/GraphQL-Demo"
RUN dotnet build "GraphQL-Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GraphQL-Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GraphQL-Demo.dll"]

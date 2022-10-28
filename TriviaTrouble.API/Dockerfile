FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TriviaTrouble/TriviaTrouble.csproj", "TriviaTrouble/"]
RUN dotnet restore "TriviaTrouble/TriviaTrouble.csproj"
COPY . .
WORKDIR "/src/TriviaTrouble"
RUN dotnet build "TriviaTrouble.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TriviaTrouble.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TriviaTrouble.dll"]

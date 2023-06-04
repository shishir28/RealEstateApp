FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Core/RealEstate.Domain/RealEstate.Domain.csproj", "src/Core/RealEstate.Domain/"]
COPY ["src/Core/RealEstate.Application/RealEstate.Application.csproj", "src/Core/RealEstate.Application/"]
COPY ["src/Infrastructure/RealEstate.Persistence/RealEstate.Persistence.csproj", "src/Infrastructure/RealEstate.Persistence/"]
COPY ["src/API/RealEstateAPI/RealEstateAPI.csproj", "src/API/RealEstateAPI/"]
RUN  dotnet restore "src/API/RealEstateAPI/RealEstateAPI.csproj"
COPY . .
WORKDIR "/src/src//API/RealEstateAPI"
RUN dotnet build "RealEstateAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RealEstateAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RealEstateAPI.dll"]

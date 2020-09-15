FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY src/MessageBoard.Api/*.csproj ./src/MessageBoard.Api/
RUN dotnet restore src/MessageBoard.Api/

# copy everything else and build app
COPY . .
WORKDIR /app/src/MessageBoard.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS runtime
WORKDIR /app
COPY --from=build /app/src/MessageBoard.Api/out ./
ENTRYPOINT ["dotnet", "MessageBoard.Api.dll"]

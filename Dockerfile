FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
EXPOSE 80
WORKDIR /app

COPY *.csproj ./
RUN for file in $(ls *.csproj); do dotnet restore $file; done

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "digiwiki.Api.dll"]
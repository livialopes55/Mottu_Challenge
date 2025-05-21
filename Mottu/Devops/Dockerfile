
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


COPY *.sln ./
COPY MottuTrackerAPI_Completo/*.csproj ./MottuTrackerAPI_Completo/
RUN dotnet restore


COPY . ./
WORKDIR /app/MottuTrackerAPI_Completo
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/MottuTrackerAPI_Completo/out ./


ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "MottuTrackerAPI_Completo.dll"]

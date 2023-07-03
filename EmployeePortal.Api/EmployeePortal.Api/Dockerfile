# Build Stage
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app
EXPOSE 80

# Copy code into container, built, test, publish

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY */*.csproj /src/csproj-files/

COPY . .
WORKDIR /src/
RUN dotnet restore && dotnet build
RUN dotnet test -v normal
RUN dotnet publish EmployeePortal.Api.csproj -c Release -o /app -r linux-x64 --self-contained false

FROM build AS publish

# Build runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "EmployeePortal.Api.dll"]


# Build Stage
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:80 

WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy code into container, built, test, publish

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["EmployeePortal.Api/EmployeePortal.Api.csproj", "EmployeePortal.Api/"]
RUN dotnet restore "EmployeePortal.Api/EmployeePortal.Api.csproj"
COPY . .
WORKDIR "/src/EmployeePortal.Api"
RUN dotnet build "EmployeePortal.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeePortal.Api.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeePortal.Api.dll"]
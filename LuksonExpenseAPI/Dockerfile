FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LuksonExpenseAPI/LuksonExpenseAPI.csproj", "LuksonExpenseAPI/"]
COPY ["LuksonExpense.Application/LuksonExpense.Application.csproj", "LuksonExpense.Application/"]
COPY ["LuksonExpense.Domain/LuksonExpense.Domain.csproj", "LuksonExpense.Domain/"]
COPY ["LuksonExpense.Infrastructure/LuksonExpense.Infrastructure.csproj", "LuksonExpense.Infrastructure/"]
RUN dotnet restore "./LuksonExpenseAPI/LuksonExpenseAPI.csproj"
COPY . .
WORKDIR "/src/LuksonExpenseAPI"
RUN dotnet build "./LuksonExpenseAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LuksonExpenseAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LuksonExpenseAPI.dll"]
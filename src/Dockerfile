FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim as base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY Mx.Messaging.Models/Mx.Messaging.Models.csproj Mx.Messaging.Models/
COPY Mx.Messaging.Api/Mx.Messaging.Api.csproj Mx.Messaging.Api/


RUN dotnet restore Mx.Messaging.Api/Mx.Messaging.Api.csproj
COPY . .
WORKDIR /src/Mx.Messaging.Api
RUN dotnet build Mx.Messaging.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Mx.Messaging.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Mx.Messaging.Api.dll"]

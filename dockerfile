# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
ARG TARGETARCH
WORKDIR /source

COPY LoginBackend/*.csproj ./LoginBackend/
RUN dotnet restore LoginBackend/LoginBackend.csproj

COPY LoginBackend/. ./LoginBackend/
RUN dotnet publish LoginBackend/LoginBackend.csproj -c Release -o /app


FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine
EXPOSE 8080
WORKDIR /app
COPY --link --from=build /app .

# Change this path to the connection string
RUN mkdir -p /app/data \
    && chown -R app:app /app/data

USER app
ENTRYPOINT ["dotnet", "LoginBackend.dll"]
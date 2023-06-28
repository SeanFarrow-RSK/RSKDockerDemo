# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine3.17 AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore --use-current-runtime /p:PublishReadyToRun=true

# copy everything else and build app
COPY ./ .
RUN dotnet publish --use-current-runtime --no-restore -o /app /p:PublishTrimmed=true /p:PublishReadyToRun=true


# Enable globalization and time zones:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/enable-globalization.md
# final stage/image
FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine3.17
WORKDIR /app
COPY --from=build /app .

EXPOSE 80

ENTRYPOINT ["./RSKDockerDemo"]
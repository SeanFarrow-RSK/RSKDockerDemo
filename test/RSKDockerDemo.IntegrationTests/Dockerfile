# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM mcr.microsoft.com/playwright/dotnet:v1.35.0-jammy as test
WORKDIR /src

# copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# copy everything else,build and run tests
COPY ./ .
RUN dotnet test
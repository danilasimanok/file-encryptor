FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /App

COPY . ./
RUN dotnet restore
RUN dotnet publish FileTransformer/FileTransformer.csproj -o out

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        fontconfig \
        libx11-6 \
        libice6 \
        libsm6 \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /App
COPY --from=build /App/out .
ENTRYPOINT ["dotnet", "FileTransformer.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# EXPOSE 80

RUN apt update &&\
         apt install -y libc6 libicu-dev libfontconfig1

ENV ASPNETCORE_URLS=http://+:80

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src

# Copy everything
COPY . ./
# Here we are adding a local folder with DevExpress packages as a source so the dotnet restore can find the packages we are referencing in our project
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c $configuration -o /app/publish /p:UseAppHost=false

WORKDIR "/src/RamenGo"
RUN dotnet build -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish -c $configuration -o /app/publish /p:UseAppHost=false

WORKDIR /app/publish
COPY RamenGo/RamenGoDB.db ./

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "RamenGo.dll"]
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet RamenGo.dll
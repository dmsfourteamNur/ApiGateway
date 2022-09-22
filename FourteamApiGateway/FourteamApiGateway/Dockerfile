FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /webapp

EXPOSE 7080
#EXPOSE 5080
 # Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

#Build image
FROM mrc.microsofts.com/dotnet/sdk:6.0
WORKDIR /webapp
COPY --from=build-env /webapp/out .
ENTRYPOINT ["dotnet","Actividad01.dll"]



FROM microsoft/aspnetcore:1
LABEL Name=tragate-admin Version=0.0.1
ARG source=.
WORKDIR /app
EXPOSE 5003
COPY $source .
ENTRYPOINT dotnet Tragate-UI.dll

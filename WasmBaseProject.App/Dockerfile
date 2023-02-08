FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WasmBaseProject.App/WasmBaseProject.App.csproj", "WasmBaseProject.App/"]
RUN dotnet restore "WasmBaseProject.App/WasmBaseProject.App.csproj"
COPY . .
WORKDIR "/src/WasmBaseProject.App"
RUN dotnet build "WasmBaseProject.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WasmBaseProject.App.csproj" -c Release -o /app/publish /p:UseAppHost=false

### STAGE 4: Run ###
FROM nginx:mainline-alpine AS final
WORKDIR /var/www/wasm-base-project
ADD  ../config/default.conf /etc/nginx/conf.d/default.conf
COPY --from=publish /app/publish/wwwroot .
CMD ["nginx", "-g", "daemon off;"]

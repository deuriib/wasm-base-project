FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BaseProject.Web/BaseProject.Web.csproj", "BaseProject.Web/"]
COPY ["BaseProject.Adapters/BaseProject.Adapters.csproj", "BaseProject.Adapters/"]
COPY ["BaseProject.Domain/BaseProject.Domain.csproj", "BaseProject.Domain/"]
COPY ["BaseProject.Infrastructure/BaseProject.Infrastructure.csproj", "BaseProject.Infrastructure/"]
RUN dotnet restore "BaseProject.Web/BaseProject.Web.csproj"
COPY . .
WORKDIR "/src/BaseProject.Web"
RUN dotnet build "BaseProject.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BaseProject.Web.csproj" -c Release -o /app/publish

FROM nginx:stable-alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
CMD ["nginx", "-g", "daemon off;"]
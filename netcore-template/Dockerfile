FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS http://*:5100
EXPOSE 5100

FROM microsoft/dotnet:sdk as builder
ARG Configuration=Release
WORKDIR /src
COPY *.sln ./

# Copy csproj and restore as distinct layers
COPY Namespace.ProjectName.Api.WebApi/*.csproj Namespace.ProjectName.Api.WebApi/
COPY Namespace.ProjectName.Application.Contract/*.csproj Namespace.ProjectName.Application.Contract/
COPY Namespace.ProjectName.Application.Implementation/*.csproj Namespace.ProjectName.Application.Implementation/
COPY Namespace.ProjectName.Domain.Entity/*.csproj Namespace.ProjectName.Domain.Entity/
COPY Namespace.ProjectName.Domain.Implementation/*.csproj Namespace.ProjectName.Domain.Implementation/
COPY Namespace.ProjectName.Infrastructure.Contract/*.csproj Namespace.ProjectName.Infrastructure.Contract/
COPY Namespace.ProjectName.Infrastructure.Implementation/*.csproj Namespace.ProjectName.Infrastructure.Implementation/
COPY Namespace.ProjectName.Persistence.Contract/*.csproj Namespace.ProjectName.Persistence.Contract/
COPY Namespace.ProjectName.Persistence.Implementation/*.csproj Namespace.ProjectName.Persistence.Implementation/

RUN dotnet restore
COPY . .
WORKDIR /src/Namespace.ProjectName
RUN dotnet build -c $Configuration -o /app ../Namespace.ProjectName.sln 

FROM builder as publish
ARG Configuration=Release
RUN dotnet publish -c $Configuration -o /app ../Namespace.ProjectName.sln

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Namespace.ProjectName.Api.WebApi.dll"]

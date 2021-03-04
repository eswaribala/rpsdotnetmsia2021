#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS runtime
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
WORKDIR /src
COPY ["PayrollAPIDockerCompose/PayrollAPIDockerCompose.csproj", "PayrollAPIDockerCompose/"]
RUN dotnet restore "PayrollAPIDockerCompose/PayrollAPIDockerCompose.csproj"
COPY . .
WORKDIR "/src/PayrollAPIDockerCompose"
RUN dotnet build "PayrollAPIDockerCompose.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PayrollAPIDockerCompose.csproj" -c Release -o /app/publish

FROM runtime AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PayrollAPIDockerCompose.dll"]
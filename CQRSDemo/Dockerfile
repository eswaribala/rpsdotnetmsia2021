FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 58886
EXPOSE 44307

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["CQRSDemo/CQRSDemo.csproj", "CQRSDemo/"]
RUN dotnet restore "CQRSDemo/CQRSDemo.csproj"
COPY . .
WORKDIR "/src/CQRSDemo"
RUN dotnet build "CQRSDemo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CQRSDemo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CQRSDemo.dll"]
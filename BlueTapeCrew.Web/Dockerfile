FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["BlueTapeCrew.Web/BlueTapeCrew.Web.csproj", "BlueTapeCrew.Web/"]
RUN dotnet restore "BlueTapeCrew.Web/BlueTapeCrew.Web.csproj"
COPY . .
WORKDIR "/src/BlueTapeCrew.Web"
RUN dotnet build "BlueTapeCrew.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BlueTapeCrew.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BlueTapeCrew.Web.dll"]
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 62842
EXPOSE 44343

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY CM.Services/CM.Services.Wallet.Views/CM.Services.Wallet.Views.Api/CM.Services.Wallet.Views.Api.csproj CM.Services/CM.Services.Wallet.Views/CM.Services.Wallet.Views.Api/
COPY CM.Shared/CM.Shared.Web/CM.Shared.Web.csproj CM.Shared/CM.Shared.Web/
COPY CM.Services/CM.Services.Wallet.Views/CM.Services.Wallet.Views.Concrete/CM.Services.Wallet.Views.Concrete.csproj CM.Services/CM.Services.Wallet.Views/CM.Services.Wallet.Views.Concrete/
COPY CM.Services/CM.Services.Wallet.Views/CM.Services.Wallet.Views.Infrastracture/CM.Services.Wallet.Views.Infrastracture.csproj CM.Services/CM.Services.Wallet.Views/CM.Services.Wallet.Views.Infrastracture/
RUN dotnet restore CM.Services/CM.Services.Wallet.Views/CM.Services.Wallet.Views.Api/CM.Services.Wallet.Views.Api.csproj
COPY . .
WORKDIR /src/CM.Services/CM.Services.Wallet.Views/CM.Services.Wallet.Views.Api
RUN dotnet build CM.Services.Wallet.Views.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CM.Services.Wallet.Views.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CM.Services.Wallet.Views.Api.dll"]

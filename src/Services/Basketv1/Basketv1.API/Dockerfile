#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Basketv1/Basketv1.API/Basketv1.API.csproj", "Services/Basketv1/Basketv1.API/"]
RUN dotnet restore "Services/Basketv1/Basketv1.API/Basketv1.API.csproj"
COPY . .
WORKDIR "/src/Services/Basketv1/Basketv1.API"
RUN dotnet build "Basketv1.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basketv1.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basketv1.API.dll"]

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo de projeto e restaura as dependências
COPY ["Sprint3/Sprint3.csproj", "Sprint3/"]
RUN dotnet restore "Sprint3/Sprint3.csproj"

# Copia o restante do código e compila
COPY . .
WORKDIR "/src/Sprint3"
RUN dotnet build "Sprint3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sprint3.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Gera a imagem final de execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# CORRIGIDO: Removida a palavra fantasma 'EXIGNMENT'
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "Sprint3.dll"]
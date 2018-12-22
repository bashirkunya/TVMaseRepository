#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 50239
EXPOSE 44371

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["TvMaze.API/TvMaze.API.csproj", "TvMaze.API/"]
RUN dotnet restore "TvMaze.API/TvMaze.API.csproj"
COPY . .
WORKDIR "/src/TvMaze.API"
RUN dotnet build "TvMaze.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TvMaze.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TvMaze.API.dll"]
# ========= BUILD STAGE =========
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy everything
COPY . .

# Publish the project (IMPORTANT: correct csproj name)
RUN dotnet publish "School Site.csproj" -c Release -o /app/out


# ========= RUNTIME STAGE =========
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/out .

# Tell ASP.NET Core to listen on Render's PORT
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}

# ENTRYPOINT – IMPORTANT: correct DLL name!
ENTRYPOINT ["dotnet", "School Site.dll"]

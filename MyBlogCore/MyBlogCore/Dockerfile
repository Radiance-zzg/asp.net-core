#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MyBlogCore/MyBlogCore.csproj", "MyBlogCore/"]
COPY ["Blog,Core.Common/Blog.Core.Common.csproj", "Blog,Core.Common/"]
COPY ["Blog.Core.Services/Blog.Core.Services.csproj", "Blog.Core.Services/"]
COPY ["Blog.Core.Model/Blog.Core.Model.csproj", "Blog.Core.Model/"]
COPY ["Blog.Core.Repository/Blog.Core.Repository.csproj", "Blog.Core.Repository/"]
COPY ["Blog.Core.Entities/Blog.Core.Entities.csproj", "Blog.Core.Entities/"]
COPY ["Blog.Core.Expansion/Blog.Core.Extensions.csproj", "Blog.Core.Expansion/"]
RUN dotnet restore "MyBlogCore/MyBlogCore.csproj"
COPY . .
WORKDIR "/src/MyBlogCore"
RUN dotnet build "MyBlogCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyBlogCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyBlogCore.dll"]
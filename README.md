# Algorithms and data structures
Repo for my learning programms.
## Create project
```bash
dotnet new sln -n <sln-name> -o ./

dotnet new classlib -o <lib-name>
mv ./<lib-name>/Class1.cs ./<lib-name>/<lib-name>.cs
dotnet sln add ./<lib-name>/<lib-name>.csproj

dotnet new xunit -o <lib-name>.Tests
dotnet add ./<lib-name>.Tests/<lib-name>.Tests.csproj reference ./<lib-name>/<lib-name>.csproj
dotnet sln add ./<lib-name>.Tests/<lib-name>.Tests.csproj

dotnet add ./Main/Main.csproj reference ./<lib-name>/<lib-name>.csproj
```
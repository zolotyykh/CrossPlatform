1. Створення NuGet пакет за допомогою команди : dotnet pack -c Release
2. Створення папку для локального репозиторію NuGet: mkdir C:\LocalNuGetRepo
3. Копіювання .nupkg файл у цю папку (LocalNuGetRepo)
4. dotnet nuget add source C:\LocalNuGetRepo --name LocalNuGetRepo
5. dotnet nuget push "AZolotykh.1.0.0.nupkg" -s LocalNuGetRepo
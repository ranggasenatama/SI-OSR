#### Run Application
```sh
dotnet run
```

#### Make Migrations
```sh
dotnet ef migrations add [MigrationName]
```

#### Revert Migrations
```sh
dotnet ef migrations remove
```

#### Apply Migrations
```sh
dotnet ef database update
```

#### Create Scaffolding
```sh
dotnet aspnet-codegenerator controller -name [ControllerName] -m [ModelName] -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
```

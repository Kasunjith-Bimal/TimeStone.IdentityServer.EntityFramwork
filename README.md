# TimeStone.IdentityServer.EntityFramwork
Identity Server with Database 
# Restore Application 
```
dotnet restore 
```
# Database Configuration 

### Go TimeStone.IdentityServer.EntityFramwork/TimeStone.IdentityServer/appsettings.json

Change Server Name and Database Name According to your Sql Server Configuration 

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=ServerName;Initial Catalog=DataBase;Integrated Security=True"
  }
}
```

### Update database (Go Package Manager Console - Select TimeStone.IdentityServer)

```
dotnet ef database update --context ApplicationDbContext
```
```
dotnet ef database update --context ConfigurationDbContext
```
```
dotnet ef database update --context PersistedGrantDbContext
```
### Go TimeStone.IdentityServer.EntityFramwork/TimeStone.IdentityServer/Startup.cs

comments InitializeDatabase(app); line 

```
 //InitializeDatabase(app);
```

### Run Seed Data (Save Default user Data)

```
dotnet run /seed
```
### Remove comments InitializeDatabase(app); line 

```
InitializeDatabase(app);
```

### Run Application 

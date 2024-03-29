# TimeStone.IdentityServer.EntityFramwork
Identity Server with Database 

# Identity Server Configuration 

### Go https://github.com/Kasunjith-Bimal/TimeStone.IdentityServer.EntityFramwork/blob/master/TimeStone.IdentityServer/Config.cs

Replace your MVC application Url - http://localhost:3728 (Change RedirectUris and PostLogoutRedirectUris)
Replace your Angualr application Url - http://localhost:4200 (Change RedirectUris and PostLogoutRedirectUris)

```
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId ="mvc",
                    ClientName="Mvc Demo",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RedirectUris ={ "http://localhost:3728/signin-oidc" },
                    AllowedScopes={ "openid","email","profile","API1"},
                    PostLogoutRedirectUris = { "http://localhost:3728/signout-callback-oidc" },
                    ClientSecrets ={new Secret("secret".Sha256()) }  
                },
                 new Client {
                    RequireConsent = false,
                    ClientId = "angular_spa",
                    ClientName = "Angular SPA",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "openid", "profile", "email", "API1" },
                    RedirectUris = {"http://localhost:4200/callback.html"},
                    PostLogoutRedirectUris = {"http://localhost:4200/signout-callback.html"},
                    AllowedCorsOrigins = {"http://localhost:4200"},
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600,
                   
                }
               
            };
        }
```


### Go https://github.com/Kasunjith-Bimal/TimeStone.IdentityServer.EntityFramwork/blob/master/TimeStone.Mvc/Startup.cs

Replace your Identity Server Url - http://localhost:5000 (Change options.Authority = "http://localhost:5000";)

```
services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            }).AddCookie("Cookies")
           .AddOpenIdConnect("oidc", options =>
           {
               options.SignInScheme = "Cookies";
               options.RequireHttpsMetadata = false;
               options.Authority = "http://localhost:5000";
               options.ClientId = "mvc";
               options.ClientSecret = "secret";
               options.ResponseType = "code id_token";
               options.Scope.Add("openid");
               options.Scope.Add("email");
               options.Scope.Add("profile");
               options.Scope.Add("API1");
               options.SaveTokens = true;
           });
 ```
 
 ### Go https://github.com/Kasunjith-Bimal/TimeStone.IdentityServer.EntityFramwork/blob/master/TimeStone.Api/Startup.cs
 Replace your Identity Server Url - http://localhost:5000 (Change  options.Authority = "http://localhost:5000";)
 
 ```
             services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
              options.Audience = "API1";
              options.Authority = "http://localhost:5000";
              options.RequireHttpsMetadata = false;
          });

 ```

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

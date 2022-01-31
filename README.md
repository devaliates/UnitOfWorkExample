# UnitOfWorkExample

  Birden fazla DbContext' e sahip Unit Of Work ve Generic Repository Pattern örneği.

# Multi DbContext

Program.cs:

  ```
  AddDbContext<ILocalDbContext, LocalDbContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("LocalConnection")));
  AddDbContext<IAzureDbContext, AzureDbContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("AzureConnection")));
  ```
appsettings.json:

  ````
  "ConnectionStrings": {
      "LocalConnection": "User ID=ali; Password=ali*ates; Server=localhost; Port=5432; Database=LocalDbTest; Integrated Security=true; Pooling=true;",
      "AzureConnection": "User ID=ali; Password=ali*ates; Server=localhost; Port=5432; Database=AzureDbTest; Integrated Security=true; Pooling=true;"
    },
  ````

PMC:
  
  ````
  add-migration v1 -c LocalDbContext -o Migrations/Local
  add-migration v1 -c AzureDbContext -o Migrations/Azure
  
  update-database -Context LocalDbContext
  update-database -Context AzureDbContext  
  ````

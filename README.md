# Database Initialization for the project

## Creating the database locally Using Docker

```bash
docker run -d \
  --name postgres-movie \
  -p 5432:5432 \
  -e POSTGRES_DB=movie \
  -e POSTGRES_USER=postgres \
  -e POSTGRES_HOST_AUTH_METHOD=trust \
  -v pgdata_movie:/var/lib/postgresql/data \
  postgres:16
```

## Generating the DB Context

```bash
dotnet ef dbcontext scaffold "Host=localhost;Port=5432;Database=movie;Username=postgres;Password=" \
  Npgsql.EntityFrameworkCore.PostgreSQL \
  --output-dir Models/EntityFramework \
  --context-dir Models \
  --context AppDbContext \
  --no-onconfiguring \
  --force
```

## Adding the DB Context to the project

```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=movie;Username=postgres;Password=")
);
```

## Creating and applying migration

```bash
dotnet ef migrations add InitialMigration
```

```bash
dotnet ef database update
```

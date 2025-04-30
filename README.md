# DotnetApp

## Connect With PG 

### How to connect a dotnet web app to PostgreSQL
- Create a new ASP.NET Core Web API project using the command line or Visual Studio.
- Open the project in your preferred IDE (e.g., Visual Studio, Visual Studio Code).
- Add the Npgsql.EntityFrameworkCore.PostgreSQL NuGet package to your project. You can do this using the NuGet Package Manager Console or by editing the .csproj file directly.

```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```
- Configure the connection string in the appsettings.json file. This string should include the PostgreSQL server address, database name, username, and password.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=mydatabase;Username=myusername;Password=mypassword"
  }
}
```

- Using DB First approach, create a new table in your PostgreSQL database. You can use a tool like pgAdmin or the psql command line interface to do this.

- Use this command to generate the model and context classes from the existing database.

```bash
Scaffold-DbContext "Host=localhost;Database=Books;Username=postgres;Password=0000" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models -Context AppDbContext -Force

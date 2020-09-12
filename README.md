# Web Api with Token Authentication

- base on : https://dev.to/_patrickgod/authentication-with-json-web-tokens-in-net-core-3-1-29bd

https://www.syncfusion.com/blogs/post/how-to-build-crud-rest-apis-with-asp-net-core-3-1-and-entity-framework-core-create-jwt-tokens-and-secure-apis.aspx

## steps

### Done so far

- `dotnet new webapi -o webapi-tokenauth`
- add `.gitignore` file
- `dotnet run`
- add models (user and role)
- `dotnet add package Microsoft.IdentityModel.Tokens`
- `dotnet add package System.IdentityModel.Tokens.Jwt`
- `dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer`

- `dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design`
- `dotnet add package Microsoft.EntityFrameworkCore.Tools`
- `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
- ``
- ``

### Todo

- install jwt package
- create Database
- add controller
- crud

## command

- `dotnet debug`
- `dotnet run`

## routes

- [`WeatherForecast`](localhost:5000/WeatherForecast)

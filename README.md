# Web Api with Token Authentication

## steps

- Make project with: `dotnet new webapi -o webapi-tokenauth`

- Add `.gitignore` file

- Add models (user, role & ...)

- Install Package for tocken auth:
	- `dotnet add package Microsoft.IdentityModel.Tokens`
	- `dotnet add package System.IdentityModel.Tokens.Jwt`
	- `dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer`

- Install Package database: 
	- `dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design`
	- `dotnet add package Microsoft.EntityFrameworkCore.Tools`
	- `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
	- `dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore`

- Create Database:
	- Add dbcontext file
	- Make migration: `dotnet ef migrations add InitialCreate`
	- Make database: `dotnet ef database update`

- Make controllers for show data (ProductsController & CategoriesController)
- Make controllers for Authenticate user (register, login and make token)

## command

- `dotnet debug`
- `dotnet run`

## routes

- Login: [`/auth`](localhost:5000/auth) with `username` & `password`
- Register: [`/auth/register`](localhost:5000/auth/register) with `email`, `username` & `password`
- Test Access: [`/auth/access`](localhost:5000/auth/access) with `Authorization`= `Bearer [token]` in header

## Database

- `dotnet ef migrations add InitialCreate`
- `dotnet ef database update`

## Usefull link

- https://jwt.io/
- https://dev.to/_patrickgod/authentication-with-json-web-tokens-in-net-core-3-1-29bd
- https://www.syncfusion.com/blogs/post/how-to-build-crud-rest-apis-with-asp-net-core-3-1-and-entity-framework-core-create-jwt-tokens-and-secure-apis.aspx
- https://medium.com/@vaibhavrb999/jwt-authentication-authorization-in-net-core-3-1-e762a7abe00a
- https://codeburst.io/jwt-auth-in-asp-net-core-148fb72bed03
- https://blog.elmah.io/how-to-secure-asp-net-core-with-oauth-and-json-web-tokens/
- https://jasonwatmore.com/post/2019/10/21/aspnet-core-3-basic-authentication-tutorial-with-example-api#running-react
- https://www.syncfusion.com/blogs/post/how-to-build-crud-rest-apis-with-asp-net-core-3-1-and-entity-framework-core-create-jwt-tokens-and-secure-apis.aspx
- https://medium.com/@vaibhavrb999/jwt-authentication-authorization-in-net-core-3-1-e762a7abe00a

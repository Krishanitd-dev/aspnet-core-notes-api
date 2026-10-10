A simple REST API built with C# and ASP.NET Core.

## Features
Create notes  
Get all notes  
Get note by ID  
Update notes  
Delete notes  
Search notes  
Count notes  
Request validation  
Swagger/OpenAPI  
Dependency Injection  
Service layer  
Unit testing  

## Technologies
C#  
ASP.NET Core  
Swagger/OpenAPI  
xUnit  

## Installation
dotnet add package Swashbuckle.AspNetCore --version 6.6.2

## Test
dotnet build

## Run
dotnet run

## unit Test 
dotnet new xunit -n NotesApi.Tests
dotnet add NotesApi.Tests\NotesApi.Tests.csproj reference "Notes API.csproj"
cd NotesApi.Tests
dotnet restore
dotnet test



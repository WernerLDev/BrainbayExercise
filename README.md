# Brainbay exercise

This is the implementation for the Brainbay developer exercise.

## Project structure

The project contains a dotnet solution with 4 projects inside.

1. Data: This contains a class library containing entityframework, the database context and database migrations
2. Console: The console application that fetches the data from the Api
3. WebApi: A dotnet WebApi project that can be used to fetch characters through Rest interface
4. WebApi.Tests: A unit test that tests data retrieval of WebApi

## Setup project locally

### Create database

Execute `database-ef database update --project=WebApi`

This will create a SQLite database called `Brainbay.db` in the root of the project folder. Console and WebApi will both use the created database.

### Import characters using Console application

Execute `dotnet run --project=Console` to run the console application

### Start WebApi project

Execute `dotnet run --project=WebApi` to start the web api project.

#### Endpoints

Fetch characters:

GET http://localhost:5025/Api/Characters

Create character:

POST http://localhost:5025/Api/Characters

Body:

```json
{
  "Name": "...",
  "Species": "...",
  "Status": "...",
  "Type": "...",
  "Gender": "...",
  "Origin": "...",
  "Location": "..."
}
```

### Run tests

Unit tests can be executed using `dotnet test`

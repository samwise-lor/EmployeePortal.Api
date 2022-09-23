# EmployeePortal.Api
The EmployeePortal.Api allows for create, read, update, and delete operations on Employees.

# How to Build
## Using dotnet
From the `EmployeePortal.Api` directory, execute `dotnet build`.

## Using Visual Studio
1. Open the `EmployeePortal.Api.sln` solution.
2. Ensure the `EmployeePortal.Api` project is highlighted in the Solution Explorer.
3. Click on Build > Build Solution.

## Local Database Deployment
Assumptions made in this project
1. Since its an InMemoryDB, EmployeeId is a Guid which is an uniqueIdentifier
2. This can be easily replace to an int

## Seed data for DB
Insert_Script.sql is provided with some seed data that can be used to populate the DB

## EF Code first approach
1. Models are created first and one can use EF migrations to execute against the DB
2. Execute the following steps in terminal or pm console of IDE
	- Add-Migrations
	- Update-Database
3. Check the database for table creation

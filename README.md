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
2. This can be easily replaced to an int

## Seed data for DB
Insert_Script.sql is provided with some seed data that can be used to populate the DB

## EF Code first approach
1. Models are created first and one can use EF migrations to execute against the DB
2. Execute the following steps in terminal or pm console of IDE
	- Add-Migrations
	- Update-Database
3. Check the database for table creation

## Employee Endpoints
1. Get Employees
	- Returns all employees with their addresses [Returns a list of employees]
2. Get EmployeeById
	- Returns employee with address given an employeeId [Returns a employee]
3. Get Employee using search [searchParam: firstName or lastName or emailAddress]
	- Returns employees given search parametes [Returns a list of employees]
4. Post Employee
	- Using employee request, inserts a record and returns an employee with 200 response
5. Put Employee
	- Using employee request and an employeeId, updates the record and returns the employee with 200 response
6. Delte Employee
	- Using an employeeId, delete an employee and returns 204 response if successful and 400 response if not found

## Unit tests
Unit tests are implemented using XUnit

## Validations
Fluent validations are in place for validations of request objects
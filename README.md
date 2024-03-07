# The .NET 8 Sandbox

## UniversityRESTSolution

### Instructions for Local Migration:

To migrate the entities driving this API to your local database, follow these steps:

1. Load the solution. and change the connection string in appsettings to be pointed to your local SQL server's name, but don't change the rest of the string.
2. Open the Server Explorer => SQL Server Object Explorer so you can get a view of your local database in the IDE
3. Open the NuGet Package Manager Console from the API project. Run the following command: Update-Database
4. Check that all of the tables required to support the entities definied in the "Entities" folder have been created in your local database.
5. Please Note that if you add entities you will need to run the: Add-Migration powershell command from the Nuget Package Manager Console, and then run: Update-Database
   this will create a new migration file for our context and run it against your local DB.
   

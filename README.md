# The .NET 8 Sandbox

## UniversityRESTSolution

### Instructions for Local Migration of Test Data for API:

To migrate the entities driving this API to your local database, follow these steps:

1. Load the solution. and change the connection string in appsettings to be pointed to your local SQL server's name, but don't change the rest of the string.
2. Open the Server Explorer => SQL Server Object Explorer so you can get a view of your local database in the IDE
3. Open the NuGet Package Manager Console from the API project. Run the following command: Update-Database
4. Check that all of the tables required to support the entities definied in the "Entities" folder have been created in your local database.
5. Please Note that if you add entities you will need to run the: Add-Migration powershell command from the Nuget Package Manager Console, and then run: Update-Database
   this will create a new migration file for our context and run it against your local DB.

### Source for API creation: https://medium.com/@chandrashekharsingh25/build-a-restful-web-api-with-net-8-44fc93b36618#id_token=eyJhbGciOiJSUzI1NiIsImtpZCI6IjA4YmY1YzM3NzJkZDRlN2E3MjdhMTAxYmY1MjBmNjU3NWNhYzMyNmYiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2FjY291bnRzLmdvb2dsZS5jb20iLCJhenAiOiIyMTYyOTYwMzU4MzQtazFrNnFlMDYwczJ0cDJhMmphbTRsamRjbXMwMHN0dGcuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJhdWQiOiIyMTYyOTYwMzU4MzQtazFrNnFlMDYwczJ0cDJhMmphbTRsamRjbXMwMHN0dGcuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJzdWIiOiIxMDk2NDY1NzcyMTk3MjY4MzExNTMiLCJlbWFpbCI6InJ5YW5oZXJpbmcxQGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJuYmYiOjE3MDk3MDM3NDEsIm5hbWUiOiJSeWFuIEhlcmluZyIsInBpY3R1cmUiOiJodHRwczovL2xoMy5nb29nbGV1c2VyY29udGVudC5jb20vYS9BQ2c4b2NMcXo1UUJKVTVwcmZZQ04wbVdSSDZNR05YYVhFWUxKUk1pcjdHNjA3LUp4QT1zOTYtYyIsImdpdmVuX25hbWUiOiJSeWFuIiwiZmFtaWx5X25hbWUiOiJIZXJpbmciLCJsb2NhbGUiOiJlbiIsImlhdCI6MTcwOTcwNDA0MSwiZXhwIjoxNzA5NzA3NjQxLCJqdGkiOiI0NWQ2ZjZhMjk3MmU3NzAyYmNkNWZlMGYwY2MzMjRjNTM2OWNkOTc0In0.G2TaIoCLimJpnhQfqOLiJSMZuWnM1gUetTHVXa2BPuwp_ioQ6HH1XGiwEwagz2PeRH5KN8TG5GdA36rrWMu9hqbV3fOehVZGgaSdynTPRTvsEiXton21eRQoxfKOVZlWMrI1kkPbyTMoSLflpQD61CaH7Z_5Iytw5a-wckuGcy649hW7_OnoR3iajPbQ7fIhdgGFpSRsuLLMOFSvPTJgJ0IQKtbmS78LeUCxvN0DeyMtq7Hwjp7RDR4G7ZT1wfO_90wgW3L_lbH6TqkxOZ-xaxCKd8H2C8EhXUrnjRHim3DgNr_z8X2HHWVNFwIfQUuhEVu6wzjFvl9czhDSSWbcWA

   

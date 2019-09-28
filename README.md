# Description 
Uploader console app has two functionalities:
* can read investments data from csv file, calculate net and totals. Then store investments in one table and totals in separate table. 
* can read investments from database and save it to the csv file 

# Database configuration
Console app use Entity Framework Core to manage database. To create database you need to execute following commands

```powershell
Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration InitialCreate
Update-Database
```

for help please have a look here https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=visual-studio
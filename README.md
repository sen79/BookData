# BookData


Technologies: 
Microsoft Visual Studio Community 2022, ASP.NET .net 6, Entity Framework Code First, MSSQL SERVER / My SQL etc., Repository Pattern with Dependency Injection.

Prerequisite Application: 
Microsoft Visual Studio Community 2022, .Net 6, MS SQL SERVER 2014 or above, IIS, Chrome/Edge Browser.

How to run this Project: 
Step 1: 
Downloaded from GitHub repository link
[https://github.com/sen79/BookStore.git]

Step:2
Open BookData.sln file with Visual Studio 2022

Step 3: 
Update database connection: appsettings.json 
"MSSqlServerConnString": "Data Source=SR;Database=BookData;Persist Security Info=True;User ID=sa;Password=a;MultipleActiveResultSets=true"
Server=Your MSSQL Server Name User ID= Your MSSQL Server User Name Password= Your MSSQL Server User Password

Step 4: 
No need to create new migration rule and update database. You just need to build and run the application. Already initial migration rule included with project. Please make sure MS SQL server running properly.

Step 5: 
5.1: Build application by pressing f6 
5.2: Run application by pressing f5 
https://localhost:44337/ 
Initially in the SQL server, relevant tables and data will be created in the database dynamically as code first approach.

Step 6:
1. Open StoredProcedure.txt in project.
2. copy all text and paste in sql server and run.

Thank You




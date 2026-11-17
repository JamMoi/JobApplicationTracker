# JobTracker

JobTracker is a web app for tracking job applications, deadlines, and application status.

## Features

- Browse, add, edit, and delete job applications.
- Review the selected application on a confirmation page before deleting it.
- Search the application list by company name or job title.
- Track deadlines and automatically record the application date when an application is saved as Applied without an existing application date.

## Tech stack

C#, ASP.NET Core MVC, Razor, Bootstrap, Entity Framework Core, and SQL Server.

## Run locally

The steps below use Visual Studio on Windows and SQL Server Express LocalDB. Use a .NET SDK that supports the target framework in the `.csproj` file.

1. Clone the repository and open the solution in Visual Studio.
2. Open a terminal in the folder containing the web project's `.csproj` file. Set up a local database connection using ASP.NET Core User Secrets.

   ```powershell
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=(localdb)\MSSQLLocalDB;Database=JobTracker;Trusted_Connection=True"
   ```

3. In Visual Studio, open **Tools → NuGet Package Manager → Package Manager Console**. Select the web project as the default project and run `Update-Database` to apply the migrations.
4. Press `F5` and open `/JobApplications` using the local address shown in the browser. Use `/JobApplications/Create` to add your first application.

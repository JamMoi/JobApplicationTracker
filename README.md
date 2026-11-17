# JobTracker

JobTracker is an ASP.NET Core MVC web application for managing job applications, tracking deadlines, and monitoring application progress.

The project demonstrates practical C# development, database operations with Entity Framework Core, and server-rendered web development using Razor and Bootstrap.

## Features

- Create, view, edit, and delete job applications.
- Search applications by company name or job title.
- Track application statuses, including Interested, Preparing, Applied, Interview, Offer, Rejected, and Withdrawn.
- Manage application deadlines.
- Automatically record the application date when an application is marked as Applied without an existing date.
- Edit or clear application dates when needed.
- Confirm before deleting an application.

## Technologies

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Razor Views
- Bootstrap
- Git and GitHub

## Run Locally

**Requirements:**
- Visual Studio with ASP.NET and web development support
- A compatible .NET SDK (see the project's `.csproj` file)
- SQL Server Express LocalDB

**Setup:**

1. Clone the repository and open the solution in Visual Studio.
2. Configure the `DefaultConnection` connection string for your local SQL Server database.
3. Open **Tools → NuGet Package Manager → Package Manager Console**.
4. Select the web project as the default project.
5. Run `Update-Database` to apply the Entity Framework Core migrations.
6. Press `F5` to start the application.

Navigate to `/JobApplications` to view and manage applications.

## Project Purpose

This project was developed to practise ASP.NET Core MVC, Entity Framework Core, CRUD operations, form validation, and database-driven application development.
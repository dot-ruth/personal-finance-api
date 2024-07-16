# PersonalFinanceAPI

This project is the backend of the Personal Finance Management System, built with .NET Core and Entity Framework Core.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio or Visual Studio Code](https://visualstudio.microsoft.com/)
- [Postman](https://www.postman.com/) (optional, for API testing)


## Project Structure

- **Controllers/**: Contains API controllers for handling requests.
- **Models/**: Contains the data models used in the application.
- **Services/**: Contains business logic and services for handling data operations.
- **appsettings.json**: Configuration file for the application settings.
- **Program.cs**: Entry point for the application.
- **Startup.cs**: Configures services and the app's request pipeline.

## Usage

1. **Authentication:**
   - Register and log in to get an authentication token for accessing protected endpoints.

2. **Income Management:**
   - Create, read, update, and delete income entries.

3. **Expense Management:**
   - Create, read, update, and delete expense entries.

4. **Budget Tracking:**
   - Set and manage budgets for different categories.

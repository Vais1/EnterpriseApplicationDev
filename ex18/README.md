# Contact Manager Application (ex18)

A full-featured contact management application built with ASP.NET Core Razor Pages, featuring user authentication and complete CRUD functionality for managing contacts.

## Features

### Authentication
- **User Registration**: Create a new account with email and password
- **User Login**: Secure login with password authentication
- **User Logout**: Sign out functionality
- **Protected Routes**: All contact management pages require authentication

### Contact Management
- **View Contacts**: Display all contacts in a table format with key information
- **Create Contact**: Add new contacts with comprehensive details
- **Edit Contact**: Update existing contact information
- **Delete Contact**: Remove contacts from the database
- **View Details**: See complete information for any contact

### Contact Fields
Each contact can store the following information:
- First Name (required)
- Last Name (required)
- Email Address (required, validated)
- Phone Number (optional)
- Address (optional)
- City (optional)
- State (optional)
- Zip Code (optional)
- Notes (optional)
- Created Date (automatically set)

## Technology Stack

- **.NET 9.0**: Latest .NET framework
- **ASP.NET Core Razor Pages**: Web application framework
- **Entity Framework Core**: ORM for database operations
- **SQL Server LocalDB**: Database for storing data
- **ASP.NET Core Identity**: Authentication and authorization
- **Bootstrap 5**: UI framework for responsive design

## Project Structure

```
ex18/
├── Areas/
│   └── Identity/
│       └── Pages/
│           └── Account/
│               ├── Login.cshtml
│               ├── Register.cshtml
│               └── Logout.cshtml
├── Data/
│   └── ApplicationDbContext.cs
├── Models/
│   └── Contact.cs
├── Pages/
│   ├── Contacts/
│   │   ├── Index.cshtml (List all contacts)
│   │   ├── Create.cshtml (Add new contact)
│   │   ├── Edit.cshtml (Update contact)
│   │   ├── Details.cshtml (View contact details)
│   │   └── Delete.cshtml (Remove contact)
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   └── _LoginPartial.cshtml
│   └── Index.cshtml (Landing page)
├── Program.cs
└── appsettings.json
```

## Setup Instructions

### Prerequisites
- .NET 9.0 SDK
- SQL Server LocalDB (included with Visual Studio) or SQL Server Express

### Installation

1. **Restore NuGet packages**:
   ```bash
   dotnet restore
   ```

2. **Update the connection string** (if needed):
   Edit `appsettings.json` and modify the `DefaultConnection` string if you're not using LocalDB:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ContactManagerDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

3. **Run the application**:
   ```bash
   dotnet run
   ```

4. **Access the application**:
   Navigate to `https://localhost:5001` or `http://localhost:5000` (check the console output for the exact URL)

### Database Setup

The database is automatically created on first run using `EnsureCreated()`. The database will include:
- Identity tables (AspNetUsers, AspNetRoles, etc.)
- Contacts table

## Usage

1. **Register a New Account**:
   - Click "Register" on the landing page or navigation bar
   - Enter your email and password
   - Click "Register" to create your account

2. **Login**:
   - Click "Login" on the landing page or navigation bar
   - Enter your email and password
   - Click "Log in"

3. **Manage Contacts**:
   - After logging in, click "Manage Contacts" in the navigation bar
   - Use "Create New Contact" to add contacts
   - Click "Edit", "Details", or "Delete" on any contact row to perform actions

## Security Features

- **User Isolation**: Each user can only see and manage their own contacts
- **Password Requirements**: 
  - Minimum 6 characters
  - Requires uppercase and lowercase letters
  - Requires at least one digit
- **Account Lockout**: After 5 failed login attempts, account is locked for 5 minutes
- **Email Validation**: Email addresses are validated for proper format

## Development Notes

- The application uses ASP.NET Core Identity for authentication
- Entity Framework Core handles all database operations
- Contacts are automatically associated with the logged-in user
- The database context uses SQL Server LocalDB by default
- All contact management pages require authentication (`[Authorize]` attribute)

## Future Enhancements

Potential improvements for future versions:
- Contact search and filtering
- Export contacts to CSV/Excel
- Contact groups/categories
- Profile picture upload
- Email integration
- Contact import functionality

## License

This project is part of an educational exercise.


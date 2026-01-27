# DotNet-WebAPI-Boilerplate

A professional ASP.NET Core Web API boilerplate project that demonstrates industry-standard patterns and practices for building scalable and maintainable web APIs.

## 🚀 Features

- **Professional Architecture**: Clean architecture with separation of concerns
- **Entity Framework Core**: Integrated with PostgreSQL database support
- **Design Patterns**: Repository pattern, Service pattern, Dependency Injection
- **API Documentation**: Swagger/OpenAPI integration for comprehensive API documentation
- **Professional Code Standards**: Comprehensive docstrings and consistent coding style
- **Example Implementation**: Complete CRUD operations with Category model
- **Database Testing**: Built-in connection testing functionality
- **CORS Configuration**: Configurable cross-origin resource sharing
- **Modern .NET**: Built on .NET 10.0 with latest best practices

## 📁 Project Structure

```
web-api-boilerplatet/
├── Controllers/           # API Controllers
├── Core/                  # Core business logic
├── DTOs/                  # Data Transfer Objects
├── Helpers/               # Utility classes
├── MapperDTOs/            # DTO mapping configurations
├── Mappers/               # Object mapping implementations
├── Models/                # Domain models
├── Models.EFC/            # Entity Framework models
├── Properties/            # Project properties
├── Repositories/          # Data access layer
├── Services/              # Business logic layer
├── Program.cs             # Application entry point
├── appsettings.json       # Application configuration
├── appsettings.Development.json
└── WebApiBoilerplate.csproj
```

## 🛠️ Technologies Used

- **.NET 10.0** - Latest .NET framework
- **ASP.NET Core** - Web API framework
- **Entity Framework Core** - ORM for database operations
- **PostgreSQL** - Primary database (Npgsql provider)
- **Swagger/OpenAPI** - API documentation
- **Dependency Injection** - Built-in IoC container

## 📋 Prerequisites

- .NET 10.0 SDK
- PostgreSQL database server
- Visual Studio 2022 or VS Code

## 🚀 Quick Start

### 1. Clone the Repository

```bash
git clone https://github.com/AleDevSharp/DotNet-WebAPI-Boilerplate.git
cd DotNet-WebAPI-Boilerplate
```

### 2. Database Configuration

Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=your_host;Database=your_database;Username=your_username;Password=your_password;"
  }
}
```

### 3. Run the Application

```bash
cd web-api-boilerplatet/web-api-boilerplatet
dotnet clean
dotnet build
dotnet run
```

### 4. Access the API

- **API Base URL**: `https://localhost:7XXX`
- **Swagger Documentation**: `https://localhost:7XXX/swagger`

## 📖 Usage Examples

### Category API Endpoints

The boilerplate includes a complete Category API with the following endpoints:

- `GET /api/category` - Get all categories
- `GET /api/category/{id}` - Get category by ID
- `POST /api/category` - Create new category
- `PUT /api/category/{id}` - Update existing category
- `DELETE /api/category/{id}` - Delete category

### Example Request

```bash
# Get all categories
curl -X GET "https://localhost:7XXX/api/category" -H "accept: application/json"

# Create new category
curl -X POST "https://localhost:7XXX/api/category" \
  -H "accept: application/json" \
  -H "Content-Type: application/json" \
  -d "{\"name\":\"New Category\",\"description\":\"Category description\"}"
```

## 🏗️ Architecture Overview

This boilerplate follows professional software architecture principles:

### Repository Pattern
- **ICategoryRepository**: Interface for data access
- **CategoryRepository**: Concrete implementation using Entity Framework Core

### Service Pattern
- **ICategoryService**: Interface for business logic
- **CategoryService**: Concrete implementation with business rules

### DTO Pattern
- Separation between domain models and API contracts
- Automatic mapping between models and DTOs

### Dependency Injection
- All services and repositories are registered in `Program.cs`
- Promotes loose coupling and testability

## 🔧 Configuration

### Environment Variables

The application supports different configurations for different environments:

- `appsettings.json` - Base configuration
- `appsettings.Development.json` - Development-specific settings
- `appsettings.Production.json` - Production-specific settings (create as needed)

### Database Support

While configured for PostgreSQL by default, the project supports:
- SQL Server (Microsoft.EntityFrameworkCore.SqlServer)
- PostgreSQL (Npgsql.EntityFrameworkCore.PostgreSQL)
- Other EF Core providers (add appropriate NuGet packages)

## 🧪 Testing the Database Connection

The application includes automatic database connection testing at startup. The `ConnectionTester` class verifies the database connectivity before the application starts serving requests.

## 📝 Code Standards

This project follows professional coding standards:

- **Comprehensive Docstrings**: Every class, method, and property includes XML documentation
- **Consistent Naming**: PascalCase for public members, camelCase for private members
- **Region Organization**: Code is organized using `#region` directives
- **Error Handling**: Proper exception handling and logging
- **Async/Await**: Modern asynchronous programming patterns

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👤 Author

**Alessio Giacché**
- Email: ale.giacc.dev@gmail.com
- License: MIT

## 🙏 Acknowledgments

- Microsoft for the excellent .NET ecosystem
- The Entity Framework Core team for the powerful ORM
- The PostgreSQL community for the robust database system

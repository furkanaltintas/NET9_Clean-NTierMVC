# NET9_Clean-NTierMVC
This project is an MVC application built with .NET 9 and Clean Architecture principles, following an N-Tier architecture. The project is designed to be modular and maintainable, ensuring a flexible and scalable codebase.

## Technologies & Tools Used

### Backend
- **.NET 9** - Modern, fast, and secure backend technology  
- **ASP.NET Core MVC** - Model-View-Controller architecture  
- **Entity Framework Core** - ORM (Object-Relational Mapping) tool  
- **Fluent Validation** - Advanced model validation  
- **MediatR** - For CQRS and event-driven patterns  
- **AutoMapper** - For model and DTO transformations  
- **Caching** - In-memory caching mechanism  
- **Autofac** - Dependency injection and IoC container  
- **Serilog** - Logging management  

### Frontend & UI
- **MVC Views** - Dynamic UI management
- **NToast** - Notification management
- **Bootstrap 5** - Responsive design

### Database
- **MS SQL Server** - Database management

### Architecture
- **N-Tier Architecture** (Core, Business, DataAccess, Entities, UI)
- **SOLID Principles** - For a more flexible and maintainable code structure
- **Repository Pattern** - For organizing data access layer
- **Unit of Work** - Transaction management
- **Dependency Injection** - Loosely coupled components

## Installation & Usage

1. **Clone the Repository:**
   ```sh
   git clone https://github.com/furkanaltintas/NET9_Clean-NTierMVC.git
   ```
2. **Install Dependencies:**
   ```sh
   dotnet restore
   ```
3. **Apply Database Migrations:**
   ```sh
   dotnet ef database update
   ```
4. **Run the Project:**
   ```sh
   dotnet run
   ```

## Features
- User management (authentication and authorization)
- CRUD operations
- Performance optimizations with caching
- Error handling with Fluent Validation
- Scalable and flexible MVC structure

## Contributing
To contribute, please create an issue before submitting a pull request. Any contribution is highly appreciated!

## License
This project is licensed under the MIT License. For more details, check the `LICENSE` file.





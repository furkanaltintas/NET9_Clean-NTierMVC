Proje geliştirilmeye devam edilmektedir.
11.03.2025

# NET9_Clean-NTierMVC
This project is an MVC application built with .NET 9 and Clean Architecture principles, following an N-Tier architecture. The project is designed to be modular and maintainable, ensuring a flexible and scalable codebase.

<img src="https://github.com/user-attachments/assets/111f6084-76fb-463e-aeb6-14b64c62d3ce" alt="Açıklama" width="300" align="left">

## Technologies & Tools Used

### Backend
- **.NET 9** - Modern, fast, and secure backend technology
- **ASP.NET Core MVC** - Model-View-Controller architecture
- **Entity Framework Core** - ORM (Object-Relational Mapping) tool
- **Fluent Validation** - Advanced model validation
- **MediatR** - For CQRS and event-driven patterns
- **AutoMapper** - For model and DTO transformations
- **Caching** - In-memory caching mechanism
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





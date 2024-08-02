This project demonstrates a layered architecture implementation using Entity Framework (EF) Core as the Object-Relational Mapper (ORM). The layered architecture helps in separating concerns, making the codebase more modular, maintainable, and testable.

# Project Structure
The project is organized into the following layers:

### 1- Presentation Layer: Responsible for handling user interface (UI) interactions. Typically, this could be an ASP.NET Core MVC or Web API project.
### 2- Application Layer: Contains the business logic and service interfaces. This layer mediates between the presentation layer and the data access layer.
### 3- Domain Layer: Represents the core of the business domain. This layer contains the business entities and domain services.
### 4- Infrastructure Layer: Implements the data access logic using EF Core and other infrastructure-related concerns.

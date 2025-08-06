# 🛒 ECommerceOrdersAPI

An ASP.NET Core Web API built to manage e-commerce orders efficiently. The project includes full CRUD operations for orders and related entities such as customers, products, and order items

## 📌 Features

- ✅ Manage Orders, Products, Customers, and Order Items
- 🧩 Clean Architecture (Controller → Service → Repository Pattern)
- 📦 Entity Framework Core with SQL Server
- 📃 Data Validation using FluentValidation
- 🔁 AutoMapper for DTO mapping
- 🔐 Secure with basic authentication (optional)
- 📄 Swagger/OpenAPI integration
- 📁 Modular folder structure for easy scalability

## 🧠 Technologies Used

| Tech                | Description                         |
|---------------------|-------------------------------------|
| ASP.NET Core        | Web API                   |
| Entity Framework    | ORM for database interaction        |
| SQL Server          | Relational database                 |
| AutoMapper          | Object-object mapping               |
| FluentValidation    | Data validation                     |
| Swagger             | API documentation                   |
| Git + GitHub        | Version control & collaboration     |

## 🗃️ Folder Structure

ECommerceOrdersAPI/
│
├── Controllers/ # API endpoints
├── Services/ # Business logic
├── Repositories/ # Data access
├── Models/ # Entity models
├── DTOs/ # Data transfer objects
├── Validators/ # FluentValidation logic
├── Mappings/ # AutoMapper profiles
├── appsettings.json # Configuration
└── ECommerceOrdersAPI.sln # Solution file

### 🛠 Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/)

### 🔧 Setup

1. **Clone the repository**  
   ```bash
   git clone https://github.com/sakshidhandar9/ECommerceOrdersAPI2.git
   cd ECommerceOrdersAPI2
   

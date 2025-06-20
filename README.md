# Dotnet Order System - ASP.NET Core Practice

RESTful API project built with ASP.NET Core, part of my **Advanced Business Development with .NET** studies at **FIAP**.  
Developed using **.NET 8** and layered architecture for better maintainability.

📚 **Class:** *Advanced Business Development with .NET*  
🎯 **Goal:** Practice developing a complete API using ASP.NET Core and Entity Framework Core.

## 🚀 Tech Stack

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- Oracle Database
- Dependency Injection (DI)
- Repository Pattern
- Swagger (OpenAPI)
- Docker (optional)

## 📝 Description

API for managing representatives, customers, products, stores, suppliers, and orders.  
Supports complex relationships such as orders with multiple products and customer-representative associations.

## ✅ Features

- 🔄 CRUD operations for all main entities
- 🧾 Many-to-many and one-to-many relationships (e.g., Orders ↔ Products)
- 🔍 Filtering and search capabilities
- 🔗 Oracle database integration
- 🧪 Separation of concerns using Services and Repositories
- 🧰 Swagger UI for API testing and documentation

## ▶️ How to Run

```bash
dotnet run
```

Or, if using Docker:
```bash
docker build -t dotnet-order-system .
docker run -p 5000:80 dotnet-order-system
```

## 📌 Notes
- The script to populate initial data is located in: `insercao-fiapalunos-script.sql`
- Configure Oracle DB connection settings in `appsettings.json`.

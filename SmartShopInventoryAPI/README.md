# SmartShop Inventory System

A high-performance inventory management microservice built with C# and Entity Framework Core. This system is designed to provide real-time stock insights and analytical reporting for retail operations, utilizing SQLite for persistent storage and optimized indexing for fast data retrieval.

## System Features
* **Relational Database Modeling:** Manages core retail entities (Products, Suppliers, Stores, Sales) with enforced referential integrity.
* **Analytical Reporting:** Implements multi-table JOINs and server-side aggregation for real-time revenue tracking.
* **Query Optimization:** Implements database indexing on frequently filtered columns (`Category`, `Price`) to ensure sub-millisecond query performance.
* **System Telemetry:** Integrated Swagger/OpenAPI for interactive endpoint testing and data seeding validation.

## Tech Stack
* **Language:** C#
* **Framework:** ASP.NET Core Web API
* **ORM:** Entity Framework Core (SQLite Provider)
* **Tools:** Swagger, EF Core Migrations, JetBrains Rider

## API Endpoints
| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `POST` | `/api/Inventory/seed` | Seeds the database with initial retail test data. |
| `GET` | `/api/Inventory/products` | Retrieves products with optional Category/Stock filtering. |
| `GET` | `/api/Inventory/sales-report` | Returns an analytical report of sales, stores, and calculated revenue. |

## How to Run
1. Ensure the .NET 10 SDK is installed.
2. Clone the repository and navigate to `SmartShopInventoryAPI/`.
3. Run `dotnet ef database update` to build the SQLite schema.
4. Run `dotnet run` to launch the server.
5. Navigate to `http://localhost:5259/swagger` to begin testing.
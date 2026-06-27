# C# Systems Engineering: User Management API

A production-ready REST API built with C# and ASP.NET Core, designed to handle employee user data. This project serves as a foundational microservice demonstrating modern backend architecture and data integrity.

## System Features
* **Complete CRUD Architecture:** Fully functional `POST`, `GET`, `PUT`, and `DELETE` endpoints for managing user records.
* **In-Memory Data Store:** Utilizes a static list to simulate database operations for rapid prototyping.
* **Layered Data Validation:** Implements strict data annotations (`[Required]`, Regex-based Email validation) to reject malformed data before it hits the controller logic.
* **Interactive Telemetry:** Integrated Swagger UI for live endpoint testing and JSON payload inspection.

## Tech Stack
* **Language:** C#
* **Framework:** .NET Core Web API
* **Tools:** Swagger / OpenAPI, JetBrains Rider

## How to Run Locally
1. Clone the repository to your local machine.
2. Navigate to the project directory in your terminal.
3. Run `dotnet run` to compile and launch the server.
4. Navigate to `http://localhost:5288/swagger` in your browser to access the control panel.
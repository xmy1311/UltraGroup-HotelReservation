# UltraGroup Hotel Reservation

Solución basada en microservicios para la gestión de hoteles y reservas, desarrollada con **.NET 10**, **ASP.NET Core**, **Entity Framework Core**, **SQL Server**, and **JWT Authentication**.

## Architecture

The solution is divided into two independent microservices:

- **HotelService**
  - Hotel management
  - Room management
  - Room availability

- **ReservationService**
  - Reservation management
  - Guest registration
  - Reservation confirmation
  - Notification service
  - JWT Authentication

Both services follow a layered architecture:

- Domain
- Application
- Infrastructure
- API

## Technologies

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core **(Code First)**
- SQL Server
- JWT Authentication
- Swagger / OpenAPI
- xUnit
- Moq
- Dependency Injection
- Repository Pattern

## Database

The solution uses **Entity Framework Core Code First** with SQL Server.

Database schema changes are managed through EF Core migrations.

Create the database:

```bash
dotnet ef database update --project src/HotelService.Infrastructure --startup-project src/HotelService.API
```

```bash
dotnet ef database update --project src/Reservation.Infrastructure --startup-project src/Reservation.API
```
---

## Solution Structure

```
src
│
├── HotelService.API
├── HotelService.App
├── HotelService.Domain
├── HotelService.Infrastructure
│
├── Reservation.API
├── Reservation.App
├── Reservation.Domain
├── Reservation.Infrastructure
│
└── UltraGroup.Common

test
│
├── HotelService.Tests
└── Reservation.Tests
```

---

## Prerequisites

- .NET 10 SDK
- SQL Server
- Visual Studio 2026 (or Visual Studio 2022)
- Git

---

## Build

```bash
dotnet build UltraGroup.HotelReservation.slnx
```

---

## Run

### Hotel Service

```bash
dotnet run --project src/HotelService.API
```

### Reservation Service

```bash
dotnet run --project src/Reservation.API
```

---

## Swagger

Each microservice exposes Swagger documentation.

Hotel Service

```
https://localhost:{port}/swagger
```

Reservation Service

```
https://localhost:{port}/swagger
```

---

## Running Tests

```bash
dotnet test UltraGroup.HotelReservation.slnx
```

---

## Authentication

The Reservation API uses JWT Authentication.

Protected endpoints require the following header:

```
Authorization: Bearer {token}
```

---

## Decisiones de Diseño

- Arquitectura por capas (Domain, Application, Infrastructure y API).
- Implementación del patrón **Repository** para el acceso a datos.
- Uso de **Entity Framework Core (Code First)** para la persistencia.
- Comunicación entre capas mediante **DTOs**.
- Autenticación basada en **JWT** para proteger los endpoints.
- Pruebas unitarias implementadas con **xUnit** y **Moq**.
- Componentes compartidos centralizados en el proyecto **UltraGroup.Common**.
- Separación de responsabilidades siguiendo principios de **Clean Architecture**.

---

## Mejoras Futuras

- Integración con un proveedor de correo electrónico (SMTP, SendGrid, etc.).
- Contenerización de los microservicios mediante **Docker**.
- Implementación de un **API Gateway** para centralizar el acceso a los microservicios.
- Registro y monitoreo distribuido (Logging y Tracing).
- Implementación de **Refresh Tokens** para mejorar la gestión de autenticación.
- Autorización basada en roles y permisos (**Role-Based Authorization**).
- Implementación de un pipeline de **CI/CD** para automatizar compilación, pruebas y despliegues.
- Incorporación de validaciones más robustas y manejo centralizado de excepciones.

---

## Author

Xiomara Zapata

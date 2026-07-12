# UltraGroup Hotel Reservation

Microservices-based solution for hotel and reservation management built with **.NET 10**, **ASP.NET Core**, **Entity Framework Core**, **SQL Server**, and **JWT Authentication**.

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
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger / OpenAPI
- xUnit
- Moq
- Dependency Injection
- Repository Pattern

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

## Design Decisions

- Clean separation between Domain, Application, Infrastructure and API.
- Repository Pattern for persistence.
- Entity Framework Core for data access.
- DTOs for communication between layers.
- Unit tests using xUnit and Moq.
- Shared classes located in the UltraGroup.Common project.

---

## Future Improvements

- Email provider integration.
- Docker support.
- API Gateway.
- Distributed logging.
- Refresh Tokens.
- Role-based authorization.
- CI/CD pipeline.

---

## Author

Xiomara Zapata

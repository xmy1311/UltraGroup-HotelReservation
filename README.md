# UltraGroup Hotel Reservation

Solución basada en microservicios para la gestión de hoteles y reservas, desarrollada con **.NET 10**, **ASP.NET Core Web API**, **Entity Framework Core (Code First)**, **SQL Server** y **autenticación mediante JWT**.

---

## Arquitectura

La solución está dividida en dos microservicios independientes:

### HotelService

Responsable de la administración de hoteles y habitaciones.

**Funcionalidades principales:**

- Gestión de hoteles.
- Gestión de habitaciones.
- Consulta de habitaciones disponibles.

### ReservationService

Responsable de la administración de reservas.

**Funcionalidades principales:**

- Gestión de reservas.
- Confirmación de reservas.
- Notificación de confirmación.
- Autenticación mediante JWT.

Ambos microservicios implementan una arquitectura por capas compuesta por:

- **Domain:** Contiene las entidades, reglas de negocio e interfaces del dominio.
- **Application:** Contiene los servicios de aplicación y la lógica de negocio.
- **Infrastructure:** Implementa el acceso a datos, repositorios y servicios externos.
- **API:** Expone los servicios REST y gestiona las solicitudes HTTP.

---

## Tecnologías

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core **(Code First)**
- SQL Server
- Autenticación mediante JWT
- Swagger / OpenAPI
- xUnit
- Moq
- Inyección de Dependencias (Dependency Injection)
- Patrón Repository

---

## Base de Datos

La solución utiliza **Entity Framework Core (Code First)** con **SQL Server**.

La estructura de la base de datos se administra mediante migraciones de Entity Framework Core.

Para crear o actualizar la base de datos ejecute los siguientes comandos:

```bash
dotnet ef database update --project src/HotelService.Infrastructure --startup-project src/HotelService.API
```

```bash
dotnet ef database update --project src/Reservation.Infrastructure --startup-project src/Reservation.API
```

> **Nota:** Para simplificar el alcance de la prueba técnica, ambos microservicios utilizan la misma base de datos SQL Server. En un entorno productivo, cada microservicio debería contar con su propia base de datos para garantizar independencia, desacoplamiento y despliegues autónomos.

---

## Estructura de la Solución

```text
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

## Prerrequisitos

- .NET 10 SDK
- SQL Server
- Visual Studio 2026 (o Visual Studio 2022)
- Git

---

## Compilación

Desde la raíz de la solución ejecute:

```bash
dotnet build UltraGroup.HotelReservation.slnx
```

---

## Ejecución

### HotelService

```bash
dotnet run --project src/HotelService.API
```

### ReservationService

```bash
dotnet run --project src/Reservation.API
```

---

## Documentación de la API

Cada microservicio expone su documentación mediante Swagger.

### HotelService

```
https://localhost:{puerto}/swagger
```

### ReservationService

```
https://localhost:{puerto}/swagger
```

---

## Ejecución de Pruebas

Para ejecutar todas las pruebas unitarias:

```bash
dotnet test UltraGroup.HotelReservation.slnx
```

---

## Autenticación

El microservicio **ReservationService** implementa autenticación mediante **JWT (JSON Web Token)**.

Los endpoints protegidos requieren el siguiente encabezado HTTP:

```
Authorization: Bearer {token}
```
---
Colección de Postman

Para facilitar las pruebas de la API, el proyecto incluye una colección de Postman con los principales flujos del sistema.

Archivos incluidos
Postman/
│
├── UltraGroup Hotel Reservation.postman_collection.json
└── UltraGroup Local.postman_environment.json

Configuración

1. Importar la colección de Postman.
2. Importar el ambiente UltraGroup Local.
Seleccionar el ambiente antes de ejecutar las peticiones.
3. Verificar que ambos microservicios estén en ejecución: HotelService.API, Reservation.API
   
Variables del ambiente

hotelUrl:	URL del HotelService
reservationUrl:	URL del ReservationService
token:	Token JWT obtenido después del login
hotelId:	Id del hotel creado
roomId:	Id de la habitación creada
reservationId:	Id de la reserva creada

Flujo recomendado de pruebas
Login
Crear Hotel
Crear Habitación
Consultar Habitaciones Disponibles
Crear Reserva
Consultar Reserva
Cancelar Reserva

---

## Decisiones de Diseño

- Arquitectura basada en microservicios.
- Arquitectura por capas (**Domain, Application, Infrastructure y API**).
- Implementación del patrón **Repository** para el acceso a datos.
- Uso de **Entity Framework Core (Code First)** para la persistencia.
- Comunicación entre capas mediante **DTOs**.
- Autenticación basada en **JWT** para proteger los endpoints.
- Pruebas unitarias implementadas con **xUnit** y **Moq**.
- Componentes compartidos centralizados en el proyecto **UltraGroup.Common**.
- Separación de responsabilidades siguiendo principios de **Clean Architecture**.

---

## Mejoras Futuras

- Integración con un proveedor de correo electrónico (SMTP, SendGrid, Amazon SES, etc.).
- Contenerización de los microservicios mediante **Docker**.
- Implementación de un **API Gateway** para centralizar el acceso a los microservicios.
- Registro y monitoreo distribuido (Logging y Tracing).
- Implementación de **Refresh Tokens** para mejorar la gestión de autenticación.
- Autorización basada en roles y permisos (**Role-Based Authorization**).
- Implementación de un pipeline de **CI/CD** para automatizar compilación, pruebas y despliegues.
- Incorporación de validaciones más robustas y manejo centralizado de excepciones.

---

## Autora

**Xiomara Zapata**

UltraGroup.HotelReservation
Solution: UltraGroup.HotelReservation (Visual Studio 2026)
Summary
•	Hotel reservation sample application and related libraries, tests and infrastructure.
•	Targets .NET 10.
Prerequisites
•	.NET 10 SDK
•	Visual Studio 2026 or dotnet CLI
Build
•	From the solution root:
•	dotnet build UltraGroup.HotelReservation.slnx
Run (API)
•	From the solution root, start the API project (example):
•	dotnet run --project src/Reservation.API/Reservation.API.csproj
•	The API project will print the listening URL(s) to the console.
Tests
•	Run all tests from the solution root:
•	dotnet test UltraGroup.HotelReservation.slnx
Projects (high level)
•	src/Reservation.API — ASP.NET Core Web API for reservations
•	src/Reservation.App — Application services and business logic
•	src/Reservation.Domain — Domain entities and interfaces
•	src/Reservation.Infrastructure — Repositories and data access
•	test/* or src/*.*Tests — Unit tests for services and components
Contributing
•	Create branches for features/fixes.
•	Follow existing code style and add unit tests for behavioral changes.
Notes
•	If you use local databases or migrations, consult the project-specific README or startup instructions inside the API/infrastructure projects.
License
•	Add a LICENSE file at the repository root if needed.
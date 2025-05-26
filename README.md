# 🧱 Plantilla de Arquitectura Onion con CQRS, DDD y Clean Architecture (.NET 8)

Este proyecto es una **plantilla base reutilizable** para desarrollar APIs RESTful usando **.NET 8**, aplicando **Clean Architecture (Arquitectura Onion)** con los principios de **DDD (Domain-Driven Design)** y el patrón **CQRS** (Command Query Responsibility Segregation) usando **MediatR**.

Está especialmente diseñado como **guía práctica para desarrolladores que están comenzando con arquitectura limpia**, permitiendo entender y aplicar estos conceptos en un proyecto real, simple y bien estructurado.

---

## 🚀 ¿Qué incluye esta plantilla?

- ✅ Estructura modular y desacoplada basada en la **Arquitectura Onion**.
- ✅ Separación clara entre **capa de dominio, aplicación, infraestructura y presentación (API)**.
- ✅ Implementación completa de un CRUD para **Autores** y **Libros**.
- ✅ Patrón **CQRS** con **MediatR** para separar comandos (escritura) y queries (lectura).
- ✅ Persistencia con **Entity Framework Core**.
- ✅ Validaciones con **FluentValidation**.
- ✅ Uso de **DTOs** para entrada y salida de datos.
- ✅ Prácticas modernas con .NET 8 (minimal APIs o controllers, DI, records, etc).
- ✅ Patrón Unit of Work se encarga de coordinar y agrupar múltiples operaciones (como inserciones, actualizaciones, eliminaciones) en una única transacción de base de datos.
- ✅ Enfoque DDD para modelar objetos de dominio inmutables, representando conceptos del negocio de forma clara, segura y predecible. 
---

## 📚 Estructura del Proyecto

```plaintext
/src
├── Application
│   ├── Authors
│   │   ├── Commands
│   │   ├── Queries
│   │   ├── Dtos
│   │   └── Validators
│   └── Interfaces
│       ├── Repositories
│       └── Services
│
├── Domain
│   ├── Entities
│   └── Repositories (interfaces)
│
├── Infrastructure
│   ├── Persistence (EF Core)
│   ├── Services (implementaciones técnicas: Email, etc)
│   └── DependencyInjection
│
├── API
│   ├── Controllers
│   ├── Middlewares
│   └── Program.cs / Startup.cs
```
## 📦 Tecnologías utilizadas

- .NET 8
- MediatR para patrón CQRS
- Entity Framework Core
- FluentValidation
- AutoMapper

## 🧠 ¿Por qué usar esta plantilla?

- ✅ Facilita la comprensión de Clean Architecture para nuevos desarrolladores.
- ✅ Aísla la lógica de negocio del acceso a datos y frameworks.
- ✅ Promueve el uso de principios SOLID, modularidad y testabilidad.
- ✅ Mejora la mantenibilidad al crecer el proyecto.
- ✅ Reutilizable para cualquier CRUD con pequeños ajustes.

## 🛠️ Cómo empezar

# Requisitos:
- .NET 8 SDK
- Visual Studio 2022 / VS Code / Rider
- SQL Server LocalDB / SQLite (configurable en appsettings.json)

# Clonar y ejecutar:

```bash
git clone https://github.com/Ivanproyectos/template-onion-architecture.git
```
# Iniciar proyecto en visual code 
iniciar migracion de base de datos y proyecto
```bash
cd cd v2/LibraryManagement
code . 
dotnet restore
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run --project LibraryManagement.API/LibraryManagement.API.csproj
```
# Iniciar proyecto en visual studio

iniciar migracion de la base de datos en consola de paquetes de nugget
```bash
add-migration InitialCreate
update-database 
```

![Captura de pantalla 2025-05-26 152219](https://github.com/user-attachments/assets/9446550e-e724-45ce-b8fe-a9e129c25380)



# Unidad 4 — Práctica 1 EF Core

Repositorio que contiene la plantilla inicial y la consigna a resolver para la ejercitación de EF Core.

## Objetivo general

Instalar en la capa de Infraestructura los paquetes NuGet necesarios para poder utilizar EF Core con **SQL Server**. Luego configurar correctamente el ORM. Y una vez hecho eso, de acuerdo al enfoque "code first" y aprovechando la entidad `Product` existente, se debe crear la migración inicial y aplicarla para que se cree automáticamente la base de datos y la tabla de productos correspondiente.

> **Nota sobre el motor de base de datos:** esta plantilla usa .NET 10 y SQL Server (en vez de MySQL/Pomelo, como quizás viste en el apunte de la unidad). Al día de hoy, `Pomelo.EntityFrameworkCore.MySql` todavía no tiene una versión estable compatible con EF Core 10, mientras que el proveedor oficial `Microsoft.EntityFrameworkCore.SqlServer` sí la tiene. El resto del enfoque —code first, migraciones, inyección de dependencias— es exactamente el mismo, solo cambia el paquete del proveedor y la connection string.

## Stack del proyecto

- .NET 10
- Entity Framework Core 10 (proveedor `Microsoft.EntityFrameworkCore.SqlServer`)
- SQL Server: LocalDB en Windows, o SQL Server en Docker en Linux/Mac
- Swagger (`Swashbuckle.AspNetCore`) ya instalado en el proyecto Presentation

## Secuencia de pasos a realizar

(podés guiarte con los ejemplos del apunte de la unidad y con el guion de la clase)

1. Instalar los paquetes de EF Core y del proveedor de SQL Server (`Microsoft.EntityFrameworkCore.SqlServer` y `Microsoft.EntityFrameworkCore.Design`, versión `10.*`) en el proyecto **Infrastructure**.
2. Crear la clase `ApplicationDbContext` en la capa de Infraestructura y agregarle una propiedad `DbSet<Product>`.
3. Agregar el `ConnectionString` en el `appsettings.Development.json` del proyecto **Presentation**.
4. Agregar en la clase `Program.cs` las instrucciones necesarias para registrar el `ApplicationDbContext` en el contenedor de servicios.
5. Intentar crear la migración inicial para luego aplicarla y crear la DB con la tabla de productos.

## EXTRA

Luego de haber conseguido aplicar la migración con éxito podés continuar programando todo lo necesario para crear un CRUD de producto:

- Crear `IProductRepository` y `ProductRepository`.
- Crear `IProductService` y `ProductService`.
- Crear `ProductController`.
- Asegurate de aplicar DI para:
  - Inyectar el `ApplicationDbContext` en el `ProductRepository`.
  - Inyectar el `IProductRepository` en el `ProductService`.
  - Inyectar el `IProductService` en el `ProductController`.
- No olvides registrar todo en el contenedor de servicios en la clase `Program.cs`.
- Por último, creá todos los métodos necesarios para conseguir un CRUD de producto funcional.

## Estructura de partida

```
src/
├── Domain/          → Entidades del dominio. Ya existe Product. Vacío de lógica.
├── Application/      → DTOs, interfaces de servicios y lógica de negocio. Vacío por ahora.
├── Infrastructure/    → Acceso a datos, DbContext, repositorios. Vacío por ahora.
└── Presentation/     → API (Controllers, Program.cs, appsettings). Ya existe el esqueleto, con Swagger instalado.
```

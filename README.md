# Template onion architecture

Este template en .NET 8 implementa la arquitectura Onion, diseñado para reutilizar y modularizar aplicaciones siguiendo buenas prácticas y principios de código limpio. Incluye un ejemplo sencillo de gestión de autores y libros, ideal para proyectos escalables y mantenibles

## Patrones usados

| Patron             | Responsabilidad                                                                |
| ----------------- | ------------------------------------------------------------------ |
| MediatR | Implementa el patrón Mediator para centralizar la comunicación entre objetos sin que estos se conozcan entre sí, facilitando el desacoplamiento y la organización de código |
| Specification | Define criterios de búsqueda o filtros como objetos reutilizables y combinables, facilitando consultas complejas de manera flexible y desacoplada. |
| Repository | Abstrae el acceso a la base de datos, proporcionando una capa intermedia entre el dominio y la persistencia, permitiendo manejar datos como colecciones en memoria |
| CQRS| Separa las operaciones de lectura (queries) y escritura (commands) en diferentes modelos, optimizando el rendimiento y la organización del código|

## Bibliotecas 

| Patron             | Responsabilidad                                                                |
| ----------------- | ------------------------------------------------------------------ |
| FluentValidation | Es una biblioteca que permite implementar validaciones de manera fluida y declarativa para asegurar que los datos ingresados cumplan con ciertas reglas, mejorando la claridad y mantenibilidad del código |
| Mapper (AutoMapper) | Es una biblioteca utilizada para mapear objetos de un tipo a otro (por ejemplo, entidades de base de datos a DTOs), automatizando y simplificando la conversión entre modelos y reduciendo el código repetitivo |


## Iniciar migraciones

Para migrar los objetos de base de datos, actualiza la cadena de conexión en la clase AuthorDbFactory dentro de la capa de persistencia. Luego, abre la Consola del Administrador de Paquetes de NuGet y ejecuta el siguiente comando:

```bash
add-migration InitialMigration -p Api.autor.Persintence -s Api.autor.Persintence -c AuthorDbContext

update-database InitialMigration -p Api.autor.Persintence -s Api.autor.Persintence -context AuthorDbContext
```
- `p Api.autor.Persistence`: El proyecto donde se encuentran las migraciones.
- `s Api.autor.Persistence`: El proyecto de inicio (donde se ejecuta la aplicación).
- `c AuthorDbContext`: Especifica que debe utilizar el contexto `AuthorDbContext` para generar la migración

## 🔗 Links
[![portfolio](https://img.shields.io/badge/my_portfolio-000?style=for-the-badge&logo=ko-fi&logoColor=white)](https://www.linkedin.com/in/ivan-perez-tintaya/)
[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/ivan-perez-tintaya/)

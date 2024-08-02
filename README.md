# devApp

**devApp** es un proyecto que implementa cuatro APIs diseñadas para la cotización de envío de paquetes. Cada API está desarrollada utilizando diferentes tecnologías y arquitecturas, cumpliendo con principios de diseño sólidos y documentadas adecuadamente. A continuación se proporciona una descripción detallada de cada API y sus características.

## APIs

### Fedex API

- **Descripción**: API web escalable para la cotización de envío de paquetes.
- **Tecnologías**:
  - **Framework**: ASP.NET Core MVC
  - **ORM**: Entity Framework
  - **Seguridad**: Identity (manejo de roles y autenticación)
  - **Patrones**: CQRS, Mediator, Singleton
  - **Documentación**: Swagger
- **Características**:
  - Arquitectura Onion
  - Implementación de principios SOLID
  - Patrones de diseño
  - Seguridad robusta y manejo de roles

### Domex API

- **Descripción**: API web escalable para la cotización de envío de paquetes.
- **Tecnologías**:
  - **Framework**: ASP.NET Core MVC
  - **ORM**: Entity Framework
  - **Seguridad**: Identity (manejo de roles y autenticación)
  - **Patrones**: CQRS, Mediator, Singleton
  - **Documentación**: Swagger
- **Características**:
  - Arquitectura Onion
  - Implementación de principios SOLID
  - Capa de servicios
  - Seguridad robusta y manejo de roles

### Vimenpaq API

- **Descripción**: API web escalable para la cotización de envío de paquetes.
- **Tecnologías**:
  - **Framework**: ASP.NET Core MVC
  - **ORM**: Entity Framework
  - **Seguridad**: Identity (manejo de roles y autenticación)
  - **Documentación**: Swagger
  - **Formato de Datos**: XML
- **Características**:
  - Arquitectura Onion
  - Implementación de principios SOLID
  - Capa de servicios
  - Peticiones consumidas y enviadas en XML

### Cristoffpaq API

- **Descripción**: API web escalable para la cotización de envío de paquetes.
- **Tecnologías**:
  - **Framework**: Express.js
  - **Formatos de Datos**: JSON, XML
- **Características**:
  - Implementación de principios SOLID
  - Capa de servicios

## Instalación

### Requisitos

- Node.js y npm (para Cristoffpaq)
- .NET Core SDK (para Fedex, Domex, y Vimenpaq)

### Clonar el Repositorio

```bash
git clone https://github.com/tu-usuario/devApp.git
cd devApp
```

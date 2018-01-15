# Football predictions
Web application for organizing score prediction games and handling football statistics. This is an (uncompleted) upgrade of previous MVC-based application, see [football-predictions-webapp](https://github.com/IlyaKugaevsky/football-predictions-webapp).

## Table of contents
> - **[Tech stack](#tech-stack-1)**
>   - [Core parts](#core-parts-1)
>   - [Additional tools](#additional-tools-1)
> - **[API server overview](#api-server-overview-1)**
> 	- [Global architectural patterns and design decisions](#global-architectural-patterns-and-design-decisions-1)
>   - [Layers](#layers)
>   - [Testing](#testing)
> - **[Client web application overview](#client-web-application-overview-1)**
>   - [Implemented features](#implemented-features)

## Tech stack
### Core parts
- Data stores
	- Microsoft SQL Server
	- SQLite
	- Redis (in progress)
- API server 
	- ASP.NET Core Web API
	- Entity Framework Core
- Client web application
	- Angular 5
	- Node.js 
### Additional tools
- DevOps
	- Docker
	- Ansible (in progress)
- Reverse proxy (in progress)
	- Nginx
- Message queue (under consideration)
	- RabbitMQ

## API server overview
### Global architectural patterns and design decisions
- Rich Domain: most business logic in domain models and domain services
- Separate ORM-configurations from domain via Entity Framework Core 2.0 features (owned types, fluent API)
- CQRS approach (via MediatR) instead of Repository Pattern 
- REST API, even non-CRUD operations are considered as GET/POST resource manipulations (in progress)
- Event sourcing (under consideration)
### Layers
- Persistence (DbContext, data fetching strategies)
- Domain (models, services)
- ReadModel (queries, DTOs)
- WriteModel (commands, DTOs)
- Web (controllers, middleware, composition root)
### Testing 
- Using xUnit 
- Unit tests for each layer
- Testing database operations with local database and json-fixtures
- Integration tests with TestServer (in progress)
- E2E tests (in progress)
## Client web application overview
For now client is very sketchy: no complex styles, no pretty animations, just borders and text, "proof of concept". 

### Implemented features
- Node.js prerendering
- Lazy loading modules
- Cyrillic dates by default
- Simple pages for "crudable" resources
- Reusable and customizable match-table component 

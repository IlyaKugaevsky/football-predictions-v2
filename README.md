# Football predictions
Web application for organizing score prediction games and handling football statistics. This is an (uncompleted) upgrade of previous MVC-based application, see [football-predictions](https://github.com/IlyaKugaevsky/football-predictions).

## Table of contents
> - **[Tech stack](#tech-stack)**
>   - [Backend](#backend)
>   - [Frontend](#frontend)
>   - [DevOps](#devops)
> - **[API server overview](#api-server-overview)**
>   - [Global architectural patterns and design decisions](#global-architectural-patterns-and-design-decisions)
>   - [Layers](#layers)
>   - [Testing](#testing)
> - **[Client web application overview](#client-web-application-overview)**
>   - [Implemented features](#implemented-features)

## Tech stack
### Backend
- Data stores
	- Microsoft SQL Server
	- SQLite
	- Redis (in progress)
- API server 
	- ASP.NET Core Web API
	- Entity Framework Core
- Message queue (under consideration)
	- RabbitMQ
	
### Frontend
- Client web application
	- Angular 5
- Server prerendering
	- Node.js
	- Webpack
- Reverse proxy (in progress)
	- Nginx
### DevOps
- DevOps
	- Docker
	- Ansible (in progress)

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

# DevTrack - Learning-Oriented SaaS Project Roadmap

## Goal

Build a production-style SaaS platform that helps software teams manage:

* Projects
* Tasks
* Deployments
* Incidents
* Notifications
* Analytics

The primary objective is not to create a successful product, but to learn:

* ASP.NET Core Web API
* Entity Framework Core
* PostgreSQL
* Authentication & Authorization
* Redis
* RabbitMQ
* Docker
* CI/CD
* Monitoring
* Microservices

---

# Architecture Evolution

The project should evolve through several stages:

```text
Simple Monolith
    ↓
Modular Monolith
    ↓
Event-Driven Monolith
    ↓
Microservices
```

Do NOT start with microservices.

---

# Phase 1 - Foundation

## Technologies

* ASP.NET Core Web API
* EF Core
* Oracle SQL
* JWT Authentication

## Modules

### Authentication

Features:

* Register
* Login
* Refresh Token
* Logout

Learn:

* JWT
* Refresh Tokens
* Claims
* Password Hashing

### Users

Features:

* View Profile
* Update Profile

Learn:

* DTOs
* Validation
* AutoMapper (optional)

### Workspaces

Features:

* Create Workspace
* Join Workspace
* List Workspace Members

Learn:

* One-to-Many Relationships
* Many-to-Many Relationships

### Projects

Features:

* Create Project
* Update Project
* Archive Project

Learn:

* Project Ownership
* Authorization

### Tasks

Features:

* Create Task
* Assign Task
* Update Status
* Delete Task

Statuses:

```text
To Do
In Progress
Review
Done
```

Learn:

* Pagination
* Filtering
* Sorting

---

# Phase 2 - Production Readiness

## Validation

Use:

* FluentValidation

Learn:

* Request Validation
* Business Validation

## Global Error Handling

Implement:

* Exception Middleware

Learn:

* ProblemDetails
* Consistent API Responses

## Logging

Use:

* Serilog

Learn:

* Structured Logging
* Correlation IDs

## Authorization

Roles:

```text
Owner
Admin
Member
Viewer
```

Learn:

* Policy-Based Authorization
* Custom Requirements

---

# Phase 3 - DevOps Domain Features

## Deployments

Entity:

```text
Deployment
- Id
- Version
- Environment
- Status
- CommitHash
- CreatedAt
```

Statuses:

```text
Success
Failed
RolledBack
```

Learn:

* Domain Modeling
* Audit Logs

## Incidents

Entity:

```text
Incident
- Id
- Title
- Severity
- Status
- RootCause
- StartedAt
- ResolvedAt
```

Severity:

```text
Low
Medium
High
Critical
```

Status:

```text
Open
Investigating
Resolved
```

Learn:

* State Transitions
* Business Rules

## Activity Log

Track:

```text
TaskCreated
TaskAssigned
ProjectCreated
DeploymentCreated
IncidentOpened
IncidentResolved
```

Learn:

* Auditing
* Event History

---

# Phase 4 - Redis

## Implement Caching

Cache:

* Dashboard Statistics
* Project Overview
* Recent Activity

Learn:

* Cache Aside Pattern
* Expiration Policies
* Cache Invalidation

Example:

```text
Request
    ↓
Redis
    ↓ (miss)
Database
    ↓
Store in Redis
```

---

# Phase 5 - RabbitMQ

## Event-Driven Architecture

Publish Events:

```text
TaskAssigned
DeploymentCreated
DeploymentFailed
IncidentOpened
IncidentResolved
```

Learn:

* Producers
* Consumers
* Exchanges
* Routing Keys

## Notifications

Create:

Notification Worker

Consumes:

```text
TaskAssigned
IncidentOpened
DeploymentFailed
```

Creates:

```text
Email Notification
In-App Notification
```

Learn:

* Background Processing
* Eventual Consistency

---

# Phase 6 - Docker

Containerize:

```text
API
PostgreSQL
Redis
RabbitMQ
```

Use:

```yaml
docker-compose.yml
```

Learn:

* Networking
* Volumes
* Environment Variables

---

# Phase 7 - CI/CD

GitHub Actions

Pipeline:

```text
Build
    ↓
Test
    ↓
Publish Docker Image
```

Learn:

* Automated Builds
* Automated Testing
* Deployment Pipelines

---

# Phase 8 - Testing

## Unit Tests

Test:

* Services
* Business Logic

Tools:

* xUnit
* FluentAssertions

## Integration Tests

Test:

* API Endpoints
* Database Interactions

Learn:

* TestContainers

---

# Phase 9 - Monitoring

## OpenTelemetry

Learn:

* Tracing
* Metrics

## Grafana

Visualize:

* Request Count
* Error Rate
* Response Times

---

# Phase 10 - Microservices

## Notification Service

Responsibilities:

```text
Consume Events
Send Notifications
Manage Notification History
```

Own Database:

```text
NotificationDb
```

## Analytics Service

Responsibilities:

```text
Generate Reports
Dashboard Statistics
Project Metrics
```

Own Database:

```text
AnalyticsDb
```

---

# Stretch Goals

* SignalR Real-Time Notifications
* API Versioning
* Feature Flags
* Rate Limiting
* OAuth2 Login (Google/GitHub)
* Kubernetes
* Helm Charts
* Azure Deployment

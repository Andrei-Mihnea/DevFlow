# DevFlow Architecture Direction

## Current State and Target

The repository contains three separately packaged APIs: Auth, Workspaces, and Projects. Each owns its domain, persistence implementation, Oracle database, and migrations. No service references another service's application, domain, or infrastructure project.

The target is independently deployable microservices organized around business capabilities. Independent releases, resilient communication, authorization, and operational readiness still need implementation.

## Capability Ownership

| Capability | Ownership | Status |
| --- | --- | --- |
| Auth | Accounts and identity/token lifecycle | Registration exists; authentication lifecycle is incomplete. |
| Workspaces | Teams, membership, and workspace permissions | Workspace creation and owner membership exist; permission enforcement is planned. |
| Projects | Projects, tasks, boards, and links to development activity | Project/task creation exists; boards and links are planned. |
| GitHub integration | Repository connections, provider credentials, webhooks, and synchronized activity | Proposed boundary; not implemented. |
| AI assistance | Model calls, review/summary jobs, outputs, evaluation, and usage budgets | Proposed boundary; not implemented. |

GitHub integration and AI assistance are candidates for separate services because their workloads, external dependencies, credentials, and release needs differ. Design their contracts before implementation. Additional services should follow business ownership and operational needs.

## Service Independence

- A service owns its data and business rules. Other services cannot query its tables or import its domain types.
- Shared building blocks contain technical utilities only. Preserve compatibility rather than force coordinated releases.
- APIs and events expose explicit contracts with documented compatibility/versioning rules.
- Each service must eventually have its own release path and controlled migration step. A monorepo is compatible with this goal.
- Cross-service IDs are logical references. Workflows spanning services need explicit consistency and recovery rules; no distributed transaction is assumed.

## Communication and Consistency

Use synchronous APIs when an immediate authoritative result is required. Use events for background processing and updates where delayed synchronization is acceptable. Adapters and message brokers do not automatically remove coupling; contracts and failure behavior determine it.

The existing Messaging building block is an in-process mediator, not an inter-service event bus.

Projects currently stores WorkspaceId and UserId references without verifying workspace existence or membership. Implement those checks before exposing protected workflows. A membership projection fed by Workspaces events is a possible design, but revocation delay must be explicitly accepted. Sensitive decisions may require an authoritative check.

Durable event processing requires idempotent consumers, bounded retries, failed-message handling, reconciliation, and an outbox when database changes and publication must stay consistent. Define behavior for duplicate and out-of-order events.

## Security and AI Boundaries

APIs should validate signed identity tokens locally and derive the acting user from verified claims. Request-supplied creator IDs are part of the prototype and must not become authority for protected operations. Resource access must enforce team/project permissions.

Verify GitHub webhook signatures and installation/repository scope. Keep limited-scope provider credentials server-side and define their lifecycle during integration design.

Authorize AI requests before fetching repository content or sending it to a provider. Private-code processing requires explicit enablement. Code, comments, and CI logs are untrusted material; embedded instructions must not override application policy. AI findings remain advisory initially, reference evidence, and never authorize merges or execute commands. Enforce usage budgets and record model/version details for evaluation.

## Containers and Future Kubernetes

Compose supports local development. Kubernetes manifests and Helm charts do not exist yet.

Before scaling replicas, establish stateless APIs, external secrets/configuration, readiness/liveness probes, graceful shutdown, resource requests/limits, connection budgets, and concurrency-safe writes. Current /health endpoints are liveness checks only. Run migrations through a controlled release step rather than from every replica.

Database constraints remain the final guard for concurrent writes. Simultaneous workspace slug creation must yield a clean conflict even when both requests pass the availability check.

Scale background GitHub and AI processing through durable queues when introduced. Oracle capacity and availability need a separate strategy; API replica scaling does not scale the database. Development and production must use separate credentials and data.

See the [roadmap](../Goal.md) for delivery order and the [README](../README.md) for current local setup.

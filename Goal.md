# DevFlow Roadmap

## Vision

Build a GitHub-connected development platform that brings planning, repository activity, and AI assistance into one team workspace. Teams should manage a Jira-style task board, link tasks to branches and pull requests, follow CI results, and request useful AI explanations and reviews.

DevFlow remains a learning project, with production-minded goals: secure authorization, clear data ownership, independently deployable services, measurable behavior, and eventual Kubernetes scaling.

## Current Baseline

Implemented in the working tree:

- Auth, Workspaces, and Projects APIs, each with application, domain, and infrastructure layers.
- Separate Oracle databases and migration histories per service.
- User registration, workspace creation with owner membership, project creation, and task creation.
- Custom in-process mediator, validation pipeline, result types, and HTTP result mapping.
- Dockerfiles for all APIs and split Compose files for infrastructure, services, and development.
- Formatting/analyzer standards and GitHub Actions for builds, unit tests with coverage, dependency audits, secret scans, and all API image scans.
- Unit tests for Results and workspace creation/validation.

Not implemented yet: login/token lifecycle, enforced workspace authorization, membership management, task boards, GitHub connectivity, AI features, Angular frontend, image publishing/CD, or Kubernetes deployment. Health endpoints are liveness checks, not database readiness checks.

## Milestone 1 — Secure Team Foundation

- Complete login, refresh tokens, logout, and password hashing/security review.
- Validate authentication tokens in APIs and derive acting user IDs from verified identity.
- Implement workspace invitations/membership and Owner, Admin, Member, and Viewer permissions.
- Enforce project/task access, including cross-service ownership rules.
- Define global error handling and safe behavior for concurrent unique-key conflicts.
- Add focused business-rule tests and API/database integration tests.

Acceptance: authenticated users can manage only the workspaces and projects they are authorized to access.

## Milestone 2 — Task Planning and Angular Frontend

- Add project listing, editing, and archiving.
- Add task listing, editing, assignment, deletion, filtering, sorting, and pagination.
- Support To Do, In Progress, Review, and Done states with defined transitions.
- Build Angular workspace/project views and the task board.
- Keep tasks and boards in Projects initially; split capabilities when ownership or independent operation warrants it.

Acceptance: a team can plan and track work through the frontend against real backend data.

## Milestone 3 — GitHub-Connected MVP

- Introduce a GitHub integration capability; design access permissions and credential handling first.
- Connect one repository to a project and receive verified GitHub webhooks.
- Synchronize pull requests, reviews, commits, and workflow results.
- Link work items to branches and PRs through explicit identifiers/conventions.
- Display linked PR and CI activity in Angular.
- Make webhook processing asynchronous, idempotent, and recoverable; reconcile missed events.
- Add optional board automation for PR opening/merging with explicit team rules.

Acceptance: one workspace can connect one repository, link tasks to PRs, and see updates without manual duplication.

## Milestone 4 — AI Assistance

- Start with user-requested PR summaries using the diff and linked task context.
- Add advisory code-review findings with file/line evidence and clear limitations.
- Explain failed CI runs and suggest task breakdowns or acceptance criteria.
- Put provider implementations behind a backend interface so models can change without changing business use cases.
- Enforce access before retrieving repository content or invoking a model.
- Require explicit enablement for sending private code to a provider.
- Treat code, comments, and logs as untrusted input; model output never grants permissions or executes changes automatically.
- Track usage, latency, costs, and model/version details; evaluate quality before expanding automation.

Acceptance: users can request useful summaries and inspect evidence-backed suggestions while retaining control of decisions.

## Milestone 5 — Independent Releases and Environments

- Publish versioned API images after required checks pass.
- Establish isolated development and production configuration, secrets, data, and approvals.
- Run migrations as controlled release steps per service.
- Make services independently buildable, testable, and deployable with compatible contracts.
- Add development-only/manual or scheduled load tests and agreed performance targets.
- Automate README upkeep only after PR merges into main, respecting branch protection. This workflow is planned, not present.

Acceptance: a compatible change to one service can be released without redeploying all services.

## Milestone 6 — Observability and Kubernetes Scaling

- Add structured logs, correlation IDs, metrics, and distributed tracing.
- Implement readiness/liveness probes, graceful shutdown, and resource requests/limits.
- Keep API replicas stateless and move durable background work into queues.
- Add Kubernetes manifests or Helm charts and autoscaling based on measured workload.
- Test retries, duplicate delivery, concurrency, and dependency outages.
- Plan Oracle capacity, connection budgets, backups, and recovery separately from API scaling.

Acceptance: services can scale independently with monitored behavior and tested failure handling.

## Later Opportunities

Notifications, activity history, deployment insights, incidents, analytics, caching, and real-time updates can extend the core workflow. Introduce Redis, RabbitMQ, or other infrastructure when a concrete requirement justifies them.

See [architecture direction](docs/architecture.md) for the rules guiding these milestones. Milestones describe intended delivery order, not completed phases or delivery dates.

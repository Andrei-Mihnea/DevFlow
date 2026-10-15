# DevFlow CI

## Scope and Triggers

The [workflow](../.github/workflows/ci.yml) adapts ASET's CI practices to DevFlow's current backend. It validates the selected event revision: PR merge candidate, branch push head, merge-group candidate, or manual ref. It does not execute every historical commit.

CI runs on pushes to every branch, PRs targeting main, merge groups, manual dispatch, and Mondays at 05:17 UTC. Scheduled runs use the default branch and recheck unchanged dependencies against new advisories. Superseded PR and feature-branch push runs are cancelled; main runs are retained.

## Checks

| Job | Behavior |
| --- | --- |
| Quality, build, and tests | Linux, Windows, and macOS matrix; solution/lock inventory; direct project-reference boundaries; locked restore; whitespace/style verification; strict Release build; tests with TRX and Coverlet. |
| Workflow and Compose validation | Checksum-verified actionlint, including ShellCheck where available; combined Compose validation using safe example values. |
| Dependency vulnerability audit | Locked restore with direct/transitive NuGet audit at low and higher severity; JSON report; fail if vulnerable packages are found. |
| Secret scan | Checksum-verified Gitleaks scans reachable Git history and current checkout files, with redacted JSON reports. |
| API container security | Independent Auth, Workspaces, and Projects image builds; checksum-verified Trivy vulnerability/secret scans; CycloneDX SBOMs; non-root startup and liveness smoke tests; cleanup and startup logs. |
| CI / Required | Aggregate check: every upstream job, including every matrix entry, must succeed. Failure, cancellation, or skipping cannot produce a successful gate. |

Security and container jobs do not wait for the build/test matrix. A failed unit test does not suppress security checks. Test/security diagnostics are uploaded after failure when produced. Jobs have explicit timeouts and read-only repository permissions; checkout credentials are not persisted.

The project-reference guard rejects references between Auth, Workspaces, and Projects, service references from shared building blocks, Application references to API/Infrastructure, and Domain references other than the shared Results primitives. It checks direct references in solution projects; it is not a complete runtime architecture verifier. Legacy projects outside DevFlow.slnx remain outside the build scope.

Each solution test project must emit exactly one nonempty, entirely passing TRX report and a nonempty Cobertura report. Skipped tests fail the test-result gate. There is no overall or changed-line percentage gate yet: the existing seven tests do not cover the full backend. Oracle integration tests and performance tests remain planned. The image vulnerability gate preserves the previous HIGH/CRITICAL and ignore-unfixed policy; NuGet auditing remains stricter and includes all severities.

## Container Smoke Test Limits

Images restore locked dependencies and use the .NET base image's non-root APP_UID user. CI starts each image in Production with a dummy Oracle connection string and polls its HTTP /health endpoint. It also checks that the running process user is non-root.

No Oracle database is started. These checks establish packaged startup/liveness, not database connectivity, schema correctness, authorization, migrations, or business behavior. Existing /health checks do not query Oracle. The smoke test makes this limitation explicit rather than treating liveness as readiness.

## Dependencies and Maintenance

Every project listed in DevFlow.slnx has a committed packages.lock.json. CI and Docker builds use --locked-mode and cannot silently refresh those files. Setup-dotnet caches NuGet packages using the lockfiles as input.

For an intentional dependency change, edit its package reference, then run:

```bash
dotnet restore DevFlow.slnx --force-evaluate
dotnet restore DevFlow.slnx --locked-mode
dotnet package list --project DevFlow.slnx --no-restore --include-transitive --vulnerable --format json
```

Review and commit affected lockfiles with the package change. Audits stay enabled, and warnings remain errors. The Pkcs 8.0.2 override in all Infrastructure projects addresses the Oracle driver's vulnerable transitive 8.0.1 dependency.

GitHub Actions are pinned to commit IDs. Security tools are pinned by release and verified SHA-256 hashes; update the version and checksum together. Dependabot is configured weekly for Actions, NuGet, and each API Dockerfile. Docker base tags still float within .NET 10; digest pinning is future hardening.

## Reports and Branch Protection

Test reports/coverage, dependency diagnostics, redacted secret reports, container scan reports, SBOMs, and startup logs are retained for 14 days. Artifact names distinguish OS or service where jobs run in parallel. Container images are not published or deployed.

After the first GitHub run exposes CI / Required, set the main ruleset to require it. Keep PR review requirements in place and remove obsolete individual job names only after the aggregate gate is available. This repository change does not activate or modify remote branch rules.

## Verification

Local validation covers locked restore, Release build, the seven unit tests with TRX/Coverlet output, formatting, workflow lint where available, and Compose configuration. Hosted Windows/Linux execution and container startup/scanning still need a GitHub run when Docker is unavailable locally. CI configuration should not be confused with a successful hosted run.

Next steps are real Oracle API/database integration tests, broader business tests and justified coverage thresholds, source-code security analysis, API compatibility checks, and controlled performance tests. Deployment remains inactive until infrastructure, environment secrets, migration steps, and approvals exist.

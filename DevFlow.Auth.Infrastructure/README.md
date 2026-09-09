# DevFlow.Auth.Infrastructure

Implements Auth persistence with EF Core and Oracle.

It contains `AuthDbContext`, entity configurations, the `UserRepository`, and the Auth migration history. This project owns the `USERS` and `REFRESH_TOKENS` tables in the Auth database container.

# DevFlow.Auth.Domain

Contains the Auth business model without framework or database dependencies.

Current concepts are `User`, `RefreshToken`, and `ApplicationRole`. This layer owns user state and token lifecycle rules; it must not reference API, EF Core, or Oracle projects.

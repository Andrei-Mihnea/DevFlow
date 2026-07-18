namespace Api.Contracts.Auth;

public sealed record RegisterUserRequest(string Email, string Password, string ReTypedPassword,string FirstName, string LastName);
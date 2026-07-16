namespace Domain.Users;

public class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private readonly List<RefreshToken> _refreshTokens = [];
    public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens;
    
    private User (){} //EF core

    public User(string email, string passwordHash, string firstName, string lastName)
    {
        Id = Guid.NewGuid();
        Email = email;
        PasswordHash = passwordHash;
        FirstName = firstName;
        LastName = lastName;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }
}
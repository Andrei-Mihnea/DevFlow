namespace Domain.Users;

public class RefreshToken
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set;}
    public string TokenHash { get; private set;}
    public DateTime ExpiresAt { get; private set;}
    public DateTime CreatedAt { get; private set;}
    public DateTime? RevokedAt { get; private set;}

    public bool IsRevoked => RevokedAt is not null;
    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;

    private RefreshToken() { } // EF Core
    
    public RefreshToken(Guid userId, string tokenHash, DateTime expiresAt)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        TokenHash = tokenHash;
        ExpiresAt = expiresAt;
        CreatedAt = DateTime.UtcNow;
    }

    public void RevokeToken()
    {
        RevokedAt = DateTime.UtcNow;
    }
}
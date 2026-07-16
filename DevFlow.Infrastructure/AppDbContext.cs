using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
}
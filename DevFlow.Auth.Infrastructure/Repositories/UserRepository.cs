using DevFlow.Auth.Application.Abstractions.Repositories;
using DevFlow.Auth.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace DevFlow.Auth.Infrastructure.Repositories;

public sealed class UserRepository(AuthDbContext dbContext) : IUserRepository
{
    public Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return dbContext.Users.AnyAsync(
            user => user.Email == email,
            cancellationToken);
    }

    public void Add(User user)
    {
        dbContext.Users.Add(user);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}

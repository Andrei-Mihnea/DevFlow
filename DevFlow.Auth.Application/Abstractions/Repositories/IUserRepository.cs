using DevFlow.Auth.Domain.Users;

namespace DevFlow.Auth.Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);
    void Add(User user);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}

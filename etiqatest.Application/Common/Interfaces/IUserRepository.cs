using etiqatest.Domain.Users;

namespace etiqatest.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user, CancellationToken cancellationToken);
        Task<List<User>> GetUsersAsync(CancellationToken cancellationToken);

        Task<User> GetUserAsync(int id, CancellationToken cancellationToken);

        Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken);

        Task<User> UpdateUserAsync(User user, CancellationToken cancellationToken);

        Task<List<Skillset>> GetUserSkillSetsAsync(int userId, CancellationToken cancellationToken);
        Task<Skillset> GetUserSkillSetAsync(int skillSetId, CancellationToken cancellationToken);
        Task<Skillset> AddUserSkillSetAsync(Skillset skillset, CancellationToken cancellationToken);
        Task<Skillset> UpdateUserSkillSetAsync(Skillset skillset, CancellationToken cancellationToken);
        Task DeleteUserSkillSetAsync(Skillset skillset, CancellationToken cancellationToken);
        Task<User?> GetUserByEmail(string email);
    }
}

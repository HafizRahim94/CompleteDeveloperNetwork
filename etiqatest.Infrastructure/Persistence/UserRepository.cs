using etiqatest.Application.Common.Interfaces;
using etiqatest.Infrastructure.Helper;
using etiqatest.Domain.Users;
using etiqatest.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace etiqatest.Infrastructure.Persistence
{
    public class UserRepository(CompleteDeveloperNetworkDbContext _context, IUserService userService) : IUserRepository
    {
        public async Task<User> AddUserAsync(User user, CancellationToken cancellationToken)
        {
            CheckExistingUsername(user);
            CheckExistingEmail(user);
            string hashedPassword = string.Empty;
            string saltString = string.Empty;
            PasswordHasher.HashPassword(user.Password, ref hashedPassword, ref saltString);
            user.Password = hashedPassword;
            user.Salt = saltString;

            _context.SetCurrentUserId(userService.GetUserId());
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;

        }

        public async Task<Skillset> AddUserSkillSetAsync(Skillset skillset, CancellationToken cancellationToken)
        {
            _context.SetCurrentUserId(userService.GetUserId());
            await _context.Skillsets.AddAsync(skillset);
            await _context.SaveChangesAsync();
            return skillset;
        }
        public async Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var user = await GetUserAsync(id, cancellationToken);

                _context.SetCurrentUserId(userService.GetUserId());
                
                _context.Users.Remove(user);
                
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }

        public async Task DeleteUserSkillSetAsync(Skillset skillset, CancellationToken cancellationToken)
        {
            _context.SetCurrentUserId(userService.GetUserId());

            _context.Skillsets.Remove(skillset);

            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(int id, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Include(x => x.Skillsets)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (user is null)
                throw new Exception($"User with id {id} does not exists!");

            return user;
        }

        public async Task<List<User>> GetUsersAsync(CancellationToken cancellationToken)
        {
            var result = await _context.Users
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<Skillset> GetUserSkillSetAsync(int skillSetId, CancellationToken cancellationToken)
        {
            return await _context.Skillsets.SingleOrDefaultAsync(x => x.Id == skillSetId);
        }

        public async Task<List<Skillset>> GetUserSkillSetsAsync(int userId, CancellationToken cancellationToken)
        {
            return await _context.Skillsets.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<User> UpdateUserAsync(User user, CancellationToken cancellationToken)
        {
            CheckExistingUsername(user);
            CheckExistingEmail(user);
            _context.SetCurrentUserId(userService.GetUserId());
            var userContext = await GetUserAsync(user.Id, cancellationToken);
            userContext.PhoneNumber = user.PhoneNumber;
            userContext.Hobby = user.Hobby;
            userContext.Username = user.Username;

            string hashedPassword = string.Empty;
            string saltString = string.Empty;
            PasswordHasher.HashPassword(user.Password, ref hashedPassword, ref saltString);
            user.Password = hashedPassword;
            user.Salt = saltString;
            await _context.SaveChangesAsync();
            return userContext;
        }

        public async Task<Skillset> UpdateUserSkillSetAsync(Skillset skillset, CancellationToken cancellationToken)
        {
            _context.SetCurrentUserId(userService.GetUserId());
            var skillsetContext = await GetUserSkillSetAsync(skillset.Id, cancellationToken);
            skillsetContext.SkillName = skillset.SkillName;
            skillsetContext.SkillDescription = skillset.SkillDescription;
            await _context.SaveChangesAsync();
            return skillsetContext;
        }

        public async Task<User?> GetUserByEmail(string email) 
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }

        private bool CheckExistingUsername(User user) 
        {
            var exists = _context.Users.Any(x => x.Username.ToLower() == user.Username.ToLower());

            if (exists)
            {
                throw new Exception($"Username {user.Username} already exists. Please try different username.");
            }

            return exists;
        }

        private bool CheckExistingEmail(User user) 
        {
            var exists = _context.Users.Any(x => x.Email.ToLower() == user.Email.ToLower());

            if (exists)
            {
                throw new Exception($"Email {user.Email} already use by another user. Please try different email.");
            }

            return exists;
        }
    }
}

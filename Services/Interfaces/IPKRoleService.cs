using PestKontroll.Models;

namespace PestKontroll.Services.Interfaces
{
    public interface IPKRoleService
    {
        public Task<bool> IsUserInRoleAsync(User user, string roleName);
        public Task<IEnumerable<string>> GetUserRolesAsync(User user);
        public Task<bool> AddUserToRoleAsync(User user, string roleName);
        public Task<bool> RemoveUserFromRoleAsync(User user, string roleName);
        public Task<bool> RemoveUserFromRolesAsync(User user, IEnumerable<string> roles);

        public Task<List<User>> GetUsersInRoleAsync(string roleName, int companyId);
        public Task<List<User>> GetUsersNotInRoleAsync(string roleName, int companyId);
        public Task<string> GetRoleNameByIdAsync(string roleId);
    }
}

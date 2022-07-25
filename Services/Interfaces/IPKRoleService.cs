using Microsoft.AspNetCore.Identity;
using PestKontroll.Models;

namespace PestKontroll.Services.Interfaces
{
    public interface IPKRoleService
    {
        public Task<bool> IsUserInRoleAsync(PKUser user, string roleName);
        public Task<List<IdentityRole>> GetRolesAsync();
        public Task<IEnumerable<string>> GetUserRolesAsync(PKUser user);
        public Task<bool> AddUserToRoleAsync(PKUser user, string roleName);
        public Task<bool> RemoveUserFromRoleAsync(PKUser user, string roleName);
        public Task<bool> RemoveUserFromRolesAsync(PKUser user, IEnumerable<string> roles);

        public Task<List<PKUser>> GetUsersInRoleAsync(string roleName, int companyId);
        public Task<List<PKUser>> GetUsersNotInRoleAsync(string roleName, int companyId);
        public Task<string> GetRoleNameByIdAsync(string roleId);
    }
}

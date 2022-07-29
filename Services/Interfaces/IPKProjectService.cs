using PestKontroll.Models;

namespace PestKontroll.Services.Interfaces
{
    public interface IPKProjectService
    {
        public Task AddNewProjectAsync(Project project);
        public Task<bool> AddProjectManagerAsync(string userId, int  projectId);
        public Task<bool> AddUserToProjectAsync(string userId, int projectId);
        public Task ArchiveProjectAsync(Project project);
        public Task<List<Project>> GetAllProjectsByCompany(int companyId);
        public Task<List<Project>> GetAllProjectsByPriority(int companyId, string priorityName);
        public Task<List<PKUser>> GetAllProjectMembersExeptPMAsync(int projectId);
        public Task<List<Project>> GetArchivedProjectsByCompany(int companyId);
        public Task<List<PKUser>> GetDevelopersOnProjectAsync(int projectId);
        public Task<PKUser> GetProjectManagerAsync(int projectId);
        public Task<List<PKUser>> GetProjectsMembersByRoleAsync(int projectId, string role);
        public Task<Project> GetProjectByIdAsync(int projectId, int companyId);
        public Task<List<PKUser>> GetSubmittersOnProjectAsync(int projectId);
        public Task<List<PKUser>> GetUsersNotOnProjectAsync(int projectId, int companyId);
        public Task<List<Project>> GetUserProjectsAsync(string userId);
        public Task<bool> IsAssignedProjectManagerAsync(string userId, int projectId);
        public Task<bool> IsUserOnProjectAsync(string userId, int projectId);
        public Task<int> LookupProjectPriorityId(string priorityName);
        public Task RemoveProjectManagerAsync(int projectId);
        public Task RemoveUsersFromProjectByRoleAsync(string role, int projectId);
        public Task RemoveUserFromProjectAsync(string userId, int projectId);
        public Task RestoreProjectAssync(Project project);
        public Task UpdateProjectAsync(Project project);
    }
}

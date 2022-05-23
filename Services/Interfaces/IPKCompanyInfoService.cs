using PestKontroll.Models;

namespace PestKontroll.Services.Interfaces
{
    public interface IPKCompanyInfoService
    {
        public Task<Company> GetCompanyByIdAsync(int? companyId);
        public Task<List<User>> GetAllMembersAsync(int userId);
        public Task<List<Project>> GetAllProjectsAsync(int companyId);
        public Task<List<Ticket>> GetAllTicketsAsync(int companyId);
    }
}

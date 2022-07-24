using PestKontroll.Models;

namespace PestKontroll.Services.Interfaces
{
    public interface IPKTicketHistoryService
    {
        Task AddHistoryAsync(Ticket oldTisket, Ticket newTicket, string userId);
        Task<List<TicketHistory>> GetProjectTicketsHistoriesAsync(int projectId, int companyId);
        Task<List<TicketHistory>> GetCompanyTicketsHistoriesAsync(int companyId);
    }
}

using Microsoft.EntityFrameworkCore;
using PestKontroll.Data;
using PestKontroll.Models;
using PestKontroll.Services.Interfaces;

namespace PestKontroll.Services
{
    public class PKLookupService : IPKLookupService
    {
        private readonly ApplicationDbContext _context;

        public PKLookupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjectPriority>> GetProjectPrioritiesAsync()
        {
            try
            {
                return await _context.ProjectPriorities.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TicketPriority>> GetTicketPrioritiesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<TicketStatus>> GetTicketStatusesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<TicketType>> GetTicketTypesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

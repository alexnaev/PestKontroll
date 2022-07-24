using PestKontroll.Models;

namespace PestKontroll.Services.Interfaces
{
    public interface IPKNotificationService
    {
        public Task AddNotificationAsync(Notification notification);
        public Task<List<Notification>> GetReceivedNotificationsAsync(string userId);
        public Task<List<Notification>> GetSentNotificationsAsync(string userId);
        public Task SendEmailNotificationsByRoleAsync(Notification notification, int companyId, string role);
        public Task SendMembersEmailNotificationsAsync(Notification notification, List<PKUser> members);
        public Task<bool> SendEmailNotificationAsync(Notification notification, string emailSubject);
    }
}

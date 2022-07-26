using Microsoft.AspNetCore.Mvc.Rendering;

namespace PestKontroll.Models.ViewModels
{
    public class AddProjectWithPMViewModel
    {
        public Project Project { get; set; }
        public SelectList PMList { get; set; }
        public string PmId { get; set; }
        public string SelectedProjectManager { get; set; }
        public SelectList PriorityList { get; set; }
    }
}

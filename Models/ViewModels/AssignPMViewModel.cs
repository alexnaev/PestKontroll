using Microsoft.AspNetCore.Mvc.Rendering;

namespace PestKontroll.Models.ViewModels
{
    public class AssignPMViewModel
    {
        public Project Project { get; set; }
        public SelectList PMList { get; set; }
        public string PmId { get; set; }
    }
}

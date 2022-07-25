using Microsoft.AspNetCore.Mvc.Rendering;

namespace PestKontroll.Models.ViewModels
{
    public class ManageUserRolesViewModel
    {
        public PKUser PKUser { get; set; }
        public MultiSelectList Roles { get; set; }
        public List<string> SelectedRoles { get; set; }
    }
}

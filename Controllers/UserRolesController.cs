using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PestKontroll.Extensions;
using PestKontroll.Models;
using PestKontroll.Models.ViewModels;
using PestKontroll.Services.Interfaces;

namespace PestKontroll.Controllers
{
    [Authorize]
    public class UserRolesController : Controller
    {
        private readonly IPKRoleService _roleService;
        private readonly IPKCompanyInfoService _companyInfoService;

        public UserRolesController(IPKRoleService roleService, IPKCompanyInfoService companyInfoService)
        {
            _roleService = roleService;
            _companyInfoService = companyInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles()
        {
            //Add an intance of the view model as a list
            List<ManageUserRolesViewModel> model = new();

            //Get company ID
            int companyId = User.Identity.GetCompanyId().Value;

            //Loop over the users to populate the view model
            // - Instatiate view model
            // - use _roleService
            // - create multi-selects
            List<PKUser> users = await _companyInfoService.GetAllMembersAsync(companyId);

            foreach (PKUser user in users)
            {
                ManageUserRolesViewModel viewModel = new();
                viewModel.PKUser = user;
                IEnumerable<string> selected = await _roleService.GetUserRolesAsync(user);
                viewModel.Roles = new MultiSelectList(await _roleService.GetRolesAsync(), "Name", "Name", selected);

                model.Add(viewModel);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageUserRoles(ManageUserRolesViewModel member)
        {
            //Get company ID
            int companyId = User.Identity.GetCompanyId().Value;

            //Instantiate user
            PKUser pkUser = (await _companyInfoService.GetAllMembersAsync(companyId)).FirstOrDefault(u => u.Id == member.PKUser.Id);

            //Get roles for user
            IEnumerable<string> roles = await _roleService.GetUserRolesAsync(pkUser);

            //Grab selected role
            string userRole = member.SelectedRoles.FirstOrDefault();

            if (!string.IsNullOrEmpty(userRole))
            {
                //Remove user from roles
                if (await _roleService.RemoveUserFromRolesAsync(pkUser, roles))
                {
                    //Add user to new role
                    await _roleService.AddUserToRoleAsync(pkUser, userRole);
                }
            }

            return RedirectToAction(nameof(ManageUserRoles));
        }
    }
}

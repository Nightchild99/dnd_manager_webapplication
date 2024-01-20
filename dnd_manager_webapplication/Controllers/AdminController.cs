using dnd_manager_webapplication.Data;
using dnd_manager_webapplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dnd_manager_webapplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPartyRepository _repo;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<SiteUser> _userManager;
        private readonly ILogger<PartyController> _logger;

        public AdminController(IPartyRepository repo, RoleManager<IdentityRole> roleManager, UserManager<SiteUser> userManager, ILogger<PartyController> logger)
        {
            _repo = repo;
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> DelegateAdmin()
        {
            var principal = this.User;
            var user = await _userManager.GetUserAsync(principal);
            var role = new IdentityRole()
            {
                Name = "Admin"
            };
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(role);
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction("Index", "Party");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View(this._repo.Read());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminDelete(string name)
        {
            _repo.Delete(name);
            return RedirectToAction("Index", "Party");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Users()
        {
            return View(_userManager.Users);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GrantAdmin(string uid)
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Id == uid);
            await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction(nameof(Users));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveAdmin(string uid)
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Id == uid);
            await _userManager.RemoveFromRoleAsync(user, "Admin");
            return RedirectToAction(nameof(Users));
        }
    }
}

using dnd_manager_webapplication.Data;
using dnd_manager_webapplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace dnd_manager_webapplication.Controllers
{
    public class PartyController : Controller
    {
        private readonly IPartyRepository _repo;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<SiteUser> _userManager;
        private readonly ILogger<PartyController> _logger;

        public PartyController(IPartyRepository repo, RoleManager<IdentityRole> roleManager, UserManager<SiteUser> userManager, ILogger<PartyController> logger)
        {
            _repo = repo;
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(this._repo.Read());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Character character, IFormFile picturedata)
        {
            character.OwnerId = _userManager.GetUserId(this.User);
            character.Owner = await _userManager.GetUserAsync(this.User);
            character.Description = $"{character.Name} is a level {character.Level} {character.Race} {character.Class}.";

            using (var stream = picturedata.OpenReadStream())
            {
                byte[] buffer = new byte[picturedata.Length];
                stream.Read(buffer, 0, (int)picturedata.Length);
                string filename = character.Id + "." + picturedata.FileName.Split('.')[1];
                character.ImageFileName = filename;
                System.IO.File.WriteAllBytes(Path.Combine("wwwroot", "images", filename), buffer);
                character.Data = buffer;
                character.ContentType = picturedata.ContentType;
            }

            _repo.Create(character);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(string name)
        {
            var character = _repo.Read(name);
            return View(character);
        }

        [HttpPost]
        public IActionResult Update(Character character)
        {
            _repo.Update(character);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(string name)
        {
            _repo.Delete(name);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetImage(string id)
        {
            var character = _repo.ReadFromId(id);
            if (character.ContentType.Length > 3)
            {
                return new FileContentResult(character.Data, character.ContentType);
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> GetUserImage(string userid)
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Id == userid);
            return new FileContentResult(user.Data, user.ContentType);
        }

        [HttpGet]
        public IActionResult LevelUp(string name)
        {
            if (_repo.Read(name).Level == 20)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _repo.LevelUp(name);
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize]
        public async Task<IActionResult> Privacy()
        {
            var principal = this.User;
            var user = await _userManager.GetUserAsync(principal);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using dnd_manager_webapplication.Data;
using dnd_manager_webapplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dnd_manager_webapplication.Controllers
{
    public class PartyController : Controller
    {
        private readonly IPartyRepository _repo;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<PartyController> _logger;

        public PartyController(IPartyRepository repo, UserManager<IdentityUser> userManager, ILogger<PartyController> logger)
        {
            this._repo = repo;
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
        public IActionResult Create(Character character, IFormFile picturedata)
        {
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

            character.OwnerId = _userManager.GetUserId(this.User);
            character.Description = $"{character.Name} is a level {character.Level} {character.Race} {character.Class}.";

            //var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (!ModelState.IsValid)
            {
                return View(character);
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
            if (!ModelState.IsValid)
            {
                return View(character);
            }
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
    }
}

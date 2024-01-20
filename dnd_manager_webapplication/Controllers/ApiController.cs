using dnd_manager_webapplication.Data;
using dnd_manager_webapplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace dnd_manager_webapplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        IPartyRepository repo;

        public ApiController(IPartyRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IEnumerable<Character> Get()
        {
            return this.repo.Read();
        }
    }
}

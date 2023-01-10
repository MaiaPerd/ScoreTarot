using Microsoft.AspNetCore.Mvc;
using DTOs;

namespace APIRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JoueurController : ControllerBase
    {

        private readonly ILogger<JoueurController> _logger;

        public JoueurController(ILogger<JoueurController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetJoueur")]
        public IEnumerable<JoueurDto> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new JoueurDto
            {
                Id = index,
                Nom = "test"
            })
            .ToArray();
        }
    }
}
using APIRest.DTOs;
using AutoMapper;
using EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing;
using Model;
using System.Net;


namespace APIRest.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class MancheController : ControllerBase
    {

        private readonly ILogger<MancheController> _logger;
        private readonly IMapper mapper;
        private readonly DataManagerAPI dataManager;

        public MancheController(ILogger<MancheController> logger, IMapper m, DataManagerAPI dm)
        {
            mapper = m;
            _logger = logger;
            this.dataManager = dm;
        }
        [HttpGet("{id}")]
        public IActionResult GetMancheById(int id)
        {
            var mdto = this.dataManager.GetManche(id);
            if (mdto == null)
            {
                _logger.LogInformation("Request GetMancheById: la manche n a pas été trouvé");
                return NotFound();
            }
            return Ok(mdto);//mapper.Map<MancheDto>(mdto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteManche(int i)
        {
            var laManche = dataManager.GetManche(i);
            if (laManche == null)
            {
                _logger.LogInformation("Request DeleteManche: la manche n'a pas été trouvé");
                return BadRequest("la manche n'existe pas");
            }
            await dataManager.RemoveManche(await laManche);
            return StatusCode((int)HttpStatusCode.OK);
        }


        [HttpPost("{id}")]
        public async Task<ActionResult> UpdateManche([FromBody] MancheDto mdto, int i)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("UpdateManche -> Request is invalid, ModelState est invalid");
            }
            var leJoueur = dataManager.GetJoueurById(i);
            if (leJoueur == null)
            {
                _logger.LogInformation("UpdateManche -> Request DeleteManche: la manche n'a pas été trouvé");
                return NotFound();
            }
            await dataManager.UpdateManche(mapper.Map<Manche>(mdto));
            return StatusCode((int)HttpStatusCode.OK);
        }
        [HttpPut]
        public async Task<ActionResult> CreateManche([FromBody] MancheDto mdto)
        {
            await dataManager.AddManche(mapper.Map<Manche>(mdto));
            return StatusCode((int)HttpStatusCode.OK);
        }

    }
}
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
    [Route("[controller]")]
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
        public async Task<ActionResult> GetMancheById(int id)
        {
            var mdto = await this.dataManager.GetManche(id);
            if (mdto == null)
            {
                _logger.LogInformation("Request GetMancheById: la manche n a pas �t� trouv�");
                return NotFound();
            }
            return Ok(mapper.Map<MancheDto>(mdto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteManche(int i)
        {
            var laManche = await dataManager.GetManche(i);
            if (laManche == null)
            {
                _logger.LogInformation("Request DeleteManche: la manche n'a pas �t� trouv�");
                return BadRequest("la manche n'existe pas");
            }
            return Ok(mapper.Map<MancheDto>(await dataManager.RemoveManche(i)));
        }


        [HttpPost("{id}")]
        public async Task<ActionResult> UpdateManche([FromBody] MancheDto mdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("UpdateManche -> Request is invalid, ModelState est invalid");
            }
            var laManche = await dataManager.GetManche(mdto.Id);
            if (laManche == null)
            {
                _logger.LogInformation("UpdateManche -> Request DeleteManche: la manche n'a pas �t� trouv�");
                return NotFound();
            }
            return Ok(mapper.Map<MancheDto>(await dataManager.UpdateManche(laManche, mdto.Id)));
        }
        [HttpPut]
        public async Task<ActionResult> CreateManche([FromBody] MancheDto mdto)
        {
            await dataManager.AddManche(mapper.Map<Manche>(mdto));
            return StatusCode((int)HttpStatusCode.OK);
        }

    }
}
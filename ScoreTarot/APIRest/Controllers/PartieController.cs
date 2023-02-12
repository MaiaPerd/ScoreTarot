using APIRest.DTOs;
using AutoMapper;
using EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Net;


namespace APIRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartieController : ControllerBase
    {

        private readonly ILogger<PartieController> _logger;
        private readonly IMapper mapper;
        private readonly DataManagerAPI dataManager;

        public PartieController(ILogger<PartieController> logger, IMapper m, DataManagerAPI dm)
        {
            mapper = m;
            _logger = logger;
            this.dataManager = dm;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPartieById(int id)
        {
            var pdto = await this.dataManager.GetPartieById(id);
            if (pdto == null)
            {
                _logger.LogInformation("Request GetPartieById: la partie n'apas �t� trouv�");
                return NotFound();
            }
            return Ok(mapper.Map<PartieDto>(pdto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePartie(int i)
        {
            var laPartie = await dataManager.GetPartieById(i);
            if (laPartie == null)
            {
                _logger.LogInformation("Request invalidDelete: la partie n'a pas �t� trouv�");
                return BadRequest("la partie n'existe pas");
            }
     
            return Ok(mapper.Map<PartieDto>(await dataManager.RemovePartie(laPartie)));
        }


        [HttpPost("{id}")]
        public async Task<ActionResult> UpdatePartie([FromBody] PartieDto pdto, int i)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Request invalid pour updatepartie:ModelState est invalid");
                return BadRequest("Request is invalid!");
            }
            var laPartie = await dataManager.GetPartieById(i);
            if (laPartie == null)
            {
                _logger.LogInformation("UpdatePartie: la partie n'a pas �t� trouv�");
                return NotFound();
            }

            return Ok(mapper.Map<PartieDto>(await dataManager.UpdatePartie(mapper.Map<Partie>(pdto))));
        }

        [HttpPut]
        public async Task<ActionResult> CreatePartie([FromBody] PartieDto pdto)
        {
            await dataManager.AddPartie(mapper.Map<Partie>(pdto));
            return StatusCode((int)HttpStatusCode.OK);
        }

        [HttpGet]
        public async Task<ActionResult> GetLesParties()
        {
            var data = await dataManager.GetParties();
            var list = mapper.Map<List<PartieDto>>(data.ToList());
            return Ok(list);
        }

        [HttpGet("byPage")]
        public async Task<IActionResult> GetPartieByPage([FromQuery] int pageNumber, int pageSize)
        {
            var data = await dataManager.GetParties();
            var list = mapper.Map<List<PartieDto>>(data.ToList());
            list.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            return Ok(data);
        }
    }
}
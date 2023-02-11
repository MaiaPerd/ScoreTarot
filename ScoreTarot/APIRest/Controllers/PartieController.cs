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
        public IActionResult GetPartieById(int id)
        {
            var pdto = this.dataManager.GetPartieById(id);
            if (pdto == null)
            {
                _logger.LogInformation("Request GetPartieById: la partie n'apas été trouvé");
                return NotFound();
            }
            return Ok(pdto);//mapper.Map<PartieDto>(pdto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePartie(int i)
        {
            var laPartie = dataManager.GetPartieById(i);
            if (laPartie == null)
            {
                _logger.LogInformation("Request invalidDelete: la partie n'a pas été trouvé");
                return BadRequest("la partie n'existe pas");
            }
            await dataManager.RemovePartie(await laPartie);
            return StatusCode((int)HttpStatusCode.OK);
        }


        [HttpPost("{id}")]
        public async Task<ActionResult> UpdatePartie([FromBody] PartieDto pdto, int i)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Request invalid pour updatepartie:ModelState est invalid");
                return BadRequest("Request is invalid!");
            }
            var laPartie = dataManager.GetPartieById(i);
            if (laPartie == null)
            {
                _logger.LogInformation("UpdatePartie: la partie n'a pas été trouvé");
                return NotFound();
            }
            await dataManager.UpdatePartie(mapper.Map<Partie>(pdto));
            return StatusCode((int)HttpStatusCode.OK);
        }
        [HttpPut]
        public async Task<ActionResult> CreatePartie([FromBody] PartieDto pdto)
        {
            await dataManager.AddPartie(mapper.Map<Partie>(pdto));
            return StatusCode((int)HttpStatusCode.OK);
        }

        [HttpGet]
        public IActionResult GetLesParties()
        {
            var data = dataManager.GetParties();
            var list = new List<PartieDto>();
            //list = mapper.Map<List<PartieDto>>(data);
            return Ok(data);
        }

        [HttpGet("byPage")]
        public async Task<IActionResult> GetPartieByPage([FromQuery] int pageNumber, int pageSize)
        {
            var data = await dataManager.GetParties();
            var parties = new List<PartieDto>();
            /*foreach (Partie p in data)
            {
                parties.Add(mapper.Map<PartieDto>(p));
            }*/
            parties.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            return Ok(data);
        }
    }
}
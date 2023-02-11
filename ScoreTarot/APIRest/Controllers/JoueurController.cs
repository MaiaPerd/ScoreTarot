using Microsoft.AspNetCore.Mvc;
using APIRest.MapperClass;
using EntityFramework;
using AutoMapper;
using EntityFramework.Entity;
using Model;
using System.Net;
using APIRest.DTOs;

namespace APIRest.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class JoueurController : ControllerBase
        {

            private readonly ILogger<JoueurController> _logger;
            private readonly IMapper mapper;
            private readonly DataManagerAPI dataManager;

            public JoueurController(ILogger<JoueurController> logger, IMapper m, DataManagerAPI dataManager)
            {
                mapper = m;
                _logger = logger;
                this.dataManager = dataManager;

            }
            [HttpGet("{id}")]
            public IActionResult GetJoueurById(int id)
            {
                var jdto = this.dataManager.GetJoueurById(id);
                if (jdto == null)
                {
                    _logger.LogInformation("GetJoueurById: le joueur n'a pas été trouvé");
                    return NotFound();
                }
                //var enmap = mapper.Map<JoueurDto>(jdto);
                
                return Ok(jdto);
            }
            [HttpGet]
            public IActionResult GetLesJoueurs()
            {
                var data = dataManager.GetJoueurs();
                var list = new List<JoueurDto>();
                //list = mapper.Map<List<JoueurDto>>(data);
                return Ok(list);
            }
            [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteJoueur(int i)
            {
                var leJoueur = dataManager.GetJoueurById(i);
                if (leJoueur == null)
                {
                    _logger.LogInformation("DeleteJoueur: Request invalidDelete Joueur: le joueur n'existe pas!");
                    return BadRequest("le joueur n'existe pas");
                }
                await dataManager.RemoveJoueur(await leJoueur);
                return StatusCode((int)HttpStatusCode.OK);
            }
            [HttpPost("{id}")]
            public async Task<ActionResult> UpdateJoueur([FromBody] JoueurDto jdto, int i)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("UpdateJoueur: Request is invalid! -> ModelState invalid");
                }
                var leJoueur = dataManager.GetJoueurById(i);
                if (leJoueur == null)
                {
                    _logger.LogInformation("UpdateJoueur: Request invalid, le joueur donné est null");
                    return NotFound();
                }
                await dataManager.UpdateJoueur(mapper.Map<Joueur>(jdto));
                return StatusCode((int)HttpStatusCode.OK);
            }
            [HttpPut]
            public async Task<ActionResult> CreateJoueur([FromBody] JoueurDto jdto)
            {
                await dataManager.AddJoueur(mapper.Map<Joueur>(jdto));
                return StatusCode((int)HttpStatusCode.OK);
            }
            [HttpGet("byPage")]
            public async Task<IActionResult> GetJoueurByPage([FromQuery] int pageNumber, int pageSize)
            {
                var data = await dataManager.GetJoueurs();
                var joueurs = new List<JoueurDto>();
                foreach (Joueur p in data)
                {
                    joueurs.Add(mapper.Map<JoueurDto>(p));
                }
                joueurs.Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);
                return Ok(data);
            }

        [HttpGet("byPseudo{pseudo}")]
        public IActionResult GetLesJoueursByPseudo([FromBody] String pseudo)
        {
            var data = dataManager.GetJoueursByPseudo(pseudo);
            var list = new List<JoueurDto>();
            
            return Ok(list);
        }
    }
}

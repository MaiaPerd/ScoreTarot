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
            public async Task<ActionResult> GetJoueurById(int id)
            {
                var jdto = await this.dataManager.GetJoueurById(id);
                if (jdto == null)
                {
                    _logger.LogInformation("GetJoueurById: le joueur n'a pas �t� trouv�");
                    return NotFound();
                }
                var enmap = mapper.Map<JoueurDto>(jdto);
                
                return Ok(enmap);
            }

            [HttpGet]
            public async Task<ActionResult> GetLesJoueurs()
            {
                var data = await dataManager.GetJoueurs();
                var list = mapper.Map<IEnumerable<JoueurDto>>(data);
                return Ok(list);
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteJoueur(int i)
            {
                Joueur leJoueur = await dataManager.GetJoueurById(i);
                if (leJoueur == null)
                {
                    _logger.LogInformation("DeleteJoueur: Request invalidDelete Joueur: le joueur d'id : "+i+" n'existe pas!");
                    return BadRequest("le joueur n'existe pas");
                }

                Joueur joueur = await dataManager.RemoveJoueur(leJoueur);
                return Ok(mapper.Map<JoueurDto>(joueur));
            }

            [HttpPost("{id}")]
            public async Task<ActionResult> UpdateJoueur([FromBody] JoueurDto jdto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("UpdateJoueur: Request is invalid! -> ModelState invalid");
                }
                Joueur leJoueur = await dataManager.GetJoueurById(jdto.Id);
                if (leJoueur == null)
                {
                    _logger.LogInformation("UpdateJoueur: Request invalid, le joueur donn� est null");
                    return NotFound();
                }
                
                 return Ok(mapper.Map<JoueurDto>(await dataManager.UpdateJoueur(mapper.Map<Joueur>(jdto))));
            }

            [HttpPut]
            public async Task<ActionResult> CreateJoueur([FromBody] JoueurDto jdto)
            {
                return Ok(mapper.Map<JoueurDto>(await dataManager.AddJoueur(mapper.Map<Joueur>(jdto))));
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
                return Ok(joueurs);
            }

            [HttpGet("byPseudo{pseudo}")]
            public async Task<ActionResult> GetLesJoueursByPseudo([FromBody] String pseudo)
            {
                var data = await dataManager.GetJoueursByPseudo(pseudo);
                var list = mapper.Map<IEnumerable<JoueurDto>>(data);
                return Ok(list);
            }
        }
}

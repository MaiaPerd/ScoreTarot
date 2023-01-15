using Microsoft.AspNetCore.Mvc;
using DTOs;
using APIRest.MapperClass;
using EntityFramework;
using AutoMapper;
using EntityFramework.Entity;
using Model;
using System.Net;

namespace APIRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JoueurController : ControllerBase
    {

        private readonly ILogger<JoueurController> _logger;
        private readonly IMapper mapper;
        private readonly DataManager dataManager;

        public JoueurController(ILogger<JoueurController> logger, IMapper m, DataManager dm)
        {
            mapper = m;
            _logger = logger;
            dataManager = dm;
        }
        [HttpGet("{id}")]
        public JoueurDto GetJoueurById(int id)
        {
            var jdto = this.dataManager.GetJoueurById(id);
            return mapper.Map<JoueurDto>(jdto);
        }
        [HttpGet]
        public List<JoueurDto> GetLesJoueurs()
        {
            var data = dataManager.GetJoueurs();
            var list= new List<JoueurDto>();
            list = mapper.Map<List<JoueurDto>>(data);
            return list;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJoueur(int i)
        {
            var leJoueur = dataManager.GetJoueurById(i);
            await dataManager.RemoveJoueur(await leJoueur);
            return StatusCode((int)HttpStatusCode.OK);
        }
        [HttpPost("{id}")]
        public async Task<ActionResult> UpdateJoueur([FromBody] JoueurDto jdto , int i)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Request is invalid!");
            }
            var leJoueur = dataManager.GetJoueurById(i);
            if(leJoueur == null)
            {
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
    }
}
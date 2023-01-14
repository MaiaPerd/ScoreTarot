using Microsoft.AspNetCore.Mvc;
using DTOs;
using APIRest.MapperClass;
using EntityFramework;
using AutoMapper;

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

        /*[HttpGet(Name = "GetJoueur")]
        public IEnumerable<JoueurDto> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new JoueurDto
            {
                Id = index,
                Pseudo = "test"
            })
            .ToArray();
        }*/
        [HttpGet("{id}")]
        public JoueurDto GetJoueurById(int id)
        {
            var jdto = this.dataManager.GetJoueurById(id);
            return mapper.Map<JoueurDto>(jdto);
        }

    }
}
using AutoMapper;
using DTOs;
using EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Net;

[ApiController]
[Route("[controller]")]
public class PartieController : ControllerBase
{

    private readonly ILogger<PartieController> _logger;
    private readonly IMapper mapper;
    private readonly DataManager dataManager;

    public PartieController(ILogger<PartieController> logger, IMapper m, DataManager dm)
    {
        mapper = m;
        _logger = logger;
        dataManager = dm;
    }
    [HttpGet("{id}")]
    public PartieDto GetPartieById(int id)
    {
        var pdto = this.dataManager.GetPartieById(id);
        return mapper.Map<PartieDto>(pdto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePartie(int i)
    {
        var laPartie = dataManager.GetPartieById(i);
        await dataManager.RemovePartie(await laPartie);
        return StatusCode((int)HttpStatusCode.OK);
    }


    [HttpPost("{id}")]
    public async Task<ActionResult> UpdatePartie([FromBody] PartieDto pdto, int i)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogInformation("Request invalid pour updatepartie");
            return BadRequest("Request is invalid!");
        }
        var leJoueur = dataManager.GetPartieById(i);
        if (leJoueur == null)
        {
            _logger.LogInformation("");
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
    public List<PartieDto> GetLesParties()
    {
        var data = dataManager.GetParties();
        var list = new List<PartieDto>();
        list = mapper.Map<List<PartieDto>>(data);
        return list;
    }
    //filtrage a pagination, query string?
    //test unitaire, action result log et gestion erreur
}
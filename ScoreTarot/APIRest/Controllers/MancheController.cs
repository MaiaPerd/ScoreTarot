using AutoMapper;
using DTOs;
using EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing;
using Model;
using System.Net;

[ApiController]
[Route("[controller]")]
public class MancheController : ControllerBase
{

    private readonly ILogger<MancheController> _logger;
    private readonly IMapper mapper;
    private readonly DataManager dataManager;

    public MancheController(ILogger<MancheController> logger, IMapper m, DataManager dm)
    {
        mapper = m;
        _logger = logger;
        dataManager = dm;
    }
    [HttpGet("{id}")]
    public IActionResult GetMancheById(int id)
    {
        var mdto = this.dataManager.GetManche(id);
        if (mdto == null)
        {
            _logger.LogInformation("Request invalidDelete Manche: la manche n'existe pas!");
            return NotFound();
        }
        return Ok(mapper.Map<MancheDto>(mdto));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteManche(int i)
    {
        var laManche = dataManager.GetManche(i);
        if (laManche == null)
        {
            _logger.LogInformation("Request invalidDelete Manche: la manche n'existe pas!");
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
            return BadRequest("Request is invalid!");
        }
        var leJoueur = dataManager.GetJoueurById(i);
        if (leJoueur == null)
        {
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
    [HttpGet]
    public async Task<IActionResult> GetMancheByPage([FromQuery] int pageNumber, int pageSize)
    {
        var data = await dataManager.GetManche();
        var manches = new List<MancheDto>();
        foreach (Manche p in data)
        {
            manches.Add(mapper.Map<MancheDto>(p));
        }
        manches.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
        return Ok(data);
    }

}

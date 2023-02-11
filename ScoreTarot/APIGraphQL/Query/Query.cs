using AutoMapper;
using DTOs;
using EntityFramework;

namespace APIGraphQL.Query
{
    public class Query
    {
        private readonly IMapper mapper;
        private readonly ILogger<Mutation> _logger;

        public Query(ILogger<Mutation> logger, IMapper mapper)
        {
            this.mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<JoueurDto>> GetJoueurs([Service] DataManagerAPI dataManager)
        {
            _logger.LogInformation("Vous récupérer l'ensemble des joueurs de la base de donnée");
            return mapper.Map<IEnumerable<JoueurDto>>(await dataManager.GetJoueurs());
        }

        public async Task<JoueurDto> GetJoueurById(int id, [Service] DataManagerAPI dataManager)
        {
            _logger.LogInformation("Vous récupérer le joueur qui a "+id+" pour id");
            return mapper.Map<JoueurDto>(await dataManager.GetJoueurById(id));
        }

        public async Task<IEnumerable<MancheDto>> GetManches([Service] DataManagerAPI dataManager)
        {
            _logger.LogInformation("Vous récupérer l'ensemble des manches de la base de donnée");
            return mapper.Map<IEnumerable<MancheDto>>(await dataManager.GetManches());
        }

        public async Task<MancheDto> GetMancheById(int id, [Service] DataManagerAPI dataManager)
        {
            _logger.LogInformation("Vous récupérer la manche qui a " + id + " pour id");
            return mapper.Map<MancheDto>(await dataManager.GetManche(id));
        }


        public async Task<PartieDto> GetPartieById(int id, [Service] DataManagerAPI dataManager)
        {
            _logger.LogInformation("Vous récupérer la partie qui a " + id + " pour id");
            return mapper.Map<PartieDto>(await dataManager.GetPartieById(id));
        }

        public async Task<IEnumerable<JoueurDto>> GetJoueurByPartie(int idPartie, [Service] DataManagerAPI dataManager)
        {
            _logger.LogInformation("Vous récupérer les joueurs de la partie qui a " + idPartie + " pour id");
            return mapper.Map<PartieDto>(await dataManager.GetPartieById(idPartie)).Joueurs;
        }

        public async Task<IEnumerable<PartieDto>> GetParties([Service] DataManagerAPI dataManager)
        {
            _logger.LogInformation("Vous récupérer l'ensemble des parties de la base de donnée");
            return mapper.Map<IEnumerable<PartieDto>>(await dataManager.GetParties());
        }

    }
}

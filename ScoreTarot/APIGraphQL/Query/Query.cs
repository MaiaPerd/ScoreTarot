using AutoMapper;
using DTOs;
using EntityFramework;

namespace APIGraphQL.Query
{
    public class Query
    {
        private readonly IMapper mapper;
        private readonly ILogger<Query> _logger;

        public Query(ILogger<Query> logger, IMapper mapper)
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
            try
            {
                return mapper.Map<JoueurDto>(await dataManager.GetJoueurById(id) ?? throw new ArgumentNullException("Il n'y a pas de joueur d'id: "+id));
            }
            catch (Exception e)
            {
                _logger.LogError("Il y a eu une erreur le joueur est inexistant : id " + id, e);
                throw;
            }
        }

        public async Task<IEnumerable<MancheDto>> GetManches([Service] DataManagerAPI dataManager)
        {
            _logger.LogInformation("Vous récupérer l'ensemble des manches de la base de donnée");
            return mapper.Map<IEnumerable<MancheDto>>(await dataManager.GetManches());
        }

        public async Task<MancheDto> GetMancheById(int id, [Service] DataManagerAPI dataManager)
        {
            _logger.LogInformation("Vous récupérer la manche qui a " + id + " pour id");
            try
            {
                return mapper.Map<MancheDto>(await dataManager.GetManche(id) ?? throw new ArgumentNullException("Il n'y a pas de manche d'id: " + id));
            }
            catch (Exception e)
            {
                _logger.LogError("Il y a eu une erreur la manche est inexistante : id " + id, e);
                throw;
            }
        }


        public async Task<PartieDto> GetPartieById(int id, [Service] DataManagerAPI dataManager)
        {
            _logger.LogInformation("Vous récupérer la partie qui a " + id + " pour id");
            try
            {
                return mapper.Map<PartieDto>(await dataManager.GetPartieById(id) ?? throw new ArgumentNullException("Il n'y a pas de partie d'id: " + id));
            }
            catch (Exception e)
            {
                _logger.LogError("Il y a eu une erreur la partie est inexistante : id " + id, e);
                throw;
            }
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

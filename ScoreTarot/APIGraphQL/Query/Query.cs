using AutoMapper;
using DTOs;
using EntityFramework;

namespace APIGraphQL.Query
{
    public class Query
    {
        private readonly DataManager dataManager;
        private readonly IMapper mapper;

        public Query(IMapper mapper)
        {
            this.mapper = mapper;
            this.dataManager = new DataManager();
        }

        public async Task<IEnumerable<JoueurDto>> GetJoueurs()
        {
            return mapper.Map<IEnumerable<JoueurDto>>(await dataManager.GetJoueurs());
        }

        public async Task<JoueurDto> GetJoueurById(int id)
        {
            return mapper.Map<JoueurDto>(await dataManager.GetJoueurById(id));
        }

        public async Task<MancheDto> GetMancheById(int id)
        {
            return mapper.Map<MancheDto>(await dataManager.GetManche(id));
        }


        public async Task<PartieDto> GetPartieById(int id)
        {
            return mapper.Map<PartieDto>(await dataManager.GetPartieById(id));
        }

        public async Task<List<JoueurDto>> GetJoueurByPartie(int idPartie)
        {
            return mapper.Map<PartieDto>(await dataManager.GetPartieById(idPartie)).Joueurs;
        }

    }
}

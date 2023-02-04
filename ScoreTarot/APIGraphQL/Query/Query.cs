using AutoMapper;
using DTOs;
using EntityFramework;

namespace APIGraphQL.Query
{
    public class Query
    {
        private readonly IMapper mapper;

        public Query(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<IEnumerable<JoueurDto>> GetJoueurs([Service] DataManagerAPI dataManager)
        {
            return mapper.Map<IEnumerable<JoueurDto>>(await dataManager.GetJoueurs());
        }

        public async Task<JoueurDto> GetJoueurById(int id, [Service] DataManagerAPI dataManager)
        {
            return mapper.Map<JoueurDto>(await dataManager.GetJoueurById(id));
        }

        public async Task<MancheDto> GetMancheById(int id, [Service] DataManagerAPI dataManager)
        {
            return mapper.Map<MancheDto>(await dataManager.GetManche(id));
        }


        public async Task<PartieDto> GetPartieById(int id, [Service] DataManagerAPI dataManager)
        {
            return mapper.Map<PartieDto>(await dataManager.GetPartieById(id));
        }

        public async Task<List<JoueurDto>> GetJoueurByPartie(int idPartie, [Service] DataManagerAPI dataManager)
        {
            return mapper.Map<PartieDto>(await dataManager.GetPartieById(idPartie)).Joueurs;
        }

    }
}

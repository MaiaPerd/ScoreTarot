using AutoMapper;
using DTOs;
using EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Net;

namespace APIGraphQL.Query
{
    public class Mutation
    {
        private readonly IMapper mapper;

        public Mutation(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<JoueurDto> AddJoueur(JoueurDto joueur, [Service] DataManagerAPI dataManager)
        {
            mapper.Map<Joueur>(joueur);
            return mapper.Map<JoueurDto>(await dataManager.AddJoueur(mapper.Map<Joueur>(joueur)) ?? throw new ArgumentNullException());
        }

        public async Task<JoueurDto> UpdateJoueur(JoueurDto joueur, [Service] DataManagerAPI dataManager)
        {
            return mapper.Map<JoueurDto>(await dataManager.UpdateJoueur(mapper.Map<Joueur>(joueur)) ?? throw new ArgumentNullException());
        }

        public async Task<JoueurDto> DeleteJoueur(JoueurDto joueur, [Service] DataManagerAPI dataManager)
        {
            return mapper.Map<JoueurDto>(await dataManager.RemoveJoueur(mapper.Map<Joueur>(joueur)) ?? throw new ArgumentNullException());
        }

        public async Task<MancheDto> AddManche(MancheDto manche, [Service] DataManagerAPI dataManager)
        {
            return mapper.Map<MancheDto>(await dataManager.AddManche(mapper.Map<Manche>(manche)) ?? throw new ArgumentNullException());
        }

        public async Task<MancheDto> UpdateManche(MancheDto manche, [Service] DataManagerAPI dataManager)
        {
            return mapper.Map<MancheDto>(await dataManager.UpdateManche(mapper.Map<Manche>(manche)) ?? throw new ArgumentNullException());
        }

        public async Task<MancheDto> DeleteManche(MancheDto manche, [Service] DataManagerAPI dataManager)
        {
            return mapper.Map<MancheDto>(await dataManager.RemoveManche(mapper.Map<Manche>(manche)) ?? throw new ArgumentNullException());
        }

    }

}

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
        private readonly DataManager dataManager;
        private readonly IMapper mapper;

        public Mutation(IMapper mapper, SQLiteContext dbContext)
        {

            this.mapper = mapper;
            this.dataManager = new DataManager(); // Regarder pour l'injection
        }

        //Voir pour avoir 2 mutation

        public async Task<JoueurDto> AddJoueur(JoueurDto joueur)
        {
            mapper.Map<Joueur>(joueur);
            return mapper.Map<JoueurDto>(await dataManager.AddJoueurDB(mapper.Map<Joueur>(joueur)) ?? throw new ArgumentNullException());
        }

        public async Task<JoueurDto> UpdateJoueur(JoueurDto joueur)
        {
            //https://chillicream.com/docs/hotchocolate/v12/defining-a-schema/mutations
            return mapper.Map<JoueurDto>(await dataManager.UpdateJoueurDB(mapper.Map<Joueur>(joueur)) ?? throw new ArgumentNullException());
        }

        public async Task<JoueurDto> DeleteJoueur(JoueurDto joueur)
        {
            return mapper.Map<JoueurDto>(await dataManager.RemoveJoueurDB(mapper.Map<Joueur>(joueur)) ?? throw new ArgumentNullException());
        }

        public async Task<MancheDto> AddManche(MancheDto manche)
        {
            return mapper.Map<MancheDto>(await dataManager.AddMancheDB(mapper.Map<Manche>(manche)) ?? throw new ArgumentNullException());
        }

        public async Task<MancheDto> UpdateManche(MancheDto manche)
        {
            //https://chillicream.com/docs/hotchocolate/v12/defining-a-schema/mutations
            return mapper.Map<MancheDto>(await dataManager.UpdateMancheDB(mapper.Map<Manche>(manche)) ?? throw new ArgumentNullException());
        }

        public async Task<MancheDto> DeleteManche(MancheDto manche)
        {
            return mapper.Map<MancheDto>(await dataManager.RemoveMancheDB(mapper.Map<Manche>(manche)) ?? throw new ArgumentNullException());
        }
    }

}

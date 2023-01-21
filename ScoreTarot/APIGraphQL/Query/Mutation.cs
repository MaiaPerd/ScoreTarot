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

        public Mutation(DataManager dataManager, IMapper mapper)
        {
            this.dataManager = dataManager;
            this.mapper = mapper;
        }

        public async Task<bool> AddJoueur(JoueurDto joueur)
        {
            // return joueur
            return await dataManager.AddJoueur(mapper.Map<Joueur>(joueur));
        }

        public async Task<bool> UpdateJoueur(JoueurDto joueur)
        {
            // update l'id et la modification
            //https://chillicream.com/docs/hotchocolate/v12/defining-a-schema/mutations
            return await dataManager.UpdateJoueur(mapper.Map<Joueur>(joueur));
        }

        public async Task<bool> DeleteJoueur(JoueurDto joueur)
        {
            return await dataManager.RemoveJoueur(mapper.Map<Joueur>(joueur));
        }
    }

}

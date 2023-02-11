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
        private readonly ILogger<Mutation> _logger;

        public Mutation(ILogger<Mutation> logger, IMapper mapper)
        {
            this.mapper = mapper;
            this._logger = logger;
        }

        public async Task<JoueurDto> AddJoueur(JoueurDto joueur, [Service] DataManagerAPI dataManager)
        {
            mapper.Map<Joueur>(joueur);
            _logger.LogInformation("Vous essayer d'ajouter un joueur dans la base: id "+joueur.Id+", pseudo "+joueur.Pseudo);
            try
            {
                return mapper.Map<JoueurDto>(await dataManager.AddJoueur(mapper.Map<Joueur>(joueur)) ?? throw new ArgumentNullException("Le joueur n'a pas pu être ajouter dans la base de donnée, soit il existe déjà vérifier l'id et le pseudo ou alors il y a eu un bug"));
            } catch(Exception e)
            {
                _logger.LogError("Il y a eu une erreur a l'ajout du joueur:  id " + joueur.Id + ", pseudo " + joueur.Pseudo, e);
                throw;
            }
        }

        public async Task<JoueurDto> UpdateJoueur(JoueurDto joueur, [Service] DataManagerAPI dataManager)
        {
            _logger.LogInformation("Vous essayer de modifier un joueur dans la base: id " + joueur.Id + ", pseudo " + joueur.Pseudo);
            try
            {
                return mapper.Map<JoueurDto>(await dataManager.UpdateJoueur(mapper.Map<Joueur>(joueur)) ?? throw new ArgumentNullException("Le joueur n'a pas pu être modifier dans la base"));
            }
            catch (Exception e)
            {
                _logger.LogError("Il y a eu une erreur pendant la modification du joueur:  id " + joueur.Id + ", pseudo " + joueur.Pseudo, e);
                throw;
            }
        }

        public async Task<JoueurDto> DeleteJoueur(JoueurDto joueur, [Service] DataManagerAPI dataManager)
        {
            _logger.LogInformation("Vous essayer de supprimer un joueur dans la base: id " + joueur.Id + ", pseudo " + joueur.Pseudo);
            try
            {
                return mapper.Map<JoueurDto>(await dataManager.RemoveJoueur(mapper.Map<Joueur>(joueur)) ?? throw new ArgumentNullException("Le joueur n'a pas pu être supprimer dans la base"));
            }
            catch (Exception e)
            {
                _logger.LogError("Il y a eu une erreur pendant la suppression du joueur:  id " + joueur.Id + ", pseudo " + joueur.Pseudo, e);
                throw;
            }
        }

        public async Task<MancheDto> AddManche(MancheDto manche, [Service] DataManagerAPI dataManager)
        {
            _logger.LogInformation("Vous essayer d'ajouter une manche dans la base: id " + manche.Id);
            try
            {
                return mapper.Map<MancheDto>(await dataManager.AddManche(mapper.Map<Manche>(manche)) ?? throw new ArgumentNullException("La manche n'a pas pu être ajouter dans la base, soit l'id existe soit un problème est survenu vérifier si la manche existe"));
            }
            catch (Exception e)
            {
                _logger.LogError("Il y a eu une erreur pendant l'ajout de la manche:  id " + manche.Id, e);
                throw;
            }
        }

        public async Task<MancheDto> UpdateManche(MancheDto manche, [Service] DataManagerAPI dataManager)
        {
            _logger.LogInformation("Vous essayer de modifier une manche dans la base: id " + manche.Id);
            try
            {
                return mapper.Map<MancheDto>(await dataManager.UpdateManche(mapper.Map<Manche>(manche)) ?? throw new ArgumentNullException("La manche n'a pas pu être modifier, erreur lors de la modification dans la base, l'id est peut-être inexistant"));
            }
            catch (Exception e)
            {
                _logger.LogError("Il y a eu une erreur pendant la modification de la manche:  id " + manche.Id, e);
                throw;
            }
}

        public async Task<MancheDto> DeleteManche(MancheDto manche, [Service] DataManagerAPI dataManager)
        {
            _logger.LogInformation("Vous essayer de supprimer une manche dans la base: id " + manche.Id);
            try
            {
                return mapper.Map<MancheDto>(await dataManager.RemoveManche(mapper.Map<Manche>(manche)) ?? throw new ArgumentNullException("La manche n'a pas pu être supprimer, erraur dans la base, l'id est peut-être inexistant"));
            }
            catch (Exception e)
            {
                _logger.LogError("Il y a eu une erreur pendant la supprimer de la manche:  id " + manche.Id, e);
                throw;
            }
        }

    }

}

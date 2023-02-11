using EntityFramework.Entity;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class DataManagerAPI : ILoader
    {
        private readonly SQLiteContext context;

        public DataManagerAPI(SQLiteContext context)
        {
            this.context = context;
        }

        public async Task<Joueur?> AddJoueur(Joueur joueur)
        {
            Joueur? j = null;
            if (context.Joueurs.Find(joueur.Id) == null)
            {
                await context.Joueurs.AddAsync(joueur.toEntity());
                if (await context.SaveChangesAsync() == 1)
                {
                    j = joueur;
                }
            }
            return j;
        }

        public async Task<Joueur?> UpdateJoueur(Joueur joueur)
        {
            Joueur? j = null;
            JoueurEntity? joueurEntity = context.Joueurs.Find(joueur.Id);
            if (joueurEntity != null)
            {
                joueurEntity = joueur.toEntity();
                context.Joueurs.Update(joueurEntity);
                if (await context.SaveChangesAsync() == 1)
                {
                    j = joueur;
                }
            }
      
            return j;
        }

        public async Task<Joueur?> RemoveJoueur(Joueur joueur)
        {
            Joueur? j = null;
            JoueurEntity? joueurEntity = context.Joueurs.Find(joueur.Id);
            if (joueurEntity != null) {
               // context.Remove(context.Parties.Select(m => m.Joueurs.Contains(joueur.toEntity())));
                context.Joueurs.Remove(joueurEntity);
                if (await context.SaveChangesAsync() == 1)
                {
                    j = joueur;
                }
            }
 
            return j;
        }

        public async Task<IEnumerable<Joueur>> GetJoueurs()
        {
            List<Joueur> joueurs = new();

            var a = context.Joueurs.Select(joueur => joueur.toModel());
            joueurs.AddRange(a);

           //await Task.Run(() =>
             //   joueurs.AddRange(context.Joueurs.Select(joueur => joueur.toModel())));
            
            return joueurs;
        }

        public async Task<IEnumerable<Joueur>> GetJoueursByPseudo(String pseudo)
        {
            List<Joueur> joueurs = new();
            joueurs.Select(joueur => joueur.Pseudo ==  pseudo);
            await Task.Run(() =>
                joueurs.AddRange(context.Joueurs.Select(joueur => joueur.toModel())));

            return joueurs;
        }


        public async Task ClearJoueurs()
        {
            context.RemoveRange(context.Joueurs);
            await context.SaveChangesAsync();
            
        }

        public async Task ClearManches()
        {
            context.RemoveRange(context.Manches);
            await context.SaveChangesAsync();   
        }

        public async Task ClearParties()
        {
            ClearManches();
            context.RemoveRange(context.Parties);
            await context.SaveChangesAsync();   
        }

    
        public async Task<IEnumerable<Partie>> GetParties()
        {
            List<Partie> parties = new();
            context.Parties.ToList().ForEach(p =>
            {
                if (p.Joueurs.Count() == 0)
                {
                    ClearParties();
                }
            });
            List<Partie> partieEntities = context.Parties.Select(p => p.ToModel()).ToList();
            await Task.Run(() =>
                parties.AddRange(partieEntities));
            
            return parties;
        }

    
        public async Task<Manche> AddManche(Manche manche)
        {
            bool result = false;
            await context.Manches.AddAsync(manche.toEntity());
            result = await context.SaveChangesAsync() == 1;
            return manche;
        }

        public async Task<Manche> UpdateManche(Manche manche)
        {
            bool result = false;
            context.Update(manche.toEntity());
            result = await context.SaveChangesAsync() == 1;
            return manche;
        }

        public async Task<Manche> RemoveManche(Manche manche)
        {
            bool result = false;
            context.Remove(manche.toEntity());
            result = await context.SaveChangesAsync() == 1;
            return manche;
        }

        public async Task<IEnumerable<Manche>> GetManches()
        {
            List<Manche> manches = new();

                await Task.Run(() =>
                    manches.AddRange(context.Manches.Select(manche => manche.ToModel())));
            
            return manches;
        }

        public async Task<Joueur?> GetJoueurById(int id)
        {
            return context.Joueurs.Find(id).toModel();
        }

        public async Task<Manche> GetManche(int id)
        {
            Manche manche;
            manche = context.Manches.Where(m => m.Id.Equals(id)).First().ToModel();
            return manche;
        }

        public async Task<Partie> GetPartieById(int id)
        {
            Partie partie;
            var query //= context.Parties.Join(context.Joueurs).Join(context.Manches).ToList();
                = (from c in context.Parties
                    where c.Id == id
                    from jp in c.Joueurs
                    join j in context.Joueurs on jp.Id equals j.Id
                    from mp in c.Manches
                    join m in context.Manches on mp.Id equals m.Id
                    select c).First();
            partie = query.ToModel();
            return partie;
        }

        public Task<IEnumerable<Partie>> LoadPartie(IEnumerable<Joueur> listJoueur)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> RemovePartie(Partie partie)
        {
            bool result = false;
          
                context.Remove(partie.ToEntity());
                result = await context.SaveChangesAsync() == 1;
            
            return result;
        }
        public async Task<bool> UpdatePartie(Partie partie)
        {
            bool result = false;
    
                context.Update(partie.ToEntity());
                result = await context.SaveChangesAsync() == 1;
            
            return result;
        }
        public async Task<bool> AddPartie(Partie partie)
        {
            bool result = false;
    
                await context.Parties.AddAsync(partie.ToEntity());
                result = await context.SaveChangesAsync() == 1;
            
            return result;
        }
    }
}

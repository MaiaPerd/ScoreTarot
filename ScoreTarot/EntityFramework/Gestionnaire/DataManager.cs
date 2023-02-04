using EntityFramework.Entity;
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
    public class DataManager : ILoader, ISaver
    {

        public async Task<bool> AddJoueur(Joueur joueur)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                await context.Joueurs.AddAsync(joueur.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> AddManche(Manche manche)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                await context.Manches.AddAsync(manche.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> AddPartie(Partie partie)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                /*PartieEntity partieEntity = partie.toEntity();
                partieEntity.Joueurs.Clear();
                List<JoueurEntity> joueurEntity = new();
                partie.Joueurs.ToList().ForEach(j =>
                {
                     joueurEntity.Add(context.Joueurs.Where(joueur => joueur.Pseudo == j.Pseudo).First());
                });
                joueurEntity.ForEach(joueur =>
                {
                    partieEntity.AjouterJoueur(joueur);
                });

            
                
                await context.Parties.AddAsync(partieEntity);
                result = await context.SaveChangesAsync() == 1;*/
                await context.Parties.AddAsync(partie.ToEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task ClearJoueurs()
        {
            using (var context = new SQLiteContext())
            {
                context.RemoveRange(context.Joueurs);
                await context.SaveChangesAsync();
            }
        }

        public async Task ClearManches()
        {
            using (var context = new SQLiteContext())
            {
                context.RemoveRange(context.Manches);
                await context.SaveChangesAsync();
            }
        }

        public async Task ClearParties()
        {
            ClearManches();
            using (var context = new SQLiteContext())
            {
                context.RemoveRange(context.Parties);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Joueur> GetJoueurById(int id)
        {
            Joueur joueur;
            using (var context = new SQLiteContext())
            {
                joueur = context.Joueurs.Where(joueur => joueur.Id.Equals(id)).First().toModel();
            }
            return joueur;
        }

        /*public async Task<IEnumerable<Joueur>> GetJoueurPartie(int id)
        {
            List<Joueur> joueurs = new();
            using (var context = new SQLiteContext())
            {
                IEnumerable<PartieJoueur> partieJoueurs = context.PartieJoueurs.Where(joueur => joueur.PartieForeignKey == id);
          
                await Task.Run(() =>
                    joueurs.AddRange(partieJoueurs.Select(partieJ => context.Joueurs.Find(partieJ.JoueurForeignKey).toModel())));
            }
            return joueurs;
            
        }*/

        public async Task<IEnumerable<Joueur>> GetJoueurs()
        {
            List<Joueur> joueurs = new();
            using (var context = new SQLiteContext())
            {
                await Task.Run(() =>
                    joueurs.AddRange(context.Joueurs.Select(joueur => joueur.toModel())));
            }
            return joueurs;
        }

        public async Task<Manche> GetManche(int id)
        {
            Manche manche;
            using (var context = new SQLiteContext())
            {
                manche = context.Manches.Where(m => m.Id.Equals(id)).First().ToModel();
            }
            return manche;
        }

        /*public async Task<IEnumerable<Manche>> GetManchePartie(int id)
        {
            List<Manche> manche = new();
            using (var context = new SQLiteContext())
            {
                Partie partie = await GetPartie(id);
                await Task.Run(() =>
                    manche.AddRange(partie.Manches));
            }
            return manche;
        }*/

        public async Task<IEnumerable<Manche>> GetManches()
        {
            List<Manche> manches = new();
            using (var context = new SQLiteContext())
            {
                await Task.Run(() =>
                    manches.AddRange(context.Manches.Select(m => m.ToModel())));
            }
            return manches;
        }

        public async Task<Partie> GetPartieById(int id)
        {
            Partie partie;
            using (var context = new SQLiteContext())
            {
                var query //= context.Parties.Join(context.Joueurs).Join(context.Manches).ToList();
                    = (from c in context.Parties
                       where c.Id == id
                       from jp in c.Joueurs
                       join j in context.Joueurs on jp.Id equals j.Id
                       from mp in c.Manches
                       join m in context.Manches on mp.Id equals m.Id
                       select c ).First();
                partie=query.ToModel();
            }
            return partie;
        }
        //??
        /*public async Task<IEnumerable<Partie>> GetPartieJoueur(string pseudo)
        {
            List<Partie> parties = new();
            using (var context = new SQLiteContext())
            {
                IEnumerable<PartieJoueur> partieJoueurs = context.PartieJoueurs.Where(joueur => joueur.JoueurForeignKey == pseudo);

                await Task.Run(() =>
                    parties.AddRange(partieJoueurs.Select(partieJ => context.Parties.Find(partieJ.PartieForeignKey).toModel())));
            }
            return parties;
        }*/

        public async Task<IEnumerable<Partie>> GetParties()
        {
            List<Partie> parties = new();
            using (var context = new SQLiteContext())
            {
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
            }
            return parties;
        }

        public async Task<IEnumerable<Partie>> LoadPartie(IEnumerable<Joueur> listJoueur)
        {
            List<Partie> parties = new();
            using (var context = new SQLiteContext())
            {
                var query //= context.Parties.Join(context.Joueurs).Join(context.Manches).ToList();
                    =(from c in context.Parties
                      from jp in c.Joueurs
                      join  j in context.Joueurs on jp.Id equals j.Id
                      from mp in c.Manches
                      join m in context.Manches on mp.Id equals m.Id
                            select c).ToList();
                /*await Task.Run(() =>
                   parties.AddRange(context.Parties.Select(p => p.toModel())));*/
            }
            return parties;
        }

        public async Task<bool> RemoveJoueur(Joueur joueur)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                context.Remove(joueur.toEntity());
                context.Remove(context.Parties.Where(m => m.Joueurs.Contains(joueur.toEntity())));
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> RemoveManche(Manche manche)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                context.Remove(manche.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> RemovePartie(Partie partie)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                context.Remove(partie.ToEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }
        //??
        public async Task<bool> RemovePartieDuJoueur(Joueur joueur)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                List<Partie> p = new();
                p.AddRange(context.Parties.Select(partie => partie.ToModel()));
                p.ForEach(partie => {
                    if (partie.Joueurs.Contains(joueur))
                    {
                        context.Remove(partie.ToEntity());
                    }
                    });
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> UpdateJoueur(Joueur joueur)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                context.Update(joueur.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> UpdateManche(Manche manche)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                context.Update(manche.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> UpdatePartie(Partie partie)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                context.Update(partie.ToEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<Joueur?> AddJoueurDB(Joueur joueur, SQLiteContext contextDB)
        {
            return joueur;// A modifier
            Joueur? j = null;
            using (var context = contextDB)
            {
                await context.Joueurs.AddAsync(joueur.toEntity());
                if( await context.SaveChangesAsync() == 1)
                {
                    j = joueur;
                }
            }
            return j;
        }

        public async Task<Joueur?> UpdateJoueurDB(Joueur joueur, SQLiteContext contextDB)
        {
            Joueur? j = null;
            using (var context = contextDB)
            {
                context.Update(joueur.toEntity());
                if (await context.SaveChangesAsync() == 1)
                {
                    j = joueur;
                }
            }
            return j;
        }

        public async Task<Joueur?> RemoveJoueurDB(Joueur joueur, SQLiteContext contextDB)
        {
            Joueur? j = null;
            using (var context = contextDB)
            {
                context.Remove(joueur.toEntity());
                context.Remove(context.Parties.Where(m => m.Joueurs.Contains(joueur.toEntity())));
                if (await context.SaveChangesAsync() == 1)
                {
                    j = joueur;
                }
            }
            return j;
        }
        public async Task<Manche> AddMancheDB(Manche manche, SQLiteContext contextDB)
        {
            return manche; // A Modifier
            bool result = false;
            using (var context = contextDB)
            {
                await context.Manches.AddAsync(manche.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return manche;
        }

        public async Task<Manche> UpdateMancheDB(Manche manche, SQLiteContext contextDB)
        {
            bool result = false;
            using (var context = contextDB)
            {
                context.Update(manche.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return manche;
        }

        public async Task<Manche> RemoveMancheDB(Manche manche, SQLiteContext contextDB)
        {
            bool result = false;
            using (var context = contextDB)
            {
                context.Remove(manche.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return manche;
        }
    }
}

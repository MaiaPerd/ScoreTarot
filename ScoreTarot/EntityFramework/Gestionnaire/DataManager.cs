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

        public async Task<bool> addJoueur(Joueur joueur)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                await context.Joueurs.AddAsync(joueur.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> addManche(Manche manche)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                await context.Manches.AddAsync(manche.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> addPartie(Partie partie)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                PartieEntity partieEntity = partie.toEntity();
                partieEntity.Joueurs.Clear();
                partieEntity.PartieJoueurs.Clear();
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
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task clearJoueurs()
        {
            using (var context = new SQLiteContext())
            {
                context.RemoveRange(context.Joueurs);
                await context.SaveChangesAsync();
            }
        }

        public async Task clearManches()
        {
            using (var context = new SQLiteContext())
            {
                context.RemoveRange(context.Manches);
                await context.SaveChangesAsync();
            }
        }

        public async Task clearParties()
        {
            clearManches();
            using (var context = new SQLiteContext())
            {
                context.RemoveRange(context.Parties);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Joueur> getJoueur(string pseudo)
        {
            Joueur joueur;
            using (var context = new SQLiteContext())
            {
                joueur = context.Joueurs.Where(joueur => joueur.Pseudo.Equals(pseudo)).First().toModel();
            }
            return joueur;
        }

        public async Task<IEnumerable<Joueur>> getJoueurPartie(int id)
        {
            List<Joueur> joueurs = new();
            using (var context = new SQLiteContext())
            {
                IEnumerable<PartieJoueur> partieJoueurs = context.PartieJoueurs.Where(joueur => joueur.PartieForeignKey == id);
          
                await Task.Run(() =>
                    joueurs.AddRange(partieJoueurs.Select(partieJ => context.Joueurs.Find(partieJ.JoueurForeignKey).toModel())));
            }
            return joueurs;
            
        }

        public async Task<IEnumerable<Joueur>> getJoueurs()
        {
            List<Joueur> joueurs = new();
            using (var context = new SQLiteContext())
            {
                await Task.Run(() =>
                    joueurs.AddRange(context.Joueurs.Select(joueur => joueur.toModel())));
            }
            return joueurs;
        }

        public async Task<Manche> getManche(int id)
        {
            Manche manche;
            using (var context = new SQLiteContext())
            {
                manche = context.Manches.Where(m => m.Id.Equals(id)).First().toModel();
            }
            return manche;
        }

        public async Task<IEnumerable<Manche>> getManchePartie(int id)
        {
            List<Manche> manche = new();
            using (var context = new SQLiteContext())
            {
                Partie partie = await getPartie(id);
                await Task.Run(() =>
                    manche.AddRange(partie.Manches));
            }
            return manche;
        }

        public async Task<IEnumerable<Manche>> getManches()
        {
            List<Manche> manches = new();
            using (var context = new SQLiteContext())
            {
                await Task.Run(() =>
                    manches.AddRange(context.Manches.Select(m => m.toModel())));
            }
            return manches;
        }

        public async Task<Partie> getPartie(int id)
        {
            Partie partie;
            using (var context = new SQLiteContext())
            {
                partie = context.Parties.Where(m => m.Id.Equals(id)).First().toModel();
            }
            return partie;
        }

        public async Task<IEnumerable<Partie>> getPartieJoueur(string pseudo)
        {
            List<Partie> parties = new();
            using (var context = new SQLiteContext())
            {
                IEnumerable<PartieJoueur> partieJoueurs = context.PartieJoueurs.Where(joueur => joueur.JoueurForeignKey == pseudo);

                await Task.Run(() =>
                    parties.AddRange(partieJoueurs.Select(partieJ => context.Parties.Find(partieJ.PartieForeignKey).toModel())));
            }
            return parties;
        }

        public async Task<IEnumerable<Partie>> getParties()
        {
            List<Partie> parties = new();
            using (var context = new SQLiteContext())
            {
                 context.Parties.ToList().ForEach(p =>
                {
                    if (p.Joueurs.Count() == 0)
                    {
                        clearParties();
                    }
                });
                List<Partie> partieEntities = context.Parties.Select(p => p.toModel()).ToList();
                await Task.Run(() =>
                    parties.AddRange(partieEntities));
            }
            return parties;
        }

        public async Task<IEnumerable<Partie>> loadPartie(IEnumerable<Joueur> listJoueur)
        {
            List<Partie> parties = new();
            using (var context = new SQLiteContext())
            {
                await Task.Run(() =>
                   parties.AddRange(context.Parties.Select(p => p.toModel())));
            }
            return parties;
        }

        public async Task<bool> removeJoueur(Joueur joueur)
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

        public async Task<bool> removeManche(Manche manche)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                context.Remove(manche.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> removePartie(Partie partie)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                context.Remove(partie.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> removePartieDuJoueur(Joueur joueur)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                List<Partie> p = new();
                p.AddRange(context.Parties.Select(partie => partie.toModel()));
                p.ForEach(partie => {
                    if (partie.Joueurs.Contains(joueur))
                    {
                        context.Remove(partie.toEntity());
                    }
                    });
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> updateJoueur(Joueur joueur)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                context.Update(joueur.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> updateManche(Manche manche)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                context.Update(manche.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> updatePartie(Partie partie)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                context.Update(partie.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }
    }
}

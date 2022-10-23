using EntityFramework.Entity;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class DataManager : IDataManager
    {

        public async Task<bool> addJoueur(Joueur joueur)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                await context.AddAsync(joueur.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> addManche(Manche manche)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                await context.AddAsync(manche.toEntity());
                result = await context.SaveChangesAsync() == 1;
            }
            return result;
        }

        public async Task<bool> addPartie(Partie partie)
        {
            bool result = false;
            using (var context = new SQLiteContext())
            {
                await context.AddAsync(partie.toEntity());
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

        public async Task<IEnumerable<Partie>> getParties()
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

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

        public async void addJoueur(Joueur joueur)
        {
            using (var context = new SQLiteContext())
            {
                await context.AddAsync(joueur.toEntity);
                await context.SaveChangesAsync();
            }
        }

        public async void addManche(Manche manche)
        {
            using (var context = new SQLiteContext())
            {
                await context.AddAsync(manche.toEntity);
                await context.SaveChangesAsync();
            }
        }

        public async void addPartie(Partie partie)
        {
            using (var context = new SQLiteContext())
            {
                await context.AddAsync(partie.toEntity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Joueur> getJoueur(string pseudo)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Joueur>> getJoueurs()
        {
            throw new NotImplementedException();
        }

        public async Task<Manche> getManche(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Manche>> getManche()
        {
            throw new NotImplementedException();
        }

        public async Task<Partie> getPartie(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Partie>> getParties()
        {
            throw new NotImplementedException();
        }

        public async void removeJoueur(Joueur joueur)
        {
            using (var context = new SQLiteContext())
            {
                context.Remove(joueur.toEntity);
                context.SaveChanges();
            }
        }

        public async void removeManche(Manche manche)
        {
            using (var context = new SQLiteContext())
            {
                context.Remove(manche.toEntity);
                context.SaveChanges();
            }
        }

        public async void removePartie(Partie partie)
        {
            using (var context = new SQLiteContext())
            {
                context.Remove(partie.toEntity);
                context.SaveChanges();
            }
        }

        public async void updateJoueur(Joueur joueur)
        {
            using (var context = new SQLiteContext())
            {
                context.Update(joueur.toEntity);
                context.SaveChanges();
            }
        }

        public async void updateManche(Manche manche)
        {
            using (var context = new SQLiteContext())
            {
                context.Update(manche.toEntity);
                context.SaveChanges();
            }
        }

        public async void updatePartie(Partie partie)
        {
            using (var context = new SQLiteContext())
            {
                context.Update(partie.toEntity);
                context.SaveChanges();
            }
        }
    }
}

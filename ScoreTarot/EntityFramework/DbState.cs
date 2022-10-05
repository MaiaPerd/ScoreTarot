using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class DbState : IDataManager
    {

        public void addJoueur(Joueur joueur)
        {
            using (var context = new SQLiteContext())
            {
                context.Add(joueur.toEntity);
                context.SaveChanges();
            }
        }

        public void addManche(Manche manche)
        {
            using (var context = new SQLiteContext())
            {
                context.Add(manche.toEntity);
                context.SaveChanges();
            }
        }

        public void addPartie(Partie partie)
        {
            throw new NotImplementedException();
        }

        public void removeJoueur(Joueur joueur)
        {
            using (var context = new SQLiteContext())
            {
                context.Remove(joueur.toEntity);
                context.SaveChanges();
            }
        }

        public void removeManche(Manche manche)
        {
            using (var context = new SQLiteContext())
            {
                context.Remove(manche.toEntity);
                context.SaveChanges();
            }
        }

        public void removePartie(Partie partie)
        {
            throw new NotImplementedException();
        }

        public void updateJoueur(Joueur joueur)
        {
            using (var context = new SQLiteContext())
            {
                context.Update(joueur.toEntity);
                context.SaveChanges();
            }
        }

        public void updateManche(Manche manche)
        {
            using (var context = new SQLiteContext())
            {
                context.Update(manche.toEntity);
                context.SaveChanges();
            }
        }

        public void updatePartie(Partie partie)
        {
            throw new NotImplementedException();
        }
    }
}

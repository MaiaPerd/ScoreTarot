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
                context.Add(joueur.toEntityJoueur());
                context.SaveChanges();
            }
        }

        public void removeJoueur(Joueur joueur)
        {
            using (var context = new SQLiteContext())
            {
                context.Remove(joueur.toEntityJoueur());
                context.SaveChanges();
            }
        }

        public void updateJoueur(Joueur joueur)
        {
            using (var context = new SQLiteContext())
            {
                context.Update(joueur.toEntityJoueur());
                context.SaveChanges();
            }
        }
    }
}

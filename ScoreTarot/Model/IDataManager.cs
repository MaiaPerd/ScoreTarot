using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IDataManager
    {
        public void addJoueur(Joueur joueur);
        public void removeJoueur(Joueur joueur);
        public void updateJoueur(Joueur joueur);

        public void addPartie(Partie partie);
        public void removePartie(Partie partie);
        public void updatePartie(Partie partie);
        public void addManche(Manche manche);
        public void removeManche(Manche manche);
        public void updateManche(Manche manche);
    }
}

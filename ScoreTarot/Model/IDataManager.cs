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
    }
}

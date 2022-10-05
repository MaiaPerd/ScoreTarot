using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface ILoader
    {
        public List<Partie> loadPartie(List<Joueur> listJoueur);
        public List<Joueur> loadJoueur();
    }
}

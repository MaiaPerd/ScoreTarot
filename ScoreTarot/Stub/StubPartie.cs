using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
    public class StubPartie 
    {
        public List<Partie> getDesPartie(List<Joueur> lesJoueurs)
        {
            List<Partie> lespartie = new();
            lespartie.Add(new Partie(new List<Joueur>(), new List<Manche>(), 1));
            
            return lespartie;
        }
    }
}

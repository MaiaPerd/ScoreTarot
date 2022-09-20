
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
    public class ManagerStub : ILoader
    {
        public List<Joueur> loadJoueur()
        {
            return new StubJoueur().chargerJoueur();
        }

        public List<Partie> loadPartie(List<Joueur> listJoueur)
        {
            return new StubPartie().getDesPartie(listJoueur);
        }
    }
}

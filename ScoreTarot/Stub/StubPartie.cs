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

        private StubManche stubManche = new StubManche();

        internal List<Partie> chargerPartie()
        {
            List<Partie> lespartie = new();
            lespartie.Add(chargerPartie3J());
            lespartie.Add(chargerPartie4J());
            lespartie.Add(chargerPartie5J());

            return lespartie;
        }

        internal Partie chargerPartie3J()
        {
            List<Joueur> lJoueur = new StubJoueur().ChargerJoueurPartie3J();
            List<Manche> lManche = stubManche.chargerLesManche3J(lJoueur);
            return new Partie(lJoueur, lManche, 1);
        }

        internal Partie chargerPartie4J()
        {
            List<Joueur> lJoueur = new StubJoueur().ChargerJoueurPartie4J();
            List<Manche> lManche = stubManche.chargerLesManche4J(lJoueur);
            List<Partie> lespartie = new();
            return new Partie(lJoueur, lManche, 2);
        }

        internal Partie chargerPartie5J()
        {
            List<Joueur> lJoueur = new StubJoueur().ChargerJoueurPartie5J();
            List<Manche> lManche = stubManche.chargerLesManche5J(lJoueur);
            List<Partie> lespartie = new();
            return new Partie(lJoueur, lManche, 3);
        }
    }
}
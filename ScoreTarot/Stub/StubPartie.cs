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

        internal List<Partie> ChargerPartie()
        {
            List<Partie> lespartie = new();
            lespartie.Add(ChargerPartie3J());
            lespartie.Add(ChargerPartie4J());
            lespartie.Add(ChargerPartie5J());

            return lespartie;
        }

        internal Partie ChargerPartie3J()
        {
            List<Joueur> lJoueur = new StubJoueur().ChargerJoueurPartie3J();
            List<Manche> lManche = stubManche.ChargerLesManche3J(lJoueur);
            return new Partie(1,lJoueur, lManche);
        }

        internal Partie ChargerPartie4J()
        {
            List<Joueur> lJoueur = new StubJoueur().ChargerJoueurPartie4J();
            List<Manche> lManche = stubManche.ChargerLesManche4J(lJoueur);
            List<Partie> lespartie = new();
            return new Partie(2, lJoueur, lManche);
        }

        internal Partie ChargerPartie5J()
        {
            List<Joueur> lJoueur = new StubJoueur().ChargerJoueurPartie5J();
            List<Manche> lManche = stubManche.ChargerLesManche5J(lJoueur);
            List<Partie> lespartie = new();
            return new Partie(3, lJoueur, lManche);
        }
    }
}
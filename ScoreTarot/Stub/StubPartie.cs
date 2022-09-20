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


        public List<Partie> chargerDesPartie3J()
        {
            List<Joueur> lJoueur = new StubJoueur().chargerJoueurPartie3J();
            List<Manche> lManche = stubManche.chargerLesManche3J(lJoueur);
            List<Partie> lespartie = new();
            lespartie.Add(new Partie(new List<Joueur>(), new List<Manche>(), 1));
            
            return lespartie;
        }

        public List<Partie> chargerDesPartie4J()
        {
            List<Joueur> lJoueur = new StubJoueur().chargerJoueurPartie4J();
            List<Manche> lManche = stubManche.chargerLesManche4J(lJoueur);
            List<Partie> lespartie = new();
            lespartie.Add(new Partie(new List<Joueur>(), new List<Manche>(), 1));

            return lespartie;
        }

        public List<Partie> chargerDesPartie5J()
        {
            List<Joueur> lJoueur = new StubJoueur().chargerJoueurPartie5J();
            List<Manche> lManche = stubManche.chargerLesManche5J(lJoueur);
            List<Partie> lespartie = new();
            lespartie.Add(new Partie(new List<Joueur>(), new List<Manche>(), 1));

            return lespartie;
        }
    }
}
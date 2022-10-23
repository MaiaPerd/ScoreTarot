using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface ISaver
    {
        public Task<bool> addJoueur(Joueur joueur);
        public Task<bool> removeJoueur(Joueur joueur);
        public Task<bool> updateJoueur(Joueur joueur);
        public Task clearJoueurs();

        public Task<bool> addPartie(Partie partie);
        public Task<bool> removePartie(Partie partie);
        public Task<bool> removePartieDuJoueur(Joueur joueur);
        public Task<bool> updatePartie(Partie partie);
        public Task clearParties();

        public Task<bool> addManche(Manche manche);
        public Task<bool> removeManche(Manche manche);
        public Task<bool> updateManche(Manche manche);
        public Task clearManches();

    }
}

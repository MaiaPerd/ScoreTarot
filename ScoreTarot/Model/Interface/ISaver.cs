using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface ISaver
    {
        public Task<bool> AddJoueur(Joueur joueur);
        public Task<bool> RemoveJoueur(Joueur joueur);
        public Task<bool> UpdateJoueur(Joueur joueur);
        public Task ClearJoueurs();

        public Task<bool> AddPartie(Partie partie);
        public Task<bool> RemovePartie(Partie partie);
        public Task<bool> RemovePartieDuJoueur(Joueur joueur);
        public Task<bool> UpdatePartie(Partie partie);
        public Task ClearParties();

        public Task<bool> AddManche(Manche manche);
        public Task<bool> RemoveManche(Manche manche);
        public Task<bool> UpdateManche(Manche manche);
        public Task ClearManches();

    }
}

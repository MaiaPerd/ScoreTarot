using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IDataManager
    {
        public Task<bool> addJoueur(Joueur joueur);
        public Task<bool> removeJoueur(Joueur joueur);
        public Task<bool> updateJoueur(Joueur joueur);
        public Task<Joueur> getJoueur(String pseudo);
        public Task<IEnumerable<Joueur>> getJoueurs();
        public Task clearJoueurs();

        public Task<bool> addPartie(Partie partie);
        public Task<bool> removePartie(Partie partie);
        public Task<bool> updatePartie(Partie partie);
        public Task<Partie> getPartie(int id);
        public Task<IEnumerable<Partie>> getParties();
        public Task clearParties();

        public Task<bool> addManche(Manche manche);
        public Task<bool> removeManche(Manche manche);
        public Task<bool> updateManche(Manche manche);
        public Task<Manche> getManche(int id);
        public Task<IEnumerable<Manche>> getManches();
        public Task clearManches();
    }
}

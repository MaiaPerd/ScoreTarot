using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface ILoader
    {
        public Task<IEnumerable<Partie>> loadPartie(IEnumerable<Joueur> listJoueur);

        public Task<Joueur> getJoueur(String pseudo);
        public Task<IEnumerable<Partie>> getPartieJoueur(String pseudo);
        public Task<IEnumerable<Joueur>> getJoueurs();

        public Task<Partie> getPartie(int id);
        public Task<IEnumerable<Joueur>> getJoueurPartie(int id);
        public Task<IEnumerable<Manche>> getManchePartie(int id);
        public Task<IEnumerable<Partie>> getParties();

        public Task<Manche> getManche(int id);
        public Task<IEnumerable<Manche>> getManches();
    }
}

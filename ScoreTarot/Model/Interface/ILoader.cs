using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface ILoader
    {
        public Task<IEnumerable<Partie>> LoadPartie(IEnumerable<Joueur> listJoueur);

        public Task<Joueur> GetJoueur(String pseudo);
        //public Task<IEnumerable<Partie>> GetPartieJoueur(String pseudo);
        public Task<IEnumerable<Joueur>> GetJoueurs();

        //public Task<Partie> GetPartie(int id);
        //public Task<IEnumerable<Joueur>> GetJoueurPartie(int id);
        //public Task<IEnumerable<Manche>> GetManchePartie(int id);
        public Task<IEnumerable<Partie>> GetParties();

        public Task<Manche> GetManche(int id);
        //public Task<IEnumerable<Manche>> GetManches();
    }
}

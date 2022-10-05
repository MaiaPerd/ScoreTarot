using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class ManagerData : IDataManager
    {
        public void addJoueur(Joueur joueur)
        {
            throw new NotImplementedException();
        }

        public void addManche(Manche manche)
        {
            throw new NotImplementedException();
        }

        public void addPartie(Partie partie)
        {
            throw new NotImplementedException();
        }

        public Task<Joueur> getJoueur(string pseudo)
        {
            throw new NotImplementedException();
        }

        public Task<List<Joueur>> getJoueurs()
        {
            throw new NotImplementedException();
        }

        public Task<Manche> getManche(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Manche>> getManche()
        {
            throw new NotImplementedException();
        }

        public Task<Partie> getPartie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Partie>> getParties()
        {
            throw new NotImplementedException();
        }

        public void removeJoueur(Joueur joueur)
        {
            throw new NotImplementedException();
        }

        public void removeManche(Manche manche)
        {
            throw new NotImplementedException();
        }

        public void removePartie(Partie partie)
        {
            throw new NotImplementedException();
        }

        public void updateJoueur(Joueur joueur)
        {
            throw new NotImplementedException();
        }

        public void updateManche(Manche manche)
        {
            throw new NotImplementedException();
        }

        public void updatePartie(Partie partie)
        {
            throw new NotImplementedException();
        }
    }
}

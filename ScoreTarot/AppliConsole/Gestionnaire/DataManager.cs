using System;
using Model;
using Model.Interface;
using Stub;
using EntityFramework;

namespace AppliConsole.Gestionnaire
{
    public class DataManager 
    {
        object dataManager = new EntityFramework.DataManager();

        bool BD;

        public DataManager()
        {
            getBDNull();
            if (BD)
            {
                (new Stub.ManagerStub()).LoadJoueur().ForEach(j => addJoueur(j));
                (new Stub.ManagerStub()).LoadPartie().ForEach(p => addPartie(p));
            }
        }

        public async Task getBDNull()
        {
            EntityFramework.DataManager d = new EntityFramework.DataManager();
            using (SQLiteContext context = new SQLiteContext())
            {
                if(context.Joueurs.Count() == 0)
                {
                    BD = true;
                }
                else {
                    BD = false;
                }
            }
           
        }
        
        public Task<bool> addJoueur(Joueur joueur)
        {
            return ((EntityFramework.DataManager)dataManager).addJoueur(joueur);
        }

        public Task<bool> addManche(Manche manche)
        {
            return ((EntityFramework.DataManager)dataManager).addManche(manche);   
        }

        public Task<bool> addPartie(Partie partie)
        {
            return ((EntityFramework.DataManager)dataManager).addPartie(partie);
        }

        public Task clearJoueurs()
        {
            return ((EntityFramework.DataManager)dataManager).clearJoueurs();  
        }

        public Task clearManches()
        {
            return ((EntityFramework.DataManager)dataManager).clearManches(); 
        }

        public Task clearParties()
        {
            return ((EntityFramework.DataManager)dataManager).clearParties(); 
        }

        public Task<Joueur> getJoueur(string pseudo)
        {
            return ((EntityFramework.DataManager)dataManager).getJoueur(pseudo);   
        }

        public Task<IEnumerable<Joueur>> getJoueurPartie(int id)
        {
            return ((EntityFramework.DataManager)dataManager).getJoueurPartie(id);           
        }

        public Task<IEnumerable<Joueur>> getJoueurs()
        {
            return ((EntityFramework.DataManager)dataManager).getJoueurs();
        }

        public Task<Manche> getManche(int id)
        {
            return ((EntityFramework.DataManager)dataManager).getManche(id);
        }

        public Task<IEnumerable<Manche>> getManchePartie(int id)
        {
            return ((EntityFramework.DataManager)dataManager).getManchePartie(id);
        }

        public Task<IEnumerable<Manche>> getManches()
        {
            return ((EntityFramework.DataManager)dataManager).getManches();
        }

        public Task<Partie> getPartie(int id)
        {
            return ((EntityFramework.DataManager)dataManager).getPartie(id);
        }

        public Task<IEnumerable<Partie>> getPartieJoueur(string pseudo)
        {
            return ((EntityFramework.DataManager)dataManager).getPartieJoueur(pseudo);
        }

        public Task<IEnumerable<Partie>> getParties()
        {
            return ((EntityFramework.DataManager)dataManager).getParties();
        }

        public Task<IEnumerable<Partie>> loadPartie(IEnumerable<Joueur> listJoueur)
        {
            return ((EntityFramework.DataManager)dataManager).loadPartie(listJoueur);
        }

        public Task<bool> removeJoueur(Joueur joueur)
        {
            return ((EntityFramework.DataManager)dataManager).removeJoueur(joueur);
        }

        public Task<bool> removeManche(Manche manche)
        {
            return ((EntityFramework.DataManager)dataManager).removeManche(manche);
        }

        public Task<bool> removePartie(Partie partie)
        {
            return ((EntityFramework.DataManager)dataManager).removePartie(partie);
        }

        public Task<bool> removePartieDuJoueur(Joueur joueur)
        {
            return ((EntityFramework.DataManager)dataManager).removePartieDuJoueur(joueur);
        }

        public Task<bool> updateJoueur(Joueur joueur)
        {
            return ((EntityFramework.DataManager)dataManager).updateJoueur(joueur);
        }

        public Task<bool> updateManche(Manche manche)
        {
            return ((EntityFramework.DataManager)dataManager).updateManche(manche);
        }

        public Task<bool> updatePartie(Partie partie)
        {
            return ((EntityFramework.DataManager)dataManager).updatePartie(partie);
        }
    }
}


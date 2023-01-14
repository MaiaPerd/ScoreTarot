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
            return ((EntityFramework.DataManager)dataManager).AddJoueur(joueur);
        }

        public Task<bool> addManche(Manche manche)
        {
            return ((EntityFramework.DataManager)dataManager).AddManche(manche);   
        }

        public Task<bool> addPartie(Partie partie)
        {
            return ((EntityFramework.DataManager)dataManager).AddPartie(partie);
        }

        public Task clearJoueurs()
        {
            return ((EntityFramework.DataManager)dataManager).ClearJoueurs();  
        }

        public Task clearManches()
        {
            return ((EntityFramework.DataManager)dataManager).ClearManches(); 
        }

        public Task clearParties()
        {
            return ((EntityFramework.DataManager)dataManager).ClearParties(); 
        }

        public Task<Joueur> getJoueur(int id)
        {
            return ((EntityFramework.DataManager)dataManager).GetJoueurById(id);   
        }

        /*public Task<IEnumerable<Joueur>> getJoueurPartie(int id)
        {
            return ((EntityFramework.DataManager)dataManager).GetJoueurPartie(id);           
        }*/

        public Task<IEnumerable<Joueur>> getJoueurs()
        {
            return ((EntityFramework.DataManager)dataManager).GetJoueurs();
        }

        public Task<Manche> getManche(int id)
        {
            return ((EntityFramework.DataManager)dataManager).GetManche(id);
        }

        /*public Task<IEnumerable<Manche>> getManchePartie(int id)
        {
            return ((EntityFramework.DataManager)dataManager).GetManchePartie(id);
        }

        public Task<IEnumerable<Manche>> getManches()
        {
            return ((EntityFramework.DataManager)dataManager).GetManches();
        }*/

        /*public Task<Partie> getPartie(int id)
        {
            return ((EntityFramework.DataManager)dataManager).GetPartie(id);
        }

        public Task<IEnumerable<Partie>> getPartieJoueur(string pseudo)
        {
            return ((EntityFramework.DataManager)dataManager).GetPartieJoueur(pseudo);
        }*/

        public Task<IEnumerable<Partie>> getParties()
        {
            return ((EntityFramework.DataManager)dataManager).GetParties();
        }

        public Task<IEnumerable<Partie>> loadPartie(IEnumerable<Joueur> listJoueur)
        {
            return ((EntityFramework.DataManager)dataManager).LoadPartie(listJoueur);
        }

        public Task<bool> removeJoueur(Joueur joueur)
        {
            return ((EntityFramework.DataManager)dataManager).RemoveJoueur(joueur);
        }

        public Task<bool> removeManche(Manche manche)
        {
            return ((EntityFramework.DataManager)dataManager).RemoveManche(manche);
        }

        public Task<bool> removePartie(Partie partie)
        {
            return ((EntityFramework.DataManager)dataManager).RemovePartie(partie);
        }

        public Task<bool> removePartieDuJoueur(Joueur joueur)
        {
            return ((EntityFramework.DataManager)dataManager).RemovePartieDuJoueur(joueur);
        }

        public Task<bool> updateJoueur(Joueur joueur)
        {
            return ((EntityFramework.DataManager)dataManager).UpdateJoueur(joueur);
        }

        public Task<bool> updateManche(Manche manche)
        {
            return ((EntityFramework.DataManager)dataManager).UpdateManche(manche);
        }

        public Task<bool> updatePartie(Partie partie)
        {
            return ((EntityFramework.DataManager)dataManager).UpdatePartie(partie);
        }
    }
}


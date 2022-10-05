
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
    public class ManagerStub 
    {
        public List<Joueur> LoadJoueur()
        {
            return new StubJoueur().chargerJoueur();
        }

        public List<Partie> LoadPartie()
        {
            return new StubPartie().chargerPartie();
        }
        public List<Joueur> ChargerDesJoueurPourUnePartie(int combienDeJoueur)
        {
            List<Joueur> listJoueur = new List<Joueur>();
            StubJoueur stub = new StubJoueur();
            switch (combienDeJoueur)
            {
                case 3:
                    {
                        listJoueur = stub.chargerJoueurPartie3J();
                        break;
                    }
                case 4:
                    {
                        listJoueur = stub.chargerJoueurPartie4J();
                        break;
                    }
                case 5:
                    {
                        listJoueur = stub.chargerJoueurPartie5J();
                        break;
                    }

            }
            return listJoueur;
        }
        public List<Bonus> ChargerBonuschargerListeBonusMoyen()
        {
            return new StubBonus().chargerListeBonusMoyen();
        }
        public List<Bonus> chargerListeBonusBien()
        {
            return new StubBonus().chargerListeBonusBien();
        }
        public List<Bonus> chargerListeBonusUnSeul()
        {
            return new StubBonus().chargerListeBonusUnSeul();
        }
        public List<Manche> chargerListManche(int pourCombienDeJoueur,List<Joueur> listJoueur)
        {
            List<Manche> listManche = new List<Manche>();
            StubManche stub = new StubManche();
            switch (pourCombienDeJoueur)
            {
                case 3:
                    {
                        listManche = stub.chargerLesManche3J(listJoueur);
                        break;
                    }
                case 4:
                    {
                        listManche = stub.chargerLesManche4J(listJoueur);
                        break;
                    }
                case 5:
                    {
                        listManche = stub.chargerLesManche5J(listJoueur);
                        break;
                    }
            }
            return listManche;

        }

    }
}

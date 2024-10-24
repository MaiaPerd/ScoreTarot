﻿
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
            return new StubJoueur().ChargerJoueur();
        }

        public List<Partie> LoadPartie()
        {
            return new StubPartie().ChargerPartie();
        }
        public List<Joueur> ChargerDesJoueurPourUnePartie(int combienDeJoueur)
        {
            List<Joueur> listJoueur = new List<Joueur>();
            StubJoueur stub = new StubJoueur();
            switch (combienDeJoueur)
            {
                case 3:
                    {
                        listJoueur = stub.ChargerJoueurPartie3J();
                        break;
                    }
                case 4:
                    {
                        listJoueur = stub.ChargerJoueurPartie4J();
                        break;
                    }
                case 5:
                    {
                        listJoueur = stub.ChargerJoueurPartie5J();
                        break;
                    }

            }
            return listJoueur;
        }
        public Bonus ChargerListeBonusMoyen()
        {
            return new StubBonus().ChargerListeBonusMoyen();
        }
        public Bonus ChargerListeBonusBien()
        {
            return new StubBonus().ChargerListeBonusBien();
        }
        public Bonus ChargerListeBonusUnSeul()
        {
            return new StubBonus().ChargerListeBonusUnSeul();
        }
        public List<Manche> ChargerListManche(int pourCombienDeJoueur,List<Joueur> listJoueur)
        {
            List<Manche> listManche = new List<Manche>();
            StubManche stub = new StubManche();
            switch (pourCombienDeJoueur)
            {
                case 3:
                    {
                        listManche = stub.ChargerLesManche3J(listJoueur);
                        break;
                    }
                case 4:
                    {
                        listManche = stub.ChargerLesManche4J(listJoueur);
                        break;
                    }
                case 5:
                    {
                        listManche = stub.ChargerLesManche5J(listJoueur);
                        break;
                    }
            }
            return listManche;

        }
        public Partie ChargerUnePartie(int combienDeJoueur)
        {
            StubPartie stub = new StubPartie();
            switch (combienDeJoueur)
            {
                case 3:
                    {
                        return stub.ChargerPartie3J();
                        break;
                    }
                case 4:
                    {
                        return stub.ChargerPartie4J();
                        break;
                    }
                case 5:
                    {
                        return stub.ChargerPartie5J();
                        break;
                    }
            }
            return null;
        }

    }
}

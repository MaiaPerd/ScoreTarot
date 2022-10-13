using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub
{
    public class StubManche
    {
        private StubBonus stubBonus = new StubBonus();

        internal Manche ChargerUneManche(List<Joueur> lJoueur)
        {
            return new Manche(1, Contrat.GardeContre, lJoueur[0], 50, stubBonus.ChargerListeBonusMoyen(), 4);
        }

        internal Manche ChargerUneManche2(List<Joueur> lJoueur)
        {
            return new Manche(2, Contrat.GardeContre, lJoueur[0], 50, stubBonus.ChargerListeBonusMoyen(), 4);
        }

        internal List<Manche> ChargerLesManche3J(List<Joueur> lJoueur)
        {
            List<Manche> manches = new List<Manche>();


            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 50, stubBonus.ChargerListeBonusMoyen(), 3));
            manches.Add(new Manche(Contrat.Prise, lJoueur[1], 56, stubBonus.ChargerListeBonusBien(), 3));
            manches.Add(new Manche(Contrat.Garde, lJoueur[2], 34, stubBonus.ChargerListeBonusBien(), 3));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[1], 21, stubBonus.ChargerListeBonusUnSeul(), 3));
            manches.Add(new Manche(Contrat.Garde, lJoueur[1], 47, stubBonus.ChargerListeBonusMoyen(), 3));
            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 60, stubBonus.ChargerListeBonusMoyen(), 3));
            manches.Add(new Manche(Contrat.Prise, lJoueur[2], 48, stubBonus.ChargerListeBonusBien(), 3));
            manches.Add(new Manche(Contrat.Prise, lJoueur[1], 37, stubBonus.ChargerListeBonusUnSeul(), 3)); 
            manches.Add(new Manche(Contrat.Prise, lJoueur[0], 46, stubBonus.ChargerListeBonusMoyen(), 3));
            manches.Add(new Manche(Contrat.Garde, lJoueur[0], 56, stubBonus.ChargerListeBonusUnSeul(), 3));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[2], 52, stubBonus.ChargerListeBonusBien(), 3));
            manches.Add(new Manche(Contrat.Garde, lJoueur[0], 51, stubBonus.ChargerListeBonusMoyen(), 3));

            return manches;
        }

        internal List<Manche> ChargerLesManche4J(List<Joueur> lJoueur)
        {
            List<Manche> manches = new List<Manche>();

            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 50, stubBonus.ChargerListeBonusMoyen(), 4));
            manches.Add(new Manche(Contrat.Prise, lJoueur[1], 56, stubBonus.ChargerListeBonusBien(), 4));
            manches.Add(new Manche(Contrat.Garde, lJoueur[2], 34, stubBonus.ChargerListeBonusBien(), 4));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[1], 21, stubBonus.ChargerListeBonusUnSeul(), 4));
            manches.Add(new Manche(Contrat.Garde, lJoueur[3], 47, stubBonus.ChargerListeBonusMoyen(), 4));
            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 60, stubBonus.ChargerListeBonusMoyen(), 4));
            manches.Add(new Manche(Contrat.Prise, lJoueur[2], 48, stubBonus.ChargerListeBonusBien(), 4));
            manches.Add(new Manche(Contrat.Prise, lJoueur[1], 37, stubBonus.ChargerListeBonusUnSeul(), 4));
            manches.Add(new Manche(Contrat.Prise, lJoueur[3], 46, stubBonus.ChargerListeBonusMoyen(), 4));
            manches.Add(new Manche(Contrat.Garde, lJoueur[0], 56, stubBonus.ChargerListeBonusUnSeul(), 4));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[2], 52, stubBonus.ChargerListeBonusBien(), 4));
            manches.Add(new Manche(Contrat.Garde, lJoueur[0], 51, stubBonus.ChargerListeBonusMoyen(), 4));

            return manches;
        }

        internal List<Manche> ChargerLesManche5J(List<Joueur> lJoueur)
        {
            List<Manche> manches = new List<Manche>();

            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 50, stubBonus.ChargerListeBonusMoyen(), 5));
            manches.Add(new Manche(Contrat.Prise, lJoueur[4], 56, stubBonus.ChargerListeBonusBien(), 5, lJoueur[2]));
            manches.Add(new Manche(Contrat.Garde, lJoueur[2], 34, stubBonus.ChargerListeBonusBien(), 5));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[1], 21, stubBonus.ChargerListeBonusUnSeul(), 5));
            manches.Add(new Manche(Contrat.Garde, lJoueur[3], 47, stubBonus.ChargerListeBonusMoyen(), 5, lJoueur[1]));
            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 60, stubBonus.ChargerListeBonusMoyen(), 5));
            manches.Add(new Manche(Contrat.Prise, lJoueur[1], 48, stubBonus.ChargerListeBonusBien(), 5));
            manches.Add(new Manche(Contrat.Prise, lJoueur[4], 37, stubBonus.ChargerListeBonusUnSeul(), 5));
            manches.Add(new Manche(Contrat.Prise, lJoueur[3], 46, stubBonus.ChargerListeBonusMoyen(), 5, lJoueur[4]));
            manches.Add(new Manche(Contrat.Garde, lJoueur[4], 56, stubBonus.ChargerListeBonusUnSeul(), 5, lJoueur[0]));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[2], 52, stubBonus.ChargerListeBonusBien(), 5));
            manches.Add(new Manche(Contrat.Garde, lJoueur[0], 51, stubBonus.ChargerListeBonusMoyen(), 5));

            return manches;
        }

    }
}

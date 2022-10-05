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

        internal Manche chargerUneManche(List<Joueur> lJoueur)
        {
            return new Manche(Contrat.GardeContre, lJoueur[0], 1, 50, stubBonus.chargerListeBonusMoyen(), 4);
        }

        internal Manche chargerUneManche2(List<Joueur> lJoueur)
        {
            return new Manche(Contrat.GardeContre, lJoueur[0], 2, 50, stubBonus.chargerListeBonusMoyen(), 4);
        }

        internal List<Manche> chargerLesManche3J(List<Joueur> lJoueur)
        {
            List<Manche> manches = new List<Manche>();


            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 50, stubBonus.chargerListeBonusMoyen(), 3));
            manches.Add(new Manche(Contrat.Prise, lJoueur[1], 56, stubBonus.chargerListeBonusBien(), 3));
            manches.Add(new Manche(Contrat.Garde, lJoueur[2], 34, stubBonus.chargerListeBonusBien(), 3));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[1], 21, stubBonus.chargerListeBonusUnSeul(), 3));
            manches.Add(new Manche(Contrat.Garde, lJoueur[1], 47, stubBonus.chargerListeBonusMoyen(), 3));
            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 60, stubBonus.chargerListeBonusMoyen(), 3));
            manches.Add(new Manche(Contrat.Prise, lJoueur[2], 48, stubBonus.chargerListeBonusBien(), 3));
            manches.Add(new Manche(Contrat.Prise, lJoueur[1], 37, stubBonus.chargerListeBonusUnSeul(), 3)); 
            manches.Add(new Manche(Contrat.Prise, lJoueur[0], 46, stubBonus.chargerListeBonusMoyen(), 3));
            manches.Add(new Manche(Contrat.Garde, lJoueur[0], 56, stubBonus.chargerListeBonusUnSeul(), 3));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[2], 52, stubBonus.chargerListeBonusBien(), 3));
            manches.Add(new Manche(Contrat.Garde, lJoueur[0], 51, stubBonus.chargerListeBonusMoyen(), 3));

            return manches;
        }

        internal List<Manche> chargerLesManche4J(List<Joueur> lJoueur)
        {
            List<Manche> manches = new List<Manche>();

            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 50, stubBonus.chargerListeBonusMoyen(), 4));
            manches.Add(new Manche(Contrat.Prise, lJoueur[1], 56, stubBonus.chargerListeBonusBien(), 4));
            manches.Add(new Manche(Contrat.Garde, lJoueur[2], 34, stubBonus.chargerListeBonusBien(), 4));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[1], 21, stubBonus.chargerListeBonusUnSeul(), 4));
            manches.Add(new Manche(Contrat.Garde, lJoueur[3], 47, stubBonus.chargerListeBonusMoyen(), 4));
            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 60, stubBonus.chargerListeBonusMoyen(), 4));
            manches.Add(new Manche(Contrat.Prise, lJoueur[2], 48, stubBonus.chargerListeBonusBien(), 4));
            manches.Add(new Manche(Contrat.Prise, lJoueur[1], 37, stubBonus.chargerListeBonusUnSeul(), 4));
            manches.Add(new Manche(Contrat.Prise, lJoueur[3], 46, stubBonus.chargerListeBonusMoyen(), 4));
            manches.Add(new Manche(Contrat.Garde, lJoueur[0], 56, stubBonus.chargerListeBonusUnSeul(), 4));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[2], 52, stubBonus.chargerListeBonusBien(), 4));
            manches.Add(new Manche(Contrat.Garde, lJoueur[0], 51, stubBonus.chargerListeBonusMoyen(), 4));

            return manches;
        }

        internal List<Manche> chargerLesManche5J(List<Joueur> lJoueur)
        {
            List<Manche> manches = new List<Manche>();

            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 50, stubBonus.chargerListeBonusMoyen(), 5));
            manches.Add(new Manche(Contrat.Prise, lJoueur[4], 56, stubBonus.chargerListeBonusBien(), 5, lJoueur[2]));
            manches.Add(new Manche(Contrat.Garde, lJoueur[2], 34, stubBonus.chargerListeBonusBien(), 5));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[1], 21, stubBonus.chargerListeBonusUnSeul(), 5));
            manches.Add(new Manche(Contrat.Garde, lJoueur[3], 47, stubBonus.chargerListeBonusMoyen(), 5, lJoueur[1]));
            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 60, stubBonus.chargerListeBonusMoyen(), 5));
            manches.Add(new Manche(Contrat.Prise, lJoueur[1], 48, stubBonus.chargerListeBonusBien(), 5));
            manches.Add(new Manche(Contrat.Prise, lJoueur[4], 37, stubBonus.chargerListeBonusUnSeul(), 5));
            manches.Add(new Manche(Contrat.Prise, lJoueur[3], 46, stubBonus.chargerListeBonusMoyen(), 5, lJoueur[4]));
            manches.Add(new Manche(Contrat.Garde, lJoueur[4], 56, stubBonus.chargerListeBonusUnSeul(), 5, lJoueur[0]));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[2], 52, stubBonus.chargerListeBonusBien(), 5));
            manches.Add(new Manche(Contrat.Garde, lJoueur[0], 51, stubBonus.chargerListeBonusMoyen(), 5));

            return manches;
        }

    }
}

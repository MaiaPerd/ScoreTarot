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

        public List<Manche> chargerLesManche3J()
        {
            List<Manche> manches = new List<Manche>();

            List<Joueur> lJoueur = new StubJoueur().chargerJoueurPartie3J();

            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 50, stubBonus.chargerListeBonusMoyen()));
            manches.Add(new Manche(Contrat.Prise, lJoueur[1], 56, stubBonus.chargerListeBonusBien()));
            manches.Add(new Manche(Contrat.Garde, lJoueur[2], 34, stubBonus.chargerListeBonusBien()));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[1], 21, stubBonus.chargerListeBonusUnSeul()));
            manches.Add(new Manche(Contrat.Garde, lJoueur[1], 47, stubBonus.chargerListeBonusMoyen()));
            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 60, stubBonus.chargerListeBonusMoyen()));
            manches.Add(new Manche(Contrat.Prise, lJoueur[2], 48, stubBonus.chargerListeBonusBien()));
            manches.Add(new Manche(Contrat.Prise, lJoueur[1], 37, stubBonus.chargerListeBonusUnSeul())); 
            manches.Add(new Manche(Contrat.Prise, lJoueur[0], 46, stubBonus.chargerListeBonusMoyen()));
            manches.Add(new Manche(Contrat.Garde, lJoueur[0], 56, stubBonus.chargerListeBonusUnSeul()));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[2], 52, stubBonus.chargerListeBonusBien()));
            manches.Add(new Manche(Contrat.Garde, lJoueur[0], 51, stubBonus.chargerListeBonusMoyen()));

            return manches;
        }

        public List<Manche> chargerLesManche4J()
        {
            List<Manche> manches = new List<Manche>();

            List<Joueur> lJoueur = new StubJoueur().chargerJoueurPartie4J();

            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 50, stubBonus.chargerListeBonusMoyen()));
            manches.Add(new Manche(Contrat.Prise, lJoueur[1], 56, stubBonus.chargerListeBonusBien()));
            manches.Add(new Manche(Contrat.Garde, lJoueur[2], 34, stubBonus.chargerListeBonusBien()));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[1], 21, stubBonus.chargerListeBonusUnSeul()));
            manches.Add(new Manche(Contrat.Garde, lJoueur[3], 47, stubBonus.chargerListeBonusMoyen()));
            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 60, stubBonus.chargerListeBonusMoyen()));
            manches.Add(new Manche(Contrat.Prise, lJoueur[2], 48, stubBonus.chargerListeBonusBien()));
            manches.Add(new Manche(Contrat.Prise, lJoueur[1], 37, stubBonus.chargerListeBonusUnSeul()));
            manches.Add(new Manche(Contrat.Prise, lJoueur[3], 46, stubBonus.chargerListeBonusMoyen()));
            manches.Add(new Manche(Contrat.Garde, lJoueur[0], 56, stubBonus.chargerListeBonusUnSeul()));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[2], 52, stubBonus.chargerListeBonusBien()));
            manches.Add(new Manche(Contrat.Garde, lJoueur[0], 51, stubBonus.chargerListeBonusMoyen()));

            return manches;
        }

        public List<Manche> chargerLesManche5J()
        {
            List<Manche> manches = new List<Manche>();

            List<Joueur> lJoueur = new StubJoueur().chargerJoueurPartie5J();

            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 50, stubBonus.chargerListeBonusMoyen()));
            manches.Add(new Manche(Contrat.Prise, lJoueur[4], 56, stubBonus.chargerListeBonusBien()));
            manches.Add(new Manche(Contrat.Garde, lJoueur[2], 34, stubBonus.chargerListeBonusBien()));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[1], 21, stubBonus.chargerListeBonusUnSeul()));
            manches.Add(new Manche(Contrat.Garde, lJoueur[3], 47, stubBonus.chargerListeBonusMoyen()));
            manches.Add(new Manche(Contrat.GardeContre, lJoueur[0], 60, stubBonus.chargerListeBonusMoyen()));
            manches.Add(new Manche(Contrat.Prise, lJoueur[1], 48, stubBonus.chargerListeBonusBien()));
            manches.Add(new Manche(Contrat.Prise, lJoueur[4], 37, stubBonus.chargerListeBonusUnSeul()));
            manches.Add(new Manche(Contrat.Prise, lJoueur[3], 46, stubBonus.chargerListeBonusMoyen()));
            manches.Add(new Manche(Contrat.Garde, lJoueur[4], 56, stubBonus.chargerListeBonusUnSeul()));
            manches.Add(new Manche(Contrat.GardeSans, lJoueur[2], 52, stubBonus.chargerListeBonusBien()));
            manches.Add(new Manche(Contrat.Garde, lJoueur[0], 51, stubBonus.chargerListeBonusMoyen()));

            return manches;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Calculator
    {
        private int OBJECTIF = 56;
        private int OBJECTIF2 = 51;
        private int OBJECTIF3 = 41;
        private int OBJECTIF4 = 36;

        private int SCOREBASE = 25;

        private int GARDE = 2;
        private int GARDESANS = 4;
        private int GARDECONTRE = 6;

        private int PETITPRISE = 10;
        private int PETITGARDE = 20;
        private int PETITGARDESANS = 30;
        private int PETITGARDECONTRE = 40;

        private int POIGNEE = 20;
        private int DOUBLEPOIGNEE = 30;
        private int TRIPLEPOIGNEE = 40;

        /// <summary>
        /// Methode qui calcule le score des joueurs qui non pas pris ou qui n'était pas allié au preneur.
        /// </summary>
        /// <param name="scoreJoueurQuiPrend"></param>
        /// <returns></returns>
        public int CalculScoreAutreJoueur(int scoreJoueurQuiPrend)
        {
            return (-1) * (scoreJoueurQuiPrend);
        }

        /// <summary>
        /// Calcule le score du joueur qui a pris en fonction de son contrat et ses bonus. 
        /// Se score correspond aussi au score du joueur allié.
        /// Si le score est négatif le joueur a perdu.
        /// </summary>
        /// <param name="lBonus"></param>
        /// <param name="contrat"></param>
        /// <param name="scoreJoueur"></param>
        /// <param name="nbJoueur"></param>
        /// <returns></returns>
        public int CalculeScoreJoueurQuiPrend(Bonus bonus, Contrat contrat, int scoreJoueur)
        {
            int score = 0;
            bool petit = false;
            int bout = 0;
            int point = 0;
            int poignet = 0;

            if (Bonus.PetitAuBout == (Bonus.PetitAuBout & bonus))
            {
                petit = true;
            }

            if (Bonus.SimplePoignee == (Bonus.SimplePoignee & bonus))
            {
                poignet += POIGNEE;
            }
            else if (Bonus.DoublePoignee == (Bonus.DoublePoignee & bonus))
            {
                poignet += DOUBLEPOIGNEE;
            }
            else if (Bonus.TriplePoignee == (Bonus.TriplePoignee & bonus))
            {
                poignet += TRIPLEPOIGNEE;
            }

            if (Bonus.Petit == (Bonus.Petit & bonus) && Bonus.Excuse == (Bonus.Excuse & bonus) && Bonus.Le21 == (Bonus.Le21 & bonus))
            {
                bout = 3;
            }
            else if ((Bonus.Petit == (Bonus.Petit & bonus) && Bonus.Excuse == (Bonus.Excuse & bonus)) ||
                (Bonus.Petit == (Bonus.Petit & bonus) && Bonus.Le21 == (Bonus.Le21 & bonus)) ||
                (Bonus.Excuse == (Bonus.Excuse & bonus) && Bonus.Le21 == (Bonus.Le21 & bonus)))
            {
                bout = 2;
            }
            else if (Bonus.Petit == (Bonus.Petit & bonus) || Bonus.Excuse == (Bonus.Excuse & bonus) || Bonus.Le21 == (Bonus.Le21 & bonus))
            {
                bout = 1;
            }
            
            

            switch (bout)
            {
                case 0:
                    point = scoreJoueur - OBJECTIF;
                    break;
                case 1:
                    point = scoreJoueur - OBJECTIF2;
                    break;
                case 2:
                    point = scoreJoueur - OBJECTIF3;
                    break;
                case 3:
                    point = scoreJoueur - OBJECTIF4;
                    break;

            }
            switch (contrat)
            {
                case Contrat.Prise:
                    score += SCOREBASE;
                    if (petit)
                    {
                        score += PETITPRISE;
                    }
                    break;
                case Contrat.Garde:
                    score += SCOREBASE * GARDE;
                    if (petit)
                    {
                        score += PETITGARDE;
                    }
                    break;
                case Contrat.GardeSans:
                    score += SCOREBASE * GARDESANS;
                    if (petit)
                    {
                        score += PETITGARDESANS;
                    }
                    break;
                case Contrat.GardeContre:
                    score += SCOREBASE * GARDECONTRE;
                    if (petit)
                    {
                        score += PETITGARDECONTRE;
                    }
                    break;
            }
            score += poignet;
            if (point < 0)
            {
                score *= -1;
            }
            score += point;

            return score;

        }

        /// <summary>
        /// Calcule le score final du joueur qui a pris multiplier par le nombre de joueur restant
        /// </summary>
        /// <param name="scoreJoueurQuiPrend"></param>
        /// <param name="nbJoueur"></param>
        /// <returns></returns>
        public int ScoreFinalJoueurQuiPrend(int scoreJoueurQuiPrend, int nbJoueur)
        {
            return scoreJoueurQuiPrend * (nbJoueur - 1);
        }

        /// <summary>
        /// Calcule le score final du joueur qui a pris multiplier par le nombre de joueur restant moins l'allier
        /// </summary>
        /// <param name="scoreJoueurQuiPrend"></param>
        /// <param name="nbJoueur"></param>
        /// <returns></returns>
        public int ScoreFinalJoueurQuiPrendAvecAllier(int scoreJoueurQuiPrend, int nbJoueur)
        {
            return scoreJoueurQuiPrend * (nbJoueur - 2);
        }

        /// <summary>
        /// Calcule le pourcentage de partie gagné d'un joueur
        /// </summary>
        /// <param name="nbPartieRealise"></param>
        /// <param name="nbPartieGagne"></param>
        /// <returns></returns>
        public float CalculerPourcentageDeReussite(int nbPartieRealise, int nbPartieGagne)
        {
            return (float)(nbPartieGagne * 100) / nbPartieRealise;
        }

        /// <summary>
        /// Clacule le score total du joueur avec le score de toutes c'est partie joué
        /// </summary>
        /// <param name="parties"></param>
        /// <param name="joueur"></param>
        /// <returns></returns>
        public int ScoreTotalDuJoueur(List<Partie> lParties, Joueur joueur)
        {
            int scoreTotal = 0;
            foreach (Partie partie in lParties)
            {
                scoreTotal += ScoreTotalDuJoueurPartie(partie.Manches, joueur);
            }
            return scoreTotal;
        }

        /// <summary>
        /// Clacule le score total du joueur dans une partie
        /// </summary>
        /// <param name="parties"></param>
        /// <param name="joueur"></param>
        /// <returns></returns>
        public int ScoreTotalDuJoueurPartie(List<Manche> lManches, Joueur joueur)
        {
            int scoreTotal = 0;
            foreach (Manche manche in lManches)
            {
                scoreTotal += manche.GetScoreJoueurManche(joueur);
            }
            return scoreTotal;
        }
    }
}

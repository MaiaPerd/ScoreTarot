using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Calculator
    {
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
        public int CalculeScoreJoueurQuiPrend(List<Bonus> lBonus, Contrat contrat, int scoreJoueur)
        {
            int score = 0;
            bool petit = false;
            int bout = 0;
            int point = 0;
            int poignet = 0;
            foreach (Bonus b in lBonus)
            {
                if (b == Bonus.PetitAuBout)
                {
                    petit = true;
                }
                else if (b == Bonus.SimplePoignee)
                {
                    poignet += 20;
                }
                else if (b == Bonus.DoublePoignee)
                {
                    poignet += 30;
                }
                else if (b == Bonus.TriplePoignee)
                {
                    poignet += 40;
                }
                else if (b == Bonus.Petit || b == Bonus.Escuse|| b == Bonus.Le21)
                {
                    bout += 1;
                }
            }
            switch (bout)
            {
                case 0:
                    point = scoreJoueur - 56;
                    break;
                case 1:
                    point = scoreJoueur - 51;
                    break;
                case 2:
                    point = scoreJoueur - 41;
                    break;
                case 3:
                    point = scoreJoueur - 36;
                    break;

            }
            switch (contrat)
            {
                case Contrat.Prise:
                    score += 25;
                    if (petit)
                    {
                        score += 10;
                    }
                    break;
                case Contrat.Garde:
                    score += 25 * 2;
                    if (petit)
                    {
                        score += 20;
                    }
                    break;
                case Contrat.GardeSans:
                    score += 25 * 4;
                    if (petit)
                    {
                        score += 30;
                    }
                    break;
                case Contrat.GardeContre:
                    score += 25 * 6;
                    if (petit)
                    {
                        score += 40;
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

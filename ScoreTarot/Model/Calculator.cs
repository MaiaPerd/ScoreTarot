using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Calculator
    {
        
        public int calculScoreAutreJoueur(int scoreJoueurQuiPrend, int nbJoueur)
        {
                return (-1)*(scoreJoueurQuiPrend);
        }

        public int calculeScoreJoueurQuiPrend(List<Bonus> bonus, Contrat contrat, int scoreJoueur, int nbJoueur)
        {
            int score = 0;
            bool petit = false;
            int bout = 0;
            int point = 0;
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
            foreach (Bonus b in bonus)
            {
                if(b == Bonus.PetitAuBout) {
                    petit = true;
                } else if(b == Bonus.SimplePoignet) {
                    score += 20;
                } else if (b == Bonus.DoublePoignet) {
                    score += 30;
                } else if (b == Bonus.TriplePoignet) {
                    score += 40;
                } else if(b == Bonus.Petit) {
                    bout += 1;
                } else if (b == Bonus.Escuse) {
                    bout += 1;
                } else if (b == Bonus.Le21) {
                    bout += 1;
                }
            }
            if (point<0)
            {
                score *= -1;
            }
            switch (contrat) {
                case Contrat.Prise:
                    if (petit)
                    {
                        score += 10;
                    }
                    break;
                case Contrat.Garde: 
                    score += point*2;
                    if (petit)
                    {
                        score += 20;
                    }
                    break;
                case Contrat.GardeSans:
                    score += point*4;
                    if (petit)
                    {
                        score += 30;
                    }
                    break;
                case Contrat.GardeContre:
                    score += point*6;
                    if (petit)
                    {
                        score += 40;
                    }
                    break;
            }
            
            return score;

        }

        public int scoreFinalJoueurQuiPrend(int scoreJoueurQuiPrend, int nbJoueur)
        {
            return scoreJoueurQuiPrend * (nbJoueur - 1);
        }


        public float calculerPourcentageDeReussite(int nbPartieRealise, int nbPartieGagne)
        {
            return (nbPartieGagne * 100) / nbPartieRealise;
        }

        public int scoreTotalDuJoueur(List<Partie> parties, Joueur joueur)
        {
            int scoreTotal = 0;
            foreach(Partie partie in parties)
            {
                scoreTotal += partie.getScoreJoueur(joueur);
            }
            return scoreTotal;
        }
    }
}

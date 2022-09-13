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
                return scoreJoueurQuiPrend/(nbJoueur-1);
        }

        public int calculeScoreJoueurQuiPrend(List<Bonus> bonus, Contrat contrat, int scoreJoueur, bool gagne, int nbJoueur)
        {
            int score = 0;
            bool petit = false;
            foreach (Bonus b in bonus)
            {
                if(b == Bonus.PetitAuBout)
                {
                    petit = true;
                } else if(b == Bonus.Poignet)
                {
                    score += 10;
                }
            }
            if(contrat == Contrat.PRISE) {
                score += scoreJoueur;
                if (petit)
                {
                    score += 10;
                }
            } else if (contrat == Contrat.GARDE) {
                score += scoreJoueur*2;
                if (petit)
                {
                    score += 20;
                }
            } else if (contrat == Contrat.GARDE_SANS) {
                score += scoreJoueur*4;
                if (petit)
                {
                    score += 30;
                }
            } else if (contrat == Contrat.GARDE_CONTRE) {
                score += scoreJoueur*6;
                if (petit)
                {
                    score += 40;
                }
            }
            if (!gagne) { score = -score; }
            return score*(nbJoueur-1);

        }

        public float calculerPourcentageDeReussite(int nbPartieRealise, int nbPartieGagne)
        {
            return (nbPartieGagne * 100) / nbPartieRealise;
        }

        public int scoreTotalDuJoueur(List<Partie> parties)
        {
            int scoreTotal = 0;
            foreach(Partie partie in parties)
            {
                scoreTotal += partie.getScoreJoueur();
            }
            return scoreTotal;
        }
    }
}

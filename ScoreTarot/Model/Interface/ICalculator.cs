using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface ICalculator
    {
        /* prototype des constante qu'un Calculator doit avoir -> échoué
         * public static int OBJECTIF { get; }

        public static int OBJECTIF2 { get; }

        public static int OBJECTIF3 { get; }
        public static int OBJECTIF4 { get; }

        public static int SCOREBASE { get; }

        public static int GARDE { get; }
        public static int GARDESANS { get; }
        public static int GARDECONTRE { get; }

        public static int PETITPRISE { get; }
        public static int PETITGARDE { get; }
        public static int PETITGARDESANS { get; }
        public static int PETITGARDECONTRE { get; }

        public static int POIGNEE { get; }
        public static int DOUBLEPOIGNEE { get; }
        public static int TRIPLEPOIGNEE { get; }

        public static int NBJOUEURMIN { get; }
        public static int NBJOUEURMAX { get; }*/

        public static int SCOREMAX { get; }
        public int CalculScoreAutreJoueur(int scoreJoueurQuiPrend);
        public int CalculeScoreJoueurQuiPrend(Bonus bonus, Contrat contrat, int scoreJoueur);
        public int ScoreFinalJoueurQuiPrend(int scoreJoueurQuiPrend, int nbJoueur);
        public int ScoreFinalJoueurQuiPrendAvecAllier(int scoreJoueurQuiPrend, int nbJoueur);
        public float CalculerPourcentageDeReussite(int nbPartieRealise, int nbPartieGagne);
        public int ScoreTotalDuJoueur(IEnumerable<Partie> lParties, Joueur joueur);
        public int ScoreTotalDuJoueurPartie(ReadOnlyCollection<Manche> lManches, Joueur joueur);
    }
}

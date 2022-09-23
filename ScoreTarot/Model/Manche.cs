using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Manche
    {
        public Contrat Contrat{ get; private set; }
        public List<Bonus> Bonus { get; private set; }
        public Joueur JoueurQuiPrend {
            get => joueurQuiPrend;
            private set
            {
                joueurQuiPrend = value;
                bool typeJoueur = false;
                if (joueurQuiPrend != null)
                {
                    typeJoueur = joueurQuiPrend.GetType() == typeof(Joueur);
                }
                if (!typeJoueur)
                {
                    throw new ArgumentNullException("Le joueur qui prend ne peut pas être null");
                }
            }
        }
        private Joueur joueurQuiPrend;

        public Joueur JoueurAllier { get; private set; }
        public int Score{
            get => score;
            private set
            {
                score = value;
                if (value < 0 || value == null)
                {
                    score = 0;
                }

            }
        }
        private int score;
        public DateTime Date {get; private set;}
        public int Id { get; private set; }
        public int NbJoueur { get; private set; }

        public Manche(Contrat contrat, Joueur joueurQuiPrend, int id, int score, List<Bonus> bonus, Joueur joueurAllier = null)
        {
            Contrat = contrat;
            Bonus = new List<Bonus>();
            if (bonus != null)
            {
                Bonus.AddRange(bonus);
            } 
            
            JoueurAllier = joueurAllier;
            Date = new DateTime();
            bool typeJoueur = false;
            if (joueurQuiPrend != null)
            {
                typeJoueur = joueurQuiPrend.GetType() == typeof(Joueur);
            }
            if (!typeJoueur)
            {
                throw new ArgumentException("Le joueur n'est pas de la classe joueur!");
            }
            else if (score < 0 || score == null)
            {
                throw new ArgumentException("Le score du joueur ne peut pas être négatif");
            }
            JoueurQuiPrend = joueurQuiPrend;
            Score = score;
            Id = id;
        }

        public Manche(Contrat contrat, Joueur joueurQuiPrend, int score, List<Bonus> bonus , Joueur joueurAllier = null)
        {
            Contrat = contrat;
            Bonus = new List<Bonus>();
            if (bonus != null)
            {
                Bonus.AddRange(bonus);
            }
            if(contrat == Contrat.Prise && score == 0)
            {
                throw new ArgumentException("Le contrat est null et score ne peut pas être zéro");
            }
            
            JoueurAllier = joueurAllier;
            bool typeJoueur = false;
            if (joueurQuiPrend != null)
            {
                typeJoueur = joueurQuiPrend.GetType() == typeof(Joueur);
            }
            if (!typeJoueur)
            {
                throw new ArgumentException("Le joueur n'est pas de la classe joueur!");
            }
            else if (score < 0 || score == null)
            {
                throw new ArgumentException("Le score du joueur ne peut pas être négatif");
            }
            JoueurQuiPrend = joueurQuiPrend;
            Score = score;
            Date = new DateTime();

        }

        public int getScoreJoueurManche(Joueur joueur)
        {
            Calculator calcule = new Calculator();
            if (joueur.Equals(JoueurQuiPrend))
            {
                if (!JoueurAllier.Equals(null))
                {
                    return calcule.scoreFinalJoueurQuiPrendAvecAllier(calcule.calculeScoreJoueurQuiPrend(Bonus, Contrat, Score), NbJoueur);
                }
                else
                {
                    return calcule.scoreFinalJoueurQuiPrend(calcule.calculeScoreJoueurQuiPrend(Bonus, Contrat, Score), NbJoueur);
                }
            }
            else if (joueur.Equals(JoueurAllier))
            {
                return calcule.calculeScoreJoueurQuiPrend(Bonus, Contrat, Score);

            }
            else
            {
                return calcule.calculScoreAutreJoueur(calcule.calculeScoreJoueurQuiPrend(Bonus, Contrat, Score));
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Manche manche &&
                   Id == manche.Id;
        }
    }
}

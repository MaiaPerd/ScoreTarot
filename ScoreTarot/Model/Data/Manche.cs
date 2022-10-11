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
                bool typeJoueur = value is Joueur;
                if (typeJoueur != null)
                {
                    if (!typeJoueur)
                    {
                        throw new ArgumentNullException("Le joueur qui prend ne peut pas être null");
                    }
                    joueurQuiPrend = value;
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

        public Manche(int id, Contrat contrat, Joueur joueurQuiPrend, int score, List<Bonus> bonus, int nbJoueur, Joueur joueurAllier = null)
        {
            Contrat = contrat;
            Bonus = new List<Bonus>();
            if (bonus != null)
            {
                Bonus.AddRange(bonus);
            }

            JoueurAllier = joueurAllier;
            if (contrat == Contrat.Prise && score == 0)
            {
                throw new ArgumentNullException("Le contrat est null et score ne peut pas être zéro");
            }

            Date = new DateTime();
            bool typeJoueur = joueurQuiPrend is Joueur;
            if (typeJoueur != null)
            {
                if (!typeJoueur)
                {
                    throw new ArgumentNullException("Le joueur qui prend ne peut pas être null");
                }
                JoueurQuiPrend = joueurQuiPrend;
            }
            if (score < 0 || score == null)
            {
                throw new ArgumentNullException("Le score du joueur ne peut pas être négatif");
            }
            Score = score;
            Date = new DateTime();
            NbJoueur = nbJoueur;
            Id = id;

        }

        public Manche(Contrat contrat, Joueur joueurQuiPrend, int score, List<Bonus> bonus, int nbJoueur, Joueur joueurAllier = null)
        {
            Contrat = contrat;
            Bonus = new List<Bonus>();
            if (bonus != null)
            {
                Bonus.AddRange(bonus);
            }
            if (contrat == Contrat.Prise && score == 0)
            {
                throw new ArgumentNullException("Le contrat est null et score ne peut pas être zéro");
            }

            JoueurAllier = joueurAllier;
            bool typeJoueur = joueurQuiPrend is Joueur;
            if (typeJoueur != null)
            {
                if (!typeJoueur)
                {
                    throw new ArgumentNullException("Le joueur qui prend ne peut pas être null");
                }
                JoueurQuiPrend = joueurQuiPrend;

            }
            if (score < 0 || score == null)
            {
                throw new ArgumentNullException("Le score du joueur ne peut pas être négatif");
            }
            Score = score;
            Date = new DateTime();
            NbJoueur = nbJoueur;

        }

        public int getScoreJoueurManche(Joueur joueur)
        {
            Calculator calcule = new Calculator();
            if (joueur.Equals(JoueurQuiPrend))
            {
                if (JoueurAllier != null)
                {
                    return calcule.scoreFinalJoueurQuiPrendAvecAllier(calcule.calculeScoreJoueurQuiPrend(Bonus, Contrat, Score), NbJoueur);
                }
                else
                {
                    return calcule.scoreFinalJoueurQuiPrend(calcule.calculeScoreJoueurQuiPrend(Bonus, Contrat, Score), NbJoueur);
                }
            }
            else if (JoueurAllier != null)
            {
                if (joueur.Equals(JoueurAllier))
                {
                    return calcule.calculeScoreJoueurQuiPrend(Bonus, Contrat, Score);
                }
                else
                {
                    return calcule.calculScoreAutreJoueur(calcule.calculeScoreJoueurQuiPrend(Bonus, Contrat, Score));
                }
            }
            else
            {
                return calcule.calculScoreAutreJoueur(calcule.calculeScoreJoueurQuiPrend(Bonus, Contrat, Score));
            }
        }

        public bool Equals(Manche manche)
        {
            return manche.Id == Id;

        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Manche);

        }



    }
}

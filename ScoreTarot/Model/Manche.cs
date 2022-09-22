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
        public Joueur JoueurQuiPrend { get; private set; }

        public Joueur JoueurAllier { get; private set; }
        public int Score{get; private set ; }
        public DateTime Date {get; private set;}
        public int Id { get; private set; }
        public int NbJoueur { get; private set; }

        public Manche(Contrat contrat, Joueur joueurQuiPrend, int id, int score, List<Bonus> bonus = null, Joueur joueurAllier = null)
        {
            Contrat = contrat;
            Bonus = new List<Bonus>();
            Bonus.AddRange(bonus);
            JoueurQuiPrend = joueurQuiPrend;
            JoueurAllier = joueurAllier;
            Score = score;
            Date = new DateTime();
            
            Id = id;
        }

        public Manche(Contrat contrat, Joueur joueurQuiPrend, int score, List<Bonus> bonus = null, Joueur joueurAllier = null)
        {
            Contrat = contrat;
            Bonus = new List<Bonus>();
            Bonus.AddRange(bonus);
            JoueurQuiPrend = joueurQuiPrend;
            JoueurAllier = joueurAllier;
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

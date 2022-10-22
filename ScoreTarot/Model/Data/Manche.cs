using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Manche :IEquatable<Manche>
    {
        public Contrat Contrat{ get; private set; }
        public Bonus Bonus { get; private set; }
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

        /// <summary>
        /// Constructeur de manche avec un id de la base de donnée, le jourAllier n'est pas obligatoire pour une partie.
        /// </summary>
        /// <param name="id"></param> identifiant unique de la manche pour la base de donnée
        /// <param name="contrat"></param> contrat du joueur qui prend
        /// <param name="joueurQuiPrend"></param> joueur qui a pris
        /// <param name="score"></param> total des point des carte du joueur qui prend
        /// <param name="bonus"></param> liste des bonus du joueur qui prend
        /// <param name="nbJoueur"></param> nombre total des joueurs de la partie
        /// <param name="joueurAllier"></param> joueur dessigner par le joueur qui prend au début de la manche, que pour les partie a 5 joueurs
        /// <exception cref="ArgumentNullException"></exception>
        public Manche(int id, Contrat contrat, Joueur joueurQuiPrend, int score, Bonus bonus, int nbJoueur, Joueur joueurAllier = null)
        {
            Contrat = contrat;
            Bonus = bonus;

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

        /// <summary>
        /// Constructeur de manche, le jourAllier n'est pas obligatoire pour une partie.
        /// </summary>
        /// <param name="contrat"></param> contrat du joueur qui prend
        /// <param name="joueurQuiPrend"></param> joueur qui a pris
        /// <param name="score"></param> total des point des carte du joueur qui prend
        /// <param name="bonus"></param> liste des bonus du joueur qui prend
        /// <param name="nbJoueur"></param> nombre total des joueurs de la partie
        /// <param name="joueurAllier"></param> joueur dessigner par le joueur qui prend au début de la manche, que pour les partie a 5 joueurs
        /// <exception cref="ArgumentNullException"></exception>
        public Manche(Contrat contrat, Joueur joueurQuiPrend, int score, Bonus bonus, int nbJoueur, Joueur joueurAllier = null)
        {
            Contrat = contrat;
            Bonus = bonus;
            if (contrat == Contrat.Inconu && score == 0)
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

        /// <summary>
        /// Retourne le score du joueur de la partie mis en paramètre, en fonction de son status (joueurQuiPrend, joueurAllier, autre joueur).
        /// </summary>
        /// <param name="joueur"></param>
        /// <returns></returns>
        public int GetScoreJoueurManche(Joueur joueur)
        {
            Calculator calcule = new Calculator();
            if (joueur.Equals(JoueurQuiPrend))
            {
                if (JoueurAllier != null)
                {
                    return calcule.ScoreFinalJoueurQuiPrendAvecAllier(calcule.CalculeScoreJoueurQuiPrend(Bonus, Contrat, Score), NbJoueur);
                }
                else
                {
                    return calcule.ScoreFinalJoueurQuiPrend(calcule.CalculeScoreJoueurQuiPrend(Bonus, Contrat, Score), NbJoueur);
                }
            }
            else if (JoueurAllier != null)
            {
                if (joueur.Equals(JoueurAllier))
                {
                    return calcule.CalculeScoreJoueurQuiPrend(Bonus, Contrat, Score);
                }
                else
                {
                    return calcule.CalculScoreAutreJoueur(calcule.CalculeScoreJoueurQuiPrend(Bonus, Contrat, Score));
                }
            }
            else
            {
                return calcule.CalculScoreAutreJoueur(calcule.CalculeScoreJoueurQuiPrend(Bonus, Contrat, Score));
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
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public void ModifierManche(Manche nouvelleManche)
        {
            joueurQuiPrend = nouvelleManche.joueurQuiPrend;
            JoueurAllier = nouvelleManche.JoueurAllier;
            score = nouvelleManche.score;
            Bonus = nouvelleManche.Bonus;
            Contrat = nouvelleManche.Contrat;
        }

    }
}

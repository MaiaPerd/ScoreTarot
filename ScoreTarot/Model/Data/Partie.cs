using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Partie :IEquatable<Partie>
    {
        private const int NBJOUEURMIN = 3;
        private const int NBJOUEURMAX = 5;

        public ReadOnlyCollection<Joueur> Joueurs
        {
            get;
            private set;
        }
        private List<Joueur> joueurs = new List<Joueur>();

        /// <summary>
        /// Une partie possède plusieurs manche, il est ainsi plus pratique d'ajouter des manches a tout moments
        /// </summary>
        public ReadOnlyCollection<Manche> Manches
        {
            get;
            private set;
        }
        private List<Manche> manches = new List<Manche>();
        public int Id { get; private set; }

        /// <summary>
        /// Constructeur de partie. Une partie est un ensemble de manche qui son les parties de carte.
        /// La partie a un identifant unique issu de l base de donnée.
        /// </summary>
        /// <param name="id"></param> identifiant unique de la partie
        /// <param name="lJoueur"></param> liste des joueurs de la partie
        /// <param name="lManche"></param> liste des manches de la partie
        /// <exception cref="InvalidDataException"></exception>
        public Partie(int id, IEnumerable<Joueur> lJoueur, IEnumerable<Manche> lManche)
        {
            joueurs = lJoueur.ToList();
            Joueurs = new ReadOnlyCollection<Joueur>(joueurs);
            if (joueurs == null || joueurs.Count < NBJOUEURMIN || joueurs.Count > NBJOUEURMAX)
            {
                throw new InvalidDataException("Nombre de joueur incorrect, il doit être compris entre {NBJOUEURMIN} et {NBJOUEURMAX}");
            }
            joueurs.AddRange(joueurs);
            manches = lManche.ToList();
            Manches = new ReadOnlyCollection<Manche>(manches);
            if (manches != null)
            {
                manches.AddRange(manches);
            }

            Id = id;
        }

        /// <summary>
        /// Constructeur de partie. Une partie est un ensemble de manche qui son les parties de carte.
        /// </summary>
        /// <param name="lJoueur"></param> liste des joueurs de la partie
        /// <param name="lManche"></param> liste des manches de la partie
        /// <exception cref="InvalidDataException"></exception>
        public Partie(IEnumerable<Joueur> lJoueur, IEnumerable<Manche> lManche)
        {
            joueurs = lJoueur.ToList();
            Joueurs = new ReadOnlyCollection<Joueur>(joueurs);
            if (joueurs == null || joueurs.Count < NBJOUEURMIN || joueurs.Count > NBJOUEURMAX)
            {
                throw new InvalidDataException("Nombre de joueur incorrect, il doit être compris entre {NBJOUEURMIN} et {NBJOUEURMAX}");
            }
            joueurs.AddRange(joueurs);
            manches = lManche.ToList();
            Manches = new ReadOnlyCollection<Manche>(manches);
            if (manches != null)
            {
                manches.AddRange(manches);
            }
        }

        /// <summary>
        /// Constructeur de partie. Une partie est un ensemble de manche qui son les parties de carte.
        /// Une partie n'a pas de manche quand on la crée.
        /// </summary>
        /// <param name="lJoueur"></param> liste des joueurs de la partie
        /// <exception cref="InvalidDataException"></exception>
        public Partie(List<Joueur> lJoueur)
        {
            joueurs = lJoueur.ToList();
            Joueurs = new ReadOnlyCollection<Joueur>(joueurs);
            if (joueurs == null || joueurs.Count < NBJOUEURMIN || joueurs.Count > NBJOUEURMAX)
            {
                throw new InvalidDataException("Nombre de joueur incorrect, il doit être compris entre {NBJOUEURMIN} et {NBJOUEURMAX}");
            }
            joueurs.AddRange(joueurs);
            Manches = new ReadOnlyCollection<Manche>(manches);
        }

        /// <summary>
        /// Ajoute une manche a la partie.
        /// </summary>
        /// <param name="manche"></param>
        /// <returns></returns>
        public bool AjouterManche(Manche manche)
        {
            if (!this.manches.Contains(manche) && manche != null) {
                manches.Add(manche);
                return this.manches.Contains(manche);
            }
            return false;
        }

        /// <summary>
        /// Ajoute un joueur a la partie.
        /// </summary>
        /// <param name="joueur"></param>
        /// <returns></returns>
        public bool AjouterJoueur(Joueur joueur)
        {
            if(this.joueurs.Count != NBJOUEURMAX)
            {
                if (!this.joueurs.Contains(joueur) && joueur != null)
                {
                    this.joueurs.Add(joueur);
                    return this.joueurs.Contains(joueur);
                }
            }
            return false;
        }

        /// <summary>
        /// Supprime le joueur donné en paramètre de la liste des joueurs.
        /// </summary>
        /// <param name="joueur"></param>
        /// <returns></returns>
        public bool SupprimerJoueur(Joueur joueur)
        {
            if (this.joueurs.Contains(joueur))
            {   
                return this.joueurs.Remove(joueur);
            }
            return false;
        }

        /// <summary>
        /// Supprime la manche donné en paramètre de la liste des manches.
        /// </summary>
        /// <param name="manche"></param>
        /// <returns></returns>
        public bool SupprimerManche(Manche manche)
        {
            if (this.manches.Contains(manche))
            {   
                return this.manches.Remove(manche);
            }
            return false;
        }

        /// <summary>
        /// Modifie la manche dans la liste des manches.
        /// </summary>
        /// <param name="manche"></param>
        /// <returns></returns>
        public bool ModifierManche(Manche manche)
        {
            if (this.manches.Contains(manche)) {
                bool modif = this.SupprimerManche(manche);
                if (modif)
                {
                    return this.AjouterManche(manche);
                }
            }
            return false;
        }

        /// <summary>
        /// Modifie le joueur dans la liste des joueurs.
        /// </summary>
        /// <param name="joueur"></param>
        /// <returns></returns>
        public bool ModifierJoueur(Joueur joueur)
        {
            if (this.joueurs.Contains(joueur))
            {
                bool modif = this.SupprimerJoueur(joueur);
                if (modif)
                {
                    return this.AjouterJoueur(joueur);
                }
            }
            return false;
        }

        
        public bool Equals(Partie partie)
        {
            return partie.Id == Id;

        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Partie);

        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }



    }
}

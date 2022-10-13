using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Partie :IEquatable<Partie>
    {
        public List<Joueur> Joueurs
        {
            get
            {
                return joueur;
            }

            private set
            {
                if (value == null || value.Count < 3 || value.Count > 5)
                {
                    throw new InvalidDataException("Nombre de joueur incorrect, il doit être compris entre 3 et 5");
                }
                joueur = value;
                
            }
        }
        private List<Joueur> joueur;
        /// <summary>
        /// Une partie possède plusieurs manche, il est ainsi plus pratique d'ajouter des manches a tout moments
        /// </summary>
        public List<Manche> Manches { get; private set; }
        public int Id { get; private set; }

        public Partie(List<Joueur> joueurs, List<Manche> manches, int id)
        {
            joueur = new List<Joueur>();
            if (joueurs == null || joueurs.Count < 3 || joueurs.Count > 5)
            {
                throw new InvalidDataException("Nombre de joueur incorrect, il doit être compris entre 3 et 5");
            }
            Joueurs.AddRange(joueurs);
            Manches = new List<Manche>();
            if (manches != null)
            {
                Manches.AddRange(manches);
            }

            Id = id;
        }

        public Partie(List<Joueur> joueurs, List<Manche> manches)
        {
            joueur = new List<Joueur>();
            if (joueurs == null || joueurs.Count < 3 || joueurs.Count > 5)
            {
                throw new InvalidDataException("Nombre de joueur incorrect, il doit être compris entre 3 et 5");
            }
            Joueurs.AddRange(joueurs);
            Manches = new List<Manche>();
            if (manches != null)
            {
                Manches.AddRange(manches);
            }
        }

        public Partie(List<Joueur> joueurs)
        {
            joueur = new List<Joueur>();
            if (joueurs == null || joueurs.Count < 3 || joueurs.Count > 5)
            {
                throw new InvalidDataException("Nombre de joueur incorrect, il doit être compris entre 3 et 5");
            }
            Joueurs.AddRange(joueurs);
            Manches = new List<Manche>();

        }

        public bool AjouterManche(Manche manche)
        {
            if (!this.Manches.Contains(manche) && manche != null) {
                Manches.Add(manche);
                return this.Manches.Contains(manche);
            }
            return false;
        }
        public bool AjouterJoueur(Joueur joueur)
        {
            if(this.Joueurs.Count != 5)
            {
                if (!this.Joueurs.Contains(joueur) && joueur != null)
                {
                    this.Joueurs.Add(joueur);
                    return this.Joueurs.Contains(joueur);
                }
            }
            return false;
        }
        public bool SupprimerJoueur(Joueur joueur)
        {
            if (this.Joueurs.Contains(joueur))
            {   
                return this.Joueurs.Remove(joueur);
            }
            return false;
        }
        public bool SupprimerManche(Manche manche)
        {
            if (this.Manches.Contains(manche))
            {   
                return this.Manches.Remove(manche);
            }
            return false;
        }
        public bool ModifierManche(Manche manche)
        {
            if (this.Manches.Contains(manche)) {
                bool modif = this.SupprimerManche(manche);
                if (modif)
                {
                    return this.AjouterManche(manche);
                }
            }
            return false;
        }
        public bool ModifierJoueur(Joueur joueur)
        {
            if (this.Joueurs.Contains(joueur))
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

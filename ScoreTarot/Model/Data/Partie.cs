using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Partie
    {
        public List<Joueur> Joueurs
        {
            get;

            private set;
        }
        public List<Manche> Manches { get; private set; }
        public int Id { get; private set; }

        public Partie(List<Joueur> joueurs, List<Manche> manches, int id)
        {

            Joueurs = new List<Joueur>();
            Joueurs.AddRange(joueurs);
            
            Manches= new List<Manche>();
            Manches.AddRange(manches);
            Id = id;
        }

        public Partie(List<Joueur> joueurs, List<Manche> manches)
        {

            Joueurs = new List<Joueur>();
            Joueurs.AddRange(joueurs);

            Manches = new List<Manche>();
            Manches.AddRange(manches);
        }

        public void AjouterManche(Manche manche)
        {
            if (!this.Manches.Contains(manche)) {
                Manches.Add(manche);
            }
        }
        public void AjouterJoueur(Joueur joueur)
        {
            if (!this.Joueurs.Contains(joueur))
            {
                this.Joueurs.Add(joueur);
            }
        }
        public void SupprimerJoueur(Joueur joueur)
        {
            if (this.Joueurs.Contains(joueur))
            {
                this.Joueurs.Remove(joueur);
            }
        }
        public void SupprimerManche(Manche manche)
        {
            if (this.Manches.Contains(manche))
            {
                this.Manches.Remove(manche);
            }
        }
        public void ModifierManche(Manche manche)
        {
            if (this.Manches.Contains(manche)) {
                this.SupprimerManche(manche);
                this.AjouterManche(manche);
            }
        }
        public void ModifierJoueur(Joueur joueur)
        {
            if (this.Joueurs.Contains(joueur))
            {
                this.SupprimerJoueur(joueur);
                this.AjouterJoueur(joueur);
            }
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



    }
}

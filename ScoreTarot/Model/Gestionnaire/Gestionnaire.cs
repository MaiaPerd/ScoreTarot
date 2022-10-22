using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using static System.Formats.Asn1.AsnWriter;

namespace Model.Gestionnaire
{
    public class Gestionnaire
    {
        public ReadOnlyCollection<Joueur> Joueurs
        {
            get;
            private set;
        }
        private List<Joueur> joueurs = new List<Joueur>();


        public ReadOnlyCollection<Partie> Parties
        {
            get;
            private set;
        }
        private List<Partie> parties = new List<Partie>();

        public Gestionnaire()
        {
            Joueurs = new ReadOnlyCollection<Joueur>(joueurs);
            Parties = new ReadOnlyCollection<Partie>(parties);
        }


        public Boolean AjouterUnJoueur(String pseudo, int age, String nom, String prenom)
        {
            if (!joueurs.Contains(new Joueur(pseudo, age, nom, prenom)))
            {
                joueurs.Add(new Joueur(pseudo, age, nom, prenom));
                return true;
            }
            return false;
        }
        public Boolean AjouterUnJoueur(Joueur j)
        {
            if (!joueurs.Contains(j))
            {
                joueurs.Add(j);
                return true;
            }
            return false;
        }

        public void AjouterUneManche(int partie, Contrat contrat, Joueur joueurQuiPrend, int score, Bonus bonus, int nbJoueur, Joueur joueurAllier)
        {
            parties.Find(p => p.Id == partie).AjouterManche(new Manche(contrat, joueurQuiPrend, score, bonus, nbJoueur, joueurAllier));
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Joueur> GetJoueurs()
        {
            return joueurs.AsReadOnly();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Partie> GetParties()
        {
            return parties.AsReadOnly();
        }


        public Partie TrouverPartieAvecID(int id)
        {
            return parties.Find(p => p.Id == id);
        }

        public List<Joueur> listeJoueurVide()
        {
            return new List<Joueur>();
        }

        public Joueur TrouverJoueur(String pseudo)
        {
            return joueurs.Find(j => j.Equals(pseudo));
        }

        public void AjouterUnePartie(List<Joueur> joueurs)
        {
            parties.Add(new Partie(joueurs));
        }

        public void ModfierPartie(Partie partie)
        {
            parties.Remove(partie);// vérifier le remove sur id
            parties.Add(partie);
            
        }

        public void ModifierJoueur(int partie, Joueur joueur)
        {
            parties.Find(p => p.Id == partie).ModifierJoueur(joueur);
        }

        public void ModifierManche(Partie partie, Manche mancheAncienne,Manche mancheNV)
        {
            foreach(Partie p in parties)
            {
                if (p == partie)
                {
                    foreach (Manche m in p.Manches)
                    {
                        if (m == mancheAncienne)
                        {
                            m.modifierManche(mancheNV);
                        }
                    }
                }
            }
        }

        public void AjouterDesPartie(List<Partie> lesPartie)
        {
            parties.AddRange(lesPartie);
        }

        public void AjouterDesManche(Partie partie, List<Manche> lesManches)
        {
            lesManches.ForEach(manche => parties.Find(p => p.Equals(partie)).AjouterManche(manche));
        }

        public void AjouterDesJoueurs(List<Joueur> lesJoueurs)
        {
            joueurs.AddRange(lesJoueurs);
        }
        public void SupprimerJoueur(Joueur joueur)
        {
            if(joueurs.Contains(joueur))
                joueurs.Remove(joueur);
        }
        public void SupprimerPartie(Partie partie)
        {
            if(parties.Contains(partie))
                parties.Remove(partie);
        }
        public Boolean ModifierUnJoueur(Joueur ancien, Joueur nv)
        {
            if (joueurs.Contains(ancien)&&!joueurs.Contains(nv)) {
                Joueur joueurdelalist = ancien;
                foreach (Joueur j in this.joueurs) {
                    if (j == ancien)
                        j.modifierLeJoueur(nv);
                } 
                return true;
            }
            return false;
            
        }

    }
}


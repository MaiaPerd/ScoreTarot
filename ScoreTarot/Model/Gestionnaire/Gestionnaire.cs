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


        public void ajouterUnJoueur(String pseudo, int age, String nom, String prenom)
        {
            joueurs.Add(new Joueur(pseudo, age, nom, prenom));
        }

        public void ajouterUneManche(int partie, Contrat contrat, Joueur joueurQuiPrend, int score, Bonus bonus, int nbJoueur, Joueur joueurAllier)
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


        public Partie trouverPartieAvecID(int id)
        {
            return parties.Find(p => p.Id == id);
        }

        public List<Joueur> listeJoueurVide()
        {
            return new List<Joueur>();
        }

        public Joueur trouverJoueur(String pseudo)
        {
            return joueurs.Find(j => j.Equals(pseudo));
        }

        public void ajouterUnePartie(List<Joueur> joueurs)
        {
            parties.Add(new Partie(joueurs));
        }

        public void modfierPartie(Partie partie)
        {
            parties.Remove(partie);// vérifier le remove sur id
            parties.Add(partie);
            
        }

        public void modifierJoueur(int partie, Joueur joueur)
        {
            parties.Find(p => p.Id == partie).ModifierJoueur(joueur);
        }

        public void modifierManche(int partie, Manche manche)
        {
            parties.Find(p => p.Id == partie).ModifierManche(manche);
        }

        public void ajouterDesPartie(List<Partie> lesPartie)
        {
            parties.AddRange(lesPartie);
        }

        public void ajouterDesManche(Partie partie, List<Manche> lesManches)
        {
            lesManches.ForEach(manche => parties.Find(p => p.Equals(partie)).AjouterManche(manche));
        }

        public void ajouterDesJoueurs(List<Joueur> lesJoueurs)
        {
            joueurs.AddRange(lesJoueurs);
        }
        public void supprimerJoueur(Joueur joueur)
        {
            if(joueurs.Contains(joueur))
                joueurs.Remove(joueur);
        }
        public void supprimerPartie(Partie partie)
        {
            if(parties.Contains(partie))
                parties.Remove(partie);
        }

    }
}


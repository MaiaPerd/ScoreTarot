using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using static System.Formats.Asn1.AsnWriter;

namespace Model.Gestionnaire
{
    public class Gestionnaire
    {
        private List<Joueur> lJoueur;
        private List<Joueur> LJoueur
        {
            get
            {
                return lJoueur;
            }
            set
            {
                lJoueur = value;
            }
            
        }

        private List<Partie> lPartie;
        private List<Partie> LPartie
        {
            get
            {
                return lPartie;
            }
            set
            {
                lPartie = value;
            }
        }
       
        public void ajouterUnJoueur(String pseudo, int age, String nom, String prenom)
        {
            LJoueur.Add(new Joueur(pseudo, age, nom, prenom));
        }

        public void ajouterUneManche(int partie, Contrat contrat, Joueur joueurQuiPrend, int score, List<Bonus> bonus, int nbJoueur, Joueur joueurAllier)
        {
            LPartie.Find(p => p.Id == partie).AjouterManche(new Manche(contrat, joueurQuiPrend, score, bonus, nbJoueur, joueurAllier));
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Joueur> GetJoueurs()
        {
            return LJoueur.AsReadOnly();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Partie> GetParties()
        {
            return LPartie.AsReadOnly();
        }


        public Partie trouverPartieAvecID(int id)
        {
            return LPartie.Find(p => p.Id == id);
        }

        public List<Joueur> listeJoueurVide()
        {
            return new List<Joueur>();
        }

        public Joueur trouverJoueur(String pseudo)
        {
            return LJoueur.Find(j => j.Equals(pseudo));
        }

        public void ajouterUnePartie(List<Joueur> joueurs)
        {
            LPartie.Add(new Partie(joueurs));
        }

        public void modfierPartie(Partie partie)
        {
            LPartie.Remove(partie);// vérifier le remove sur id
            LPartie.Add(partie);
            
        }

        public void modifierJoueur(int partie, Joueur joueur)
        {
            LPartie.Find(p => p.Id == partie).ModifierJoueur(joueur);
        }

        public void modifierManche(int partie, Manche manche)
        {
            LPartie.Find(p => p.Id == partie).ModifierManche(manche);
        }

        public void ajouterDesPartie(List<Partie> lesPartie)
        {
            LPartie.AddRange(lesPartie);
        }

        public void ajouterDesManche(Partie partie, List<Manche> lesManches)
        {
            lesManches.ForEach(manche => LPartie.Find(p => p.Equals(partie)).AjouterManche(manche));
        }

        public void ajouterDesJoueurs(List<Joueur> lesJoueurs)
        {
            LJoueur.AddRange(lesJoueurs);
        }

    }
}


﻿using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace Model.Gestionnaire
{
    public class Gestionnaire
    {
        private List<Joueur> lJoueur;
        public List<Joueur> LJoueur
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
        public List<Partie> LPartie
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

        private Afficheur afficheur = new Afficheur();
        private Sasisseur saisisseur = new Sasisseur();

        public Gestionnaire()
        {
        }

        public void afficherManche(Manche manche, Partie partie)
        {
            afficheur.AfficherDetailManche(manche, partie);
        }
       
        public void ajouterUnJoueur()
        {
            afficheur.AfficherDemandeEntreQuelqueChose("votre pseudo: ");
            string pseudo = "";
            bool pseudoCorrecte = false;
            while (pseudoCorrecte == false)
            {
                pseudo = saisisseur.saisirString();
                if (String.IsNullOrEmpty(pseudo))
                {  
                    afficheur.AfficherErreur("Le pseudo ne peut pas être vide !");
                    afficheur.AfficherDemandeEntreQuelqueChose("votre pseudo: ");
                }
                else
                {
                    pseudoCorrecte = true;
                }  
            }

            int age = this.ajouterEntier("age");
            afficheur.AfficherDemandeEntreQuelqueChose("votre nom: ");
            string nom = saisisseur.saisirString();
            afficheur.AfficherDemandeEntreQuelqueChose("votre prenom: ");
            string prenom = saisisseur.saisirString();
            LJoueur.Add(new Joueur(pseudo, age, nom, prenom));
        }

        public void ajouterUneManche(int partie)
        {
            Contrat contrat = this.choisirContrat();
            Joueur joueurQuiPrend = this.joueurExistantDansPartie(partie, "qui prend");
            int score = this.ajouterEntier("score");
            List<Bonus> bonus = this.choisirBonus();
            int nbJoueur = trouverPartieAvecID(partie).Joueurs.Count;
            Joueur joueurAllier = this.joueurExistantDansPartie(partie, "allier");
            LPartie.Find(p => p.Id == partie).AjouterManche(new Manche(contrat, joueurQuiPrend, score, bonus, nbJoueur, joueurAllier));
        }

        private Contrat choisirContrat()
        {
            int? valContrat = null;
            Contrat contrat = Contrat.Prise;
            while (valContrat == null)
            {
                afficheur.AfficherContrat();
                afficheur.AfficherDemandeChoix();
                valContrat = saisisseur.saisirInt();
                switch (valContrat)
                {
                    case null:
                        afficheur.AfficherErreurChoix();
                        break;
                    case 1:
                        contrat = Contrat.Prise;
                        break;
                    case 2:
                        contrat = Contrat.Garde;
                        break;
                    case 3:
                        contrat = Contrat.GardeSans;
                        break;
                    case 4:
                        contrat = Contrat.GardeContre;
                        break;
                    case 666:
                        afficheur.AfficherMenu();
                        break;
                }
            }
            return contrat;
        }

        private List<Bonus> choisirBonus()
        {
            int? valBonus = null;
            bool fin = false;
            List<Bonus> bonus = new List<Bonus>();
            while (fin)
            {
                afficheur.AfficherBonus();
                afficheur.AfficherDemandeChoix();
                valBonus = saisisseur.saisirInt();
                switch (valBonus)
                {
                    case null:
                        afficheur.AfficherErreurChoix();
                        break;
                    case 1:
                        if (!bonus.Contains(Bonus.Petit))
                        {
                            bonus.Add(Bonus.Petit);
                        }
                        break;
                    case 2:
                        if (!bonus.Contains(Bonus.Petit) && !bonus.Contains(Bonus.PetitAuBout))
                        {
                            bonus.Add(Bonus.Petit);
                            bonus.Add(Bonus.PetitAuBout);
                        }
                        else if (!bonus.Contains(Bonus.PetitAuBout))
                        {
                            bonus.Add(Bonus.PetitAuBout);
                        }
                        break;
                    case 3:
                        if (!bonus.Contains(Bonus.Escuse))
                        {
                            bonus.Add(Bonus.Escuse);
                        }
                        break;
                    case 4:
                        if (!bonus.Contains(Bonus.Le21))
                        {
                            bonus.Add(Bonus.Le21);
                        }
                        break;
                    case 5:
                        if (!bonus.Contains(Bonus.SimplePoignet))
                        {
                            bonus.Add(Bonus.SimplePoignet);   
                        }
                        bonus.Remove(Bonus.TriplePoignet);
                        bonus.Remove(Bonus.DoublePoignet);                     
                        break;
                    case 6:
                        if (!bonus.Contains(Bonus.DoublePoignet))
                        {
                            bonus.Add(Bonus.DoublePoignet);
                        }
                        bonus.Remove(Bonus.TriplePoignet);
                        bonus.Remove(Bonus.SimplePoignet);
                        break;
                    case 7:
                        if (!bonus.Contains(Bonus.TriplePoignet))
                        {
                            bonus.Add(Bonus.TriplePoignet);
                        }
                        bonus.Remove(Bonus.DoublePoignet);
                        bonus.Remove(Bonus.SimplePoignet);
                        break;
                    case 666:
                        fin = true;
                        break;
                }
            }
            return bonus;
        }

        private int ajouterEntier(string quoi)
        {
            int? valeur = null;
            while (valeur == null)
            {
                afficheur.AfficherDemandeEntreQuelqueChose("votre " + quoi + ": ");
                valeur = saisisseur.saisirInt();
                if (valeur == null)
                {
                    afficheur.AfficherErreur("Veuillez saisir un chiffre !");
                    break;
                }
                if (valeur < 0)
                {
                    afficheur.AfficherErreur("L'age ne peut pas être négatif !");
                }
            }
            return (int)valeur;
        }

        private Joueur joueurExistantDansPartie(int partie, string prend)
        {
            Joueur joueur= LJoueur[0];
            string pseudo = "";
            bool pseudoCorrecte = false;
            while (pseudoCorrecte == false)
            {
                afficheur.AfficherDemandeEntreQuelqueChose("le joueur "+prend+" : ");
                pseudo = saisisseur.saisirString();
                if(prend.Equals("allier") && String.IsNullOrEmpty(pseudo))
                {
                    return null;
                }
                List<Joueur> joueurs = trouverPartieAvecID(partie).Joueurs;
                joueur = joueurs.Find(j => j.Equals(pseudo));
                if (joueur is not Joueur)
                {
                    afficheur.AfficherErreur("Le joueur ne fait pas partie de cette partie!");
                }
                else
                {
                    pseudoCorrecte = true;
                }
            }
            return joueur;
        }

        private Joueur joueurExistantDansLaListe()
        {
            Joueur joueur = LJoueur[0];
            string pseudo = "";
            bool pseudoCorrecte = false;
            while (pseudoCorrecte == false)
            {
                pseudo = saisisseur.saisirString();
                joueur = LJoueur.Find(j => j.Equals(pseudo));
                if (joueur is not Joueur)
                {
                    afficheur.AfficherErreur("Le joueur ne fait pas partie de cette partie!");
                    ajouterUnJoueur();
                    break;
                }
                else
                {
                    pseudoCorrecte = true;
                }
            }
            return joueur;
        }

        private Partie trouverPartieAvecID(int id)
        {
            return LPartie.Find(p => p.Id == id);
        }

        public void ajouterUnePartie()
        {
            List<Joueur> joueurs = new List<Joueur>();

            afficheur.AfficherDemandeEntreQuelqueChose("les joueurs de la partie");
            afficheur.AfficherDemandeEntreQuelqueChose("le joueur 1");
            joueurs.Add(joueurExistantDansLaListe());
            afficheur.AfficherDemandeEntreQuelqueChose("le joueur 2");
            joueurs.Add(joueurExistantDansLaListe());
            afficheur.AfficherDemandeEntreQuelqueChose("le joueur 3");
            joueurs.Add(joueurExistantDansLaListe());
            int? valeur = 0;
            while(valeur<3 || valeur!=null) {
               afficheur.AfficherDemandeEntreQuelqueChose("1 si vous voulez ajouter un autre joueurs");
               valeur = saisisseur.saisirInt();
               if (valeur == 1)
               {
                    joueurs.Add(joueurExistantDansLaListe());
                }
            }
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

        public void afficherPartie()
        {
            afficheur.AfficherLesPartie(LPartie);
        }

        public void afficherJoueur(Joueur joueur)
        {
            afficheur.AfficherJoueur(joueur);
        }

        public void afficherJoueurs()
        {
            LJoueur.ForEach(joueur => afficheur.AfficherJoueur(joueur));
        }
    }
}


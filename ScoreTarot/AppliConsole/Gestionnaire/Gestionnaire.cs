using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using AppliConsole.InterfaceUtilisateur;
using Model;
using Model.Gestionnaire;

namespace AppliConsole.Gestionnaire
{
    public class Gestionnaire
    {
        private readonly Model.Gestionnaire.Gestionnaire gestionnaire = new Model.Gestionnaire.Gestionnaire();

        private readonly Afficheur afficheur = new Afficheur();
        private readonly Sasisseur saisisseur = new Sasisseur();

        public Gestionnaire()
        {
        }

        public void AfficherManche(Manche manche, Partie partie)
        {
            afficheur.AfficherDetailManche(manche, partie);
        }
       
        public void AjouterUnJoueur()
        {
            afficheur.AfficherDemandeEntreQuelqueChose("votre pseudo: ");
            string pseudo = "";
            bool pseudoCorrecte = true;
            while (pseudoCorrecte)
            {
                pseudo = saisisseur.SaisirString();
                if (String.IsNullOrEmpty(pseudo))
                {  
                    afficheur.AfficherErreur("Le pseudo ne peut pas être vide !");
                    afficheur.AfficherDemandeEntreQuelqueChose("votre pseudo: ");
                }
                else
                {
                    pseudoCorrecte = false;
                }  
            }

            int age = this.AjouterEntier("age");
            afficheur.AfficherDemandeEntreQuelqueChose("votre nom: ");
            string nom = saisisseur.SaisirString();
            afficheur.AfficherDemandeEntreQuelqueChose("votre prenom: ");
            string prenom = saisisseur.SaisirString();
            gestionnaire.ajouterUnJoueur(pseudo, age, nom, prenom);
        }

        public void AjouterUneManche(int partie)
        {
            Contrat contrat = this.ChoisirContrat();
            Joueur joueurQuiPrend = this.JoueurExistantDansPartie(partie, "qui prend");
            int score = this.AjouterEntier("score");
            List<Bonus> bonus = this.ChoisirBonus();
            int nbJoueur = TrouverPartieAvecID(partie).Joueurs.Count;
            Joueur joueurAllier = this.JoueurExistantDansPartie(partie, "allier");
            gestionnaire.ajouterUneManche(partie, contrat, joueurQuiPrend, score, bonus, nbJoueur, joueurAllier);
        }

        private Contrat ChoisirContrat()
        {
            int? valContrat = null;
            Contrat contrat = Contrat.Prise;
            while (valContrat == null)
            {
                afficheur.AfficherContrat();
                afficheur.AfficherDemandeChoix();
                valContrat = saisisseur.SaisirInt();
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

        private List<Bonus> ChoisirBonus()
        {
            int? valBonus = null;
            bool fin = true;
            List<Bonus> bonus = new List<Bonus>();
            while (fin)
            {
                afficheur.AfficherBonus();
                afficheur.AfficherDemandeChoix();
                valBonus = saisisseur.SaisirInt();
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
                        if (!bonus.Contains(Bonus.SimplePoignee))
                        {
                            bonus.Add(Bonus.SimplePoignee);   
                        }
                        bonus.Remove(Bonus.TriplePoignee);
                        bonus.Remove(Bonus.DoublePoignee);                     
                        break;
                    case 6:
                        if (!bonus.Contains(Bonus.DoublePoignee))
                        {
                            bonus.Add(Bonus.DoublePoignee);
                        }
                        bonus.Remove(Bonus.TriplePoignee);
                        bonus.Remove(Bonus.SimplePoignee);
                        break;
                    case 7:
                        if (!bonus.Contains(Bonus.TriplePoignee))
                        {
                            bonus.Add(Bonus.TriplePoignee);
                        }
                        bonus.Remove(Bonus.DoublePoignee);
                        bonus.Remove(Bonus.SimplePoignee);
                        break;
                    case 666:
                        fin = false;
                        break;
                }
            }
            return bonus;
        }

        private int AjouterEntier(string quoi)
        {
            int? valeur = null;
            while (valeur == null)
            {
                afficheur.AfficherDemandeEntreQuelqueChose("votre " + quoi + ": ");
                valeur = saisisseur.SaisirInt();
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

        private Joueur JoueurExistantDansPartie(int partie, string prend)
        {
            Joueur joueur = gestionnaire.GetJoueurs()[0];
            string pseudo = "";
            bool pseudoCorrecte = false;
            while (pseudoCorrecte == false)
            {
                afficheur.AfficherDemandeEntreQuelqueChose("le joueur "+prend+" : ");
                pseudo = saisisseur.SaisirString();
                if(prend.Equals("allier") && String.IsNullOrEmpty(pseudo))
                {
                    return null;
                }
                List<Joueur> joueurs = TrouverPartieAvecID(partie).Joueurs;
                joueur = gestionnaire.trouverJoueur(pseudo);
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

        private Joueur JoueurExistantDansLaListe()
        {
            Joueur joueur = gestionnaire.GetJoueurs()[0];
            string pseudo = "";
            bool pseudoCorrecte = false;
            while (pseudoCorrecte == false)
            {
                pseudo = saisisseur.SaisirString();
                joueur = gestionnaire.trouverJoueur(pseudo);
                if (joueur is not Joueur)
                {
                    afficheur.AfficherErreur("Le joueur ne fait pas partie de cette partie!");
                    AjouterUnJoueur();
                    break;
                }
                else
                {
                    pseudoCorrecte = true;
                }
            }
            return joueur;
        }

        private Partie TrouverPartieAvecID(int id)
        {
            return gestionnaire.trouverPartieAvecID(id);
        }

        public void AjouterUnePartie()
        {
            List<Joueur> joueurs = gestionnaire.listeJoueurVide();

            afficheur.AfficherDemandeEntreQuelqueChose("les joueurs de la partie");
            afficheur.AfficherDemandeEntreQuelqueChose("le joueur 1");
            joueurs.Add(JoueurExistantDansLaListe());
            afficheur.AfficherDemandeEntreQuelqueChose("le joueur 2");
            joueurs.Add(JoueurExistantDansLaListe());
            afficheur.AfficherDemandeEntreQuelqueChose("le joueur 3");
            joueurs.Add(JoueurExistantDansLaListe());
            int? valeur = 0;
            while(valeur<3 || valeur!=null) {
               afficheur.AfficherDemandeEntreQuelqueChose("1 si vous voulez ajouter un autre joueurs");
               valeur = saisisseur.SaisirInt();
               if (valeur == 1)
               {
                    joueurs.Add(JoueurExistantDansLaListe());
                }
            }
            gestionnaire.ajouterUnePartie(joueurs);

        }

        public void ModfierPartie(Partie partie)
        {
            gestionnaire.modfierPartie(partie);
            
        }

        public void ModifierJoueur(int partie, Joueur joueur)
        {
            gestionnaire.modifierJoueur(partie, joueur);
        }

        public void ModifierManche(int partie, Manche manche)
        {
            gestionnaire.modifierManche(partie, manche);
        }

        public void AjouterDesPartie(List<Partie> lesPartie)
        {
            gestionnaire.ajouterDesPartie(lesPartie);
        }

        public void AjouterDesManche(Partie partie, List<Manche> lesManches)
        {
            gestionnaire.ajouterDesManche(partie, lesManches);
        }

        public void AjouterDesJoueurs(List<Joueur> lesJoueurs)
        {
            gestionnaire.ajouterDesJoueurs(lesJoueurs);
        }

        public void AfficherPartie()
        {
            afficheur.AfficherLesPartie(gestionnaire.GetParties());
        }

        public void AfficherJoueur(Joueur joueur)
        {
            afficheur.AfficherJoueur(joueur);
        }

        public void AfficherJoueurs()
        {
            foreach(Joueur joueur in gestionnaire.GetJoueurs())
            {
                afficheur.AfficherJoueur(joueur);
            }
        }
        public void SupprimerJoueur()
        {
            afficheur.AfficherlisteJoueur(gestionnaire.GetJoueurs());
            afficheur.AfficherDemandeChoixObject("du joueur");
            int choix = (int)saisisseur.SaisirInt();
            while (choix <0 && choix > gestionnaire.GetJoueurs().Count)
            {
                afficheur.AfficherErreurChoix();
                choix = (int)saisisseur.SaisirInt();
            }
            Joueur jouerAsupprimer = gestionnaire.GetJoueurs()[choix];
            gestionnaire.supprimerJoueur(jouerAsupprimer);
        }
        public void SupprimerPartie()
        {
            afficheur.AfficherLesPartie(gestionnaire.GetParties());
            afficheur.AfficherDemandeChoixObject("de la partie");
            int choix = (int)saisisseur.SaisirInt();
            while (choix < 0 && choix > gestionnaire.GetParties().Count)
            {
                afficheur.AfficherErreurChoix();
                choix = (int)saisisseur.SaisirInt();
            }
            Partie partieASupprimer = gestionnaire.GetParties()[choix];
            gestionnaire.supprimerPartie(partieASupprimer);
        }

        public void ModifierUnJoueur()
        {
            afficheur.AfficherlisteJoueur(gestionnaire.GetJoueurs());
            afficheur.AfficherDemandeChoixObject("du joueur");
            int choix = (int)saisisseur.SaisirInt();
            while (choix < 0 && choix > gestionnaire.GetJoueurs().Count)
            {
                afficheur.AfficherErreur(" choix du joueur incorrect");
                choix = (int)saisisseur.SaisirInt();
            }
            Joueur joueurAModifier = gestionnaire.GetJoueurs()[choix];
            Joueur joueurModifier = ModifierUnJoueur(joueurAModifier);

        }
        private Joueur ModifierUnJoueur(Joueur joueurAModifier)
        {
            afficheur.AfficherJoueur(joueurAModifier);
            string pseudo = joueurAModifier.Pseudo;
            int age = joueurAModifier.Age;
            string img = joueurAModifier.URLIMG;
            string prenom = joueurAModifier.Prenom;
            string nom = joueurAModifier.Nom;
            int choix=DemandeModif("le pseudo");
            if (choix == 1)
            {
                string pseudochoisis = "";
                bool pseudoCorrecte = true;
                while (pseudoCorrecte)
                {
                    pseudo = saisisseur.SaisirString();
                    if (String.IsNullOrEmpty(pseudo))
                    {
                        afficheur.AfficherErreur("Le pseudo ne peut pas être vide !");
                        afficheur.AfficherDemandeEntreQuelqueChose("votre pseudo: ");
                    }
                    else
                    {
                        pseudoCorrecte = false;
                    }
                }
                pseudo = pseudochoisis;
            }
            choix = DemandeModif("l'age");
            if (choix == 1)
            {
                age = (int)saisisseur.SaisirInt();
            }
            choix = DemandeModif("le nom");
            if(choix == 1)
            {
                nom = saisisseur.SaisirString();
            }
            choix = DemandeModif("le prenom");
            if (choix == 1)
            {
                prenom = saisisseur.SaisirString();
            }
            choix = DemandeModif("l image");
            if (choix == 1)
            {
                img = saisisseur.SaisirString();
            }


            return new Joueur(pseudo, age, nom, prenom, img);
        }
        private int DemandeModif(String quoi)
        {
            afficheur.Afficherdemandemodif(quoi);
            int choix;
            afficheur.AfficherDemandeEntreQuelqueChose(" 1 pour oui et 0 pour non");
            choix = (int)saisisseur.SaisirInt();
            while (choix != 0 || choix != 1)
            {
                afficheur.AfficherErreur("choix incorrect");
                choix = (int)saisisseur.SaisirInt();
            }
            return choix;
        }
    }
}


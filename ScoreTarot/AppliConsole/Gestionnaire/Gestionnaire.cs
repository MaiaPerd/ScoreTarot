using System;
using System.Collections.ObjectModel;
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

        private readonly Afficheur afficheur = new();
        private readonly Sasisseur saisisseur = new();

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
            Boolean bienfait = gestionnaire.AjouterUnJoueur(pseudo, age, nom, prenom);
            if (!bienfait)
                afficheur.AfficherErreur("une erreur s'est produite");
        }
        /// <summary>
        /// permet de choisir rentrer une manche dans une partie
        /// </summary>
        /// <param name="partie"></param>
        private void AjouterUneManche(int partie)
        {
            Contrat contrat = this.ChoisirContrat();
            Joueur joueurQuiPrend = this.selectionnerJoueurDansList(gestionnaire.Parties[partie]);
            int score = this.AjouterEntier("score");
            Bonus bonus = this.ChoisirBonus();
            int nbJoueur = TrouverPartieAvecID(partie).Joueurs.Count;
            Joueur joueurAllier = this.selectionnerJoueurDansList(gestionnaire.Parties[partie]);
            gestionnaire.AjouterUneManche(partie, contrat, joueurQuiPrend, score, bonus, nbJoueur, joueurAllier);
        }
        /// <summary>
        /// est appelé par le program lorsque le joueur veut ajouter une manche
        /// il doit choisir a quel partie il veut l'ajouter puis rentrer les données pour créer une manche
        /// </summary>
        public void AjouterUneManche()
        {
            afficheur.AfficherLesPartie(gestionnaire.Parties);
            int choixPartie = this.ChoisirElementCorectDUneList(gestionnaire.Parties.Count);
            AjouterUneManche(choixPartie);
        }
        public Joueur selectionnerJoueurDansList(Partie partie)
        {
            afficheur.AfficherlisteJoueur(partie.Joueurs);
            afficheur.AfficherDemandeChoixObject("de joueur");
            int choix = ChoisirElementCorectDUneList(partie.Joueurs.Count);
            return partie.Joueurs[choix];
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

        private Bonus ChoisirBonus()
        {
            int? valBonus = null;
            bool fin = true;
            Bonus bonus = Bonus.Inconu;
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
                        if (!(bonus == Bonus.Petit))
                        {
                            bonus |= Bonus.Petit;
                        }
                        break;
                    case 2:
                        if (!(bonus == Bonus.Petit) && !(bonus == Bonus.PetitAuBout))
                        {
                            bonus |= Bonus.Petit;
                            bonus |= Bonus.PetitAuBout;
                        }
                        else if (!(bonus == Bonus.PetitAuBout))
                        {
                            bonus |= Bonus.PetitAuBout;
                        }
                        break;
                    case 3:
                        if (!(bonus == Bonus.Excuse))
                        {
                            bonus |= Bonus.Excuse;
                        }
                        break;
                    case 4:
                        if (!(bonus == Bonus.Le21))
                        {
                            bonus |= Bonus.Le21;
                        }
                        break;
                    case 5:
                        if (!(bonus == Bonus.SimplePoignee))
                        {
                            bonus |= Bonus.SimplePoignee;
                        }
                        bonus ^= Bonus.DoublePoignee;
                        bonus ^= Bonus.TriplePoignee;
                        break;
                    case 6:
                        if (!(bonus == Bonus.DoublePoignee))
                        {
                            bonus |= Bonus.DoublePoignee;
                        }
                        bonus ^= Bonus.SimplePoignee;
                        bonus ^= Bonus.TriplePoignee;
                        break;
                    case 7:
                        if (!(bonus == Bonus.TriplePoignee))
                        {
                            bonus |= Bonus.TriplePoignee;
                        }
                        bonus ^= Bonus.SimplePoignee;
                        bonus ^= Bonus.DoublePoignee;
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
                valeur = SaisirInt();
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
                ReadOnlyCollection<Joueur> joueurs = TrouverPartieAvecID(partie).Joueurs;
                joueur = gestionnaire.TrouverJoueur(pseudo);
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
                joueur = gestionnaire.TrouverJoueur(pseudo);
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
            return gestionnaire.TrouverPartieAvecID(id);
        }
        /// <summary>
        /// permet a l'utilisateur d'ajouter une partie si il y a assez de joueurs. 
        ///
        /// </summary>
        public void AjouterUnePartie()
        {
            if (gestionnaire.Joueurs.Count <3)
                afficheur.AfficherErreur("\naucun joueur n'est enregistré ou pas assez, la création d'une partie est donc impossible.\n");
            else
            {
                List<Joueur> joueurs = gestionnaire.listeJoueurVide();
                List<Joueur> joueursPasDansLaPartie=new();
                joueursPasDansLaPartie.AddRange(gestionnaire.Joueurs);
                afficheur.AfficherlisteJoueur(joueursPasDansLaPartie.AsReadOnly());
                afficheur.AfficherDemandeEntreQuelqueChose("les joueurs de la partie");
                int choixjoueur;
                int continuer = 1;
                while (continuer == 1)
                {
                    choixjoueur = this.ChoisirElementCorectDUneList(joueursPasDansLaPartie.Count);
                    joueurs.Add(joueursPasDansLaPartie[choixjoueur]);
                    joueursPasDansLaPartie.Remove(joueursPasDansLaPartie[choixjoueur]);
                    afficheur.AfficherlisteJoueur(joueursPasDansLaPartie.AsReadOnly());
                    if(joueurs.Count>=3)
                        continuer = this.DemandeUnAutre("un joueur");
                }
                gestionnaire.AjouterUnePartie(joueurs);
            }
        }

        public void ModfierPartie(Partie partie)
        {
            gestionnaire.ModfierPartie(partie);
            
        }

        public void ModifierJoueur(int partie, Joueur joueur)
        {
            gestionnaire.ModifierJoueur(partie, joueur);
        }

        public void ModifierManche(int partie, Manche manche)
        {
            gestionnaire.ModifierManche(partie, manche);
        }

        public void AjouterDesPartie(List<Partie> lesPartie)
        {
            gestionnaire.AjouterDesPartie(lesPartie);
        }

        public void AjouterDesManche(Partie partie, List<Manche> lesManches)
        {
            gestionnaire.AjouterDesManche(partie, lesManches);
        }

        public void AjouterDesJoueurs(List<Joueur> lesJoueurs)
        {
            gestionnaire.AjouterDesJoueurs(lesJoueurs);
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
            if (gestionnaire.GetJoueurs().Count == 0)
                afficheur.AfficherErreur("\naucun joueurs\n");
            else
                foreach(Joueur joueur in gestionnaire.GetJoueurs())
                {
                    afficheur.AfficherJoueur(joueur);
                }
        }
        public void SupprimerJoueur()
        {
            if (gestionnaire.GetJoueurs().Count == 0)
                afficheur.AfficherErreur("\naucun joueur a supprimer\n");
            else
            {
                afficheur.AfficherlisteJoueur(gestionnaire.GetJoueurs());
                afficheur.AfficherDemandeChoixObject("du joueur");
                int choix = ChoisirElementCorectDUneList(gestionnaire.GetJoueurs().Count);
                Joueur jouerAsupprimer = gestionnaire.GetJoueurs()[choix];
                gestionnaire.SupprimerJoueur(jouerAsupprimer);
            }
        }
        public void SupprimerPartie()
        {
            if (gestionnaire.GetParties().Count == 0)
                afficheur.AfficherErreur("\naucune partie a supprimer\n");
            else
            {
                afficheur.AfficherLesPartie(gestionnaire.GetParties());
                afficheur.AfficherDemandeChoixObject("de la partie");
                int choix = ChoisirElementCorectDUneList(gestionnaire.GetParties().Count);
                Partie partieASupprimer = gestionnaire.GetParties()[choix];
                gestionnaire.SupprimerPartie(partieASupprimer);
            }
        }

        public void ModifierUnJoueur()
        {
            if (gestionnaire.Joueurs.Count == 0)
            {
                afficheur.AfficherErreur("\naucun joueur a modifier\n");
            }
            else
            {
                afficheur.AfficherlisteJoueur(gestionnaire.GetJoueurs());
                afficheur.AfficherDemandeChoixObject("du joueur");
                int choix = ChoisirElementCorectDUneList(gestionnaire.GetJoueurs().Count);
                Joueur joueurAModifier = gestionnaire.GetJoueurs()[choix];
                Joueur joueurModifier = ModifierUnJoueur(joueurAModifier);
                Boolean bienfait= gestionnaire.ModifierUnJoueur(joueurAModifier, joueurModifier);
                if (!bienfait)
                    afficheur.AfficherErreur("une erreur s'est produite");
            }
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
                    pseudochoisis = saisisseur.SaisirString();
                    if (String.IsNullOrEmpty(pseudochoisis))
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
                age = SaisirInt();
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
            return new Joueur(pseudo, age, nom, prenom);
        }
        private int DemandeModif(String quoi)
        {
            afficheur.Afficherdemandemodif(quoi);
            int choix;
            afficheur.AfficherDemandeEntreQuelqueChose(" 1 pour oui et 0 pour non");
            choix = SaisirInt();
            while (choix < 0 || choix > 1)
            {
                afficheur.AfficherErreur("choix incorrect");
                choix = SaisirInt();
            }
            return choix;
        }
        private int DemandeUnAutre(String quoi)
        {
            afficheur.AfficherDemandeRessaisi(quoi);
            int choix;
            afficheur.AfficherDemandeEntreQuelqueChose(" 1 pour oui et 0 pour non");
            choix = SaisirInt();
            while (choix < 0 || choix > 1)
            {
                afficheur.AfficherErreur("choix incorrect");
                choix = SaisirInt();
            }
            return choix;
        }
        public void ModifierPartie()
        {
            if (gestionnaire.Parties.Count == 0)
                afficheur.AfficherErreur("\naucune partie a modifier");
            else
            {
                afficheur.AfficherLesPartie(gestionnaire.Parties);
                int choix = DemandeModif("une partie");
                if (choix == 1)
                {
                    int choixpartie;
                    afficheur.AfficherDemandeChoixObject("de la partie");
                    choixpartie = ChoisirElementCorectDUneList(gestionnaire.Parties.Count);
                    afficheur.AfficherDetailPartie(gestionnaire.Parties[choixpartie]);
                    int demandeSiModifManche = DemandeModif("une manche de cette partie");
                    if (demandeSiModifManche == 1)
                    {
                        afficheur.AfficherDemandeChoixObject("de la manche");
                        int choixmanche = ChoisirElementCorectDUneList(gestionnaire.Parties[choixpartie].Manches.Count);
                        int choixmodifContrat = DemandeModif("le contrat");
                        if (choixmodifContrat == 1)
                        {
                            Contrat c = this.ChoisirContrat();
                        }
                        int choixmodifJoueurAllier = DemandeModif("le Joueur Allier");
                        List<Joueur> lesJoueursDeLaPartie = new();
                        lesJoueursDeLaPartie.AddRange(gestionnaire.Parties[choixpartie].Joueurs);
                        if (choixmodifJoueurAllier == 1)
                        {
                            afficheur.AfficherlisteJoueur(lesJoueursDeLaPartie.AsReadOnly());
                            int choixnewJoueurAllier = ChoisirElementCorectDUneList(lesJoueursDeLaPartie.Count);
                        }
                        int choixmodifJoueurQuiPrend = DemandeModif("le joueur qui prend");
                        if (choixmodifJoueurQuiPrend == 1)
                        {
                            afficheur.AfficherlisteJoueur(lesJoueursDeLaPartie.AsReadOnly());
                            int choixnewJoueurQuiPrend = ChoisirElementCorectDUneList(lesJoueursDeLaPartie.Count);
                        }
                        int choixmodifScore = DemandeModif("le score");
                        if (choixmodifScore == 1)
                        {
                            afficheur.AfficherDemandeEntreQuelqueChose("le score");
                            int score = SaisirInt();
                            while (score < 0 && score > 91)
                            {
                                afficheur.AfficherErreur("le score doit etre entre 0 et 91");
                                score = SaisirInt();
                            }
                        }
                        int choisirmodifBonus = DemandeModif("les bonus");
                        Bonus lesBonus = Bonus.Inconu;//gestionnaire.Parties[choixpartie].Manches[choixmanche].Bonus;
                        if (choisirmodifBonus == 1)
                        {
                            lesBonus = ChoisirBonus();
                        }

                    }
                }
            }
        }
        private int ChoisirElementCorectDUneList(int sizeOfTheList)
        {
            int choixObjet = SaisirInt();
            while (choixObjet < 0 || choixObjet > sizeOfTheList)
            {
                afficheur.AfficherErreur("mauvais choix, recommencez");
                choixObjet = SaisirInt();
            }
            return choixObjet;
        }
        private int RessaisiCorrect(int sizeOFlist,List<int> dejaChoisis)
        {
            int choixObject = SaisirInt();
            while (choixObject<0||dejaChoisis.Contains(choixObject)||choixObject>sizeOFlist)
            {
                afficheur.AfficherErreur("mauvais choix, recommencez");
                choixObject = SaisirInt();
            }
            return choixObject;
        }
        public int SaisirInt()
        {
            int intsaisi;
            try
            {
                intsaisi = (int)saisisseur.SaisirInt();
            }catch(Exception e)
            {
                afficheur.AfficherErreur("erreur de saisie, recommencez");
                intsaisi = SaisirInt();
            }
            return intsaisi;
        }

    }
}


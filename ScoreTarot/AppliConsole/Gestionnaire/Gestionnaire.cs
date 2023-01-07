using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using AppliConsole.InterfaceUtilisateur;
using EntityFramework;
using Model;
using Model.Gestionnaire;

namespace AppliConsole.Gestionnaire
{
    public class Gestionnaire
    {
        private readonly Model.Gestionnaire.Gestionnaire gestionnaire = new Model.Gestionnaire.Gestionnaire();
        private readonly DataManager dataManager = new DataManager();

        private readonly Afficheur afficheur = new();
        private readonly Sasisseur saisisseur = new();

        public Gestionnaire()
        {
            initialiseDonnees();
        }

        public async Task initialiseDonnees()
        {
            using (var context = new SQLiteContext())
            {
                context.Database.EnsureCreated();

                IEnumerable<Joueur> joueurs = await dataManager.getJoueurs();
                joueurs.ToList().ForEach(j => gestionnaire.AjouterUnJoueur(j.Pseudo, j.Age, j.Nom, j.Prenom));

     
                IEnumerable<Partie> parties = await dataManager.getParties();
                
                parties.ToList().ForEach(p => gestionnaire.AjouterUnePartie(p.Joueurs.ToList()));

            }
        }

        public async Task sauvegarder()
        {
            using (var context = new SQLiteContext())
            {
                context.Database.EnsureCreated();

                List<Joueur> joueurs = gestionnaire.Joueurs.ToList();
                List<Partie> parties = gestionnaire.Parties.ToList();
                joueurs.ForEach(j => dataManager.addJoueur(j));
                parties.ForEach(p => dataManager.addPartie(p));
            }
        }

        public Model.Gestionnaire.Gestionnaire GetGestionnaire()
        {
            return gestionnaire;
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
            if (gestionnaire.Parties.Count==0)
            {
                afficheur.AfficherErreur("\naucune partie pour ajouter une manche!");
            }
            else {
                Contrat contrat = this.ChoisirContrat();
                Joueur joueurQuiPrend = this.selectionnerJoueurDansList(gestionnaire.Parties[partie], "qui prend");
                int score = this.SaisirScore();
                Bonus bonus = this.ChoisirBonus();
                int nbJoueur = TrouverPartieAvecID(partie).Joueurs.Count;
                int choixallier = DemandeOuiNon("le joueur allier", 2);
                Joueur joueurAllier;
                if (choixallier==1)
                    joueurAllier = this.selectionnerJoueurDansList(gestionnaire.Parties[partie], "allié");
                else
                    joueurAllier = null;
                gestionnaire.AjouterUneManche(partie, contrat, joueurQuiPrend, score, bonus, nbJoueur, joueurAllier);
            }   
        }
        
        /// <summary>
        /// est appelé par le program lorsque le joueur veut ajouter une manche
        /// il doit choisir a quel partie il veut l'ajouter puis rentrer les données pour créer une manche
        /// </summary>
        public void AjouterUneManche()
        {
            afficheur.AfficherLesPartie(gestionnaire.Parties);
            if(gestionnaire.Parties.Count != 0)
            {
                afficheur.AfficherDemandeChoix();
                int choixPartie = this.ChoisirElementCorectDUneList(gestionnaire.Parties.Count);
                AjouterUneManche(choixPartie);
            }
            else
            {
                afficheur.AfficherErreur("\naucune partie pour ajouter une manche!");
            }
           
        }
        /// <summary>
        /// permet de sélectionner un joueur dans la partie, qui représente le joueur allié ou le joueur qui prend
        /// </summary>
        /// <param name="partie"></param>
        /// <param name="qui"></param>
        /// <returns></returns>
        public Joueur selectionnerJoueurDansList(Partie partie,String qui)
        {
            afficheur.AfficherlisteJoueur(partie.Joueurs);
            afficheur.AfficherDemandeChoixObject("du joueur "+qui);
            int choix = ChoisirElementCorectDUneList(partie.Joueurs.Count);
            return partie.Joueurs[choix];
        }

        /// <summary>
        /// Permet de choisir un contrat pour une partie
        /// </summary>
        /// <returns></returns> le contrat choisi
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

        /// <summary>
        /// Permet de choisir un ensembe de bonus, tant que l'utilisateur veut ajouter des bonus ils continues.
        /// </summary>
        /// <returns></returns> une addition d'ennumeration de bonus
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

        /// <summary>
        /// Permet de saisir le score.
        /// </summary>
        /// <returns></returns>
        private int SaisirScore()
        {
            afficheur.AfficherDemandeEntreQuelqueChose("le score");
            int score = SaisirInt();
            while (score < 0 || score > 91)
            {
                afficheur.AfficherErreur("mauvais choix, le score est compris entre 0 et 91, recommencez");
                score = SaisirInt();
            }
            return score;
        }

        /// <summary>
        /// Permet de saisir un entier en function de la demande (quoi)
        /// </summary>
        /// <param name="quoi"></param> ce que l'on veut afficher dans la console
        /// <returns></returns> valeur saisie par l'utilisateur si elle est correct.
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
                List<Joueur> joueurs = new();
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
                    if(joueurs.Count>=3 &&joueursPasDansLaPartie.Count!=0)
                        continuer = this.DemandeOuiNon("un joueur0",0);
                    if(joueursPasDansLaPartie.Count == 0)
                    {
                        continuer = 0;
                    }
                }
                gestionnaire.AjouterUnePartie(joueurs);
            }
        }

       

        public void AfficherPartie()
        {
            afficheur.AfficherLesPartie(gestionnaire.GetParties());
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
            int choix= DemandeOuiNon("le pseudo",1);
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
            choix = DemandeOuiNon("l'age",1);
            if (choix == 1)
            {
                age = SaisirInt();
            }
            choix = DemandeOuiNon("le nom",1);
            if(choix == 1)
            {
                nom = saisisseur.SaisirString();
            }
            choix = DemandeOuiNon("le prenom",1);
            if (choix == 1)
            {
                prenom = saisisseur.SaisirString();
            }
            return new Joueur(pseudo, age, nom, prenom);
        }
        
        /// <summary>
        /// raison : 0 ressaisie
        ///          1 demande modif
        ///          2 si joueur allier
        /// </summary>
        /// <param name="quoi"></param>
        /// <param name="raison"></param>
        /// <returns></returns>
        private int DemandeOuiNon(String quoi,int raison)
        {
            if (raison < 3 || raison > 0)
            {
                if (raison == 0)
                    afficheur.AfficherDemandeRessaisi(quoi);
                if (raison == 1)
                    afficheur.Afficherdemandemodif(quoi);
                if (raison == 2)
                    afficheur.AfficherDemandeSiVeuxSaisir(quoi);
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
            return 0;
        }
        public void ModifierPartie()
        {
            if (gestionnaire.Parties.Count == 0)
                afficheur.AfficherErreur("\naucune partie a modifier");
            else
            {
                afficheur.AfficherLesPartie(gestionnaire.Parties);
                int choix = DemandeOuiNon("une partie",1);
                if (choix == 1)
                {
                    int choixpartie;
                    afficheur.AfficherDemandeChoixObject("de la partie");
                    choixpartie = ChoisirElementCorectDUneList(gestionnaire.Parties.Count);
                    afficheur.AfficherDetailPartie(gestionnaire.Parties[choixpartie]);
                    if(gestionnaire.Parties[choixpartie].Manches.Count() == 0)
                    {
                        afficheur.AfficherErreur("\naucune manche a modifier dans la partie");
                    }
                    else
                    {
                        int demandeSiModifManche = DemandeOuiNon("une manche de cette partie",1);
                        if (demandeSiModifManche == 1)
                        {
                            afficheur.AfficherDemandeChoixObject("de la manche");
                            int choixmanche = ChoisirElementCorectDUneList(gestionnaire.Parties[choixpartie].Manches.Count);
                            int choixmodifContrat = DemandeOuiNon("le contrat",1);
                            //contrat
                            Contrat c= gestionnaire.Parties[choixpartie].Manches[choixmanche].Contrat;
                            if (choixmodifContrat == 1)
                                c = this.ChoisirContrat();
                            //joueur allier
                            int choixmodifJoueurAllier = DemandeOuiNon("le Joueur Allier",1);
                            Joueur joueurAllie = gestionnaire.Parties[choixpartie].Manches[choixmanche].JoueurAllier;
                            if (choixmodifJoueurAllier==1)
                                joueurAllie=selectionnerJoueurDansList(gestionnaire.Parties[choixpartie], "allié");
                            //joueur qui prend
                            int choixmodifJoueurQuiPrend = DemandeOuiNon("le joueur qui prend",1);
                            Joueur joueurQuiPrend = gestionnaire.Parties[choixpartie].Manches[choixmanche].JoueurQuiPrend;
                            if (choixmodifJoueurQuiPrend == 1)
                                joueurQuiPrend = selectionnerJoueurDansList(gestionnaire.Parties[choixpartie], "qui prend");
                            //score
                            int choixmodifScore = DemandeOuiNon("le score",1);
                            int score= gestionnaire.Parties[choixpartie].Manches[choixmanche].Score;
                            score = SaisirScore();

                            int choisirmodifBonus = DemandeOuiNon("les bonus",1);
                            Bonus lesBonus = gestionnaire.Parties[choixpartie].Manches[choixmanche].Bonus;
                            if (choisirmodifBonus == 1)
                            {
                                lesBonus = ChoisirBonus();
                            }
                            Manche nouvelleManche = new Manche( c, joueurQuiPrend, score, lesBonus, gestionnaire.Parties[choixpartie].Joueurs.Count, joueurAllie);
                            gestionnaire.ModifierManche(gestionnaire.Parties[choixpartie], gestionnaire.Parties[choixpartie].Manches[choixmanche], nouvelleManche);
                        }
                    }
                }
            }
        }
        public int ChoisirElementCorectDUneList(int sizeOfTheList)
        {
            sizeOfTheList -= 1;
            int choixObjet = SaisirInt();
            while (choixObjet < 0 || choixObjet > sizeOfTheList)
            {
                afficheur.AfficherErreur("mauvais choix, recommencez");
                choixObjet = SaisirInt();
            }
            return choixObjet;
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
        public void afficherUnePartieEnDetail()
        {
            afficheur.AfficherLesPartie(gestionnaire.Parties);
            if (gestionnaire.Parties.Count != 0)
            {
                afficheur.AfficherDemandeChoix();
                int choixpartie = this.ChoisirElementCorectDUneList(gestionnaire.Parties.Count);
                afficheur.AfficherDetailPartie(gestionnaire.Parties[choixpartie]);
            }
           
        }

    }
}


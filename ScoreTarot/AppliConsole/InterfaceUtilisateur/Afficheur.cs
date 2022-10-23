using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace AppliConsole.InterfaceUtilisateur
{
    public class Afficheur
    {
        public void AfficherMenu()
        {
            Console.WriteLine("\n-----    Menu   ------");
            Console.WriteLine("1 - afficher les parties");
            Console.WriteLine("2 - afficher les joueurs");
            Console.WriteLine("3 - supprimer un joueur");
            Console.WriteLine("4 - modifier un joueur");
            Console.WriteLine("5 - modifier une partie");
            Console.WriteLine("6 - supprimer une partie");
            Console.WriteLine("7 - ajouter une partie");
            Console.WriteLine("8 - ajouter un joueur");
            Console.WriteLine("9 - ajouter une manche");
            Console.WriteLine("10 - afficher les détails d'une partie");
            Console.WriteLine("666- quitter notre belle application\n");
        }
        public void AfficherErreurChoix()
        {
            Console.WriteLine("il faut entrer un chiffre correspondant à un des choix du menu patate");
        }
        public void AfficherDemandeChoix()
        {
            Console.WriteLine("Veuillez entrez un chiffre correspondant a votre choix du menu");
        }
        public void AfficherDetailManche(Manche manche, Partie partie)
        {
            int i=0;
            Console.WriteLine("affichage de la manche du "+manche.Date+ " nombre de joueurs : "+manche.NbJoueur);
            Console.WriteLine("le contrat :" + manche.Contrat);
            Console.WriteLine("Les joueurs et leur score :");
            foreach (Joueur j in partie.Joueurs){
                i++;
                Console.WriteLine(i+" - "+j.Pseudo+" score : "+manche.GetScoreJoueurManche(j));
                
            }
            if(manche.JoueurAllier==null)
                Console.WriteLine(" le jour qui a pris : "+manche.JoueurQuiPrend.Pseudo);
            else
                Console.WriteLine(" le jour qui a pris : " + manche.JoueurQuiPrend.Pseudo+" son allier : "+manche.JoueurAllier.Pseudo);

        }
        public void AfficherJoueur(Joueur joueur)
        {
            Console.WriteLine("\n-- Joueur : "+joueur.Pseudo);
            Console.WriteLine("age : " + joueur.Age);
            if (joueur.Nom != null)
                Console.WriteLine("nom : "+joueur.Nom);
            else
                Console.WriteLine("nom : null");
            if (joueur.Prenom != null)
                Console.WriteLine("prenom : " + joueur.Prenom);
            else
                Console.WriteLine("prenom : null");
        }
        public void AfficherLesPartie(System.Collections.ObjectModel.ReadOnlyCollection<Partie> lesPartie)
        {
            if (lesPartie.Count == 0)
                Console.WriteLine("\n aucune partie \n");
            int i=0;
            Console.WriteLine("affichage des parties:");
            foreach(Partie p in lesPartie)
            {
                if(p.Manches.Count!=0)
                    Console.WriteLine(i+" - nombre de joueurs : "+p.Joueurs.Count+" date de la premiere manche : "+p.Manches.First().Date);
                else
                    Console.WriteLine(i + " - nombre de joueurs : " + p.Joueurs.Count + " aucune manche");
                i++;
            }
        }
        /// <summary>
        /// le parametre quoi permet de mettre par exemple "du joueur" ou "de la partie"
        /// </summary>
        /// <param name="quoi"></param>
        public void AfficherDemandeChoixObject(String quoi)
        {
            Console.WriteLine("Veuillez entrer le numéro "+quoi);
        }
        /// <summary>
        /// le parametre quoi permet de mettre par exemple "le nom du joueur" ou "l'age du joueur"
        /// </summary>
        /// <param name="quoi"></param>
        public void AfficherDemandeEntreQuelqueChose(String quoi)
        {
            Console.WriteLine("Veuillez entrer "+quoi);
        }

        public void AfficherContrat()
        {
            Console.WriteLine("-----    Contrat   ------");
            Console.WriteLine("1 - Prise");
            Console.WriteLine("2 - Garde");
            Console.WriteLine("3 - GardeSans");
            Console.WriteLine("4 - GardeContre");
            Console.WriteLine("666- retourner au menu");
        }

        public void AfficherBonus()
        {
            Console.WriteLine("-----    Bonus   ------");
            Console.WriteLine("1 - Petit");
            Console.WriteLine("2 - PetitAuBout");
            Console.WriteLine("3 - Escuse");
            Console.WriteLine("4 - Le21");
            Console.WriteLine("5 - SimplePoignet");
            Console.WriteLine("6 - DoublePoignet");
            Console.WriteLine("7 - TriplePoignet");
            Console.WriteLine("666- terminer");
        }

        public void AfficherErreur(String erreur)
        {
            Console.WriteLine(erreur);
        }

        public void AfficherlisteJoueur(System.Collections.ObjectModel.ReadOnlyCollection<Joueur> lJoueur)
        {
            if (lJoueur.Count == 0)
                Console.WriteLine("\naucun joueurs\n");
            for(int i = 0; i < lJoueur.Count; i++)
            {
                Console.WriteLine(i +" - "+ lJoueur[i].Pseudo);
            }
        }
        public void Afficherdemandemodif(String quoi)
        {
            Console.WriteLine("voulez vous modifier " + quoi + " ?");
        }

        public void AfficherDetailPartie(Partie partie)
        {
            Console.WriteLine("\n     Les joueurs de la partie: ");
            AfficherlisteJoueur(partie.Joueurs);
            if(partie.Manches.Count()==0)
                Console.WriteLine("\n aucune manche pour cette partie");
            else
            {
                Console.WriteLine("\n      Les manches de la partie: ");
                int i=0;
                foreach (Manche m in partie.Manches)
                {
                    Console.WriteLine(i);
                    AfficherDetailManche(m,partie);
                    i += 1;
                }
            }
        }
        /// <summary>
        /// Demande de ressaisie, exemple Voules vous ressaisir quoi
        /// </summary>
        /// <param name="quoi"></param>
        public void AfficherDemandeRessaisi(String quoi)
        {
            Console.WriteLine("Voules vous ressaisir "+quoi);
        }
        public void AfficherDemandeSiVeuxSaisir(String quoi)
        {
            Console.WriteLine("voules vous saisir " + quoi);
        }

    }
}

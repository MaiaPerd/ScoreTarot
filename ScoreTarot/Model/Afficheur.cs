﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Afficheur
    {
        public void AfficherMenu()
        {
            Console.WriteLine("-----    Menu   ------");
            Console.WriteLine("1 - afficher les parties");
            Console.WriteLine("2 - afficher les joueurs");
            Console.WriteLine("3 - supprimer un joueur");
            Console.WriteLine("4 - modifier un joueur");
            Console.WriteLine("5 - modifier une partie");
            Console.WriteLine("6 - supprimer une partie");
            Console.WriteLine("7 - ajouter une partie");
            Console.WriteLine("8 - ajouter un joueur");
            Console.WriteLine("666- quitter notre belle application");
        }
        public void AfficherErreurChoix()
        {
            Console.WriteLine("il faut entrer un chiffre correspondant à un des choix du menu patate");
        }
        public void AfficherDemandeChoix()
        {
            Console.WriteLine("Veuillez entrez un chiffre correspondant a votre choix du menu");
        }
        public void AfficherDetailManche(Manche manche,Partie partie)
        {
            Calculator calculator = new Calculator();
            int i=0;
            Console.WriteLine("affichage de la manche du "+manche.Date+ " nombre de joueurs : "+manche.NbJoueur);
            Console.WriteLine("Les joueurs et leur score :");
            foreach (Joueur j in partie.Joueurs){
                i++;
                Console.WriteLine(i+" - "+j.Pseudo+" score : "+manche.getScoreJoueurManche(j));
                
            }
            if(manche.JoueurAllier==null)
                Console.WriteLine(" le jour qui a pris : "+manche.JoueurQuiPrend);
            else
                Console.WriteLine(" le jour qui a pris : " + manche.JoueurQuiPrend.Pseudo+" sans allier : "+manche.JoueurAllier.Pseudo);

        }
        public void AfficherJoueur(Joueur joueur)
        {
            Console.WriteLine(" Joueur : "+joueur.Pseudo);
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
        public void AfficherLesPartie(List<Partie> lesPartie)
        {
            int i=0;
            Console.WriteLine("affichage des parties:");
            foreach(Partie p in lesPartie)
            {
                i++;
                if(p.Manches.Count!=0)
                    Console.WriteLine(i+" - nombre de joueurs : "+p.Joueurs.Count+" date de la premiere manche : "+p.Manches.First().Date);
                else
                    Console.WriteLine(i + " - nombre de joueurs : " + p.Joueurs.Count + "aucune manche");
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
        public void AfficherDemandeEntreQuelsueChose(String quoi)
        {
            Console.WriteLine("Veuillez entrer "+quoi);
        }

    }
}

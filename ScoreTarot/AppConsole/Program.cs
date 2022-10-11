using AppConsole.InterfaceUtilisateur;

namespace AppConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppConsole.Gestionnaire.Gestionnaire gestionnaire = new Gestionnaire.Gestionnaire();
            int choix;
            Afficheur afficheur = new Afficheur();
            Sasisseur saisisseur = new Sasisseur();
            afficheur.AfficherMenu();
            afficheur.AfficherDemandeChoix();
            choix = (int)saisisseur.saisirInt();
            while (choix != 666)
            {
                switch (choix)
                {
                    case 1:
                        {
                            gestionnaire.afficherPartie();
                            break;
                        }
                    case 2:
                        {
                            gestionnaire.afficherJoueurs();
                            break;
                        }
                    case 3:
                        {
                            gestionnaire.supprimerJoueur();
                            break;
                        }
                    case 4:
                        {
                            new Afficheur().AfficherErreur("pas encore fait");
                            break;
                        }
                    case 5:
                        {
                            new Afficheur().AfficherErreur("pas encore fait");
                            break;
                        }

                    case 6:
                        {
                            gestionnaire.supprimerPartie();
                            break;
                        }
                    case 7:
                        {
                            gestionnaire.ajouterUnePartie();
                            break;
                        }
                    case 8:
                        {
                            gestionnaire.ajouterUnJoueur();
                            break;
                        }
                    default:
                        {
                            afficheur.AfficherErreurChoix();
                            break;
                        }


                }
                afficheur.AfficherMenu();
                afficheur.AfficherDemandeChoix();
                choix=(int)saisisseur.saisirInt();
            }


        }
    }
}
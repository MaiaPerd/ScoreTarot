using AppliConsole.InterfaceUtilisateur;

namespace AppliConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppliConsole.Gestionnaire.Gestionnaire gestionnaire = new Gestionnaire.Gestionnaire();
            int choix;
            Afficheur afficheur = new();
            Sasisseur saisisseur = new();
            afficheur.AfficherMenu();
            afficheur.AfficherDemandeChoix();
            choix = gestionnaire.SaisirInt();
            while (choix != 666)
            {
                switch (choix)
                {
                    case 1:
                        {
                            gestionnaire.AfficherPartie();
                            break;
                        }
                    case 2:
                        {
                            gestionnaire.AfficherJoueurs();
                            break;
                        }
                    case 3:
                        {
                            gestionnaire.SupprimerJoueur();
                            break;
                        }
                    case 4:
                        {
                            gestionnaire.ModifierUnJoueur();
                            break;
                        }
                    case 5:
                        {
                            gestionnaire.ModifierPartie();
                            break;
                        }

                    case 6:
                        {
                            gestionnaire.SupprimerPartie();
                            break;
                        }
                    case 7:
                        {
                            gestionnaire.AjouterUnePartie();
                            break;
                        }
                    case 8:
                        {
                            gestionnaire.AjouterUnJoueur();
                            break;
                        }
                    case 9:
                        {
                            gestionnaire.AjouterUneManche();
                            break;
                        }
                    case 10:
                        {
                            gestionnaire.afficherUnePartieEnDetail();
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
                choix = gestionnaire.SaisirInt();

            }


        }
    }
}
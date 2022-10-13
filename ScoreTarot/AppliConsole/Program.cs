using AppliConsole.InterfaceUtilisateur;

namespace AppliConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppliConsole.Gestionnaire.Gestionnaire gestionnaire = new Gestionnaire.Gestionnaire();
            int choix;
            Afficheur afficheur = new Afficheur();
            Sasisseur saisisseur = new Sasisseur();
            afficheur.AfficherMenu();
            afficheur.AfficherDemandeChoix();
            choix = (int)saisisseur.SaisirInt();
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
                    default:
                        {
                            afficheur.AfficherErreurChoix();
                            break;
                        }


                }
                afficheur.AfficherMenu();
                afficheur.AfficherDemandeChoix();
                choix=(int)saisisseur.SaisirInt();
            }


        }
    }
}
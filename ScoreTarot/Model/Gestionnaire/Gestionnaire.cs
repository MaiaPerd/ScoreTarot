using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using static System.Formats.Asn1.AsnWriter;

namespace Model.Gestionnaire
{
    public class Gestionnaire
    {
        public ReadOnlyCollection<Joueur> Joueurs
        {
            get;
            private set;
        }
        private List<Joueur> joueurs = new List<Joueur>();


        public ReadOnlyCollection<Partie> Parties
        {
            get;
            private set;
        }
        private List<Partie> parties = new List<Partie>();

        public Gestionnaire()
        {
            Joueurs = new ReadOnlyCollection<Joueur>(joueurs);
            Parties = new ReadOnlyCollection<Partie>(parties);
        }


        public Boolean AjouterUnJoueur(String pseudo, int age, String nom, String prenom)
        {
            if (!joueurs.Contains(new Joueur(pseudo, age, nom, prenom)))
            {
                joueurs.Add(new Joueur(pseudo, age, nom, prenom));
                return true;
            }
            return false;
        }

        public void AjouterUneManche(int partie, Contrat contrat, Joueur joueurQuiPrend, int score, Bonus bonus, int nbJoueur, Joueur joueurAllier)
        {
            //if(joueurAllier!=null)
                parties.Find(p => p.Id == partie).AjouterManche(new Manche(contrat, joueurQuiPrend, score, bonus, nbJoueur, joueurAllier));
            //else
                //parties.Find(p => p.Id == partie).AjouterManche(new Manche(contrat, joueurQuiPrend, score, bonus, nbJoueur));
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Joueur> GetJoueurs()
        {
            return joueurs.AsReadOnly();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Partie> GetParties()
        {
            return parties.AsReadOnly();
        }


        public Partie TrouverPartieAvecID(int id)
        {
            return parties.Find(p => p.Id == id);
        }


        public Boolean AjouterUnePartie(List<Joueur> joueurs)
        {
            if (joueurs.Count>=3&&joueurs.Count <= 5)
            {
                parties.Add(new Partie(joueurs));
                return true;
            }
            return false;

        }

        public void ModifierManche(Partie partie, Manche mancheAncienne,Manche mancheNV)
        {
            for(int i=0;i<parties.Count;i++)
            {
                if (parties[i].Id == partie.Id)
                {
                    foreach (Manche m in parties[i].Manches)
                    {
                        if (m.Equals(mancheAncienne))
                        {
                            m.ModifierManche(mancheNV);
                        }
                    }
                }
            }
        }

        public void SupprimerJoueur(Joueur joueur)
        {
            List<Partie> partieASupprimer=new();
            foreach(Partie p in parties)
            {
                if (p.Joueurs.Contains(joueur))
                {
                    partieASupprimer.Add(p);
                }
            }
            if(joueurs.Contains(joueur))
                joueurs.Remove(joueur);
            SupprimerPlusieursPartie(partieASupprimer);
        }
        public void SupprimerPlusieursPartie(List<Partie> partieASupprimer)
        {
            foreach (Partie p in partieASupprimer)
            {
                parties.Remove(p);
            }
        }
        public void SupprimerPartie(Partie partie)
        {
            if(parties.Contains(partie))
                parties.Remove(partie);
        }
        public Boolean ModifierUnJoueur(Joueur ancien, Joueur nv)
        {
            if (joueurs.Contains(ancien)&&!joueurs.Contains(nv)) {
                Joueur joueurdelalist = ancien;
                foreach (Joueur j in this.joueurs) {
                    if (j == ancien)
                        j.ModifierLeJoueur(nv);
                } 
                return true;
            }
            return false;
            
        }

    }
}


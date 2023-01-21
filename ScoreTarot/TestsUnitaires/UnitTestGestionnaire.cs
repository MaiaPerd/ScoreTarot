using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Gestionnaire;

namespace TestsUnitaires
{
    public class UnitTestGestionnaire
    {
        [Theory]
        [MemberData(nameof(UnitTestControlerDto.Data_TestGestionnaire), MemberType = typeof(UnitTestControlerDto))]
        public void TestGestionnaireAjoutJoueurEtPartie(List<Joueur> joueurs)
        {
            Gestionnaire g = new Gestionnaire();
            Boolean bienPasse=false;
            for (int i = 0; i < joueurs.Count; i++)
            {
                bienPasse = g.AjouterUnJoueur(joueurs[i].Pseudo, joueurs[i].Age, joueurs[i].Prenom, joueurs[i].Nom);
                Assert.True(bienPasse);
            }
            Assert.Equal(joueurs.Count, g.Joueurs.Count);
            bienPasse = g.AjouterUnJoueur(joueurs[0].Pseudo, joueurs[0].Age, joueurs[0].Prenom, joueurs[0].Nom);
            Assert.False(bienPasse);
            bienPasse = g.AjouterUnePartie(joueurs);
            if(joueurs.Count >= 3&&joueurs.Count<=5)
                Assert.True(bienPasse);
            else
                Assert.False(bienPasse);
        }
        [Theory]
        [MemberData(nameof(UnitTestControlerDto.Data_TestGestionnaireAjoutManche), MemberType = typeof(UnitTestControlerDto))]
        public void TestGestionnaireAjoutManche(Partie partie, Contrat contrat, Joueur joueurQuiPrend, int score, Bonus bonus, int nbJoueur, Joueur joueurAllier)
        {
            Gestionnaire g = new();
            List<Joueur> listj = new();
            listj.AddRange(partie.Joueurs);
            g.AjouterUnePartie(listj);
            int id = g.Parties[0].Id;
            g.AjouterUneManche(id, contrat, joueurQuiPrend, score, bonus, nbJoueur, joueurAllier);
            Assert.Single(g.Parties[0].Manches);
        }

        [Theory]
        [MemberData(nameof(UnitTestControlerDto.Data_TestGestionnaireModifManche), MemberType = typeof(UnitTestControlerDto))]
        public void TestGestionnaireAjoutManch(Partie partie,Manche oldv, Manche newv)
        {
            List<Joueur> listj = new();
            listj.AddRange(partie.Joueurs);
            Gestionnaire g= new();
            bool bienPasse = false;
            bienPasse = g.AjouterUnePartie(listj);
            Assert.True(bienPasse);
            g.AjouterUneManche(g.Parties[0].Id, oldv.Contrat, oldv.JoueurQuiPrend, oldv.Score, oldv.Bonus, listj.Count, oldv.JoueurQuiPrend);
            
            //Partie partie2 = new Partie(g.Parties[0].Id, g.Parties[0].Joueurs, g.Parties[0].Manches);
            Manche newv2 = new Manche(g.Parties[0].Manches[0].Id,newv.Contrat,newv.JoueurQuiPrend,newv.Score,newv.Bonus,listj.Count,newv.JoueurAllier);
            g.ModifierManche(g.Parties[0], oldv, newv2);
            Assert.Single(g.Parties[0].Manches);
            Assert.Equal(newv2.JoueurAllier, g.Parties[0].Manches[0].JoueurAllier);
            Assert.Equal(newv2.Score, g.Parties[0].Manches[0].Score);
            Assert.Equal(newv2.JoueurQuiPrend, g.Parties[0].Manches[0].JoueurQuiPrend);
            Assert.Equal(newv2.Bonus, g.Parties[0].Manches[0].Bonus);
            Assert.Equal(newv2.Contrat, g.Parties[0].Manches[0].Contrat);
        }
        [Theory]
        [MemberData(nameof(UnitTestControlerDto.Data_TestGestionnaireSuppressionJoueur), MemberType = typeof(UnitTestControlerDto))]
        public void TestGestionnaireSuppressionJoueur(Partie partie,List<Joueur> joueurs)
        {
            Gestionnaire g = new();
            List<Joueur> lisj = new();
            for (int i = 0; i < joueurs.Count; i++)
            {
                g.AjouterUnJoueur(joueurs[i].Pseudo, joueurs[i].Age, joueurs[i].Prenom, joueurs[i].Nom);
            }
            lisj.AddRange(partie.Joueurs);
            g.AjouterUnePartie(lisj);
            g.SupprimerJoueur(joueurs[0]);
            Assert.Empty(g.Parties);
        }

    }
}

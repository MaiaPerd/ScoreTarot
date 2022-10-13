using EntityFramework.Entity;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using System.Runtime.Serialization;
using System.Reflection;
using AngleSharp.Common;

namespace TestsUnitaires
{
    public class UnitTestExtension
    {
        [Theory]
        [MemberData(nameof(DataTest.Data_TestExtensionJoueur),MemberType = typeof(DataTest))]
        public void TestExetentionJoueur(Joueur joueur)
        {
            JoueurEntity joueure= joueur.toEntity();
            Assert.Equal(joueur.Nom, joueure.Nom);
            Assert.Equal(joueur.Prenom, joueure.Prenom);
            Assert.Equal(joueur.Pseudo, joueure.Pseudo);
            Assert.Equal(joueur.URLIMG, joueure.URLIMG);
            Assert.Equal(joueur.Age, joueure.Age);
        }
        [Theory]
        [MemberData(nameof(DataTest.Data_TestExtentionPartie), MemberType = typeof(DataTest))]
        public void TestExtentionPartie(Partie partie)
        {
            PartieEntity party = partie.toEntity();
            Assert.Equal(party.Joueurs.Count(), partie.Joueurs.Count);
            Assert.Equal(party.Manches.Count,partie.Manches.Count);
            for(int i=0;i<party.Manches.Count;i++)
            {
                Assert.Equal(party.Manches.GetItemByIndex(i).Date, partie.Manches.GetItemByIndex(i).Date);
                Assert.Equal(party.Manches.GetItemByIndex(i).Score, partie.Manches.GetItemByIndex(i).Score);
                if (party.Manches.GetItemByIndex(i).JoueurAllier!=null&& partie.Manches.GetItemByIndex(i).JoueurAllier!=null) {
                    Assert.Equal(party.Manches.GetItemByIndex(i).JoueurAllier.URLIMG, partie.Manches.GetItemByIndex(i).JoueurAllier.URLIMG);
                    Assert.Equal(party.Manches.GetItemByIndex(i).JoueurAllier.Prenom, partie.Manches.GetItemByIndex(i).JoueurAllier.Prenom);
                    Assert.Equal(party.Manches.GetItemByIndex(i).JoueurAllier.Age, partie.Manches.GetItemByIndex(i).JoueurAllier.Age);
                    Assert.Equal(party.Manches.GetItemByIndex(i).JoueurAllier.Nom, partie.Manches.GetItemByIndex(i).JoueurAllier.Nom);
                    Assert.Equal(party.Manches.GetItemByIndex(i).JoueurAllier.Pseudo, partie.Manches.GetItemByIndex(i).JoueurAllier.Pseudo);
                }
                    Assert.Equal(party.Manches.GetItemByIndex(i).JoueurQuiPrend.Pseudo, partie.Manches.GetItemByIndex(i).JoueurQuiPrend.Pseudo);
                    Assert.Equal(party.Manches.GetItemByIndex(i).JoueurQuiPrend.Prenom, partie.Manches.GetItemByIndex(i).JoueurQuiPrend.Prenom);
                    Assert.Equal(party.Manches.GetItemByIndex(i).JoueurQuiPrend.URLIMG, partie.Manches.GetItemByIndex(i).JoueurQuiPrend.URLIMG);
                    Assert.Equal(party.Manches.GetItemByIndex(i).JoueurQuiPrend.Age, partie.Manches.GetItemByIndex(i).JoueurQuiPrend.Age);
                    Assert.Equal(party.Manches.GetItemByIndex(i).JoueurQuiPrend.Nom, partie.Manches.GetItemByIndex(i).JoueurQuiPrend.Nom);
                
            }
            Assert.Equal(party.Joueurs.Count(), partie.Joueurs.Count);
            for (int i=0; i<party.Joueurs.Count(); i++)
            {
                Assert.Equal(party.Joueurs.GetItemByIndex(i).Nom, partie.Joueurs.GetItemByIndex(i).Nom);
                Assert.Equal(party.Joueurs.GetItemByIndex(i).URLIMG, partie.Joueurs.GetItemByIndex(i).URLIMG);
                Assert.Equal(party.Joueurs.GetItemByIndex(i).Prenom, partie.Joueurs.GetItemByIndex(i).Prenom);
                Assert.Equal(party.Joueurs.GetItemByIndex(i).Age, partie.Joueurs.GetItemByIndex(i).Age);
                Assert.Equal(party.Joueurs.GetItemByIndex(i).Pseudo, partie.Joueurs.GetItemByIndex(i).Pseudo);
            }
        }
        [Theory]
        [MemberData(nameof(DataTest.Data_TestExtentionManche),MemberType =typeof(DataTest))]
        public void Data_TestExtentionManche(Manche manche)
        {
            MancheEntity manchy = manche.toEntity();
            Assert.Equal(manche.Contrat, manchy.Contrat.toModel());
            Assert.Equal(manche.Date, manchy.Date);
            Assert.Equal(manche.JoueurQuiPrend.Nom, manchy.JoueurQuiPrend.Nom);
            Assert.Equal(manche.JoueurQuiPrend.Pseudo, manchy.JoueurQuiPrend.Pseudo);
            Assert.Equal(manche.JoueurQuiPrend.Age, manchy.JoueurQuiPrend.Age);
            Assert.Equal(manche.JoueurQuiPrend.URLIMG, manchy.JoueurQuiPrend.URLIMG);
            Assert.Equal(manche.JoueurQuiPrend.Prenom, manchy.JoueurQuiPrend.Prenom);
            Assert.Equal(manche.NbJoueur, manchy.NbJoueur);
            if (manche.JoueurAllier != null && manchy.JoueurAllier != null)
            {
                Assert.Equal(manche.JoueurAllier.Nom, manchy.JoueurAllier.Nom);
                Assert.Equal(manche.JoueurAllier.Prenom, manchy.JoueurAllier.Prenom);
                Assert.Equal(manche.JoueurAllier.URLIMG, manchy.JoueurAllier.URLIMG);
                Assert.Equal(manche.JoueurAllier.Pseudo, manchy.JoueurAllier.Pseudo);
                Assert.Equal(manche.JoueurAllier.Age, manchy.JoueurAllier.Age);
            }
        }
        [Theory]
        [InlineData("Dani_45","Dani",50,"img","DEBOIS")]
        public void TesterNewJoueurEntity(String pseudo,String prenom,int age,String image,String nom)
        {
            JoueurEntity jentity =new JoueurEntity();
            jentity.Prenom = prenom;
            jentity.Nom = nom;
            jentity.URLIMG = image;
            jentity.Pseudo = pseudo;
            jentity.Age = age;
            Assert.Equal(prenom, jentity.Prenom);
            Assert.Equal(pseudo, jentity.Pseudo);
            Assert.Equal(nom, jentity.Nom);
            Assert.Equal(image, jentity.URLIMG);
            Assert.Equal(age, jentity.Age);
        }
        [Theory]
        [MemberData(nameof(DataTest.Data_TestExtentionContrat),MemberType = typeof(DataTest))]
        public void TesterContratEntity(Contrat contrat)
        {
            ContratEntity contratEntity = contrat.toEntity();
            if (contrat == Contrat.GardeContre)
            {
                Assert.Equal(ContratEntity.GardeContre, contratEntity);
            }
            if (contrat == Contrat.GardeSans)
            {
                Assert.Equal(ContratEntity.GardeSans, contratEntity);
            }
            if (contrat == Contrat.Garde)
            {
                Assert.Equal(ContratEntity.Garde, contratEntity);
            }
            if (contrat == Contrat.Prise)
            {
                Assert.Equal(ContratEntity.Prise, contratEntity);
            }
        }
        [Theory]
        [MemberData(nameof(DataTest.Data_TestExtensionBonus), MemberType=typeof(DataTest))]
        public void TestExtentionBonus(Bonus bonus)
        {
            BonusEntity bonusEntity = bonus.toEntity();
            if (Bonus.PetitAuBout == bonus)
            {
                Assert.Equal(BonusEntity.PetitAuBout, bonusEntity);
            }
            if (Bonus.Petit == bonus)
            {
                Assert.Equal(BonusEntity.Petit, bonusEntity);
            }
            if (Bonus.Le21 == bonus)
            {
                Assert.Equal(BonusEntity.Le21, bonusEntity);
            }
            if (Bonus.DoublePoignee == bonus)
            {
                Assert.Equal(BonusEntity.DoublePoignee, bonusEntity);
            }
            if (Bonus.SimplePoignee == bonus)
            {
                Assert.Equal(BonusEntity.SimplePoignee, bonusEntity);
            }
            if (Bonus.TriplePoignee == bonus)
            {
                Assert.Equal(BonusEntity.TriplePoignee, bonusEntity);
            }
        }
    }
}

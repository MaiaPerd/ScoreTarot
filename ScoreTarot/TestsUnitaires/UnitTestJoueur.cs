using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitaires
{
    public class UnitTestJoueur
    {
        [Theory]
        [InlineData(true, "nom", 10, "nomDeFamille", "Young","img")]
        [InlineData(false, "", 50, "nomDeFamille", "Young", "img")]
        [InlineData(true, "nom", 0, "nomDeFamille", "Young", "img")]
        [InlineData(true, "nom", 10, "", "Young", "img")]
        [InlineData(false, null , 10, "nomDeFamille", "Young", "img")]
        [InlineData(true, "nom", 10, null, "Young", "img")]
        [InlineData(true, "nom", 10, "nomDeFamille", null, "img")]
        [InlineData(true, "nom", 10, "nomDeFamille", "Young", "")]

        public void TestConstructorJoueur(Boolean estValide,string pseudo, int age, string nom, string prenom, string nomImage)
        {
            if (!estValide)
            {
                Assert.Throws<ArgumentNullException>(
                        () => new Joueur(pseudo, age, nom, prenom,nomImage));
                return;
            }
            Joueur joueur = new Joueur(pseudo, age, nom, prenom, nomImage);
            //test si pseudo a était bien pris en compte
            Assert.Equal(pseudo, joueur.Pseudo);
            Assert.Equal(nom, joueur.Nom);
            Assert.Equal(prenom,joueur.Prenom);
            Assert.Equal(age,joueur.Age);
            //autre constructeur
            Joueur joueur2 = new Joueur(pseudo,age,nom,prenom);
            Assert.Equal(pseudo, joueur2.Pseudo);
            Assert.Equal(nom, joueur2.Nom);
            Assert.Equal(prenom, joueur2.Prenom);
            Assert.Equal(age, joueur2.Age);
            //autre constructeur
            Joueur joueur3 = new Joueur(pseudo, age);
            Assert.Equal(pseudo, joueur3.Pseudo);
            Assert.Equal(age, joueur3.Age);
            //
            Joueur joueur4 = new Joueur(pseudo, age,nomImage);
            Assert.Equal(pseudo, joueur4.Pseudo);
            Assert.Equal(age, joueur4.Age);
        }
        [Theory]
        [MemberData(nameof(DataTest.Data_TesEqualJoueur), MemberType = typeof(DataTest))]
        public void TestEqualsJoueur(bool equal, Joueur joueur1, Joueur joueur2)
        {
            Assert.Equal(equal, joueur1.Equals(joueur2));
        }
    }
}

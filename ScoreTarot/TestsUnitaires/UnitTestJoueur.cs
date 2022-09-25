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
        [InlineData(true, "nom", 10, "nomDeFamille", "Young","")]

        public void TestConstructorJoueur(Boolean estValide,string pseudo, int age, string nom, string prenom, string nomImage)
        {
            if (!estValide)
            {
                Assert.Throws<ArgumentException>(
                        () => new Joueur(pseudo, age, nom, prenom,nomImage));
                return;
            }
            Joueur joueur = new Joueur(pseudo, age, nom, prenom, nomImage);
            //test si pseudo a était bien pris en compte
            Assert.Equal(pseudo, joueur.Pseudo);
            Assert.Equal(nom, joueur.Nom);
            Assert.Equal(prenom,joueur.Prenom);
            Assert.Equal(nomImage,joueur.URLIMG);
            Assert.Equal(age,joueur.Age);
        }
    }
}

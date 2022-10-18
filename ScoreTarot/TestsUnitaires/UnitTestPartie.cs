using Model;
using Stub;

namespace TestsUnitaires;

public class UnitTestPartie
{
    
    [Theory]
    [MemberData(nameof(DataTest.Data_TestConstructeurPartie), MemberType = typeof(DataTest))]
    public void TestConstructeurPartie(bool estValide, List<Joueur> joueurs, List<Manche> manches)
    {
        if (!estValide)
        {
            Assert.Throws<InvalidDataException>(
                    () => new Partie(joueurs, manches));
            return;
        }
        Partie partie = new Partie(joueurs, manches);
        Assert.Equal(joueurs, partie.Joueurs);
        Assert.Equal(manches, partie.Manches);
    }
    
    [Theory]
    [MemberData(nameof(DataTest.Data_TestAjouterManche), MemberType = typeof(DataTest))]
    public void TestAjouterManche(bool reusite, Manche manche, Partie partie)
    {
        Assert.Equal(reusite, partie.AjouterManche(manche));
    }

    [Theory]
    [MemberData(nameof(DataTest.Data_TestSupprimerManche), MemberType = typeof(DataTest))]
    public void TestSupprimerManche(bool reusite, Manche manche, Partie partie)
    {
        Assert.Equal(reusite, partie.SupprimerManche(manche));
    }
    
    [Theory]
    [MemberData(nameof(DataTest.Data_TestModifierManche), MemberType = typeof(DataTest))]
    public void TestModifierManche(bool reusite, Manche manche, Partie partie)
    {
        Assert.Equal(reusite, partie.ModifierManche(manche));
    }

    [Theory]
    [MemberData(nameof(DataTest.Data_TestAjouterJoueur), MemberType = typeof(DataTest))]
    public void TestAjouterJoueur(bool reusite, Joueur joueur, Partie partie)
    {
        Assert.Equal(reusite, partie.AjouterJoueur(joueur));
    }

    [Theory]
    [MemberData(nameof(DataTest.Data_TestSupprimerJoueur), MemberType = typeof(DataTest))]
    public void TestSupprimerJoueur(bool reusite, Joueur joueur, Partie partie)
    {
        Assert.Equal(reusite, partie.SupprimerJoueur(joueur));
    }


    [Theory]
    [MemberData(nameof(DataTest.Data_TestEqualsPartie), MemberType = typeof(DataTest))]
    public void TestEqualsPartie(bool equal, Partie partie1, object partie2)
    {
        Assert.Equal(equal, partie1.Equals(partie2));
    }

}

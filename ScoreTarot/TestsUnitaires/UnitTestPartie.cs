using Model;
using Stub;

namespace TestsUnitaires;

public class UnitTestPartie
{
    
    [Theory]
    [MemberData(nameof(UnitTestControlerDto.Data_TestConstructeurPartie), MemberType = typeof(UnitTestControlerDto))]
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
    [MemberData(nameof(UnitTestControlerDto.Data_TestAjouterManche), MemberType = typeof(UnitTestControlerDto))]
    public void TestAjouterManche(bool reusite, Manche manche, Partie partie)
    {
        Assert.Equal(reusite, partie.AjouterManche(manche));
    }

    [Theory]
    [MemberData(nameof(UnitTestControlerDto.Data_TestSupprimerManche), MemberType = typeof(UnitTestControlerDto))]
    public void TestSupprimerManche(bool reusite, Manche manche, Partie partie)
    {
        Assert.Equal(reusite, partie.SupprimerManche(manche));
    }
    
    [Theory]
    [MemberData(nameof(UnitTestControlerDto.Data_TestModifierManche), MemberType = typeof(UnitTestControlerDto))]
    public void TestModifierManche(bool reusite, Manche manche, Partie partie)
    {
        Assert.Equal(reusite, partie.ModifierManche(manche));
    }

    [Theory]
    [MemberData(nameof(UnitTestControlerDto.Data_TestAjouterJoueur), MemberType = typeof(UnitTestControlerDto))]
    public void TestAjouterJoueur(bool reusite, Joueur joueur, Partie partie)
    {
        Assert.Equal(reusite, partie.AjouterJoueur(joueur));
    }

    [Theory]
    [MemberData(nameof(UnitTestControlerDto.Data_TestSupprimerJoueur), MemberType = typeof(UnitTestControlerDto))]
    public void TestSupprimerJoueur(bool reusite, Joueur joueur, Partie partie)
    {
        Assert.Equal(reusite, partie.SupprimerJoueur(joueur));
    }


    [Theory]
    [MemberData(nameof(UnitTestControlerDto.Data_TestEqualsPartie), MemberType = typeof(UnitTestControlerDto))]
    public void TestEqualsPartie(bool equal, Partie partie1, object partie2)
    {
        Assert.Equal(equal, partie1.Equals(partie2));
    }

}

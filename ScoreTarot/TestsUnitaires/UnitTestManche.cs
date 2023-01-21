using Model;
using Stub;

namespace TestsUnitaires;

public class UnitTestManche
{
    
    [Theory]
    [MemberData(nameof(UnitTestControlerDto.Data_TestConstructeurManche), MemberType = typeof(UnitTestControlerDto))]
    public void TestConstructeurManche(bool estValide, Contrat contrat, Joueur joueurQuiPrend, int score, Bonus bonus, int nbJoueur)
    {
        if (!estValide)
        {
            Assert.Throws<ArgumentNullException>(
                    () => new Manche(contrat, joueurQuiPrend, score, bonus, nbJoueur));
            return;
        }
        Manche manche = new Manche( contrat, joueurQuiPrend, score, bonus, nbJoueur);
        Assert.Equal(contrat, manche.Contrat);
        Assert.Equal(joueurQuiPrend, manche.JoueurQuiPrend);
        if (bonus == null) { bonus = Bonus.None;  }
        Assert.Equal(bonus, manche.Bonus);
        Assert.Equal(score, manche.Score);
    }
    
    [Theory]
    [MemberData(nameof(UnitTestControlerDto.Data_TestGetScoreJoueurManche), MemberType = typeof(UnitTestControlerDto))]
    public void TestGetScoreJoueurManche(int score, Joueur joueur, Manche manche)
    {
        Assert.Equal(score, manche.GetScoreJoueurManche(joueur));
    }

    [Theory]
    [MemberData(nameof(UnitTestControlerDto.Data_TestEqualsManche), MemberType=typeof(UnitTestControlerDto))]
    public void TestEqualsManche(bool equal, Manche manche1, Manche manche2)
    {
        Assert.Equal(equal, manche1.Equals(manche2));
    }

    
}

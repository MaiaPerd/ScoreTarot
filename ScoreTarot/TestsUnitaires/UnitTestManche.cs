using Model;
using Stub;

namespace TestsUnitaires;

public class UnitTestManche
{
    

    [Theory]
    [MemberData(nameof(DataTest.Data_TestConstructeurManche), MemberType = typeof(DataTest))]
    public void TestConstructeurManche(bool estValide, Contrat contrat, Joueur joueurQuiPrend, int score, List<Bonus> bonus)
    {
        if (!estValide)
        {
            Assert.Throws<ArgumentException>(
                    () => new Manche(contrat, joueurQuiPrend, score, bonus));
            return;
        }
        Manche manche = new Manche( contrat, joueurQuiPrend, score, bonus);
        Assert.Equal(contrat, manche.Contrat);
        Assert.Equal(joueurQuiPrend, manche.JoueurQuiPrend);
        if (bonus == null) { bonus = new List<Bonus>();  }
        Assert.Equal(bonus, manche.Bonus);
        Assert.Equal(score, manche.Score);
    }

    [Theory]
    [MemberData(nameof(DataTest.Data_TestEqualsManche), MemberType = typeof(DataTest))]
    public void TestGetScoreJoueurManche(int score, Joueur joueur, Manche manche)
    {
        Assert.Equal(score, manche.getScoreJoueurManche(joueur));
    }

    [Theory]
    [MemberData(nameof(DataTest.Data_TestEqualsManche), MemberType=typeof(DataTest))]
    public void TestEqualsManche(bool equal, Manche manche1, Manche manche2)
    {
        Assert.Equal(equal, manche1.Equals(manche2));
    }

    
}

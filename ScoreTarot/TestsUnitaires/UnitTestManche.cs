using Model;
using Stub;

namespace TestsUnitaires;

public class UnitTestManche
{
    

    [Theory]
    [MemberData(nameof(StubManche.chargerLesManche3J))]
    public void TestConstructeurMancheAvecId(Contrat contrat, Joueur joueurQuiPrend, int id, int score, List<Bonus> bonus, Joueur joueurAllier)
    {
        Manche manche = new Manche( contrat, joueurQuiPrend, id, score, bonus, joueurAllier);
        Assert.Equal(contrat, manche.Contrat);
        Assert.Equal(joueurQuiPrend, manche.JoueurQuiPrend);
        Assert.Equal(joueurAllier, manche.JoueurAllier);
        Assert.Equal(id, manche.Id);
        Assert.Equal(bonus, manche.Bonus);
    }

    [Theory]
    [MemberData(nameof(DataTest.Data_TestEqualsManche))]
    public void TestEqualsManche(bool equal, Manche manche1, Manche manche2)
    {
        Assert.Equal(equal, manche1.Equals(manche2));
    }

    
}

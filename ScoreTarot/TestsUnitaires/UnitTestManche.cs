using Model;
using Stub;

namespace TestsUnitaires;

public class UnitTestManche
{
    private StubBonus stubBonus = new StubBonus();
    private StubManche stubManche = new StubManche();
    private StubPartie stubPartie = new StubPartie();
    private StubJoueur stubJoueur = new StubJoueur();

    [Theory]
    [InlineData(Contrat.Garde, 1, 10)]
    [InlineData(Contrat.GardeContre, 1, 10)]
    [InlineData(Contrat.Prise, 1, 10)]
    [InlineData(Contrat.GardeSans, 1, 10)]
    [InlineData(Contrat.Garde, null, 10)]
    [InlineData(Contrat.Garde, 1, null)]
    [InlineData(null, 1, 10)]
    [InlineData(Contrat.Garde, 0, -1.4)]
    [InlineData(null, null, -1.4)]
    [InlineData(null, null, null)]
    [InlineData(Contrat.Garde, null, null)]
    [InlineData(null, 0, null)]
    [InlineData(Contrat.Garde, 0939393, 1)]
    public void TestConstructeurMancheAvecId(Contrat contrat, int id, int score)
    {
        Joueur joueur = new Joueur("Joueur", 0);
        Manche manche = new Manche(contrat, joueur, id, score, stubBonus.chargerListeBonusBien(), joueur);
        Assert.Equal(contrat, manche.Contrat);
        Assert.Equal(joueur, manche.JoueurQuiPrend);
        Assert.Equal(joueur, manche.JoueurAllier);
        Assert.Equal(id, manche.Id);
        Assert.Equal(stubBonus.chargerListeBonusBien(), manche.Bonus);
    }

    [Fact]
    public void TestEqualsManche()
    {
        Manche manche = stubManche.chargerUneManche(stubJoueur.chargerJoueurPartie3J());
        Manche manche2 = stubManche.chargerUneManche(stubJoueur.chargerJoueurPartie3J());
        Assert.Equal(true, manche.Equals(manche2));
    }

    [Fact]
    public void TestNotEqualsManche()
    {
        Manche manche = stubManche.chargerUneManche(stubJoueur.chargerJoueurPartie3J());
        Manche manche2 = stubManche.chargerUneManche2(stubJoueur.chargerJoueurPartie3J());
        Assert.Equal(false, manche.Equals(manche2));
    }

    
}

using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitaires
{
    public class UnitTestCalculator
    {
        [Theory]
        [InlineData(20, 10, 2)]
        [InlineData(50, 10, 5)]
        [InlineData(12, 50, 6)]
        [InlineData(10, 60, 6)]
        public void TestMethodeCalculator_calculerPourcentageDeReussite(float result, int nbPartieRealise, int nbPartieGagne)
        {
            Calculator calculator = new Calculator();
            Assert.Equal(calculator.CalculerPourcentageDeReussite(nbPartieRealise, nbPartieGagne) , result);
        }

        [Theory]
        [InlineData(0, 40, 2)]
        [InlineData(112, 56, 4)]
        [InlineData(177, 59, 5)]
        [InlineData(80, 80, 3)]
        public void TestMethodeCalculator_scoreFinalJoueurQuiPrendAvecAllier(float result, int scoreJoueurQuiPrend, int nbJoueur)
        {
            Calculator calculator = new Calculator();
            Assert.Equal(calculator.ScoreFinalJoueurQuiPrendAvecAllier(scoreJoueurQuiPrend, nbJoueur), result);
        }


        [Theory]
        [InlineData(40, 10, 5)]
        [InlineData(90, 90, 2)]
        [InlineData(240, 80, 4)]
        [InlineData(-540, -180, 4)]
        public void TestMethodeCalculator_scoreFinalJoueurQuiPrend(float result, int scoreJoueurQuiPrend, int nbJoueur)
        {
            Calculator calculator = new Calculator();
            Assert.Equal(calculator.ScoreFinalJoueurQuiPrend(scoreJoueurQuiPrend, nbJoueur), result);
        }


        [Theory]
        [MemberData(nameof(DataTest.Data_TestCalculator), MemberType = typeof(DataTest))]
        public void TestMethodeCalculator_calculeScoreJoueurQuiPrend(int result,List<Bonus> lBonus, Contrat contrat, int scoreJoueur)
        {
            Calculator calculator = new Calculator();
            Assert.Equal(calculator.CalculeScoreJoueurQuiPrend(lBonus, contrat, scoreJoueur),result);
        }

        [Theory]
        [InlineData(-40,40)]
        [InlineData(-16,16)]
        [InlineData(-84,84)]
        public void TestMethodeCalculator_calculScoreAutreJoueur(int result, int scoreJoueurQuiPrend)
        {
            Calculator calculator = new Calculator();
            Assert.Equal(calculator.CalculScoreAutreJoueur(scoreJoueurQuiPrend), result);
        }


        

    }
}

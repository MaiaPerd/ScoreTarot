using Model;
using Stub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitaires
{
    public class DataTest
    {

        public static IEnumerable<object[]> Data_TestEqualsManche()
        {
            StubBonus stubBonus = new StubBonus();
            yield return new object[]
            {
                true,
                new Manche(Contrat.GardeContre, new Joueur("Joueur", 0), 1, 50, stubBonus.chargerListeBonusMoyen()),
                new Manche(Contrat.GardeContre, new Joueur("Joueur", 0), 1, 50, stubBonus.chargerListeBonusMoyen())
            };
            yield return new object[]
            {
                false,
                new Manche(Contrat.GardeContre, new Joueur("Joueur", 0), 1, 50, stubBonus.chargerListeBonusMoyen()),
                new Manche(Contrat.GardeContre, new Joueur("Joueur", 0), 2, 50, stubBonus.chargerListeBonusMoyen())
            };
        }


    }
}

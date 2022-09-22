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

        public static IEnumerable<object[]> Data_TestConstructeurManche()
        {

            yield return new object[]
            {
                true,
                Contrat.GardeContre,
                new Joueur("Joueur", 0),
                50,
                new StubBonus().chargerListeBonusBien()

            };
            yield return new object[]
            {
                false,
                Contrat.GardeContre,
                new Joueur("Joueur", 0),
                -14,
                new StubBonus().chargerListeBonusBien()

            };
            yield return new object[]
            {
                true,
                Contrat.GardeContre,
                new Joueur("Joueur", 0),
                50,
                null

            };
            yield return new object[]
            {
                false,
                Contrat.Garde,
                null,
                0,
                null,
            };
            yield return new object[]
            {
                false,
                null,
                null,
                null,
                null
            };
            yield return new object[]
            {
                true,
                null,
                new Joueur("JoueurTest", 0),
                null,
                null
            };
            
        }

        public static IEnumerable<object[]> Data_TestEqualsManche()
        {
            
            yield return new object[]
            {
                true,
                new Manche(Contrat.GardeContre, new Joueur("Joueur", 0), 1, 50, new StubBonus().chargerListeBonusMoyen()),
                new Manche(Contrat.GardeContre, new Joueur("Joueur", 0), 1, 50, new StubBonus().chargerListeBonusMoyen())
            };
            yield return new object[]
            {
                false,
                new Manche(Contrat.GardeContre, new Joueur("Joueur", 0), 1, 50, new StubBonus().chargerListeBonusMoyen()),
                new Manche(Contrat.GardeContre, new Joueur("Joueur", 0), 2, 50, new StubBonus().chargerListeBonusMoyen())
            };
        }


    }
}

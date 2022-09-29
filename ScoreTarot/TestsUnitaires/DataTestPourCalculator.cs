using Model;
using Stub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitaires
{
    internal class DataTestPourCalculator
    {
        public static IEnumerable<object[]> Data_TesEqualJoueur()
        {

            yield return new object[]
            {
                true,
                new Joueur("Daniel",40),
                new Joueur("Daniel",45,"img")
            };
            yield return new object[]
            {
                false,
                new Joueur("Daniel",40),
                new Joueur("QuelquUnDautre",45,"img")
            };
            yield return new object[]
            {
                true,
                new Joueur("Daniel",40),
                new Joueur("Daniel",45)
            };
        }
        public static IEnumerable<object[]> Data_TestCalculator()
        {
            yield return new object[]
            {
                169,
                new List<Bonus>(){Bonus.Escuse},
                Contrat.GardeContre,
                70
            };
            yield return new object[]
            {
                -196,
                new List<Bonus>(){Bonus.Escuse},
                Contrat.GardeContre,
                5
            };
            yield return new object[]
            {
                -191,
                new List<Bonus>(){Bonus.Escuse,Bonus.DoublePoignet},
                Contrat.GardeContre,
                40
            };
            yield return new object[]
            {
                -151,
                new List<Bonus>(){Bonus.Escuse,Bonus.Le21},
                Contrat.GardeContre,
                40
            };
            yield return new object[]
            {
                -181,
                new List<Bonus>(){Bonus.Escuse,Bonus.SimplePoignet},
                Contrat.GardeContre,
                40
            };
            yield return new object[]
            {
                -191,
                new List<Bonus>(){Bonus.TriplePoignet},
                Contrat.GardeContre,
                55
            };
            yield return new object[]
            {
                194,
                new List<Bonus>(){Bonus.SimplePoignet},
                Contrat.GardeContre,
                80
            };
            yield return new object[]
            {
                -201,
                new List<Bonus>(){Bonus.PetitAuBout,Bonus.Petit},
                Contrat.GardeContre,
                40
            };
            yield return new object[]
            {
                190,
                new List<Bonus>(){Bonus.Le21},
                Contrat.GardeContre,
                91
            };
            yield return new object[]
            {
                -116,
                new List<Bonus>(){},
                Contrat.GardeSans,
                40
            };
            yield return new object[]
            {
                -61,
                new List<Bonus>(){Bonus.Escuse},
                Contrat.Garde,
                40
            };
            yield return new object[]
            {
                -41,
                new List<Bonus>(){},
                Contrat.Prise,
                40
            };
            yield return new object[]
            {
                32,
                new List<Bonus>(){Bonus.Escuse},
                Contrat.Prise,
                58
            };
        }

        

    }
}

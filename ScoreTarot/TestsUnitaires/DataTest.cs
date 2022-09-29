﻿using Model;
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

        #region Data Manche

        public static IEnumerable<object[]> Data_TestConstructeurManche()
        {

            yield return new object[]
            {
                true,
                Contrat.GardeContre,
                new Joueur("Joueur", 0),
                50,
                new StubBonus().chargerListeBonusBien(),
                4

            };
            yield return new object[]
            {
                false,
                Contrat.GardeContre,
                new Joueur("Joueur", 0),
                -14,
                new StubBonus().chargerListeBonusBien(),
                4

            };
            yield return new object[]
            {
                true,
                Contrat.GardeContre,
                new Joueur("Joueur", 0),
                50,
                null,
                4

            };
            yield return new object[]
            {
                false,
                Contrat.Garde,
                null,
                0,
                null,
                4
            };
            yield return new object[]
            {
                false,
                null,
                null,
                null,
                null,
                4
            };
            yield return new object[]
            {
                false,
                null,
                new Joueur("JoueurTest", 0),
                null,
                null,
                4
            };

        }

        public static IEnumerable<object[]> Data_TestGetScoreJoueurManche()
        {

            yield return new object[]
            {
                458,
                new Joueur("JoueurQuiprend", 0),
                new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
            };
            yield return new object[]
            {
                -51,
                new Joueur("JoueurAllier", 0),
                new Manche(Contrat.Garde, new Joueur("JoueurQuiprend", 0), 1, 50, new StubBonus().chargerListeBonusUnSeul(), 5, new Joueur("JoueurAllier", 0))
            };
            yield return new object[]
            {
                -153,
                new Joueur("JoueurQuiprend", 0),
                new Manche(Contrat.Garde, new Joueur("JoueurQuiprend", 0), 1, 50, new StubBonus().chargerListeBonusUnSeul(),  5, new Joueur("JoueurAllier", 0))
            };
            yield return new object[]
            {
                221,
                new Joueur("Joueur", 0),
                new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 50, new StubBonus().chargerListeBonusMoyen(), 5,  new Joueur("JoueurAllier", 0))
            };
            yield return new object[]
            {
                -229,
                new Joueur("Joueur", 0),
                new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 4)
            };
        }

        public static IEnumerable<object[]> Data_TestEqualsManche()
        {

            yield return new object[]
            {
                true,
                new Manche(Contrat.GardeContre, new Joueur("Joueur", 0), 1, 50, new StubBonus().chargerListeBonusMoyen(), 4),
                new Manche(Contrat.GardeContre, new Joueur("Joueur", 0), 1, 50, new StubBonus().chargerListeBonusMoyen(), 4)
            };
            yield return new object[]
            {
                false,
                new Manche(Contrat.GardeContre, new Joueur("Joueur", 0), 1, 50, new StubBonus().chargerListeBonusMoyen(), 4),
                new Manche(Contrat.GardeContre, new Joueur("Joueur", 0), 2, 50, new StubBonus().chargerListeBonusMoyen(), 4)
            };
        }

        #endregion

        #region Data Partie

        public static IEnumerable<object[]> Data_TestConstructeurPartie()
        {

            yield return new object[]
            {
                true,
                new StubJoueur().chargerJoueurPartie3J(),
                new StubManche().chargerLesManche3J(new StubJoueur().chargerJoueurPartie3J())
            };
            yield return new object[]
            {
                true,
                new StubJoueur().chargerJoueurPartie4J(),
                new StubManche().chargerLesManche4J(new StubJoueur().chargerJoueurPartie4J())
            };
            yield return new object[]
            {
                true,
                new StubJoueur().chargerJoueurPartie5J(),
                new StubManche().chargerLesManche5J(new StubJoueur().chargerJoueurPartie5J())
            };
            yield return new object[]
            {
                false,
                new List<Joueur>
                {
                    new Joueur("albertus", 56, "Patricus"),
                    new Joueur("dani", 10, "Duboit", "daniel", "dani_avatar.png"),
                    new Joueur("egard", 10, "Duboit", "", "dani_avatar.png"),
                    new Joueur("chaise", 10, "Duboit", "laTable", "tabouret.png"),
                    new Joueur("Andreal", 58, "Bourdin", "Andrea", "andread.png"),
                    new Joueur("Andreal", 58, "Bourdin", "Andrea", "andread.png")
                },
                new StubManche().chargerLesManche5J(new StubJoueur().chargerJoueurPartie5J())
            };
            yield return new object[]
            {
               false,
               null,
               new StubManche().chargerLesManche5J(new StubJoueur().chargerJoueurPartie5J())
            };
            yield return new object[]
            {
                false,
                null,
                null
            };
            yield return new object[]
            {
                true,
                new StubJoueur().chargerJoueurPartie5J(),
                null
            };
            yield return new object[]
            {
                false,
                new List<Joueur> {
                    new Joueur("albertus", 56, "Patricus")
                },
                null
            };

        }

        #region Manche
        public static IEnumerable<object[]> Data_TestAjouterManche()
        {

            yield return new object[]
            {
                false,
                new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3),
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })

            };
            yield return new object[]
            {
                true,
                new Manche(Contrat.Garde, new Joueur("JoueurQuiprend", 0), 2, 50, new StubBonus().chargerListeBonusUnSeul(), 5, new Joueur("JoueurAllier", 0)),
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                true,
                new Manche(Contrat.Garde, new Joueur("JoueurQuiprend", 0), 3, 10, new StubBonus().chargerListeBonusUnSeul(),  5, new Joueur("JoueurAllier", 0)),
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                true,
                new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 4, 50, new StubBonus().chargerListeBonusMoyen(), 5,  new Joueur("JoueurAllier", 0)),
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>())
            };
            yield return new object[]
            {
                false,
                null,
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>())
            };
        }

        public static IEnumerable<object[]> Data_TestSupprimerManche()
        {

            yield return new object[]
            {
                true,
                new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3),
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                new Manche(Contrat.Garde, new Joueur("JoueurQuiprend", 0), 2, 50, new StubBonus().chargerListeBonusUnSeul(), 5, new Joueur("JoueurAllier", 0)),
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                null,
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })
            };
        }

        public static IEnumerable<object[]> Data_TestModifierManche()
        {

            yield return new object[]
            {
                true,
                new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3),
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                new Manche(Contrat.Garde, new Joueur("JoueurQuiprend", 0), 2, 50, new StubBonus().chargerListeBonusUnSeul(), 5, new Joueur("JoueurAllier", 0)),
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                null,
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })
            };
        }

        #endregion

        #region Joueur

        public static IEnumerable<object[]> Data_TestAjouterJoueur()
        {

            yield return new object[]
            {
                true,
                new Joueur("JoueurAjouter", 0),
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })

            };
            yield return new object[]
            {
                false,
                new Joueur("albertus", 56, "Patricus"),
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                new Joueur("JoueurAjouter", 0),
                new Partie(new StubJoueur().chargerJoueurPartie5J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                null,
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche> {})
            };
        }

        public static IEnumerable<object[]> Data_TestSupprimerJoueur()
        {

            yield return new object[]
            {
                false,
                new Joueur("JoueurSupprimer", 0),
                new Partie(new StubJoueur().chargerJoueurPartie5J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                true,
                new Joueur("albertus", 56, "Patricus"),
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                null,
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })
            };
        }

        public static IEnumerable<object[]> Data_TestModifierJoueur()
        {

            yield return new object[]
            {
                true,
                new Joueur("albertus", 70, "Patricus"),
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                new Joueur("JoueurAModifier", 0),
                new Partie(new StubJoueur().chargerJoueurPartie5J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                null,
                new Partie(new StubJoueur().chargerJoueurPartie3J(), new List<Manche>
                {
                    new Manche(Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 1, 60, new StubBonus().chargerListeBonusMoyen(), 3)
                })
            };
        }
        #endregion


        public static IEnumerable<object[]> Data_TestEqualsPartie()
        {

            yield return new object[]
            {
                true,
                new StubPartie().chargerPartie3J(),
                new StubPartie().chargerPartie3J()

            };
            yield return new object[]
            {
                false,
                new StubPartie().chargerPartie3J(),
                new StubPartie().chargerPartie4J(),
            };
            yield return new object[]
            {
                false,
                new StubPartie().chargerPartie4J(),
                null,
            };
        }


        #endregion

        #region Data Joueur
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

        #endregion

        #region Data Calculator
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
#endregion
    }
}

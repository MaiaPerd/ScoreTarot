using Microsoft.EntityFrameworkCore.Diagnostics;
using Model;
using Stub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitaires
{
    public class UnitTestControlerDto
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
                new ManagerStub().ChargerListeBonusBien(),
                4

            };
            yield return new object[]
            {
                false,
                Contrat.GardeContre,
                new Joueur("Joueur", 0),
                -14,
                new ManagerStub().ChargerListeBonusBien(),
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
                new Manche(1, Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
            };
            yield return new object[]
            {
                -51,
                new Joueur("JoueurAllier", 0),
                new Manche(1 ,Contrat.Garde, new Joueur("JoueurQuiprend", 0), 50, new ManagerStub().ChargerListeBonusUnSeul(), 5, new Joueur("JoueurAllier", 0))
            };
            yield return new object[]
            {
                -153,
                new Joueur("JoueurQuiprend", 0),
                new Manche(1 ,Contrat.Garde, new Joueur("JoueurQuiprend", 0), 50, new ManagerStub().ChargerListeBonusUnSeul(),  5, new Joueur("JoueurAllier", 0))
            };
            yield return new object[]
            {
                221,
                new Joueur("Joueur", 0),
                new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 50, new ManagerStub().ChargerListeBonusMoyen(), 5,  new Joueur("JoueurAllier", 0))
            };
            yield return new object[]
            {
                -229,
                new Joueur("Joueur", 0),
                new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 4)
            };
        }

        public static IEnumerable<object[]> Data_TestEqualsManche()
        {

            yield return new object[]
            {
                true,
                new Manche(1 ,Contrat.GardeContre, new Joueur("Joueur", 0), 50, new ManagerStub().ChargerListeBonusMoyen(), 4),
                new Manche(1 ,Contrat.GardeContre, new Joueur("Joueur", 0), 50, new ManagerStub().ChargerListeBonusMoyen(), 4)
            };
            yield return new object[]
            {
                false,
                new Manche(1 ,Contrat.GardeContre, new Joueur("Joueur", 0), 50, new ManagerStub().ChargerListeBonusMoyen(), 4),
                new Manche(2 ,Contrat.GardeContre, new Joueur("Joueur", 0), 50, new ManagerStub().ChargerListeBonusMoyen(), 4)
            };
        }

        #endregion

        #region Data Partie

        public static IEnumerable<object[]> Data_TestConstructeurPartie()
        {

            yield return new object[]
            {
                true,
                new ManagerStub().ChargerDesJoueurPourUnePartie(3),
                new ManagerStub().ChargerListManche(3,new ManagerStub().ChargerDesJoueurPourUnePartie(3))
            };
            yield return new object[]
            {
                true,
                new ManagerStub().ChargerDesJoueurPourUnePartie(4),
                new ManagerStub().ChargerListManche(4,new ManagerStub().ChargerDesJoueurPourUnePartie(4))
            };
            yield return new object[]
            {
                true,
                new ManagerStub().ChargerDesJoueurPourUnePartie(5),
                new ManagerStub().ChargerListManche(5,new ManagerStub().ChargerDesJoueurPourUnePartie(5))
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
                new ManagerStub().ChargerListManche(5,new ManagerStub().ChargerDesJoueurPourUnePartie(5))
            };
            yield return new object[]
            {
               false,
               null,
               new ManagerStub().ChargerListManche(5,new ManagerStub().ChargerDesJoueurPourUnePartie(5))
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
                new ManagerStub().ChargerDesJoueurPourUnePartie(5),
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
                new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3),
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })

            };
            yield return new object[]
            {
                true,
                new Manche(2 ,Contrat.Garde, new Joueur("JoueurQuiprend", 0), 50, new ManagerStub().ChargerListeBonusUnSeul(), 5, new Joueur("JoueurAllier", 0)),
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                true,
                new Manche(3 ,Contrat.Garde, new Joueur("JoueurQuiprend", 0), 10, new ManagerStub().ChargerListeBonusUnSeul(),  5, new Joueur("JoueurAllier", 0)),
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                true,
                new Manche(4 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 50, new ManagerStub().ChargerListeBonusMoyen(), 5,  new Joueur("JoueurAllier", 0)),
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>())
            };
            yield return new object[]
            {
                false,
                null,
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>())
            };
        }

        public static IEnumerable<object[]> Data_TestSupprimerManche()
        {

            yield return new object[]
            {
                true,
                new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3),
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                new Manche(2 ,Contrat.Garde, new Joueur("JoueurQuiprend", 0), 50, new ManagerStub().ChargerListeBonusUnSeul(), 5, new Joueur("JoueurAllier", 0)),
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                null,
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })
            };
        }

        public static IEnumerable<object[]> Data_TestModifierManche()
        {

            yield return new object[]
            {
                true,
                new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3),
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                new Manche(2 ,Contrat.Garde, new Joueur("JoueurQuiprend", 0), 50, new ManagerStub().ChargerListeBonusUnSeul(), 5, new Joueur("JoueurAllier", 0)),
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                null,
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
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
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })

            };
            yield return new object[]
            {
                false,
                new Joueur("albertus", 56, "Patricus"),
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                new Joueur("JoueurAjouter", 0),
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(5), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                null,
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche> {})
            };
        }

        public static IEnumerable<object[]> Data_TestSupprimerJoueur()
        {

            yield return new object[]
            {
                false,
                new Joueur("JoueurSupprimer", 0),
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(5), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                true,
                new Joueur("albertus", 56, "Patricus"),
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                null,
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })
            };
        }

        public static IEnumerable<object[]> Data_TestModifierJoueur()
        {

            yield return new object[]
            {
                true,
                new Joueur("albertus", 70, "Patricus"),
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                new Joueur("JoueurAModifier", 0),
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(5), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })
            };
            yield return new object[]
            {
                false,
                null,
                new Partie(new ManagerStub().ChargerDesJoueurPourUnePartie(3), new List<Manche>
                {
                    new Manche(1 ,Contrat.GardeContre, new Joueur("JoueurQuiprend", 0), 60, new ManagerStub().ChargerListeBonusMoyen(), 3)
                })
            };
        }
        #endregion


        public static IEnumerable<object[]> Data_TestEqualsPartie()
        {

            yield return new object[]
            {
                true,
                new ManagerStub().ChargerUnePartie(3),
                new ManagerStub().ChargerUnePartie(3)

            };
            yield return new object[]
            {
                false,
                new ManagerStub().ChargerUnePartie(3),
                new ManagerStub().ChargerUnePartie(4),
            };
            yield return new object[]
            {
                false,
                new ManagerStub().ChargerUnePartie(4),
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
                Bonus.Excuse,
                Contrat.GardeContre,
                70
            };
            yield return new object[]
            {
                -196,
                Bonus.Excuse,
                Contrat.GardeContre,
                5
            };
            yield return new object[]
            {
                -191,
                Bonus.ExcuseDoublePoignee,
                Contrat.GardeContre,
                40
            };
            yield return new object[]
            {
                -151,
                Bonus.Le21Excuse,
                Contrat.GardeContre,
                40
            };
            yield return new object[]
            {
                -181,
                Bonus.ExcuseSimplePoignee,
                Contrat.GardeContre,
                40
            };
            yield return new object[]
            {
                -191,
                Bonus.TriplePoignee,
                Contrat.GardeContre,
                55
            };
            yield return new object[]
            {
                194,
                Bonus.SimplePoignee,
                Contrat.GardeContre,
                80
            };
            yield return new object[]
            {
                -201,
                Bonus.PetitAuBout | Bonus.Petit,
                Contrat.GardeContre,
                40
            };
            yield return new object[]
            {
                190,
                Bonus.Le21,
                Contrat.GardeContre,
                91
            };
            yield return new object[]
            {
                -116,
                Bonus.None,
                Contrat.GardeSans,
                40
            };
            yield return new object[]
            {
                -61,
                Bonus.Excuse,
                Contrat.Garde,
                40
            };
            yield return new object[]
            {
                -41,
                Bonus.None,
                Contrat.Prise,
                40
            };
            yield return new object[]
            {
                32,
                Bonus.Excuse,
                Contrat.Prise,
                58
            };
        }
        #endregion

        #region Data StubManager
        public static IEnumerable<object[]> Data_TestStub()
        {

            yield return new object[]
            {
                3,
                new List<Joueur>(){ new Joueur("Daniel", 51) , new Joueur("Francis", 51) , new Joueur("Antoine", 51) },
                12
            };
            yield return new object[]
            {
                4,
                new List<Joueur>(){ new Joueur("Daniel", 51) , new Joueur("Francis", 51) , new Joueur("Antoine", 51), new Joueur("Christophe", 51) },
                12
            };
            yield return new object[]
            {
                5,
                new List<Joueur>(){ new Joueur("Daniel", 51) , new Joueur("Francis", 51) , new Joueur("Antoine", 51), new Joueur("Christophe", 51), new Joueur("Bernadette", 51) },
                12
            };

        }
        #endregion

        #region Data Extension
        public static IEnumerable<object[]> Data_TestExtensionJoueur()
        {

            yield return new object[]
            {
                new Joueur("Daniel", 51)

            };
            yield return new object[]
            {
                new Joueur("Daniel",50,"DELACROIX","Francis","img")

            };
            yield return new object[]
            {
                new Joueur("Daniel", 51,"img")

            };
            yield return new object[]
            {
                new Joueur("Daniel", 51,"img","Francis")

            };
            yield return new object[]
            {
                new Joueur("Daniel", 51,"DELACROIX",null,"img")

            };
            yield return new object[]
            {
                new Joueur("Daniel", 51,null,"Francis","img")

            };
        }

        public static IEnumerable<object[]> Data_TestExtentionPartie()
        {
            yield return new object[]{
                new Partie(
                    new List<Joueur>(){new Joueur("Patrick",50),new Joueur("Francis",15),new Joueur("Marta",77)},new List<Manche>())
            };
            yield return new object[]{
                new Partie(
                    new List<Joueur>(){new Joueur("Patrick",50),new Joueur("Francis",15),new Joueur("Marta",77)},new List<Manche>()
                    {
                        new Manche(Contrat.Garde,new Joueur("Patrick",50),40,Bonus.ExcuseTriplePoignee,3)
                    })
            };
            yield return new object[]{
                new Partie(
                    new List<Joueur>(){new Joueur("Patrick",50),new Joueur("Francis",15),new Joueur("Marta",77)},new List<Manche>()
                    {
                        new Manche(Contrat.Garde,new Joueur("Patrick",50),40,Bonus.ExcuseTriplePoignee,3)
                    })
            };
        }
        public static IEnumerable<object[]> Data_TestExtentionManche()
        {
            yield return new object[]{
                new Manche(Contrat.Garde,new Joueur("Patoch",50),80,Bonus.PetitAuBoutSimplePoignee,5)
            };
            yield return new object[]{
                new Manche(Contrat.Garde,new Joueur(";-;",9876543),80,Bonus.PetitAuBoutExcuseTriplePoignee,4)
            };
            yield return new object[]{
                new Manche(Contrat.Garde,new Joueur(";-;",9876543),80, Bonus.PetitAuBoutExcuseTriplePoignee,4,new Joueur("arheuh",4))
            };
        }
        public static IEnumerable<Object[]> Data_TestExtentionContrat()
        {
            yield return new object[]
            {
                Contrat.Garde
            };
            yield return new object[]
            {
                Contrat.GardeContre
            };
            yield return new object[]
            {
                Contrat.GardeSans
            };
            yield return new object[]
            {
                Contrat.Prise
            };
        }

        public static IEnumerable<Object[]> Data_TestExtensionBonus()
        {
            yield return new object[]
            {
                Bonus.TriplePoignee
            };
            yield return new object[]
            {
                Bonus.DoublePoignee
            };
            yield return new object[]
            {
                Bonus.PetitAuBout
            };
            
            yield return new object[]
            {
                Bonus.SimplePoignee
            };
            yield return new object[]
            {
                Bonus.Petit
            };
            yield return new object[]
            {
                Bonus.Le21
            };
        }
        #endregion
        #region Gestionnaire Model
        public static IEnumerable<Object[]> Data_TestGestionnaire()
        {
            yield return new object[]
            {
                new List<Joueur>(){new Joueur("Daniel", 45),new Joueur("Patricier",78) },
            };
            yield return new object[]
            {
                new List<Joueur>(){new Joueur("Daniel", 45),new Joueur("Patricier",78),new Joueur("Paratata",6),new Joueur("Tarl",6) },
            };
            yield return new object[]
            {
                new List<Joueur>(){new Joueur("Daniel", 45),new Joueur("Patricier",78),new Joueur("Paratata",6),new Joueur("Tarl",6),new Joueur("f",6) },
            };
            yield return new object[]
            {
                new List<Joueur>(){new Joueur("Daniel", 45),new Joueur("Patricier",78),
                    new Joueur("Paratata",6),new Joueur("Tarl",6),new Joueur("f",6),
                new Joueur("p",6),new Joueur("g",6),new Joueur("o",6)},
            };
        }
        public static IEnumerable<Object[]> Data_TestGestionnaireAjoutManche()
        {
            yield return new object[]
            {
                new Partie(new List<Joueur>(){new Joueur("sherpman",87),new Joueur("structman",88),new Joueur("superman",66)}),
                Contrat.GardeSans,
                new Joueur("sherpman",87),
                45,
                Bonus.Excuse|Bonus.SimplePoignee,
                3,
                null
            };
            yield return new object[]
            {
                new Partie(new List<Joueur>(){new Joueur("sherpman",87),new Joueur("structman",88),new Joueur("superman",66),new Joueur("batman",87)}),
                Contrat.GardeSans,
                new Joueur("sherpman",87),
                45,
                Bonus.Excuse|Bonus.SimplePoignee,
                4,
                new Joueur("superman",66)
            };
        }
        public static IEnumerable<Object[]> Data_TestGestionnaireModifManche()
        {
            yield return new object[]
            {
                new Partie(45,new List<Joueur>(){new Joueur("sherpman",87),new Joueur("structman",88),new Joueur("superman",66)},new List<Manche>()),
                new Manche(Contrat.Garde,new Joueur("sherpman",87),40,Bonus.Excuse,3),
                new Manche(Contrat.Prise,new Joueur("sherpman",87),40,Bonus.Excuse,3)
            };
            yield return new object[]
            {
                new Partie(45,new List<Joueur>(){new Joueur("sherpman",87),new Joueur("structman",88),new Joueur("superman",66)},new List<Manche>()),
                new Manche(Contrat.Garde,new Joueur("sherpman",87),40,Bonus.Excuse,3),
                new Manche(Contrat.Prise,new Joueur("sherpman",87),41,Bonus.Excuse,3)
            };
            yield return new object[]
            {
                new Partie(new List<Joueur>(){new Joueur("sherpman",87),new Joueur("structman",88),new Joueur("superman",66)}),
                new Manche(Contrat.Garde,new Joueur("sherpman",87),40,Bonus.Excuse,3),
                new Manche(Contrat.Prise,new Joueur("sherpman",87),40,Bonus.ExcuseDoublePoignee|Bonus.Petit,3)
            };
            yield return new object[]
            {
                new Partie(new List<Joueur>(){new Joueur("sherpman",87),new Joueur("structman",88),new Joueur("superman",66)}),
                new Manche(Contrat.Garde,new Joueur("sherpman",87),40,Bonus.Excuse,3),
                new Manche(Contrat.Prise,new Joueur("structman",88),40,Bonus.ExcuseDoublePoignee|Bonus.Petit,3)
            };
        }
        public static IEnumerable<Object[]> Data_TestGestionnaireSuppressionJoueur()
        {
            yield return new object[]
            {
                new Partie(45,new List<Joueur>(){new Joueur("sherpman",87),new Joueur("structman",88),new Joueur("superman",66)},new List<Manche>()),
                new List<Joueur>(){new Joueur("sherpman",87),new Joueur("structman",88),new Joueur("superman",66)}
            };
        }
        #endregion
        }
    }

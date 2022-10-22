using System;
using EntityFramework;
using EntityFramework.Entity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Model;

namespace TestsUnitaires
{
    public class UnitTestBDParties
    {
      
        [Fact]
        public void Add_Test_Parties()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            
            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "Add_Test_Partie_database")
                .Options;


            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();


                //List<JoueurEntity> joueurs = new List<JoueurEntity>();
             //   joueurs.Add(new JoueurEntity { Pseudo = "albertus", Age = 56, Nom = "Patricus", Prenom = "Albert", URLIMG = "image" });

                Dictionary<string, PartieEntity> parties = new Dictionary<string, PartieEntity>()
                {
                    ["partie1"] = new PartieEntity { Id=1 },
                    ["partie2"] = new PartieEntity { Id=2 }
                };
                Dictionary<string, JoueurEntity> joueurs = new Dictionary<string, JoueurEntity>()
                {
                    ["albertus"] = new JoueurEntity {  Pseudo = "albertus", Age = 56, Nom = "Patricus", Prenom = "Albert", URLIMG = "image" },
                    ["dani"] = new JoueurEntity { Pseudo = "dani", Age = 10, Nom = "Duboit", Prenom = "Daniel", URLIMG = "image" },
                    ["egard"] = new JoueurEntity {  Pseudo = "egard", Age = 10, Nom = "Duboit", Prenom = "Egard", URLIMG = "image" },
                    ["chaise"] = new JoueurEntity { Pseudo = "chaise", Age = 10, Nom = "Duboit", Prenom = "LaTable", URLIMG = "image" },
                    ["andreal"] = new JoueurEntity {  Pseudo = "andreal", Age = 10, Nom = "Bourdin", Prenom = "Andrea", URLIMG = "image" }
                };


                context.Joueurs.Add(joueurs["albertus"]);
                context.Parties.Add(parties["partie1"]);
              
                context.SaveChanges();

                PartieJoueur partieJoueur = new PartieJoueur { Joueur = joueurs["albertus"], Partie = parties["partie1"] };

                context.PartieJoueurs.Add(partieJoueur);
                //  joueurs["albertus"].PartieJoueurs = parties["partie1"].PartieJoueurs;
                //joueurs["albertus"].AjouterPartie(parties["partie1"]);
                /*joueurs["dani"].AjouterPartie(parties["partie1"]);
                joueurs["egard"].AjouterPartie(parties["partie1"]);

                MancheEntity manche1 = new MancheEntity { JoueurQuiPrend = joueurs["albertus"], NbJoueur = context.Joueurs.Count(), Bonus = BonusEntity.Le21DoublePoignee, Contrat = ContratEntity.Garde, Score = 52, Date = new DateTime(2022, 11, 27) };
                MancheEntity manche2 = new MancheEntity { JoueurQuiPrend = joueurs["dani"], NbJoueur = context.Joueurs.Count(), Bonus = BonusEntity.PetitAuBoutLe21, Contrat = ContratEntity.Prise, Score = 41, Date = new DateTime(2022, 11, 27) };
                MancheEntity manche3 = new MancheEntity { JoueurQuiPrend = joueurs["egard"], NbJoueur = context.Joueurs.Count(), Bonus = BonusEntity.PetitAuBoutExcuse, Contrat = ContratEntity.GardeSans, Score = 46, Date = new DateTime(2022, 11, 27), JoueurAllier = andreal };


                parties["partie1"].Manches.Add(manche1);
                parties["partie1"].Manches.Add(manche2);
                /*
                parties["partie2"].AjouterJoueur(joueurs["albertus"]);
                parties["partie2"].AjouterJoueur(joueurs["dani"]);
                parties["partie2"].AjouterJoueur(joueurs["egard"]);
                parties["partie2"].AjouterJoueur(joueurs["chaise"]);
                parties["partie2"].AjouterJoueur(joueurs["andreal"]);

                parties["partie2"].Manches.Add(manche3);*/


                try
                {
                    context.SaveChanges();
                }
                catch(InvalidOperationException e)
                {
                    Console.WriteLine(e);
                }
                
               

               
            }
          
            using (var context = new SQLiteContext(options))
            {/*
                Assert.Equal(2, context.Parties.Count());
                Assert.Equal(3, context.Parties.First().Joueurs.Count());
                Assert.Equal(5, context.Parties.Last().Joueurs.Count());
                Assert.Equal(3, context.Parties.First().Manches.Count());*/
            }

        }

     
    }
}


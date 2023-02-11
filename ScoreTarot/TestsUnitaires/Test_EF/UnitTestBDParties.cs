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
        public void Add_Modify_Test_Parties()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            
            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "Add_Modify_Test_Partie_database")
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

                //Partie 1
                parties["partie1"].AjouterJoueur(joueurs["albertus"]);
                parties["partie1"].AjouterJoueur(joueurs["dani"]);
                parties["partie1"].AjouterJoueur(joueurs["egard"]);

                //Partie2
                parties["partie2"].AjouterJoueur(joueurs["albertus"]);
                parties["partie2"].AjouterJoueur(joueurs["dani"]);
                parties["partie2"].AjouterJoueur(joueurs["egard"]);
                parties["partie2"].AjouterJoueur(joueurs["chaise"]);
                parties["partie2"].AjouterJoueur(joueurs["andreal"]);
 
                MancheEntity manche1 = new MancheEntity { JoueurQuiPrend = joueurs["albertus"], NbJoueur = context.Joueurs.Count(), Bonus = BonusEntity.Le21DoublePoignee, Contrat = ContratEntity.Garde, Score = 52, Date = new DateTime(2022, 11, 27) };
                MancheEntity manche2 = new MancheEntity { JoueurQuiPrend = joueurs["dani"], NbJoueur = context.Joueurs.Count(), Bonus = BonusEntity.PetitAuBoutLe21, Contrat = ContratEntity.Prise, Score = 41, Date = new DateTime(2022, 11, 27) };
                MancheEntity manche3 = new MancheEntity { JoueurQuiPrend = joueurs["egard"], NbJoueur = context.Joueurs.Count(), Bonus = BonusEntity.PetitAuBoutExcuse, Contrat = ContratEntity.GardeSans, Score = 46, Date = new DateTime(2022, 11, 27), JoueurAllier = joueurs["andreal"] };


                parties["partie1"].Manches.Add(manche1);
                parties["partie1"].Manches.Add(manche2);

                parties["partie2"].Manches.Add(manche3);

                context.Joueurs.AddRange(joueurs.Values);
                context.Parties.AddRange(parties.Values);

                context.SaveChanges();

            }
          
            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(2, context.Parties.Count());
                Assert.Equal(5, context.Joueurs.Count());
                Assert.Equal(3, context.Manches.Count());
                Assert.Equal(2, context.Parties.Count());
                var joueurPartie1 = (from c in context.Parties
                                     from jp in c.Joueurs
                                     join j in context.Joueurs on jp.Id equals j.Id
                                     where c.Id == 1
                                     select c.Joueurs).ToList();
                var joueurPartie2 = (from c in context.Parties
                                     from jp in c.Joueurs
                                     join j in context.Joueurs on jp.Id equals j.Id
                                     where c.Id == 2
                                     select c.Joueurs).ToList();
                //Assert.Equal(3, joueurPartie1.Count());
                Assert.Equal(5, joueurPartie2.Count());
                /*Assert.Equal(8, context.PartieJoueurs.Count());
                Assert.Equal(1, context.Manches.First().PartieForeignKey);*/
            }

        }

     
    }
}


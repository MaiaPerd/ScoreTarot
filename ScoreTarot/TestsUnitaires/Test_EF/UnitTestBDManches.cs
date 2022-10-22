using System;
using EntityFramework;
using EntityFramework.Entity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestsUnitaires
{
    public class UnitTestBDManches
    {
      
        [Fact]
        public void Add_Test_Manches()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            
            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "Add_Test_Manche_database")
                .Options;

            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                JoueurEntity albertus = new JoueurEntity { Pseudo = "albertus", Age = 56, Nom = "Patricus", Prenom = "Albert", URLIMG = "image" };
                JoueurEntity dani = new JoueurEntity { Pseudo = "dani", Age = 10, Nom = "Duboit", Prenom = "Daniel", URLIMG = "image" };
                JoueurEntity egard = new JoueurEntity { Pseudo = "egard", Age = 10, Nom = "Duboit", Prenom = "Egard", URLIMG = "image" };

                context.Joueurs.Add(albertus);
                context.Joueurs.Add(dani);
                context.Joueurs.Add(egard);

                MancheEntity manche1 = new MancheEntity { JoueurQuiPrend = albertus, NbJoueur = context.Joueurs.Count(), Bonus = BonusEntity.Le21DoublePoignee, Contrat = ContratEntity.Garde, Score = 52, Date = new DateTime(2022, 11, 27) };
                MancheEntity manche2 = new MancheEntity { JoueurQuiPrend = dani, NbJoueur = context.Joueurs.Count(), Bonus = BonusEntity.PetitAuBoutLe21, Contrat = ContratEntity.Prise, Score = 41, Date = new DateTime(2022, 11, 27) };
                MancheEntity manche3 = new MancheEntity { JoueurQuiPrend = albertus, NbJoueur = context.Joueurs.Count(), Bonus = BonusEntity.PetitAuBoutExcuse, Contrat = ContratEntity.GardeSans, Score = 46, Date = new DateTime(2022, 11, 27) };

                context.Manches.Add(manche1);
                context.Manches.Add(manche2);
                context.Manches.Add(manche3);

                context.SaveChanges();
            }
          
            using (var context = new SQLiteContext(options))
            {
                Assert.Equal(3, context.Manches.Count());
                Assert.Equal(2, context.Manches.Where(n => n.JoueurQuiPrend.Pseudo.Equals("albertus")).Count());
                Assert.Equal(52, context.Manches.First().Score);
            }

        }

        [Fact]
        public void Remove_Test_Manches()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "Remove_Test_Manche_database")
                .Options;

            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                JoueurEntity albertus = new JoueurEntity { Pseudo = "albertus", Age = 56, Nom = "Patricus", Prenom = "Albert", URLIMG = "image" };
                JoueurEntity dani = new JoueurEntity { Pseudo = "dani", Age = 10, Nom = "Duboit", Prenom = "Daniel", URLIMG = "image" };
                JoueurEntity egard = new JoueurEntity { Pseudo = "egard", Age = 10, Nom = "Duboit", Prenom = "Egard", URLIMG = "image" };

                context.Joueurs.Add(albertus);
                context.Joueurs.Add(dani);
                context.Joueurs.Add(egard);

                MancheEntity manche1 = new MancheEntity { JoueurQuiPrend = albertus, NbJoueur = context.Joueurs.Count(), Bonus = BonusEntity.Le21DoublePoignee, Contrat = ContratEntity.Garde, Score = 52, Date = new DateTime(2022, 11, 27) };
                MancheEntity manche2 = new MancheEntity { JoueurQuiPrend = dani, NbJoueur = context.Joueurs.Count(), Bonus = BonusEntity.PetitAuBoutLe21, Contrat = ContratEntity.Prise, Score = 41, Date = new DateTime(2022, 11, 27) };
                MancheEntity manche3 = new MancheEntity { JoueurQuiPrend = albertus, NbJoueur = context.Joueurs.Count(), Bonus = BonusEntity.PetitAuBoutExcuse, Contrat = ContratEntity.GardeSans, Score = 46, Date = new DateTime(2022, 11, 27) };

                context.Manches.Add(manche1);
                context.Manches.Add(manche2);
                context.Manches.Add(manche3);

                context.SaveChanges();
            }

            using (var context = new SQLiteContext(options))
            {
                Assert.Equal(3, context.Manches.Count());
            }

            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                JoueurEntity albertus = context.Joueurs.Where(n => n.Pseudo.Contains("albertus")).First();
                JoueurEntity dani = context.Joueurs.Where(n => n.Pseudo.Contains("dani")).First();

                MancheEntity manche1 = context.Manches.Where(n => n.JoueurQuiPrend.Equals(albertus)).First();
                MancheEntity manche2 = context.Manches.Where(n => n.JoueurQuiPrend.Equals(dani)).First();
                MancheEntity manche3 = context.Manches.Where(n => n.JoueurQuiPrend.Equals(albertus)).Last();

                context.Manches.Remove(manche1);
                context.Manches.Remove(manche2);
                context.Manches.Remove(manche3);

                context.SaveChanges();
            }

            using (var context = new SQLiteContext(options))
            {
                Assert.Equal(0, context.Manches.Count());
            }
        }

        [Fact]
        public void Modify_Test_Manches()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "Modify_Test_Manche_database")
                .Options;

            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                JoueurEntity albertus = new JoueurEntity { Pseudo = "albertus", Age = 56, Nom = "Patricus", Prenom = "Albert", URLIMG = "image" };
                JoueurEntity dani = new JoueurEntity { Pseudo = "dani", Age = 10, Nom = "Duboit", Prenom = "Daniel", URLIMG = "image" };
                JoueurEntity egard = new JoueurEntity { Pseudo = "egard", Age = 10, Nom = "Duboit", Prenom = "Egard", URLIMG = "image" };
                JoueurEntity chaise = new JoueurEntity { Pseudo = "chaise", Age = 10, Nom = "Duboit", Prenom = "LaTable", URLIMG = "image" };
                JoueurEntity andreal = new JoueurEntity { Pseudo = "andreal", Age = 10, Nom = "Bourdin", Prenom = "Andrea", URLIMG = "image" };

                context.Joueurs.Add(albertus);
                context.Joueurs.Add(dani);
                context.Joueurs.Add(egard);

                MancheEntity manche1 = new MancheEntity { JoueurQuiPrend = albertus, NbJoueur = context.Joueurs.Count(), Bonus = BonusEntity.Le21DoublePoignee, Contrat = ContratEntity.Garde, Score = 52, Date = new DateTime(2022, 11, 27) };
                MancheEntity manche2 = new MancheEntity { JoueurQuiPrend = dani, NbJoueur = context.Joueurs.Count(), Bonus = BonusEntity.PetitAuBoutLe21, Contrat = ContratEntity.Prise, Score = 42, Date = new DateTime(2022, 11, 27) };
                MancheEntity manche3 = new MancheEntity { JoueurQuiPrend = albertus, NbJoueur = context.Joueurs.Count(), Bonus = BonusEntity.PetitAuBoutExcuse, Contrat = ContratEntity.GardeSans, Score = 42, Date = new DateTime(2022, 11, 27), JoueurAllier = andreal };

                context.Manches.Add(manche1);
                context.Manches.Add(manche2);
                context.Manches.Add(manche3);

                context.SaveChanges();
            }

            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                int scoreToFind = 42;
                Assert.Equal(2, context.Manches.Where(n => n.Score == scoreToFind).Count());
                JoueurEntity joueurToFind = context.Joueurs.Where(n => n.Pseudo.Contains("albertus")).First();
                Assert.Equal(2, context.Manches.Where(n => n.JoueurQuiPrend.Equals(joueurToFind)).Count());
                var test = context.Manches.Where(n => n.Bonus.Equals(BonusEntity.PetitAuBoutExcuse)).Last();
                test.Score = 32;
                test.Bonus = BonusEntity.PetitAuBoutSimplePoignee;
                test.JoueurQuiPrend = context.Joueurs.Where(n => n.Pseudo.Contains("egard")).First();

                context.SaveChanges();
            }

            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                Assert.Equal(0, context.Manches.Where(n => n.Bonus.Equals(BonusEntity.PetitAuBoutExcuse)).Count());
                Assert.Equal(1, context.Manches.Where(n => n.Bonus.Equals(BonusEntity.PetitAuBoutSimplePoignee)).Count());
                int scoreToFind = 32;
                Assert.Equal(1, context.Manches.Where(n => n.Score == scoreToFind).Count());
                JoueurEntity joueurToFind = context.Joueurs.Where(n => n.Pseudo.Contains("egard")).First();
                Assert.Equal(1, context.Manches.Where(n => n.JoueurQuiPrend.Equals(joueurToFind)).Count());
                joueurToFind = context.Joueurs.Where(n => n.Pseudo.Contains("albertus")).First();
                Assert.Equal(1, context.Manches.Where(n => n.JoueurQuiPrend.Equals(joueurToFind)).Count());

            }
        }
    }
}


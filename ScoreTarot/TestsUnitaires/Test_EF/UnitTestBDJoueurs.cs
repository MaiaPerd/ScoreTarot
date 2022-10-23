using System;
using EntityFramework;
using EntityFramework.Entity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestsUnitaires
{
    public class UnitTestBDJoueurs
    {
      
        [Fact]
        public void Add_Test_Joueurs()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            
            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "Add_Test_Joueur_database")
                .Options;

            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                JoueurEntity maia = new JoueurEntity { Pseudo = "Maia", Age = 20, Nom= "Perderizet", Prenom= "Maïa", URLIMG= "img" };
                JoueurEntity cecile = new JoueurEntity { Pseudo = "Cecile", Age = 20, Nom = "Bonal", Prenom = "Celile", URLIMG = "img" };
                JoueurEntity test = new JoueurEntity { Pseudo = "Test", Age= 100, Nom = "Test", Prenom = "Test" , URLIMG = "img" };

                context.Joueurs.Add(maia);
                context.Joueurs.Add(cecile);
                context.Joueurs.Add(test);
                context.SaveChanges();
            }

          
            using (var context = new SQLiteContext(options))
            {
                Assert.Equal(3, context.Joueurs.Count());
                Assert.Equal("Maia", context.Joueurs.First().Pseudo);
                Assert.Equal("Test", context.Joueurs.Last().Nom);
                Assert.Equal(20, context.Joueurs.First().Age);
            }
        }

        [Fact]
        public void Remove_Test_Joueurs()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "Remove_Test_Joueur_database")
                .Options;

            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                JoueurEntity maia = new JoueurEntity { Pseudo = "Maia", Age = 20, Nom = "Perderizet", Prenom = "Maïa", URLIMG = "img" };
                JoueurEntity cecile = new JoueurEntity { Pseudo = "Cecile", Age = 20, Nom = "Bonal", Prenom = "Celile", URLIMG = "img" };
                JoueurEntity test = new JoueurEntity { Pseudo = "Test", Age = 100, Nom = "Test", Prenom = "Test", URLIMG = "img" };

                context.Joueurs.Add(maia);
                context.Joueurs.Add(cecile);
                context.Joueurs.Add(test);
                context.SaveChanges();
            }

            using (var context = new SQLiteContext(options))
            {
                Assert.Equal(3, context.Joueurs.Count());
            }

            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                JoueurEntity maia = context.Joueurs.Where(n => n.Pseudo.Contains("Maia")).First();
                JoueurEntity cecile = context.Joueurs.Where(n => n.Pseudo.Contains("Cecile")).First();
                JoueurEntity test = context.Joueurs.Where(n => n.Pseudo.Contains("Test")).First();

                context.Joueurs.Remove(maia);
                context.Joueurs.Remove(cecile);
                context.Joueurs.Remove(test);
                context.SaveChanges();
            }


            using (var context = new SQLiteContext(options))
            {
                Assert.Equal(0, context.Joueurs.Count());
            }
        }

        [Fact]
        public void Modify_Test_Joueurs()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "Modify_Test_Joueur_database")
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
                context.SaveChanges();
            }

            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "ar";
                Assert.Equal(1, context.Joueurs.Where(n => n.Prenom.Contains(nameToFind)).Count());
                nameToFind = "r";
                Assert.Equal(2, context.Joueurs.Where(n => n.Pseudo.Contains(nameToFind)).Count());
                var test = context.Joueurs.Where(n => n.Pseudo.Contains(nameToFind)).Last();
                test.Prenom = "New name";
                test.Age = 15;
                context.SaveChanges();
            }

            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "ar";
                Assert.Equal(0, context.Joueurs.Where(n => n.Prenom.Contains(nameToFind)).Count());
                nameToFind = "name";
                Assert.Equal(1, context.Joueurs.Where(n => n.Prenom.Contains(nameToFind)).Count());
                int ageToFind = 15;
                Assert.Equal(1, context.Joueurs.Where(n => n.Age == ageToFind).Count());
                string URLtoFind = "image";
                Assert.Equal(3, context.Joueurs.Where(n => n.URLIMG.Contains(URLtoFind)).Count());
            }

        }
    }
}


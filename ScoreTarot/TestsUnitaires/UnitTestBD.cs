using System;
using EntityFramework;
using EntityFramework.Entity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Model;

namespace TestsUnitaires
{
    public class UnitTestBD
    {
      
        [Fact]
        public void Add_Test_Joueurs()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            
            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "Add_Test_database")
                .Options;

            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                JoueurEntity maia = new JoueurEntity { Pseudo = "Maia", Age = 20, Nom= "Perderizet", Prenom= "Maïa", URLIMG= "img" };
                JoueurEntity cecile = new JoueurEntity { Pseudo = "Cecile", Age = 20, Nom = "Bonal", Prenom = "Celile", URLIMG = "img" };
                JoueurEntity test = new JoueurEntity { Pseudo = "Test", Age= 10, Nom = "Test", Prenom = "Test" , URLIMG = "img" };

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
        public void Modify_Test_Joueurs()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "Add_Test_database")
                .Options;

            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                JoueurEntity maia = new JoueurEntity { Pseudo = "Maia", Age = 20, Nom = "Perderizet", Prenom = "Maïa", URLIMG = "img" };
                JoueurEntity cecile = new JoueurEntity { Pseudo = "Cecile", Age = 20, Nom = "Bonal", Prenom = "Celile", URLIMG = "img" };
                JoueurEntity test = new JoueurEntity { Pseudo = "Test", Age = 10, Nom = "test", Prenom = "test", URLIMG = "img" };

                context.Joueurs.Add(maia);
                context.Joueurs.Add(cecile);
                context.Joueurs.Add(test);
                context.SaveChanges();
            }

            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "tes";
                Assert.Equal(1, context.Joueurs.Where(n => n.Nom.Contains(nameToFind)).Count());
                nameToFind = "e";
                Assert.Equal(2, context.Joueurs.Where(n => n.Nom.Contains(nameToFind)).Count());
                var test = context.Joueurs.Where(n => n.Nom.Contains(nameToFind)).Last();
                test.Nom = "New name";
                test.Age = 15;
                context.SaveChanges();
            }

            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "tes";
                Assert.Equal(0, context.Joueurs.Where(n => n.Nom.Contains(nameToFind)).Count());//Erreur
                nameToFind = "name";
                Assert.Equal(1, context.Joueurs.Where(n => n.Nom.Contains(nameToFind)).Count());
                int ageToFind = 15;
                Assert.Equal(1, context.Joueurs.Where(n => n.Age == ageToFind).Count());
                ageToFind = 20;
                Assert.Equal(2, context.Joueurs.Where(n => n.Age == ageToFind).Count());
                string URLtoFind = "img";
                Assert.Equal(3, context.Joueurs.Where(n => n.URLIMG.Contains(URLtoFind)).Count());
            }
        }
    }
}


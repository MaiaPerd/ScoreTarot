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
        public void Add_Test()
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
                JoueurEntity test = new JoueurEntity { Pseudo = "Test", Age= 10, Nom = "test", Prenom = "test", URLIMG = "img" };

                context.Joueurs.Add(maia);
                context.Joueurs.Add(cecile);
                context.Joueurs.Add(test);
                context.SaveChanges();
            }

          
            using (var context = new SQLiteContext(options))
            {
                Assert.Equal(3, context.Joueurs.Count());
                Assert.Equal("Maia", context.Joueurs.First().Pseudo);
            }
        }

        [Fact]
        public void Modify_Test()
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

                string nameToFind = "Te";
                Assert.Equal(2, context.Joueurs.Where(n => n.Pseudo.ToLower().Contains(nameToFind)).Count());
                nameToFind = "es";
                Assert.Equal(1, context.Joueurs.Where(n => n.Pseudo.ToLower().Contains(nameToFind)).Count());
                var test = context.Joueurs.Where(n => n.Pseudo.ToLower().Contains(nameToFind)).First();
                test.Pseudo = "New name";
                context.SaveChanges();
            }

            using (var context = new SQLiteContext(options))
            {
                context.Database.EnsureCreated();

                string nameToFind = "Te";
                Assert.Equal(1, context.Joueurs.Where(n => n.Pseudo.ToLower().Contains(nameToFind)).Count());
                nameToFind = "name";
                Assert.Equal(1, context.Joueurs.Where(n => n.Pseudo.ToLower().Contains(nameToFind)).Count());
            }
        }
    }
}


using EntityFramework.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class SQLiteContext : DbContext
    {

        public DbSet<JoueurEntity> Joueurs { get; set; }
        public DbSet<MancheEntity> Manches { get; set; }
        public DbSet<PartieEntity> Parties { get; set; }
        public DbSet<PartieJoueur> PartieJoueurs { get; set; }
       

        public SQLiteContext()
        { }

        public SQLiteContext(DbContextOptions<SQLiteContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source=baseTarotScore.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartieJoueur>().Property<int>("PartieId");
            modelBuilder.Entity<PartieJoueur>().Property<String>("JoueurId");

            modelBuilder.Entity<PartieJoueur>().HasKey("PartieId", "JoueurId");

            modelBuilder.Entity<PartieJoueur>()
                .HasOne(partieJoueur => partieJoueur.Partie)
                .WithMany(partie => partie.PartieJoueurs)
                .HasForeignKey("PartieId");
            modelBuilder.Entity<PartieJoueur>()
                .HasOne(partieJoueur => partieJoueur.Joueur)
                .WithMany(joueur => joueur.PartieJoueurs)
                .HasForeignKey("JoueurId");

            base.OnModelCreating(modelBuilder);
        }

       
    }
}

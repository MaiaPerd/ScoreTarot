using APIGraphQL.Query;
using AutoMapper;
using DTOs;
using EntityFramework;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitaires.Test_API
{
    [TestClass]
    public class UnitTestAPIJoueurs
    {
        private readonly IMapper _mapper;
        private readonly ILogger<Mutation> _logger;
        private readonly Mutation _mutation;

        public UnitTestAPIJoueurs()
        {
            var maperconf = new MapperConfiguration(cgf => cgf.AddProfile(typeof(Mapper)));
            _mapper = maperconf.CreateMapper();
            _logger = new NullLogger<Mutation>();
            _mutation = new Mutation(_logger, _mapper);
        }

        [TestMethod]
        public void Add_Test_Joueurs()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "Add_Test_Joueur_API")
                .Options;

            DataManagerAPI dataManagerAPI = new DataManagerAPI(new SQLiteContext(options));

            JoueurDto joueurDto = new JoueurDto { Pseudo = "albertus", Age = 56, Nom = "Patricus", Prenom = "Albert", Id = 0 };
            Task<JoueurDto> task = _mutation.AddJoueur(joueurDto, dataManagerAPI);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(joueurDto.Id, task.Result.Id);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(joueurDto.Pseudo, task.Result.Pseudo);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(joueurDto.Nom, task.Result.Nom);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(joueurDto.Prenom, task.Result.Prenom);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(joueurDto.Age, task.Result.Age);
            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsException<Exception>(() => task.Wait());

        }

        [Fact]
        public void Remove_Test_Joueurs()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "Remove_Test_Joueur_API")
                .Options;

           
        }

        [Fact]
        public void Modify_Test_Joueurs()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "Modify_Test_Joueur_API")
                .Options;

           

        }
    }
}

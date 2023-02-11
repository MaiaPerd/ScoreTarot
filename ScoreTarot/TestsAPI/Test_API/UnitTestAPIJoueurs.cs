using APIGraphQL.Query;
using AutoMapper;
using DTOs;
using EntityFramework;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestsUnitaires.Test_API
{
    [TestClass]
    public class UnitTestAPIJoueurs
    {
        private readonly IMapper _mapper;
        private readonly ILogger<Mutation> _logger;
        private readonly Mutation _mutation;
        private readonly DataManagerAPI dataManagerAPI;

        public UnitTestAPIJoueurs()
        {
            var maperconf = new MapperConfiguration(cgf => cgf.AddProfile(typeof(APIGraphQL.Mappers.Mapper)));
            _mapper = maperconf.CreateMapper();
            _logger = new NullLogger<Mutation>();
            _mutation = new Mutation(_logger, _mapper);

            //DataManager
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "Test_Joueur_API_GraphQL")
                .Options;

            dataManagerAPI = new DataManagerAPI(new SQLiteContext(options));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Add_Test_Joueurs_API()
        {

            JoueurDto joueurDto = new JoueurDto { Pseudo = "albertus", Age = 56, Nom = "Patricus", Prenom = "Albert", Id = 1, URLIMG = ""};
            JoueurDto task = await _mutation.AddJoueur(joueurDto, dataManagerAPI);
            Assert.AreEqual(joueurDto.Id, task.Id);
            Assert.AreEqual(joueurDto.Pseudo, task.Pseudo);
            Assert.AreEqual(joueurDto.Nom, task.Nom);
            Assert.AreEqual(joueurDto.Prenom, task.Prenom);
            Assert.AreEqual(joueurDto.Age, task.Age);

            JoueurDto joueurDto2 = new JoueurDto { Pseudo = "albertus", Age = 56, Nom = "Patricus", Prenom = "Albert", Id = 1, URLIMG = "" };
            await _mutation.AddJoueur(joueurDto2, dataManagerAPI);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Remove_Test_Joueurs_API()
        {
            JoueurDto joueurDto = new JoueurDto { Pseudo = "albertus", Age = 56, Nom = "Patricus", Prenom = "Albert", Id = 0, URLIMG = "" };
            JoueurDto task = await _mutation.DeleteJoueur(joueurDto, dataManagerAPI);
            Assert.AreEqual(joueurDto.Id, task.Id);
            Assert.AreEqual(joueurDto.Pseudo, task.Pseudo);
            Assert.AreEqual(joueurDto.Nom, task.Nom);
            Assert.AreEqual(joueurDto.Prenom, task.Prenom);
            Assert.AreEqual(joueurDto.Age, task.Age);

            JoueurDto joueurDto2 = new JoueurDto { Pseudo = "aaaa", Age = 56, Nom = "Patricus", Prenom = "Albert", Id = 5, URLIMG = "" };
            await _mutation.DeleteJoueur(joueurDto2, dataManagerAPI);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Modify_Test_Joueurs_API()
        {
            JoueurDto joueurDto = new JoueurDto { Pseudo = "al", Age = 56, Nom = "Patricus", Prenom = "Albert", Id = 1, URLIMG = "" };
            JoueurDto task = await _mutation.AddJoueur(joueurDto, dataManagerAPI);
            task.Age = 10;
            JoueurDto task2 = await _mutation.UpdateJoueur(task, dataManagerAPI);
            Assert.AreEqual(task.Id, task2.Id);
            Assert.AreEqual(task.Pseudo, task2.Pseudo);
            Assert.AreEqual(task.Nom, task2.Nom);
            Assert.AreEqual(task.Prenom, task2.Prenom);
            Assert.AreEqual(task.Age, task2.Age);

            task2.Id = 15;

            await _mutation.UpdateJoueur(task2, dataManagerAPI);

        }
    }
}

using APIGraphQL.Mappers;
using APIGraphQL.Query;
using AutoMapper;
using DTOs;
using EntityFramework;
using HotChocolate;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestsAPI.Test_API_GraphQL
{
    [TestClass]
    public class UnitTestAPIJoueurs
    {
        private readonly IMapper _mapper;
        private readonly ILogger<Mutation> _logger;
        private readonly Mutation _mutation;
        private readonly Query _query;
        private readonly DataManagerAPI dataManagerAPI;

        public UnitTestAPIJoueurs()
        {
            var maperconf = new MapperConfiguration(cgf => cgf.AddProfile(typeof(APIGraphQL.Mappers.Mapper)));
            _mapper = maperconf.CreateMapper();
            _logger = new NullLogger<Mutation>();
            _mutation = new Mutation(_logger, _mapper);
            _query = new Query(new NullLogger<Query>(), _mapper);

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
            await _mutation.AddJoueur(joueurDto2, dataManagerAPI); // Exception

        }

        [TestMethod]
        public async Task Get_Test_Joueurs_API()
        {
            IEnumerable<JoueurDto> task1 = await _query.GetJoueurs(dataManagerAPI);
            Assert.AreEqual(0, task1.Count());

            JoueurDto joueurDto = new JoueurDto { Pseudo = "albertus", Age = 56, Nom = "Patricus", Prenom = "Albert", Id = 1, URLIMG = "" };
            await _mutation.AddJoueur(joueurDto, dataManagerAPI);
            IEnumerable<JoueurDto> task = await _query.GetJoueurs(dataManagerAPI);
            Assert.AreEqual(1, task.Count());
            Assert.AreEqual(joueurDto.Id, task.ElementAt(0).Id);
            Assert.AreEqual(joueurDto.Pseudo, task.ElementAt(0).Pseudo);
            Assert.AreEqual(joueurDto.Nom, task.ElementAt(0).Nom);
            Assert.AreEqual(joueurDto.Prenom, task.ElementAt(0).Prenom);
            Assert.AreEqual(joueurDto.Age, task.ElementAt(0).Age);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Get_Test_Joueurs_By_Id_API()
        {
            JoueurDto joueurDto = new JoueurDto { Pseudo = "albertus", Age = 56, Nom = "Patricus", Prenom = "Albert", Id = 1, URLIMG = "" };
            await _mutation.AddJoueur(joueurDto, dataManagerAPI);
            JoueurDto task = await _query.GetJoueurById(1, dataManagerAPI);
            Assert.AreEqual(joueurDto.Id, task.Id);
            Assert.AreEqual(joueurDto.Pseudo, task.Pseudo);
            Assert.AreEqual(joueurDto.Nom, task.Nom);
            Assert.AreEqual(joueurDto.Prenom, task.Prenom);
            Assert.AreEqual(joueurDto.Age, task.Age);

            await _query.GetJoueurById(2, dataManagerAPI); // Exception


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Remove_Test_Joueurs_API()
        {
            JoueurDto joueurDto = new JoueurDto { Pseudo = "albertus", Age = 56, Nom = "Patricus", Prenom = "Albert", Id = 2, URLIMG = "" };
            await _mutation.AddJoueur(joueurDto, dataManagerAPI);
            JoueurDto task = await _mutation.DeleteJoueur(joueurDto, dataManagerAPI);
            Assert.AreEqual(joueurDto.Id, task.Id);
            Assert.AreEqual(joueurDto.Pseudo, task.Pseudo);
            Assert.AreEqual(joueurDto.Nom, task.Nom);
            Assert.AreEqual(joueurDto.Prenom, task.Prenom);
            Assert.AreEqual(joueurDto.Age, task.Age);

            JoueurDto joueurDto2 = new JoueurDto { Pseudo = "aaaa", Age = 56, Nom = "Patricus", Prenom = "Albert", Id = 5, URLIMG = "" };
            await _mutation.DeleteJoueur(joueurDto2, dataManagerAPI); // Exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Modify_Test_Joueurs_API()
        {
            JoueurDto joueurDto = new JoueurDto { Id = 3, Pseudo = "al", Age = 56, Nom = "Patricus", Prenom = "Albert", URLIMG = "" };
            JoueurDto task = await _mutation.AddJoueur(joueurDto, dataManagerAPI);
            task.Age = 10;
            JoueurDto task2 = await _mutation.UpdateJoueur(task, dataManagerAPI);
            Assert.AreEqual(task.Id, task2.Id);
            Assert.AreEqual(task.Pseudo, task2.Pseudo);
            Assert.AreEqual(task.Nom, task2.Nom);
            Assert.AreEqual(task.Prenom, task2.Prenom);
            Assert.AreNotEqual(joueurDto.Age, task2.Age);

            task2.Id = 15;

            await _mutation.UpdateJoueur(task2, dataManagerAPI); // Exception
        }
    }
}

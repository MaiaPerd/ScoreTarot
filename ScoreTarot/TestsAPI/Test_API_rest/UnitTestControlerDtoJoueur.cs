using APIRest.Controllers;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using APIRest.DTOs;
using AutoMapper;
using Microsoft.Extensions.Logging;
using EntityFramework.Entity;
using Microsoft.AspNetCore.Mvc;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using APIRest.MapperClass;
using Microsoft.Extensions.Logging.Abstractions;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using DTOs;
using JoueurDto = APIRest.DTOs.JoueurDto;

namespace TestsAPI.Test_API_rest
{
    [TestClass]
    public class UnitTestControlerDtoJoueur
    {
        private readonly IMapper _mapper;
        private readonly JoueurController _joueurController;
        private readonly ILogger<JoueurController> _logger;
        private readonly DataManagerAPI dmAPI;

        public UnitTestControlerDtoJoueur()
        {
            var maperconf = new MapperConfiguration(cgf => cgf.AddProfile(typeof(MapperApiREST)));
            _mapper = maperconf.CreateMapper();
            _logger = new NullLogger<JoueurController>();
            //_logger = Mock.Of<ILogger<JoueurController>>(); no mieux davoir un logger null

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "TestApiDataBaseREST")
                .Options;
            dmAPI = new DataManagerAPI(new SQLiteContext(options));
        }


        [TestMethod]
        public async Task TestGetJoueurs()
        {
            Joueur j = new Joueur("nom", 45);
            await dmAPI.AddJoueur(j);
            var actionResult = new JoueurController(_logger, _mapper, dmAPI).GetLesJoueurs();

            var actionResultOK = await actionResult as OkObjectResult;

            Assert.AreEqual(actionResultOK.StatusCode,((int)HttpStatusCode.OK));//should().be marche pas

            var joueurDto = actionResultOK.Value as IEnumerable<JoueurDto>;

            Assert.IsNotNull(joueurDto);
            Assert.AreEqual(j.Nom,joueurDto.First().Nom);
        }

        [TestMethod]
        public async Task TestGetJoueurById()
        {
            Joueur j = new Joueur(1, "nom", 45);
            await dmAPI.AddJoueur(j);
            var actionResult = new JoueurController(_logger, _mapper, dmAPI).GetJoueurById(1);

            var actionResultOK = await actionResult as OkObjectResult;

            Assert.AreEqual(actionResultOK.StatusCode, ((int)HttpStatusCode.OK));

            var joueurDto = actionResultOK.Value as JoueurDto;

            Assert.IsNotNull(joueurDto);
            Assert.AreEqual(j.Nom, joueurDto.Nom);
        }
        [TestMethod]
        public async Task TestDeleteJoueurId()
        {
            Joueur j = new Joueur(1, "nom", 45);
            await dmAPI.AddJoueur(j);

            var actionResult = new JoueurController(_logger, _mapper, dmAPI).DeleteJoueur(1);

            var actionResultOK = await actionResult as OkObjectResult;

            Assert.AreEqual(actionResultOK.StatusCode, ((int)HttpStatusCode.OK));

            var joueurDto = actionResultOK.Value as JoueurDto;

            Assert.IsNotNull(joueurDto);
            Assert.AreEqual(j.Nom, joueurDto.Nom);
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Joueur j = new Joueur(1, "nom", 45);
            await dmAPI.AddJoueur(j);

            var actionResult = new JoueurController(_logger, _mapper, dmAPI).UpdateJoueur(j.toDTO(),j.Id);

            var actionResultOK = await actionResult as OkObjectResult;

            Assert.AreEqual(actionResultOK.StatusCode, ((int)HttpStatusCode.OK));

            var joueurDto = actionResultOK.Value as JoueurDto;

            Assert.IsNotNull(joueurDto);
            Assert.AreNotEqual(j.Nom, joueurDto.Nom);
        }

        [TestMethod]
        public async Task TestGetJoueurByPage()
        {
            Joueur j = new Joueur(1, "nom", 45);
            await dmAPI.AddJoueur(j);
            var actionResult = new JoueurController(_logger, _mapper, dmAPI).GetJoueurByPage(0,1);

            var actionResultOK = await actionResult as OkObjectResult;

            Assert.AreEqual(actionResultOK.StatusCode, ((int)HttpStatusCode.OK));

            var joueurDto = actionResultOK.Value as IEnumerable<JoueurDto>;

            Assert.IsNotNull(joueurDto);
            Assert.AreEqual(j.Nom, joueurDto.First().Nom);
        }

    }
}

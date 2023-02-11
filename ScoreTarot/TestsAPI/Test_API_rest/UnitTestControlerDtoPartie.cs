using APIRest.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using APIRest.MapperClass;
using EntityFramework;
using APIRest.DTOs;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Microsoft.EntityFrameworkCore;
using Stub;
using Microsoft.Data.Sqlite;

namespace TestsAPI.Test_API_rest
{
    [TestClass]
    public class UnitTestControlerDtoPartie
    {
        private readonly IMapper _mapper;
        private readonly PartieController _mancheController;
        private readonly ILogger<PartieController> _logger;
        private readonly DataManagerAPI dmAPI;

        public UnitTestControlerDtoPartie()
        {
            var maperconf = new MapperConfiguration(cgf => cgf.AddProfile(typeof(MapperApiREST)));
            _mapper = maperconf.CreateMapper();
            _logger = new NullLogger<PartieController>();
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "TestApiDataBaseREST")
                .Options;
            dmAPI = new DataManagerAPI(new SQLiteContext(options));
        }

        [TestMethod]
        public async Task TestGetPartie()
        {
            Partie p = new StubPartie().ChargerPartie3J();
            await dmAPI.AddPartie(p);
            var actionResult = new PartieController(_logger, _mapper, dmAPI).GetLesParties();

            var actionResultOK = await actionResult as OkObjectResult;

            actionResultOK.StatusCode.Equals(((int)HttpStatusCode.OK));
            var partieDto = actionResultOK.Value as PartieDto;
            Assert.IsNotNull(partieDto);
            Assert.AreEqual(p.Joueurs.First().Id, partieDto.JoueursId.First());
        }
        [TestMethod]
        public async Task TestGetPartieByid()
        {
            Partie p = new StubPartie().ChargerPartie3J();
            await dmAPI.AddPartie(p);
            var actionResult = new PartieController(_logger, _mapper, dmAPI).GetPartieById(0);

            var actionResultOK = await actionResult as OkObjectResult;

            actionResultOK.StatusCode.Equals(((int)HttpStatusCode.OK));
            var partieDto = actionResultOK.Value as PartieDto;
            Assert.IsNotNull(partieDto);
            Assert.AreEqual(p.Joueurs.First().Id, partieDto.JoueursId.First());
        }
    }
}

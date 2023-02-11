using APIRest.Controllers;
using APIRest.DTOs;
using APIRest.MapperClass;
using AutoMapper;
using EntityFramework;
using EntityFramework.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestsAPI.Test_API_rest
{
    [TestClass]
    public class UnitTestControlerDtoManche
    {
        private readonly IMapper _mapper;
        private readonly MancheController _mancheController;
        private readonly ILogger<MancheController> _logger;
        private readonly DataManagerAPI dmAPI;

        public UnitTestControlerDtoManche()
        {
            var maperconf = new MapperConfiguration(cgf => cgf.AddProfile(typeof(MapperApiREST)));
            _mapper = maperconf.CreateMapper();
            _logger = new NullLogger<MancheController>();

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseInMemoryDatabase(databaseName: "TestApiDataBaseREST")
                .Options;
            dmAPI = new DataManagerAPI(new SQLiteContext(options));
        }


        [TestMethod]
        public async Task TestGetMancheById()
        {
            //insert l'objet
            Manche m = new Manche(1,Contrat.Garde, new Joueur("nomperso", 45), 40, Bonus.DoublePoignee, 5);
            await dmAPI.AddManche(m);

            var actionResult = new MancheController(_logger, _mapper, dmAPI).GetMancheById(1);

            var actionResultOK = await actionResult as OkObjectResult;//verrifie si reponse 200, il contient le code retour + les données

            //assert
            Assert.AreEqual(actionResultOK.StatusCode, ((int)HttpStatusCode.OK));//should().be marche pas
            var mancheDto = actionResultOK.Value as IEnumerable<MancheDto>;
            Assert.IsNotNull(mancheDto);
        }

        [TestMethod]
        public async Task TestDeleteMancheId()
        {
            Manche m = new Manche(1, Contrat.Garde, new Joueur("nomperso", 45), 40, Bonus.DoublePoignee, 5);
            await dmAPI.AddManche(m);

            var actionResult = new MancheController(_logger, _mapper, dmAPI).DeleteManche(1);

            var actionResultOK = await actionResult as OkObjectResult;

            Assert.AreEqual(actionResultOK.StatusCode, ((int)HttpStatusCode.OK));
            var mancheDto = actionResultOK.Value as IEnumerable<MancheDto>;
            Assert.IsNotNull(mancheDto);
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Manche m = new Manche(1,Contrat.Garde,new Joueur("nomperso",45),40,Bonus.DoublePoignee,5);
            await dmAPI.AddManche(m);

            var actionResult = new MancheController(_logger, _mapper, dmAPI).UpdateManche(m.toDto(), m.Id);

            var actionResultOK = await actionResult as OkObjectResult;

            Assert.AreEqual(actionResultOK.StatusCode, ((int)HttpStatusCode.OK));
            var mancheDto = actionResultOK.Value as MancheDto;
            Assert.IsNotNull(mancheDto);
            Assert.AreNotEqual(m.Date, mancheDto.Date);
        }
    }
}

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
                .UseInMemoryDatabase(databaseName: "TestApiDataBaseRESTManche")
                .Options;
            dmAPI = new DataManagerAPI(new SQLiteContext(options));
        }


        [TestMethod]
        public async Task TestGetMancheById()
        {
            //insert l'objet
            Joueur j = new Joueur(1, "nomperso", 45);
            Joueur? joueur = await dmAPI.AddJoueur(j);
            if(joueur != null)
            {
                Manche m = new Manche(1, Contrat.Garde, joueur, 40, Bonus.DoublePoignee, 5);
                await dmAPI.AddManche(m);
                var actionResult = new MancheController(_logger, _mapper, dmAPI).GetMancheById(1);

                var actionResultOK = await actionResult as OkObjectResult;//verrifie si reponse 200, il contient le code retour + les données

                //assert
                Assert.AreEqual(actionResultOK.StatusCode, ((int)HttpStatusCode.OK));//should().be marche pas
                var mancheDto = actionResultOK.Value as MancheDto;
                Assert.IsNotNull(mancheDto);
                Assert.AreEqual(m.Id, mancheDto.Id);
            }
     
        }

        [TestMethod]
        public async Task TestDeleteMancheId()
        {
            Joueur j = new Joueur(1, "nomperso", 45);
            await dmAPI.AddJoueur(j);
            Manche m = new Manche(2, Contrat.Garde, j, 40, Bonus.DoublePoignee, 5);
            await dmAPI.AddManche(m);

            var actionResult = new MancheController(_logger, _mapper, dmAPI).DeleteManche(2);

            var actionResultOK = await actionResult as OkObjectResult;

            Assert.AreEqual(actionResultOK.StatusCode, ((int)HttpStatusCode.OK));
            var mancheDto = actionResultOK.Value as MancheDto;
            Assert.IsNotNull(mancheDto);
            Assert.AreEqual(m.Id, mancheDto.Id); 
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Joueur j = new Joueur( "nomperso", 45);
            await dmAPI.AddJoueur(j);
            Manche m = new Manche(3, Contrat.Garde, j, 40, Bonus.DoublePoignee, 5);
            await dmAPI.AddManche(m);
            m = new Manche(3, Contrat.Garde, j, 45, Bonus.DoublePoignee, 5);
            var actionResult = new MancheController(_logger, _mapper, dmAPI).UpdateManche(m.toDto());

            var actionResultOK = await actionResult as OkObjectResult;

            Assert.AreEqual(actionResultOK.StatusCode, ((int)HttpStatusCode.OK));
            var mancheDto = actionResultOK.Value as MancheDto;
            Assert.IsNotNull(mancheDto);
            Assert.AreEqual(45, mancheDto.Score);
            Assert.AreEqual(m.Id, mancheDto.Id);
        }
    }
}

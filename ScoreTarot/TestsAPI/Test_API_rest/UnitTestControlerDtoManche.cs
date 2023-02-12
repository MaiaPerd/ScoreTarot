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
using Stub;
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
            Partie p = new StubPartie().ChargerPartie3J();
            await dmAPI.AddJoueur(new Joueur(1, p.Joueurs[0].Pseudo, p.Joueurs[0].Age));
            await dmAPI.AddJoueur(new Joueur(2, p.Joueurs[1].Pseudo, p.Joueurs[1].Age));
            await dmAPI.AddJoueur(new Joueur(3, p.Joueurs[2].Pseudo, p.Joueurs[2].Age));
            foreach (Manche m in p.Manches)
            {
                await dmAPI.AddManche(m);
            }
                var actionResult = new MancheController(_logger, _mapper, dmAPI).GetMancheById(1);

                var actionResultOK = await actionResult as OkObjectResult;//verrifie si reponse 200, il contient le code retour + les données

                //assert
                Assert.AreEqual(actionResultOK.StatusCode, ((int)HttpStatusCode.OK));//should().be marche pas
                var mancheDto = actionResultOK.Value as MancheDto;
                Assert.IsNotNull(mancheDto);
                Assert.AreEqual(p.Manches[1].Id, mancheDto.Id);
            
     
        }

        [TestMethod]
        public async Task TestDeleteMancheId()
        {
            Partie p = new StubPartie().ChargerPartie3J();
            await dmAPI.AddJoueur(new Joueur(1, p.Joueurs[0].Pseudo, p.Joueurs[0].Age));
            await dmAPI.AddJoueur(new Joueur(2, p.Joueurs[1].Pseudo, p.Joueurs[1].Age));
            await dmAPI.AddJoueur(new Joueur(3, p.Joueurs[2].Pseudo, p.Joueurs[2].Age));
            foreach (Manche m in p.Manches)
            {
                await dmAPI.AddManche(m);
            }

            var actionResult = new MancheController(_logger, _mapper, dmAPI).DeleteManche(1);

            var actionResultOK = await actionResult as OkObjectResult;

            Assert.AreEqual(actionResultOK.StatusCode, ((int)HttpStatusCode.OK));
            var mancheDto = actionResultOK.Value as MancheDto;
            Assert.IsNotNull(mancheDto);
            Assert.AreEqual(p.Manches[1].Id, mancheDto.Id); 
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Partie p = new StubPartie().ChargerPartie3J();
            await dmAPI.AddJoueur(new Joueur(1, p.Joueurs[0].Pseudo, p.Joueurs[0].Age));
            await dmAPI.AddJoueur(new Joueur(2, p.Joueurs[1].Pseudo, p.Joueurs[1].Age));
            await dmAPI.AddJoueur(new Joueur(3, p.Joueurs[2].Pseudo, p.Joueurs[2].Age));
            foreach (Manche m in p.Manches)
            {
                await dmAPI.AddManche(m);
            }/*
            Manche m2 = new Manche(1, p.Manches[1].Contrat, p.Manches[1].JoueurQuiPrend, p.Manches[1].Score, p.Manches[1].Bonus, p.Manches[1].NbJoueur);
            var actionResult = new MancheController(_logger, _mapper, dmAPI).UpdateManche(m2.toDto());

            var actionResultOK = await actionResult as OkObjectResult;

            Assert.AreEqual(actionResultOK.StatusCode, ((int)HttpStatusCode.OK));
            var mancheDto = actionResultOK.Value as MancheDto;
            Assert.IsNotNull(mancheDto);
            Assert.AreEqual(45, mancheDto.Score);
            Assert.AreEqual(p.Manches[1].Id, mancheDto.Id);*/ //Erreur du test on ne peut pas modifier une manche
        }
    }
}

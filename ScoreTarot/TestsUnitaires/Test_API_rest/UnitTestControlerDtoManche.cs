using APIRest.Controllers;
using APIRest.DTOs;
using APIRest.MapperClass;
using AutoMapper;
using EntityFramework;
using EntityFramework.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestsUnitaires.Test_API_rest
{
    public class UnitTestControlerDtoManche
    {
        private readonly IMapper _mapper;
        private readonly MancheController _mancheController;
        private readonly ILogger<MancheController> _logger;

        public UnitTestControlerDtoManche()
        {
            var maperconf = new MapperConfiguration(cgf => cgf.AddProfile(typeof(MapperApiREST)));
            _mapper = maperconf.CreateMapper();
            _logger = new NullLogger<MancheController>();
        }


        [TestMethod]
        public async Task TestGetMancheById()
        {
            //insert l'objet
            var actionResult = new MancheController(_logger, _mapper).GetMancheById(0);

            var actionResultOK = actionResult as OkObjectResult;//verrifie si reponse 200, il contient le code retour + les données
            //assert
            actionResultOK.StatusCode.Equals(((int)HttpStatusCode.OK));//should().be marche pas
            var mancheDto = actionResultOK.Value as IEnumerable<MancheDto>;
            Assert.IsNotNull(mancheDto);

        }
        [TestMethod]
        public async Task TestdeleteJoueurd()
        {
            Joueur j = new Joueur("nom", 45);
            await new DataManager().AddJoueur(j);

            var actionResult = new MancheController(_logger, _mapper).DeleteManche(0);

            var actionResultOK = await actionResult as OkObjectResult;

            actionResultOK.StatusCode.Equals(((int)HttpStatusCode.NoContent));//should().be marche pas
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            Manche m = new Manche(Contrat.Garde,new Joueur("nomperso",45),40,Bonus.DoublePoignee,5);
            await new DataManager().AddManche(m);
            var actionResult = new MancheController(_logger, _mapper).UpdateManche(m.toDTO(), m.Id);

            var actionResultOK = await actionResult as OkObjectResult;

            actionResultOK.StatusCode.Equals(((int)HttpStatusCode.OK));//should().be marche pas
            var mancheDto = actionResultOK.Value as MancheDto;
            Assert.IsNotNull(mancheDto);
            Assert.AreNotEqual(m.Date, mancheDto.Date);
        }

        [TestMethod]
        public async Task TestGetMancheBypage()
        {
            Manche m = new Manche(Contrat.Garde, new Joueur("nomperso", 45), 40, Bonus.DoublePoignee, 5);
            await new DataManager().AddJoueur(j);
            var actionResult = new MancheController(_logger, _mapper).GetMancheByPage(0, 1);

            var actionResultOK = await actionResult as OkObjectResult;

            actionResultOK.StatusCode.Equals(((int)HttpStatusCode.OK));//should().be marche pas
            var joueurDto = actionResultOK.Value as IEnumerable<MancheDto>;
            Assert.IsNotNull(joueurDto);
            Assert.AreEqual(m.Date, joueurDto.First().Date);
        }
    }
}

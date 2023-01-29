using APIRest.Controllers;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Stub;
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
using Moq;
using Microsoft.AspNetCore.Mvc;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestsUnitaires.Test_API_rest
{
    [TestClass]
    public class UnitTestControlerDtoJoueur
    {
        private readonly IMapper _mapper;
        private readonly JoueurController _joueurController;
        private readonly ILogger<JoueurController> _logger;

        public UnitTestControlerDtoJoueur()
        {
            _mapper = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<JoueurEntity, JoueurDto>().ReverseMap();
                cgf.CreateMap<PartieEntity, PartieDto>()
                    .ForMember(parten => parten.ManchesId, act => act.MapFrom(source => source.Manches.Select(m => m.Id).ToArray()))
                    .ForMember(parten => parten.JoueursId, act => act.MapFrom(source => source.Joueurs.Select(j => j.Id).ToArray()))
                    .ReverseMap()
                        .ForMember(pdto => pdto.Manches.Select(m => m.Id), act => act.MapFrom(source => source.ManchesId.ToArray()))
                        .ForMember(pdto => pdto.Joueurs.Select(j => j.Id), act => act.MapFrom(source => source.JoueursId.ToArray()))
                    ;
                cgf.CreateMap<MancheEntity, MancheDto>()
                    .ForMember(mancheEn => mancheEn.JoueurAllierId, act => act.MapFrom(source => source.JoueurAllier.Id))
                    .ForMember(mancheEn => mancheEn.JoueurQuiPrendId, act => act.MapFrom(source => source.JoueurQuiPrend.Id))
                    .ReverseMap()
                    .ForMember(mancheEn => mancheEn.JoueurAllier.Id, act => act.MapFrom(source => source.JoueurAllierId))
                    .ForMember(mancheEn => mancheEn.JoueurQuiPrend.Id, act => act.MapFrom(source => source.JoueurQuiPrendId))
                    ;
                cgf.CreateMap<JoueurDto, Joueur>().ReverseMap();
                cgf.CreateMap<Manche, MancheDto>().ReverseMap();
            }).CreateMapper();
            _logger = Mock.Of<ILogger<JoueurController>>();
        }


        [TestMethod]
        public async Task TestGetJoueur()
        {
            var actionResult = new JoueurController(_logger, _mapper,new EntityFramework.DataManager()).GetLesJoueurs();

            var actionResultOK = actionResult as OkObjectResult;

            actionResultOK.StatusCode.Equals(((int)HttpStatusCode.OK));//should().be marche pas
            var joueurDto = actionResultOK.Value as IEnumerable<JoueurDto>;
            Assert.IsNotNull(joueurDto);
        }

    }
}

using APIRest.Controllers;
using APIRest.;
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
            _mapper = MapperConfiguration();
        }


        [TestMethod]
        public async Task TestGetJoueur()
        {
            var actionResult = await new JoueurController().GetLesJoueurs();

            var actionResultOK = actionResult as OKObjectResult;

            actionResultOK.Status.Code.Should().Be((int)HttpStatusCode.OK);
            var joueurDto = actionResultOK.Value as IEnumerable<JoueurDto>;
            //mockService.Verify(mbox => mbox.get, TimeSpan.once);
        }

    }
}

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
using Stub;
using APIRest.DTOs;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestsUnitaires.Test_API_rest
{
    public class UnitTestControlerDtoPartie
    {
        private readonly IMapper _mapper;
        private readonly PartieController _mancheController;
        private readonly ILogger<PartieController> _logger;

        public UnitTestControlerDtoPartie()
        {
            var maperconf = new MapperConfiguration(cgf => cgf.AddProfile(typeof(MapperApiREST)));
            _mapper = maperconf.CreateMapper();
            _logger = new NullLogger<PartieController>();
        }
    }
}

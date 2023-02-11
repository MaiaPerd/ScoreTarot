using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;

namespace UnitTestRest.Test_API_rest
{
    [TestClass]
    public class UnitTestControlerDto
    {
        
        [TestMethod]
        public async Task TestGetJoueur()
        {
            var actionResult = await new JoueurController();

            var actionResultOK = actionResult as OKObjectResult;

            actionResultOK.Status.Code.Should().Be((int)HttpStatusCode.OK);
            var joueurDto = actionResultOK.Value as IEnumerable<JoueurDto>;
            mockService.Verify(mbox => mbox.get, TimeSpan.once);
        }

    }
}

using FN.Store.UI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FN.Store.Tests.Controllers
{
    [TestClass]
    [TestCategory("HomeController")]
    public class HomeControllerTest
    {
        // Dado um HomeController

        [TestMethod]
        public void OMetodoIndexDeveraRetornarUmaView()
        {
            //a
            var homeCtrl = new HomeController();

            //a
            var result = homeCtrl.Index();

            //a
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }
    }
}

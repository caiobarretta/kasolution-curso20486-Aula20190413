using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Tests
{
    [TestClass]
    public class HelloWorldTest
    {
        [TestMethod]
        public void TestandoAtravesDoHelloWorld()
        {
            //a - arrange (ambiente do seu teste)
            var helloworld = "valor do helloworld";

            //a - action (ação que vai ser testada)
            var radom = new Random().Next(0, 4);
            if (radom > 3)
                helloworld = string.Empty;

            //a - assert (onde testamos o resultado da action)
            Assert.AreEqual("valor do helloworld", helloworld);
        }
    }
}

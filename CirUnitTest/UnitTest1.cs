using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Cir.Controllers;
using Cir.Models;
using Xunit;
using Moq;

namespace CirUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var mock1 = new Mock<IConfiguration>();
            var mock2 = new Mock<ICirRepository>();
            var cirInterface1 = mock1.Object;
            var cirInterface2 = mock2.Object;
            CirController cir = new CirController(cirInterface1, cirInterface2);
            var result = cir.GetCir();

            Assert.NotEmpty(result);
        }

        [Theory]
        [InlineData("100030010070")]
        [InlineData("999999999999")]
        public void Test2(string contrato)
        {
            var mock1 = new Mock<IConfiguration>();
            var mock2 = new Mock<ICirRepository>();
            var cirInterface1 = mock1.Object;
            var cirInterface2 = mock2.Object;
            CirController cir = new CirController(cirInterface1, cirInterface2);
            var result = cir.GetCirContrato(contrato);

            Assert.NotEmpty(result);
        }
    }
}

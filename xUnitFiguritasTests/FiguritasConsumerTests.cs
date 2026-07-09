using Figuritas.Abstractions.DTO;
using Figuritas.Abstractions.Interfaces;
using Figuritas.Consumer.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace xUnitFiguritasTests
{
        public class FiguritasConsumerTests
        {
            public class FiguritaTests
            {
                [Fact]
                public async Task ObtenerFiguritasPorPaisPaisExistente()
                {
                    // ARRANGE
                    var pais = "Japan";
                    var listadoSimulado = new List<FiguritaDTO>
                    {
                        new FiguritaDTO { id = "1", country = pais, playerFirstName = "Langosh", playerLastName = "Chelsea", isDeleted = false }
                    };

                    var mockrepo = new Mock<IFiguritaService>();
                    mockrepo.Setup(r => r.GetFigusByCountry(pais)).ReturnsAsync(listadoSimulado.Cast<FiguritaDTO?>().ToList());

                    var controller = new FiguritasController(mockrepo.Object);

                    // ACT
                    var result = await controller.GetFigusByCountry(pais);

                    // ASSERT
                    Assert.IsType<OkObjectResult>(result);
                }

                [Fact]
                public async Task ObtenerFiguritasPaisNOExistente()
                {
                    // ARRANGE
                    var pais = "Narnia";
                    var listadoSimulado = new List<FiguritaDTO?>();

                    var mockrepo = new Mock<IFiguritaService>();
                    mockrepo.Setup(r => r.GetFigusByCountry(pais)).ReturnsAsync(listadoSimulado);

                    var controller = new FiguritasController(mockrepo.Object);

                    // ACT
                    var result = await controller.GetFigusByCountry(pais);

                    // ASSERT
                    Assert.IsType<NotFoundObjectResult>(result);
                }
            }
        }
}
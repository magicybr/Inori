using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Inori.Domain.Infrastructure;
using Inori.Domain.Models.Catalogs;
using Inori.WebApi;
using Inori.WebApi.Controllers;
using Inori.WebApi.Models;
using Inori.WebApi.Profiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Inori.UnitTests.Application
{
    public class CatalogControllerTest : IClassFixture<CatalogClassFixtrue>
    {
        private readonly CatalogClassFixtrue _fixtrue;
        public CatalogControllerTest(CatalogClassFixtrue fixtrue)
        {
            _fixtrue = fixtrue;
        }

        [Fact]
        public async Task Get_items_success()
        {
            // Arrange
            // var context = new InoriDbContext(_fixtrue.InoriOptions);

            // Act
            // var controller = new CatalogController(context, _fixtrue.TestCatalogSettings, _fixtrue.catalogIntegrationEventService.Object, _fixtrue.CatalogMapper, _fixtrue.Logger.Object);
            var controller = (CatalogController)_fixtrue.CreateCatalogController();
            var actionResult = await controller.ItemsAsync();

            // Assert
            var result = Assert.IsType<ActionResult<IEnumerable<CatalogItemViewModel>>>(actionResult).Result;
            var resultValue = Assert.IsType<OkObjectResult>(result).Value;
            Assert.True((resultValue as IEnumerable<CatalogItemViewModel>).Count() > 0);
        }

        [Fact]
        public async Task Get_item_with_id_bad_request()
        {
            // Arrange
            // var context = new InoriDbContext(_fixtrue.InoriOptions);
            var fakeId = -1;
            // Act
            // var controller = new CatalogController(context, _fixtrue.TestCatalogSettings, _fixtrue.catalogIntegrationEventService.Object, _fixtrue.CatalogMapper, _fixtrue.Logger.Object);
            var controller = (CatalogController)_fixtrue.CreateCatalogController();
            var actionResult = await controller.ItemByIdAsync(fakeId);

            // Assert
            Assert.IsType<BadRequestResult>(actionResult.Result);
        }

        [Fact]
        public async Task Get_item_with_id_not_fount()
        {
            // Arrange
            // var context = new InoriDbContext(_fixtrue.InoriOptions);
            var fakeId = 100;
            // Act
            // var controller = new CatalogController(context, _fixtrue.TestCatalogSettings, _fixtrue.catalogIntegrationEventService.Object, _fixtrue.CatalogMapper, _fixtrue.Logger.Object);
            var controller = (CatalogController)_fixtrue.CreateCatalogController();
            var actionResult = await controller.ItemByIdAsync(fakeId);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task Get_item_with_id_success()
        {
            // Arrange
            // var context = new InoriDbContext(_fixtrue.InoriOptions);
            var fakeId = 2;

            // Act
            // var controller = new CatalogController(context, _fixtrue.TestCatalogSettings, _fixtrue.catalogIntegrationEventService.Object, _fixtrue.CatalogMapper, _fixtrue.Logger.Object);
            var controller = (CatalogController)_fixtrue.CreateCatalogController();
            var actionResult = await controller.ItemByIdAsync(fakeId);

            // Assert
            var resultValue = Assert.IsType<ActionResult<CatalogItemViewModel>>(actionResult).Value;
            Assert.Equal(2, resultValue.Id);
        }
        [Fact]
        public async Task Get_item_with_name_success()
        {
            // Arrange
            // var context = new InoriDbContext(_fixtrue.InoriOptions);
            var fakeName = "fakeItemB";

            // Act
            // var controller = new CatalogController(context, _fixtrue.TestCatalogSettings, _fixtrue.catalogIntegrationEventService.Object, _fixtrue.CatalogMapper, _fixtrue.Logger.Object);
            var controller = (CatalogController)_fixtrue.CreateCatalogController();
            var actionResult = await controller.ItemsWithNameAsync(fakeName);

            // Assert
            var result = Assert.IsType<ActionResult<IEnumerable<CatalogItemViewModel>>>(actionResult).Result;
            Assert.Equal((result as OkObjectResult).StatusCode, (int)HttpStatusCode.OK);
            Assert.Single(((result as OkObjectResult).Value as IEnumerable<CatalogItemViewModel>));

        }
        [Fact]
        public async Task Get_product_success()
        {
            // Arrange
            var brandFilterApplied = 1;
            var typesFilterApplied = 2;
            // var context = new InoriDbContext(_fixtrue.InoriOptions);

            // Act
            // var controller = new CatalogController(context, _fixtrue.TestCatalogSettings, _fixtrue.catalogIntegrationEventService.Object, _fixtrue.CatalogMapper, _fixtrue.Logger.Object);
            var controller = (CatalogController)_fixtrue.CreateCatalogController();
            var actionResult = await controller.ItemsByTypeIdAndBrandIdAsync(typesFilterApplied, brandFilterApplied);

            // Assert
            var result = Assert.IsType<ActionResult<IEnumerable<CatalogItemViewModel>>>(actionResult).Result;
            var resultValue = Assert.IsType<OkObjectResult>(result).Value;
            Assert.True((resultValue as IEnumerable<CatalogItemViewModel>).Count() > 0);
        }

        [Fact]
        public async Task Post_product_success()
        {
            // Arrange
            // var context = new InoriDbContext(_fixtrue.InoriOptions);
            var fakeItem = new CatalogItem()
            {
                CatalogBrandId = 1,
                CatalogTypeId = 3,
                Description = "fake description",
                Name = "fake name",
                PictureFileName = "fake fileName",
                Price = 100
            };

            // Act
            // var controller = new CatalogController(context, _fixtrue.TestCatalogSettings, _fixtrue.catalogIntegrationEventService.Object, _fixtrue.CatalogMapper, _fixtrue.Logger.Object);
            var controller = (CatalogController)_fixtrue.CreateCatalogController();
            var actionResult = await controller.CreateProductAsync(fakeItem);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult);
            Assert.Equal(createdAtActionResult.StatusCode, (int)System.Net.HttpStatusCode.Created);
            Assert.Equal(nameof(controller.ItemByIdAsync), createdAtActionResult.ActionName);
        }

        [Fact]
        public async Task Delete_product_with_id_success()
        {
            // Arrange
            // var context = new InoriDbContext(_fixtrue.InoriOptions);
            var fakeProductId = 1;

            // Act
            // var controller = new CatalogController(context, _fixtrue.TestCatalogSettings, _fixtrue.catalogIntegrationEventService.Object, _fixtrue.CatalogMapper, _fixtrue.Logger.Object);
            var controller = (CatalogController)_fixtrue.CreateCatalogController();
            var actionResult = await controller.DeleteProductAsync(fakeProductId);

            // Assert
            Assert.IsType<NoContentResult>(actionResult);
        }
        [Fact]
        public async Task Delete_product_with_id_not_found()
        {
            // Arrange
            // var context = new InoriDbContext(_fixtrue.InoriOptions);
            var fakeProductId = 10;

            // Act
            // var controller = new CatalogController(context, _fixtrue.TestCatalogSettings, _fixtrue.catalogIntegrationEventService.Object, _fixtrue.CatalogMapper, _fixtrue.Logger.Object);
            var controller = (CatalogController)_fixtrue.CreateCatalogController();
            var actionResult = await controller.DeleteProductAsync(fakeProductId);

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task Put_catalog_item_success()
        {
            // Arrange
            var productToUpdate = new CatalogItem
            {
                Id = 5,
                Name = "fakeItemA",
                CatalogTypeId = 2,
                CatalogBrandId = 1,
                PictureFileName = "fakeItemA.png",
                Price = 1000
            };

            // Act
            var controller = (CatalogController)_fixtrue.CreateCatalogController();
            var actionResult = await controller.UpdateProductAsync(productToUpdate);

            // Assert
            Assert.IsType<CreatedAtActionResult>(actionResult);
        }
    }
    public class TestCatalogSettings : IOptionsSnapshot<CatalogSettings>
    {
        public CatalogSettings Value => new CatalogSettings
        {
            PicBaseUrl = "http://image-server.com/",
        };

        public CatalogSettings Get(string name) => Value;
    }
    public class CatalogClassFixtrue : IDisposable
    {
        private readonly TestCatalogSettings _catalogSettings;
        private readonly DbContextOptions<InoriDbContext> _inoriOptions;
        private readonly Mock<ILogger<CatalogController>> _logger;
        private readonly IMapper _mapper;
        // private readonly Mock<ICatalogIntegrationEventService> _catalogIntegrationEventService;
        public CatalogClassFixtrue()
        {
            _inoriOptions = new DbContextOptionsBuilder<InoriDbContext>()
                            .UseInMemoryDatabase(databaseName: "in-memory")
                            .EnableSensitiveDataLogging()
                            .Options;

            _catalogSettings = new TestCatalogSettings();
            _logger = new Mock<ILogger<CatalogController>>();
            // _catalogIntegrationEventService = new Mock<ICatalogIntegrationEventService>();

            var profile = new CatalogItemProfile();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            _mapper = new Mapper(config);

            using (var context = new InoriDbContext(_inoriOptions))
            {
                context.AddRange(GetFakeCatalog());
                context.SaveChanges();
            }
        }

        public Controller CreateCatalogController()
        {
            var context = new InoriDbContext(_inoriOptions);
            // return new CatalogController(context, _catalogSettings, _catalogIntegrationEventService.Object, _mapper, _logger.Object);
            return new CatalogController(context, _catalogSettings, _mapper, _logger.Object);
        }
        private List<CatalogItem> GetFakeCatalog()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem()
                {
                    Id = 1,
                    Name = "fakeItemA",
                    CatalogTypeId = 2,
                    CatalogBrandId = 1,
                    PictureFileName = "fakeItemA.png"
                },
                new CatalogItem()
                {
                    Id = 2,
                    Name = "fakeItemB",
                    CatalogTypeId = 2,
                    CatalogBrandId = 1,
                    PictureFileName = "fakeItemB.png"
                },
                new CatalogItem()
                {
                    Id = 3,
                    Name = "fakeItemC",
                    CatalogTypeId = 2,
                    CatalogBrandId = 1,
                    PictureFileName = "fakeItemC.png"
                },
                new CatalogItem()
                {
                    Id = 4,
                    Name = "fakeItemD",
                    CatalogTypeId = 2,
                    CatalogBrandId = 1,
                    PictureFileName = "fakeItemD.png"
                },
                new CatalogItem()
                {
                    Id = 5,
                    Name = "fakeItemE",
                    CatalogTypeId = 2,
                    CatalogBrandId = 1,
                    PictureFileName = "fakeItemE.png"
                },
                new CatalogItem()
                {
                    Id = 6,
                    Name = "fakeItemF",
                    CatalogTypeId = 2,
                    CatalogBrandId = 1,
                    PictureFileName = "fakeItemF.png"
                }
            };
        }

        public void Dispose()
        {

        }
    }
}
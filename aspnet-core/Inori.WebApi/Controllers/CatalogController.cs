using AutoMapper;
using Inori.Domain.Infrastructure;
using Inori.Domain.Models.Catalogs;
using Inori.WebApi.Extensions;
using Inori.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Inori.WebApi.Controllers
{

    [Route("api/Catalog")]
    [ApiController]
    // [Authorize]
    public class CatalogController : Controller
    {
        private readonly InoriDbContext _context;
        private readonly CatalogSettings _settings;
        private readonly IMapper _mapper;
        private readonly ILogger<CatalogController> _logger;
        public CatalogController(
            InoriDbContext context,
            IOptionsSnapshot<CatalogSettings> settings,
            IMapper mapper,
            ILogger<CatalogController> logger)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._settings = settings.Value;

            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        [HttpGet]
        [Route("items")]
        public async Task<ActionResult<IEnumerable<CatalogItemViewModel>>> ItemsAsync()
        {
            var context = HttpContext;
            var root = (IQueryable<CatalogItem>)this._context.CatalogItems;

            var item = await root.ToListAsync();

            var vms = _mapper.Map<IEnumerable<CatalogItemViewModel>>(item);

            return Ok(vms);
        }

        [HttpGet]
        [Route("items/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CatalogItemViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CatalogItemViewModel>> ItemByIdAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var item = await this._context.CatalogItems.SingleOrDefaultAsync(c => c.Id == id);

            if (item == null)
                return NotFound();

            var vm = _mapper.Map<CatalogItemViewModel>(item);

            vm.FillProductUrl(_settings.PicBaseUrl);

            return vm;
        }

        [HttpGet]
        [Route("items/withname/{name:minlength(1)}")]
        [ProducesResponseType(typeof(IEnumerable<CatalogItemViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CatalogItemViewModel>>> ItemsWithNameAsync(string name)
        {
            var items = await this._context.CatalogItems.Where(c => c.Name.StartsWith(name)).ToListAsync();

            var vms = _mapper.Map<IEnumerable<CatalogItemViewModel>>(items);

            return Ok(vms);
        }

        [HttpGet]
        [Route("items/type/{catalogTypeId:int}/brand/{catalogBrandId:int?}")]
        [ProducesResponseType(typeof(IEnumerable<CatalogItemViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CatalogItemViewModel>>> ItemsByTypeIdAndBrandIdAsync(int catalogTypeId, int? catalogBrandId)
        {
            var root = (IQueryable<CatalogItem>)this._context.CatalogItems;

            root.Where(c => c.CatalogTypeId == catalogTypeId);
            if (catalogBrandId.HasValue)
            {
                root.Where(c => c.CatalogBrandId == catalogBrandId);
            }

            var items = await root.ToListAsync();

            var vms = _mapper.Map<IEnumerable<CatalogItemViewModel>>(items);

            return Ok(vms);
        }
        [HttpGet]
        [Route("items/type/all/brand/{catalogBrandId:int?}")]
        public async Task<ActionResult<IEnumerable<CatalogItemViewModel>>> ItemsByBrandIdAsync(int? catalogBrandId)
        {
            var root = (IQueryable<CatalogItem>)this._context.CatalogItems.Where(c => c.CatalogBrandId == catalogBrandId);

            var items = await root.ToListAsync();

            var vms = _mapper.Map<IEnumerable<CatalogItemViewModel>>(items);

            return Ok(vms);
        }

        [HttpGet]
        [Route("catalogtypes")]
        [ProducesResponseType(typeof(List<CatalogTypeViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<CatalogTypeViewModel>>> CatalogTypesAsync()
        {
            var items = await this._context.CatalogTypes.ToListAsync();

            var vms = _mapper.Map<List<CatalogTypeViewModel>>(items);

            return Ok(vms);
        }

        [HttpGet]
        [Route("catalogbrands")]
        [ProducesResponseType(typeof(List<CatalogBrand>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<CatalogBrand>>> CatalogBrandsAsync()
        {
            return await _context.CatalogBrands.ToListAsync();
        }

        [Route("items")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> UpdateProductAsync([FromBody] CatalogItem productToUpdate)
        {
            var catalogItem = await _context.CatalogItems.SingleOrDefaultAsync(i => i.Id == productToUpdate.Id);

            if (catalogItem == null)
            {
                return NotFound(new { Message = $"Item with id {productToUpdate.Id} not found." });
            }

            var oldPrice = catalogItem.Price;
            var raiseProductPriceChangedEvent = oldPrice != productToUpdate.Price;

            // Update current product
            catalogItem = productToUpdate;
            _context.CatalogItems.Update(catalogItem);

            if (raiseProductPriceChangedEvent)
            {
            }
            else
            {
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction(nameof(ItemByIdAsync), new { Id = productToUpdate.Id }, null);
        }

        [HttpPost]
        [Route("items")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> CreateProductAsync([FromBody] CatalogItem product)
        {

            var item = new CatalogItem()
            {
                CatalogBrandId = product.CatalogBrandId,
                CatalogTypeId = product.CatalogTypeId,
                Description = product.Description,
                Name = product.Name,
                PictureFileName = product.PictureFileName,
                Price = product.Price
            };

            _context.CatalogItems.Add(item);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ItemByIdAsync), new { id = item.Id }, null);
        }

        [HttpDelete]
        [Route("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> DeleteProductAsync(int Id)
        {

            var product = _context.CatalogItems.SingleOrDefault(c => c.Id == Id);

            if (product == null)
                return NotFound();

            _context.CatalogItems.Remove(product);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
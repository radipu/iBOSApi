using iBOSApi.Models;
using iBOSApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBOSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class iBOSController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public iBOSController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<iBOS>> GetProducts()
        {
            return await _productRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<iBOS>> GetProducts(int id)
        {
            return await _productRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<iBOS>> PostProducts([FromBody] iBOS product)
        {
            var newProduct = await _productRepository.Create(product);
            return CreatedAtAction(nameof(GetProducts), new { id = newProduct.intColdDrinksId }, newProduct);
        }

        [HttpPut]
        public async Task<ActionResult> PutProducts(int id, [FromBody] iBOS product)
        {
            if (id != product.intColdDrinksId)
            {
                return BadRequest();
            }

            await _productRepository.Update(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productToDelete = await _productRepository.Get(id);
            if (productToDelete == null)
                return NotFound();

            await _productRepository.Delete(productToDelete.intColdDrinksId);
            return NoContent();
        }
    }
}

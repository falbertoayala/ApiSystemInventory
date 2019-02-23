using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Models;

namespace Sistema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandsController : ControllerBase
    {
        private readonly SistemaContext _context;

        public ProductBrandsController(SistemaContext context)
        {
            _context = context;
        }

        // GET: api/ProductBrands
        [HttpGet]
        public IEnumerable<ProductBrand> GetProductBrand()
        {
            return _context.ProductBrand;
        }

        // GET: api/ProductBrands/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductBrand([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productBrand = await _context.ProductBrand.FindAsync(id);

            if (productBrand == null)
            {
                return NotFound();
            }

            return Ok(productBrand);
        }

        // PUT: api/ProductBrands/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductBrand([FromRoute] int id, [FromBody] ProductBrand productBrand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productBrand.ProductBrandId)
            {
                return BadRequest();
            }

            _context.Entry(productBrand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductBrandExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductBrands
        [HttpPost]
        public async Task<IActionResult> PostProductBrand([FromBody] ProductBrand productBrand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductBrand.Add(productBrand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductBrand", new { id = productBrand.ProductBrandId }, productBrand);
        }

        // DELETE: api/ProductBrands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductBrand([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productBrand = await _context.ProductBrand.FindAsync(id);
            if (productBrand == null)
            {
                return NotFound();
            }

            _context.ProductBrand.Remove(productBrand);
            await _context.SaveChangesAsync();

            return Ok(productBrand);
        }

        private bool ProductBrandExists(int id)
        {
            return _context.ProductBrand.Any(e => e.ProductBrandId == id);
        }
    }
}
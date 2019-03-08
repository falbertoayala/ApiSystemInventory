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
    public class Product2Controller : ControllerBase
    {
        private readonly SistemaContext _context;

        public Product2Controller(SistemaContext context)
        {
            _context = context;
        }

        // GET: api/Product2
        [HttpGet]
        public IEnumerable<Product2> GetProduct2()
        {
            var query = _context.Product2
                .Include(b => b.ProductBrand)
                .Include(p => p.Providers)
                .Include(e => e.Storage)
                .Include(t => t.TypeProduct)
                .Select(s => new Product2()
                {
                    ProductId = s.ProductId,
                    ProductCode = s.ProductCode,
                    ProductName = s.ProductName,
                    ProductCost = s.ProductCost,
                    ProductBrand = s.ProductBrand,
                    Providers = s.Providers,
                    Storage = s.Storage,
                    TypeProduct = s.TypeProduct
                });


            return query.ToList();
        }

        // GET: api/Product2/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct2([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product2 = await _context.Product2.FindAsync(id);

            if (product2 == null)
            {
                return NotFound();
            }

            return Ok(product2);
        }

        // PUT: api/Product2/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct2([FromRoute] int id, [FromBody] Product2 product2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product2.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product2Exists(id))
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

        // POST: api/Product2
       /* [HttpPost]
        public async Task<IActionResult> PostProduct2([FromBody] Product2 product2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Product2.Add(product2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct2", new { id = product2.ProductId }, product2);
        }
*/
        // POST: api/Product2 Segunda Opcion
        [HttpPost]
        public async Task<IActionResult> PostProduct2([FromBody] Product2 product2)
        {
            if (ModelState.IsValid)
            {
                _context.Product2.Add(product2);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetProduct2", new { id = product2.ProductId }, product2);
            }

            return BadRequest(ModelState);
           
        }






        // DELETE: api/Product2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct2([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product2 = await _context.Product2.FindAsync(id);
            if (product2 == null)
            {
                return NotFound();
            }

            _context.Product2.Remove(product2);
            await _context.SaveChangesAsync();

            return Ok(product2);
        }

        private bool Product2Exists(int id)
        {
            return _context.Product2.Any(e => e.ProductId == id);
        }
    }
}
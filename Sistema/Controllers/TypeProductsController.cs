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
    public class TypeProductsController : ControllerBase
    {
        private readonly SistemaContext _context;

        public TypeProductsController(SistemaContext context)
        {
            _context = context;
        }

        // GET: api/TypeProducts
        [HttpGet]
        public IEnumerable<TypeProduct> GetTypeProduct()
        {
            return _context.TypeProduct;
        }

        // GET: api/TypeProducts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var typeProduct = await _context.TypeProduct.FindAsync(id);

            if (typeProduct == null)
            {
                return NotFound();
            }

            return Ok(typeProduct);
        }

        // PUT: api/TypeProducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeProduct([FromRoute] int id, [FromBody] TypeProduct typeProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeProduct.TypeProductId)
            {
                return BadRequest();
            }

            _context.Entry(typeProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeProductExists(id))
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

        // POST: api/TypeProducts
        [HttpPost]
        public async Task<IActionResult> PostTypeProduct([FromBody] TypeProduct typeProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TypeProduct.Add(typeProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeProduct", new { id = typeProduct.TypeProductId }, typeProduct);
        }

        // DELETE: api/TypeProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var typeProduct = await _context.TypeProduct.FindAsync(id);
            if (typeProduct == null)
            {
                return NotFound();
            }

            _context.TypeProduct.Remove(typeProduct);
            await _context.SaveChangesAsync();

            return Ok(typeProduct);
        }

        private bool TypeProductExists(int id)
        {
            return _context.TypeProduct.Any(e => e.TypeProductId == id);
        }
    }
}
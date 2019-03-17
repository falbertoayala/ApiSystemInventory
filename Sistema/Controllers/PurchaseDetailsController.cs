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
    public class PurchaseDetailsController : ControllerBase
    {
        private readonly SistemaContext _context;

        public PurchaseDetailsController(SistemaContext context)
        {
            _context = context;
        }

        // GET: api/PurchaseDetails
        [HttpGet]
        public IEnumerable<PurchaseDetail> GetPruchaseDetail()
        {
            return _context.PruchaseDetail;
        }

        // GET: api/PurchaseDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchaseDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var purchaseDetail = await _context.PruchaseDetail.FindAsync(id);

            if (purchaseDetail == null)
            {
                return NotFound();
            }

            return Ok(purchaseDetail);
        }

        // PUT: api/PurchaseDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseDetail([FromRoute] int id, [FromBody] PurchaseDetail purchaseDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchaseDetail.PurchaseDetailId)
            {
                return BadRequest();
            }

            _context.Entry(purchaseDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseDetailExists(id))
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

        // POST: api/PurchaseDetails
        [HttpPost]
        public async Task<IActionResult> PostPurchaseDetail([FromBody] PurchaseDetail purchaseDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PruchaseDetail.Add(purchaseDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseDetail", new { id = purchaseDetail.PurchaseDetailId }, purchaseDetail);
        }

        // DELETE: api/PurchaseDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var purchaseDetail = await _context.PruchaseDetail.FindAsync(id);
            if (purchaseDetail == null)
            {
                return NotFound();
            }

            _context.PruchaseDetail.Remove(purchaseDetail);
            await _context.SaveChangesAsync();

            return Ok(purchaseDetail);
        }

        private bool PurchaseDetailExists(int id)
        {
            return _context.PruchaseDetail.Any(e => e.PurchaseDetailId == id);
        }
    }
}
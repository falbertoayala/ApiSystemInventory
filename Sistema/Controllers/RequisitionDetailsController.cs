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
    public class RequisitionDetailsController : ControllerBase
    {
        private readonly SistemaContext _context;

        public RequisitionDetailsController(SistemaContext context)
        {
            _context = context;
        }

        // GET: api/RequisitionDetails
        [HttpGet]
        public IEnumerable<RequisitionDetail> GetRequisitionDetail()
        {
            return _context.RequisitionDetail;
        }

        // GET: api/RequisitionDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequisitionDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requisitionDetail = await _context.RequisitionDetail.FindAsync(id);

            if (requisitionDetail == null)
            {
                return NotFound();
            }

            return Ok(requisitionDetail);
        }

        // PUT: api/RequisitionDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequisitionDetail([FromRoute] int id, [FromBody] RequisitionDetail requisitionDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requisitionDetail.RequisitionDetailId)
            {
                return BadRequest();
            }

            _context.Entry(requisitionDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequisitionDetailExists(id))
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

        // POST: api/RequisitionDetails
        [HttpPost]
        public async Task<IActionResult> PostRequisitionDetail([FromBody] RequisitionDetail requisitionDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RequisitionDetail.Add(requisitionDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequisitionDetail", new { id = requisitionDetail.RequisitionDetailId }, requisitionDetail);
        }

        // DELETE: api/RequisitionDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequisitionDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requisitionDetail = await _context.RequisitionDetail.FindAsync(id);
            if (requisitionDetail == null)
            {
                return NotFound();
            }

            _context.RequisitionDetail.Remove(requisitionDetail);
            await _context.SaveChangesAsync();

            return Ok(requisitionDetail);
        }

        private bool RequisitionDetailExists(int id)
        {
            return _context.RequisitionDetail.Any(e => e.RequisitionDetailId == id);
        }
    }
}
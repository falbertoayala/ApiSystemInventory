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
    public class RequisitionStatusController : ControllerBase
    {
        private readonly SistemaContext _context;

        public RequisitionStatusController(SistemaContext context)
        {
            _context = context;
        }

        // GET: api/RequisitionStatus
        [HttpGet]
        public IEnumerable<RequisitionStatus> GetRequisitionStatus()
        {
            return _context.RequisitionStatus;
        }

        // GET: api/RequisitionStatus/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequisitionStatus([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requisitionStatus = await _context.RequisitionStatus.FindAsync(id);

            if (requisitionStatus == null)
            {
                return NotFound();
            }

            return Ok(requisitionStatus);
        }

        // PUT: api/RequisitionStatus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequisitionStatus([FromRoute] int id, [FromBody] RequisitionStatus requisitionStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requisitionStatus.RequisitionStatusId)
            {
                return BadRequest();
            }

            _context.Entry(requisitionStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequisitionStatusExists(id))
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

        // POST: api/RequisitionStatus
        [HttpPost]
        public async Task<IActionResult> PostRequisitionStatus([FromBody] RequisitionStatus requisitionStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RequisitionStatus.Add(requisitionStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequisitionStatus", new { id = requisitionStatus.RequisitionStatusId }, requisitionStatus);
        }

        // DELETE: api/RequisitionStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequisitionStatus([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requisitionStatus = await _context.RequisitionStatus.FindAsync(id);
            if (requisitionStatus == null)
            {
                return NotFound();
            }

            _context.RequisitionStatus.Remove(requisitionStatus);
            await _context.SaveChangesAsync();

            return Ok(requisitionStatus);
        }

        private bool RequisitionStatusExists(int id)
        {
            return _context.RequisitionStatus.Any(e => e.RequisitionStatusId == id);
        }
    }
}
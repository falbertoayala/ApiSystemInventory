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
    public class RequisitionsController : ControllerBase
    {
        private readonly SistemaContext _context;

        public RequisitionsController(SistemaContext context)
        {
            _context = context;
        }

        // GET: api/Requisitions
        [HttpGet]
        public IEnumerable<Object> GetRequisition()
        {
            var result = _context
                .Requisition
                .Select(s => new
                {
                    s.RequisitionId,
                    s.Class,
                    s.Section,
                    s.ReqPracticeName,
                    s.ClassHour,
                    s.PracticeDate,
                    s.RequisitionStatus.Name,
                    s.RequistionDate,
                    s.StatusRequisitionDate,
                    s.StorageId,
                    s.Storage.StorageDescription,
                    RequisitionDetails = s.RequisitionDetails.ToList()
                })
                .ToList();
            return result;
        }

        // GET: api/Requisitions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequisition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requisition = await _context.Requisition.FindAsync(id);

            if (requisition == null)
            {
                return NotFound();
            }

            return Ok(requisition);
        }

        // PUT: api/Requisitions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequisition([FromRoute] int id, [FromBody] Requisition requisition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requisition.RequisitionId)
            {
                return BadRequest();
            }

            _context.Entry(requisition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequisitionExists(id))
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

        // POST: api/Requisitions
        [HttpPost]
        public async Task<IActionResult> PostRequisition([FromBody] Requisition requisition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try { 
                _context.Requisition.Add(requisition);

                String message = "";

                foreach (var r in requisition.RequisitionDetails)
                {
                    var product = _context.Product.Find(r.ProductId);
                    if (!product.MakeRequest(r.Quantity))
                    {
                        message += "No hay cantidad suficiente en producto " + product.ProductName;
                    }
                }

                if(message.Length > 0)
                {
                    return BadRequest(new { status = "Error", Message = message });
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(new { status = "Error", Message = e.Message, InnerExption = e.InnerException.Message });
            }



            return Ok(new { status = "Ok" });
        }

        // DELETE: api/Requisitions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequisition([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var requisition = await _context.Requisition.FindAsync(id);
            if (requisition == null)
            {
                return NotFound();
            }

            _context.Requisition.Remove(requisition);
            await _context.SaveChangesAsync();

            return Ok(requisition);
        }

        private bool RequisitionExists(int id)
        {
            return _context.Requisition.Any(e => e.RequisitionId == id);
        }
    }
}
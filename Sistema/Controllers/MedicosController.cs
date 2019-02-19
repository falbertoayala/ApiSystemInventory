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
    public class MedicosController : ControllerBase
    {
        private readonly SistemaContext _context;

        public MedicosController(SistemaContext context)
        {
            _context = context;
        }

        // GET: api/Medicos
        [HttpGet]
        public IEnumerable<Medico> GetMedico()
        {
            return _context.Medico;
        }

        // GET: api/Medicos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedico([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medico = await _context.Medico.FindAsync(id);

            if (medico == null)
            {
                return NotFound();
            }

            return Ok(medico);
        }

        // PUT: api/Medicos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedico([FromRoute] int id, [FromBody] Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medico.MedicId)
            {
                return BadRequest();
            }

            _context.Entry(medico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicoExists(id))
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

        // POST: api/Medicos
        [HttpPost]
        public async Task<IActionResult> PostMedico([FromBody] Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Medico.Add(medico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedico", new { id = medico.MedicId }, medico);
        }

        // DELETE: api/Medicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedico([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medico = await _context.Medico.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }

            _context.Medico.Remove(medico);
            await _context.SaveChangesAsync();

            return Ok(medico);
        }

        private bool MedicoExists(int id)
        {
            return _context.Medico.Any(e => e.MedicId == id);
        }
    }
}
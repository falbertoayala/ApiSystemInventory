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
    public class ProvidersController : ControllerBase
    {
        private readonly SistemaContext _context;

        public ProvidersController(SistemaContext context)
        {
            _context = context;
        }

        // GET: api/Providers
        [HttpGet]
        public IEnumerable<Providers> GetProviders()
        {
            var query = _context.Providers
                .Include(n => n.ProviderName)
                .Include(r => r.ProviderRtn)
                .Include(p1 => p1.ProviderPhone1)
                .Include(p2 => p2.ProviderPhone2)
                .Include(a => a.ProviderAddress)
                .Include(c => c.City)
                .Include(e => e.ProviderEmail)
                .Include(co => co.ProviderContact)
                .Include(cp => cp.ContactPosition)
                .Select(s => new Providers()
                {
                    ProvidersId = s.ProvidersId,
                    ProviderName = s.ProviderName,
                    ProviderRtn = s.ProviderRtn,
                    ProviderPhone1 = s.ProviderPhone1,
                    ProviderPhone2 = s.ProviderPhone2,
                    ProviderAddress = s.ProviderAddress,
                    City = s.City,
                    ProviderEmail = s.ProviderEmail,
                    ProviderContact =s.ProviderContact,
                    ContactPosition = s.ContactPosition

                });

            return query.ToList();
                                                  
         }


        // GET: api/Providers
       /* [HttpGet]
        public IEnumerable<Providers> GetProviders()
        {
            return _context.Providers;
        }*/
        

        // GET: api/Providers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProviders([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var providers = await _context.Providers.FindAsync(id);

            if (providers == null)
            {
                return NotFound();
            }

            return Ok(providers);
        }

        // PUT: api/Providers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProviders([FromRoute] int id, [FromBody] Providers providers)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
                
            }

            if (id != providers.ProvidersId)
            {
                return BadRequest();
            }

            _context.Entry(providers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvidersExists(id))
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

        // POST: api/Providers
        [HttpPost]
        public async Task<IActionResult> PostProviders([FromBody] Providers providers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Providers.Add(providers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProviders", new { id = providers.ProvidersId }, providers);
        }

        // DELETE: api/Providers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProviders([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var providers = await _context.Providers.FindAsync(id);
            if (providers == null)
            {
                return NotFound();
            }

            _context.Providers.Remove(providers);
            await _context.SaveChangesAsync();

            return Ok(providers);
        }

        private bool ProvidersExists(int id)
        {
            return _context.Providers.Any(e => e.ProvidersId == id);
        }
    }
}
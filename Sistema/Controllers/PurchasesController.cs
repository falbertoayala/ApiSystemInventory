﻿using System;
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
    public class PurchasesController : ControllerBase
    {
        private readonly SistemaContext _context;

        public PurchasesController(SistemaContext context)
        {
            _context = context;
        }

        // GET: api/Purchases
        [HttpGet]
        public IEnumerable<Object> GetPurchase()
        {
            var result = _context.Purchase
                .Include(p => p.ProvidersId)
                .Include(d => d.PurchaseDate)
                .Include(t => t.PurchaseDetails)
                
                .Select(s => new
                {
                    s.PurchaseId,
                    s.PurchaseDate,
                    PurchaseDetails = s.PurchaseDetails.ToList()
                })
                 .ToList();
            return result;
        }

        // GET: api/Purchases/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchase([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var purchase = await _context.Purchase.FindAsync(id);

            if (purchase == null)
            {
                return NotFound();
            }

            return Ok(purchase);
        }

        // PUT: api/Purchases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchase([FromRoute] int id, [FromBody] Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchase.PurchaseId)
            {
                return BadRequest();
            }

            _context.Entry(purchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseExists(id))
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

        // POST: api/Purchases
        [HttpPost]
        public async Task<IActionResult> PostPurchase([FromBody] Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try {
                _context.Purchase.Add(purchase);

                String message = "";

                foreach (var p in purchase.PurchaseDetails)
                {
                    var product = _context.Product.Find(p.ProductId);
                    if (!product.MakePurchase(p.Quantity))
                    {
                        message += "Cantidad debe ser mayor 1" + product.ProductName;
                    }
                }

                if (message.Length > 0)
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

      
        // DELETE: api/Purchases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var purchase = await _context.Purchase.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            _context.Purchase.Remove(purchase);
            await _context.SaveChangesAsync();

            return Ok(purchase);
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchase.Any(e => e.PurchaseId == id);
        }
    }
}
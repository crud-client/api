using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudClients;
using CrudClients.Models;

namespace CrudClients.Controllers
{
    [Route("api/{clientId}/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ClientContext _context;

        public AddressController(ClientContext context)
        {
            _context = context;
        }

        // GET: api/Address
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses([FromRoute] int clientId)
        {
            if (!ClientExists(clientId))
            {
                return NotFound();
            }
            return await _context.Addresses.Where(a => a.ClientID == clientId).ToListAsync();
        }

        // GET: api/Address/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress([FromRoute] int clientId, int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(a =>
                a.ClientID == clientId && a.ID == id
            );

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Address/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress([FromRoute] int clientId, int id, Address address)
        {
            if (id != address.ID || clientId != address.ClientID)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                return Conflict();
            }

            return NoContent();
        }

        // POST: api/Address
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress([FromRoute] int clientId, Address address)
        {
            if (!ClientExists(clientId))
            {
                return NotFound();
            }

            address.ClientID = clientId;

            _context.Addresses.Add(address);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                return Conflict();
            }
            return CreatedAtAction("GetAddress", new { clientId = clientId, id = address.ID }, address);
        }

        // DELETE: api/Address/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress([FromRoute] int clientId, int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(a =>
                a.ClientID == clientId && a.ID == id
            );

            if (address == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.ID == id);
        }
        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ID == id);
        }
    }
}

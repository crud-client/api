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
    public class TelphoneController : ControllerBase
    {
        private readonly ClientContext _context;

        public TelphoneController(ClientContext context)
        {
            _context = context;
        }

        // GET: api/Telphone
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telphone>>> GetTelphones([FromRoute] int clientId)
        {
            if (!ClientExists(clientId))
            {
                return NotFound();
            }
            return await _context.Telphones.Where(t => t.ClientID == clientId).ToListAsync();
        }

        // GET: api/Telphone/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Telphone>> GetTelphone([FromRoute] int clientId, int id)
        {
            var telphone = await _context.Telphones.FirstOrDefaultAsync(t =>
                t.ClientID == clientId && t.ID == id
            );

            if (telphone == null)
            {
                return NotFound();
            }

            return telphone;
        }

        // PUT: api/Telphone/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelphone([FromRoute] int clientId, int id, Telphone telphone)
        {
            if (id != telphone.ID || clientId != telphone.ClientID)
            {
                return BadRequest();
            }

            _context.Entry(telphone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelphoneExists(id))
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

        // POST: api/Telphone
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Telphone>> PostTelphone([FromRoute] int clientId, Telphone telphone)
        {
            if (!ClientExists(clientId))
            {
                return NotFound();
            }

            telphone.ClientID = clientId;

            _context.Telphones.Add(telphone);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                return Conflict();
            }


            return CreatedAtAction(
                nameof(GetTelphone),
                new { clientId = clientId, id = telphone.ID },
                telphone
            );
        }

        // DELETE: api/Telphone/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelphone([FromRoute] int clientId, int id)
        {
            var telphone = await _context.Telphones.FirstOrDefaultAsync(t =>
                t.ClientID == clientId && t.ID == id
            );

            if (telphone == null)
            {
                return NotFound();
            }

            _context.Telphones.Remove(telphone);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool TelphoneExists(int id)
        {
            return _context.Telphones.Any(e => e.ID == id);
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ID == id);
        }
    }
}

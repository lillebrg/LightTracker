using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LightTracker.Data;
using Models;

namespace LightTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MQTTMessagesController : ControllerBase
    {
        private readonly LightTrackerContext _context;

        //remeber to make a new instantiation of your dbcontext, else it wont work
        public MQTTMessagesController()
        {
            _context = new LightTrackerContext();
        }

        // GET: api/MQTTMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MQTTMessage>>> GetMQTTMessages()
        {
          if (_context.MQTTMessages == null)
          {
              return NotFound();
          }
            return await _context.MQTTMessages.ToListAsync();
        }

        // GET: api/MQTTMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MQTTMessage>> GetMQTTMessage(int id)
        {
          if (_context.MQTTMessages == null)
          {
              return NotFound();
          }
            var mQTTMessage = await _context.MQTTMessages.FindAsync(id);

            if (mQTTMessage == null)
            {
                return NotFound();
            }

            return mQTTMessage;
        }

        // PUT: api/MQTTMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMQTTMessage(int id, MQTTMessage mQTTMessage)
        {
            if (id != mQTTMessage.Id)
            {
                return BadRequest();
            }

            _context.Entry(mQTTMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MQTTMessageExists(id))
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

        // POST: api/MQTTMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MQTTMessage>> PostMQTTMessage(MQTTMessage mQTTMessage)
        {
          if (_context.MQTTMessages == null)
          {
              return Problem("Entity set 'LightTrackerContext.MQTTMessages'  is null.");
          }
            _context.MQTTMessages.Add(mQTTMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMQTTMessage", new { id = mQTTMessage.Id }, mQTTMessage);
        }

        // DELETE: api/MQTTMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMQTTMessage(int id)
        {
            if (_context.MQTTMessages == null)
            {
                return NotFound();
            }
            var mQTTMessage = await _context.MQTTMessages.FindAsync(id);
            if (mQTTMessage == null)
            {
                return NotFound();
            }

            _context.MQTTMessages.Remove(mQTTMessage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MQTTMessageExists(int id)
        {
            return (_context.MQTTMessages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

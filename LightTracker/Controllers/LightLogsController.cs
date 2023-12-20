﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LightTrackerAPI.Data;
using Models;

namespace LightTrackerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LightLogsController : ControllerBase
    {
        private readonly LightTrackerAPIContext _context;

        public LightLogsController()
        {
            _context = new LightTrackerAPIContext();
        }

        // GET: api/LightLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LightLog>>> GetLightLogs()
        {
          if (_context.LightLogs == null)
          {
              return NotFound();
          }
            return await _context.LightLogs.ToListAsync();
        }

        // GET: api/LightLogs/5
        [HttpGet("{productid}")]
        public async Task<ActionResult<IEnumerable<LightLog>>> GetCustomerLightLogs(int productid)
        {
          if (_context.LightLogs == null)
          {
              return NotFound();
          }
            var lightLog = await _context.LightLogs.Where(l => l.ProductId == productid).ToListAsync();

            if (lightLog == null)
            {
                return NotFound();
            }

            return lightLog;
        }

        // PUT: api/LightLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLightLog(int id, LightLog lightLog)
        {
            if (id != lightLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(lightLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LightLogExists(id))
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

        // POST: api/LightLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LightLog>> PostLightLog(LightLog lightLog)
        {
          if (_context.LightLogs == null)
          {
              return Problem("Entity set 'LightTrackerAPIContext.LightLogs'  is null.");
          }
            _context.LightLogs.Add(lightLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLightLog", new { id = lightLog.Id }, lightLog);
        }

        // DELETE: api/LightLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLightLog(int id)
        {
            if (_context.LightLogs == null)
            {
                return NotFound();
            }
            var lightLog = await _context.LightLogs.FindAsync(id);
            if (lightLog == null)
            {
                return NotFound();
            }

            _context.LightLogs.Remove(lightLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/LightLogs
        [HttpDelete]
        public async Task<IActionResult> DeleteLightLogs([FromBody] int[] ids)
        {
            try
            {
                if (ids == null || !ids.Any())
                {
                    return BadRequest("Please provide IDs to delete.");
                }

                var lightLogs = await _context.LightLogs.Where(log => ids.Contains(log.Id)).ToListAsync();
                if (lightLogs == null || !lightLogs.Any())
                {
                    return NotFound("No matching records found for the provided IDs.");
                }

                _context.LightLogs.RemoveRange(lightLogs);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }



        private bool LightLogExists(int id)
        {
            return (_context.LightLogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookshelfAPI.Data;
using BookshelfAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookshelfAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingLogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReadingLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReadingLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadingLog>>> GetReadingLogs()
        {
            return await _context.ReadingLogs
                .Include(rl => rl.Book)
                .Include(rl => rl.User)
                .ToListAsync();
        }

        // GET: api/ReadingLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadingLog>> GetReadingLog(int id)
        {
            var readingLog = await _context.ReadingLogs
                .Include(rl => rl.Book)
                .Include(rl => rl.User)
                .FirstOrDefaultAsync(rl => rl.Id == id);

            if (readingLog == null)
            {
                return NotFound();
            }

            return readingLog;
        }

        // POST: api/ReadingLogs
        [HttpPost]
        public async Task<ActionResult<ReadingLog>> PostReadingLog(ReadingLog readingLog)
        {
            _context.ReadingLogs.Add(readingLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReadingLog), new { id = readingLog.Id }, readingLog);
        }

        // PUT: api/ReadingLogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReadingLog(int id, ReadingLog readingLog)
        {
            if (id != readingLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(readingLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReadingLogExists(id))
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

        // PUT: api/ReadingLogs/5/start
        [HttpPut("{id}/start")]
        public async Task<IActionResult> StartReading(int id)
        {
            var readingLog = await _context.ReadingLogs.FindAsync(id);
            if (readingLog == null)
            {
                return NotFound();
            }

            readingLog.Status = ReadingStatus.CurrentlyReading;
            readingLog.StartDate = DateTime.UtcNow;

            _context.Entry(readingLog).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/ReadingLogs/5/complete
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteReading(int id)
        {
            var readingLog = await _context.ReadingLogs.FindAsync(id);
            if (readingLog == null)
            {
                return NotFound();
            }

            readingLog.Status = ReadingStatus.Finished;
            readingLog.EndDate = DateTime.UtcNow;

            _context.Entry(readingLog).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/ReadingLogs/5/drop
        [HttpPut("{id}/drop")]
        public async Task<IActionResult> DropReading(int id)
        {
            var readingLog = await _context.ReadingLogs.FindAsync(id);
            if (readingLog == null)
            {
                return NotFound();
            }

            readingLog.Status = ReadingStatus.Dropped;

            _context.Entry(readingLog).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ReadingLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReadingLog(int id)
        {
            var readingLog = await _context.ReadingLogs.FindAsync(id);
            if (readingLog == null)
            {
                return NotFound();
            }

            _context.ReadingLogs.Remove(readingLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReadingLogExists(int id)
        {
            return _context.ReadingLogs.Any(e => e.Id == id);
        }
    }
}

using EcoVitalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoVitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActivityRecordsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UserActivityRecordsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/UserActivityRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserActivityRecord>>> GetUserActivityRecords()
        {
            // Retorna solo los IDs de la relación sin incluir los objetos completos
            return await _context.UserActivityRecords.ToListAsync();
        }

        // POST: api/UserActivityRecords
        [HttpPost]
        public async Task<ActionResult<UserActivityRecord>> PostUserActivityRecord(UserActivityRecord userActivityRecord)
        {
            _context.UserActivityRecords.Add(userActivityRecord);
            await _context.SaveChangesAsync();

           
            return CreatedAtAction(nameof(GetUserActivityRecord), new { id = userActivityRecord.UserActivityId }, userActivityRecord);
        }

        // GET: api/UserActivityRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserActivityRecord>> GetUserActivityRecord(int id)
        {
            var userActivityRecord = await _context.UserActivityRecords.FindAsync(id);

            if (userActivityRecord == null)
            {
                return NotFound();
            }

            return userActivityRecord;
        }

        // PUT: api/UserActivityRecords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserActivityRecord(int id, UserActivityRecord userActivityRecord)
        {
            if (id != userActivityRecord.UserActivityId)
            {
                return BadRequest();
            }

            _context.Entry(userActivityRecord).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserActivityRecordExists(id))
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

        // GET: api/UserActivityRecords/ByUser/5
        [HttpGet("ByUser/{userId}")]
        public async Task<ActionResult<IEnumerable<UserActivityRecord>>> GetUserActivityRecordsByUserId(int userId)
        {
            var userActivityRecords = await _context.UserActivityRecords
                .Where(x => x.UserId == userId)
                .ToListAsync();

            if (userActivityRecords == null || userActivityRecords.Count == 0)
            {
                return NotFound();
            }

            return userActivityRecords;
        }


        // DELETE: api/UserActivityRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserActivityRecord(int id)
        {
            var userActivityRecord = await _context.UserActivityRecords.FindAsync(id);
            if (userActivityRecord == null)
            {
                return NotFound();
            }

            _context.UserActivityRecords.Remove(userActivityRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserActivityRecordExists(int id) =>
            _context.UserActivityRecords.Any(e => e.UserActivityId == id);
    }
}

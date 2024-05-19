using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcoVitalAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoVitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ActivityController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Activity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityRecord>>> GetActivityRecords()
        {
            return await _context.ActivityRecords.ToListAsync();
        }

        // GET: api/Activity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityRecord>> GetActivityRecord(int id)
        {
            var activityRecord = await _context.ActivityRecords.FirstOrDefaultAsync(ar => ar.RecordId == id);

            if (activityRecord == null)
            {
                return NotFound();
            }

            return activityRecord;
        }
        // POST: api/Activity
        [HttpPost]
        public async Task<ActionResult<ActivityRecord>> PostActivityRecord(ActivityRecord activityRecord)
        {
            _context.ActivityRecords.Add(activityRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActivityRecord), new { id = activityRecord.RecordId }, activityRecord);
        }

        // DELETE: api/Activity/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityRecord(int id)
        {
            var activityRecord = await _context.ActivityRecords.FindAsync(id);
            if (activityRecord == null)
            {
                return NotFound();
            }

            _context.ActivityRecords.Remove(activityRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

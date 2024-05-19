using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcoVitalAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcoVitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGoalController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UserGoalController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/UserGoal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGoal>>> GetUserGoals()
        {
            return await _context.UserGoals.ToListAsync();
        }

        // GET: api/UserGoal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGoal>> GetUserGoal(int id)
        {
            var userGoal = await _context.UserGoals.FirstOrDefaultAsync(ug => ug.GoalId == id);

            if (userGoal == null)
            {
                return NotFound();
            }

            return userGoal;
        }

        // POST: api/UserGoal
        [HttpPost]
        public async Task<ActionResult<UserGoal>> PostUserGoal(UserGoal userGoal)
        {
            _context.UserGoals.Add(userGoal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserGoal), new { id = userGoal.GoalId }, userGoal);
        }
        // POST: api/UserGoal/UpdateGoal
        [HttpPost]
        [Route("UpdateGoal")]
        public async Task<ActionResult<UserGoal>> UpdateGoal(UserGoal userGoal)
        {
            var goal = await _context.UserGoals.FirstOrDefaultAsync(ug => ug.GoalId == userGoal.GoalId);
            if (goal == null)
            {
                return NotFound();
            }
            goal.IsAchieved = userGoal.IsAchieved;
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserGoal), new { id = userGoal.GoalId }, userGoal);
        }

        // POST: api/UserGoal/{userId}
        [HttpPost("{userId}")]
        public async Task<ActionResult<UserGoal>> PostUserGoal(int userId, UserGoal userGoal)
        {
            
            userGoal.UserId = userId; 

            _context.UserGoals.Add(userGoal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserGoal), new { id = userGoal.GoalId }, userGoal);
        }

        // DELETE: api/UserGoal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserGoal(int id)
        {
            var userGoal = await _context.UserGoals.FindAsync(id);
            if (userGoal == null)
            {
                return NotFound();
            }

            _context.UserGoals.Remove(userGoal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/UserGoal/Activity/5
        [HttpGet("Activity/{activityId}")]
        public async Task<ActionResult<UserGoal>> GetUserGoalByActivityId(int activityId)
        {
            var userGoal = await _context.UserGoals.FirstOrDefaultAsync(ug => ug.ActivityRecordId == activityId);

            if (userGoal == null)
            {
                return NotFound();
            }

            return userGoal;
        }
    }
}

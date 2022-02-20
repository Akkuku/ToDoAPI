using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly AssignmentContext _context;
        
        public AssignmentController(AssignmentContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignments()
        {
            return await _context.Assignments.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAssignment(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            return assignment;
        }
        
        [HttpPost]
        public async Task<ActionResult<Assignment>> PostAssignment(Assignment assignment)
        {
            _context.Add(assignment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAssignment), new {id = assignment.Id}, assignment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignment(int id, Assignment assignment)
        {
            if (id != assignment.Id)
            {
                return BadRequest();
            }

            _context.Entry(assignment).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                var assignmentExists = _context.Assignments.Any(a => a.Id == id);
                if (!assignmentExists)
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
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        [HttpGet("today")]
        public async Task<ActionResult<ICollection<Assignment>>> GetTodayAssignments()
        {
            var todayAssignments = _context.Assignments
                .Where(a => a.Date.Value.Date == DateTime.Today);
            return await todayAssignments.ToListAsync();
        }

        [HttpGet("unfinished")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetUnfinishedAssignments()
        {
            var unfinishedAssignments = _context.Assignments
                .Where(a => a.IsDone == false);
            return await unfinishedAssignments.ToListAsync();
        }
        
        [HttpGet("overdue")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetOverdueAssignments()
        {
            var overdueAssignments = _context.Assignments
                .Where(a => a.Date.Value.Date < DateTime.Today && a.IsDone == false);
            return await overdueAssignments.ToListAsync();
        }
    }
}
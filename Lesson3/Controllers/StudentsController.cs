using Lesson3.DbContexts;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lesson3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("add-new")]
        public async Task<IActionResult> AddNewStudent(Student studentP)
        {
            _context.Students.Add(studentP);
            await _context.SaveChangesAsync();

            return Ok("Student save successfully");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateStudent(Student studentP)
        {
            _context.Students.Update(studentP);
            await _context.SaveChangesAsync();

            return Ok("Student updated successfully");            
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var studentFromDb = await _context.Students
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            return Ok(studentFromDb);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var studentFromDb = await _context.Students
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
            if (studentFromDb != null)
            {
                _context.Students.Remove(studentFromDb);
                await _context.SaveChangesAsync();
            }

            return Ok("Student deleted successfully");
        }
    }
}

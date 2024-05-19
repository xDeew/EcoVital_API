using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginAPI.Models;
using EcoVitalAPI.Models;

namespace EcoVitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityQuestionsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public SecurityQuestionsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // POST: api/SecurityQuestions
        [HttpPost]
        public async Task<ActionResult<SecurityQuestion>> PostSecurityQuestion(SecurityQuestion securityQuestion)
        {
            _context.SecurityQuestions.Add(securityQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSecurityQuestion", new { id = securityQuestion.SecurityQuestionId }, securityQuestion);
        }
        // GET: api/SecurityQuestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SecurityQuestion>>> GetSecurityQuestions()
        {
            return await _context.SecurityQuestions.ToListAsync();
        }

        // GET: api/SecurityQuestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SecurityQuestion>> GetSecurityQuestion(int id)
        {
            var securityQuestion = await _context.SecurityQuestions.FindAsync(id);

            if (securityQuestion == null)
            {
                return NotFound();
            }

            return securityQuestion;
        }


        // GET : api/GetSecurityQuestionByUserId
        // It only has to return the question text
        [HttpGet]
        [Route("GetSecurityQuestionByUserId/{userId}")]
        public async Task<ActionResult<string>> GetSecurityQuestionByUserId(int userId)
        {
            var securityQuestion = await _context.SecurityQuestions
                                                 .Where(x => x.UserId == userId)
                                                 .Select(q => q.QuestionText) // Seleccionamos solo el texto de la pregunta
                                                 .FirstOrDefaultAsync(); // Usamos FirstOrDefaultAsync en lugar de ToListAsync

            if (securityQuestion == null)
            {
                return NotFound();
            }

            return securityQuestion; // Esto ahora devuelve solo el texto de la pregunta
        }


        // GET: api/GetSecurityQuestionByQuestion
        // Le pasamos tanto el texto como el id del usuario
        [HttpGet]
        [Route("GetSecurityQuestionByQuestion/{questionText}/{userId}")]
        
        public async Task<ActionResult<SecurityQuestion>> GetSecurityQuestionByQuestion(string questionText, int userId)
        {
            var securityQuestion = await _context.SecurityQuestions
                                                 .Where(x => x.UserId == userId && x.QuestionText == questionText)
                                                 .FirstOrDefaultAsync();

            if (securityQuestion == null)
            {
                return NotFound();
            }

            return securityQuestion;
        }

      

    }
}
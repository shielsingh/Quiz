using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quizbackend;
using quizbackend.Models;

namespace quizbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly QuizContext _context;

        public QuestionsController(QuizContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet]
        public IEnumerable<Question> GetQuestions()
        {
            return _context.Questions;
        }

        // GET: api/Questions/1
        [HttpGet("{quizId}")]
        public IEnumerable<Question> GetQuestions([FromRoute] int quizId)
        {
            return _context.Questions.Where(q=> q.QuizId == quizId);
        }

        ////// GET: api/Questions/5
        ////[HttpGet("{id}")]
        ////public async Task<IActionResult> GetQuestion([FromRoute] int id)
        ////{
        ////    if (!ModelState.IsValid)
        ////    {
        ////        return BadRequest(ModelState);
        ////    }

        ////    var question = await _context.Questions.FindAsync(id);

        ////    if (question == null)
        ////    {
        ////        return NotFound();
        ////    }

        ////    return Ok(question);
        ////}

        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion([FromRoute] int id, [FromBody] Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != question.QuestionId)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
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

        // POST: api/Questions
        [HttpPost]
        public async Task<IActionResult> PostQuestion([FromBody] Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Quiz quiz = _context.Quizzes.SingleOrDefault(q => q.QuizId == question.QuizId);
            if (quiz == null)
                return NotFound();

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = question.QuestionId }, question);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return Ok(question);
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.QuestionId == id);
        }
    }
}
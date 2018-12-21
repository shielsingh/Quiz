using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quizbackend.Models;

namespace quizbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        // GET api/questions
        [HttpGet]
        public ActionResult<IEnumerable<Question>> Get()
        {
            return new Question[] {
                new Question { Text = "Hello"},
                new Question { Text = "Hi"}
            };
        }

        // POST api/questions
        [HttpPost]
        public void Post([FromBody] Question question)
        {

        }
    }
}
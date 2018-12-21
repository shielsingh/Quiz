using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quizbackend.Models
{
    public class Question
    {
        private int QuestionId { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
    }
}

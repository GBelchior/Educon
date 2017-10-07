using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Educon.ViewModels
{
    public class QuizAnswerViewModel
    {
        public string Answer { get; set; }
        public int NumCorrectAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }
}
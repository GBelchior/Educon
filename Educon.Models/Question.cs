using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educon.Models
{
    public class Question
    {
        public int NidQuestion { get; set; }
        public string DesQuestion { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public string DesAnswerOne { get; set; }
        public string DesAnswerTwo { get; set; }
        public string DesAnswerThree { get; set; }
        public string DesAnswerFour { get; set; }
        public int NumCorrectAnswer { get; set; }
        public Category Category { get; set; }
        public string DesAnswer { get; set; }
        public virtual ICollection<UserQuestion> UserQuestions { get; set; }
    }
}

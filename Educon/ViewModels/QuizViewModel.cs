using Educon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Educon.ViewModels
{
    public class QuizViewModel
    {
        public int NidQuestion { get; set; }
        public string DesQuestion { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public string DesAnswerOne { get; set; }
        public string DesAnswerTwo { get; set; }
        public string DesAnswerThree { get; set; }
        public string DesAnswerFour { get; set; }
        public Category Category { get; set; }
    }
}
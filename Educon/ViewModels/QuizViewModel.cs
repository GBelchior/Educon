using Educon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Educon.ViewModels
{
    public class QuizViewModel
    {
        public int NidUser { get; set; }
        public int NidQuestion { get; set; }
        public string DesQuestion { get; set; }
        public AgeGroup AgeGroup { get; set; }
        public string DesAnswerOne { get; set; }
        public string DesAnswerTwo { get; set; }
        public string DesAnswerThree { get; set; }
        public string DesAnswerFour { get; set; }
        public String Category { get; set; }
        public int QtyQuestions { get; set; }

        public QuizViewModel(Question AQuestion)
        {
            NidQuestion = AQuestion.NidQuestion;
            DesQuestion = AQuestion.DesQuestion;
            AgeGroup = AQuestion.AgeGroup;
            DesAnswerOne = AQuestion.DesAnswerOne;
            DesAnswerTwo = AQuestion.DesAnswerTwo;
            DesAnswerThree = AQuestion.DesAnswerThree;
            DesAnswerFour = AQuestion.DesAnswerFour;

            switch(AQuestion.Category)
            {
                case Models.Category.Energy:
                    Category = "ENERGIA";
                    break;
                case Models.Category.Environment:
                    Category = "MEIO AMBIENTE";
                    break;
                case Models.Category.Recycling:
                    Category = "RECICLAGEM";
                    break;
                case Models.Category.Water:
                    Category = "ÁGUA";
                    break;
            }
            
        }
    }
}
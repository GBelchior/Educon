using Educon.Core;
using Educon.Helpers;
using Educon.Hubs;
using Educon.Models;
using Educon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Educon.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        QuizCore Core = new QuizCore();

        public ActionResult EndGame(bool AWin, int AQtyCorQuestions, int AQtyQuestions)
        {
            ViewBag.Win = AWin;
            SinglePlayerEndGameViewModel LModel = new SinglePlayerEndGameViewModel();
            LModel.QtyCorQuestions = AQtyCorQuestions;
            LModel.QtyQuestions = AQtyQuestions;
            LModel.QtyExperience = (AQtyCorQuestions * 50);

            return View(LModel);
        }

        public ActionResult EndMultiPlayerGame(string ANamUser1, string ANamUser2, int AQtyCorQuestions, int AQtyQuestions, int AQtyCorQuestionsOpponent = 0)
        {
            int LWhoIAm = AccountHelpers.GetSignedUser().NamUser.Equals(ANamUser1) ? 1 : 2;

            HttpContext.Application["EndGame" + AccountHelpers.GetSignedUser().NamUser] = true;

            User LOpponent;

            bool bothFinishedGame = false;

            if (LWhoIAm == 1)
            {
                if (HttpContext.Application["EndGame" + ANamUser2] != null && 
                   (bool)HttpContext.Application["EndGame" + ANamUser2] == true)
                {
                    bothFinishedGame = true;
                }

                LOpponent = Core.GetUserByName(ANamUser2);
            }
            else
            {
                if (HttpContext.Application["EndGame" + ANamUser1] != null &&
                   (bool)HttpContext.Application["EndGame" + ANamUser1] == true)
                {
                    bothFinishedGame = true;
                }

                LOpponent = Core.GetUserByName(ANamUser1);
            }

            if (bothFinishedGame)
            {
                MultiplayerHub.HubContext.Clients.User(LOpponent.NamUser).OpponentFinished(AQtyCorQuestions);
            }

            MultiPlayerEndGameViewModel LViewModel = new MultiPlayerEndGameViewModel()
            {
                BothFinishedGame = bothFinishedGame,
                NamOpponent = LOpponent.NamPerson,
                QtyCorQuestions = AQtyCorQuestions,
                QtyQuestions = AQtyQuestions,
                QtyExperience = AQtyCorQuestions * 50,
                QtyCorQuestionsOpponent = AQtyCorQuestionsOpponent
            };

            return View(LViewModel);
        }

        public ActionResult Lose(int AQtyCorQuestions, int AQtyQuestions)
        {
            return Json((new { redirectUrl = Url.Action("EndGame", "Quiz", new { AWin = false, AQtyCorQuestions = AQtyCorQuestions - 1, AQtyQuestions = AQtyQuestions }) }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult NextQuestion(int AQtyQuestions)
        {
            List<Question> LQuestions = (List<Question>) Session["Questions"];



            if (LQuestions.Count == 0)
                return Json((new { redirectUrl = Url.Action("EndGame", "Quiz", new { AWin = true, AQtyCorQuestions = AQtyQuestions, AQtyQuestions = AQtyQuestions })}), JsonRequestBehavior.AllowGet);

            Random LRandom = new Random();
            int LIndex = LRandom.Next(LQuestions.Count);

            Question LQuestion = LQuestions.ElementAt(LIndex);
            LQuestions.Remove(LQuestion);
            Session["Questions"] = LQuestions;

            QuizViewModel LReturnedQuestion = new QuizViewModel(LQuestion);

            return Json(LReturnedQuestion, JsonRequestBehavior.AllowGet);
        }
         
        public ActionResult ValidateAnswer(int ANidUser, int ANidQuestion, int ANumAnswer)
        {
            Question LQuestion = Core.GetQuestion(ANidQuestion);
            QuizAnswerViewModel LAnswer = new QuizAnswerViewModel();

            LAnswer.Answer = LQuestion.DesAnswer;
            LAnswer.NumCorrectAnswer = LQuestion.NumCorrectAnswer;
            LAnswer.IsCorrect = (LQuestion.NumCorrectAnswer == ANumAnswer);

            string LNamUser = AccountHelpers.GetSignedUser().NamUser;

            if (LAnswer.IsCorrect)
            {
                if (HttpContext.Application["QtyCorAnswers" + LNamUser] == null)
                {
                    HttpContext.Application["QtyCorAnswers" + LNamUser] = 1;
                }
                else
                {
                    HttpContext.Application["QtyCorAnswers" + LNamUser] = (int)HttpContext.Application["QtyCorAnswers" + LNamUser] + 1;
                }
            }

            if (LAnswer.IsCorrect)
            {
                Core.IncreaseUserExperience(50, ANidUser);
            }

            Core.ComputeAnswer(ANidUser, ANidQuestion);

            return Json(LAnswer, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NextMultiplayerQuestion(string ANamUser1, string ANamUser2)
        {
            ICollection<Question> LMatchQuestions = ((ICollection<Question>)HttpContext.Application[$"Game-[{ANamUser1}]-{ANamUser2}"]);
            int LNextQuestion = (int)Session["NumCurrentQuestion"];
            Session["NumCurrentQuestion"] = LNextQuestion + 1;

            Question LQuestion = LMatchQuestions.ElementAtOrDefault(LNextQuestion);

            string LMyName = AccountHelpers.GetSignedUser().NamUser;
            string LOtherName = LMyName.Equals(ANamUser1) ? ANamUser2 : ANamUser1;

            if (LQuestion == null)
            {
                return Json((new { redirectUrl = Url.Action("EndMultiPlayerGame", new { ANamUser1 = ANamUser1, ANamUser2 = ANamUser2, AQtyCorQuestions = (int)HttpContext.Application["QtyCorAnswers" + LMyName], AQtyQuestions = LMatchQuestions.Count, AQtyCorQuestionsOpponent = (int)HttpContext.Application["QtyCorAnswers" + LOtherName] }) }), JsonRequestBehavior.AllowGet);
            }

            QuizViewModel LQuestionViewModel = new QuizViewModel(LQuestion);
            LQuestionViewModel.NidUser = AccountHelpers.GetSignedUser().NidUser;
            LQuestionViewModel.QtyQuestions = 15 + 1 - (int)Session["NumCurrentQuestion"];

            return Json(LQuestionViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}
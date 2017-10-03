using Educon.Core;
using Educon.Models;
using Educon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Educon.Controllers
{
    public class UserController : Controller
    {
        private UserCore FCore;
        private UserCore Core
        {
            get
            {
                return FCore;
            }
            set
            {
                FCore = value;
            }
        }

        public UserController()
        {
            FCore = new UserCore();
        }
        public ActionResult Register()
        {
            return View("Register");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Create(string ADesName, string ADesUserName, string ADesAgeGroup, string ADesPassword, string ADesConfirmPassword)
        {
            ErrorType LErrorType = ErrorType.None;

            if (!ADesPassword.Equals(ADesConfirmPassword)) {
                ModelState.AddModelError("Senha", "As senhas não coincidem.");
                LErrorType = ErrorType.Password;
            }
            //if (Core.GetUserByName(ADesUserName) != null)
            //{
            //    ModelState.AddModelError("Usuário", "O nome de usuário já existe.");
            //    LErrorType = ErrorType.User;
            //}           

            User LUser = new Models.User { NamPerson = ADesName, NamUser = ADesUserName, DesPassword = ADesPassword, AgeGroup = GeneralUtils.ConvertToAgeGroup(ADesAgeGroup) };

            if (!ModelState.IsValid)
            {
                return View(LUser);
            }
            //Core.Add(LUser);

            return Json(GeneralUtils.ConvertToString(LErrorType), JsonRequestBehavior.AllowGet);

        }


    }
}
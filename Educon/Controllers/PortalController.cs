using Educon.Helpers;
using Educon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Educon.Controllers
{
    public class PortalController : Controller
    {
        // GET: Portal
        public ActionResult Index()
        {
            User LLoggedInUser = AccountHelpers.GetSignedUser();
            return View(LLoggedInUser);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;

namespace PresentationTier.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            Logger.Log.Debug("Debug message");
            Logger.Log.Error("Error message");
            Logger.Log.Info("Info message");

            return View();
        }
    }
}
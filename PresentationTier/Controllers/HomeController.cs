using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using LogicTier;
using PresentationTier.Models;

namespace PresentationTier.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestProvider Provider;

        public HomeController(ITestProvider ProviderInput)
        {
            Provider = ProviderInput;
        }
        // GET: Home
            //Logger.Log.Debug("Debug message");
            //Logger.Log.Error("Error message");
            //Logger.Log.Info("Info message");

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel { Message = Provider.GetMessage() };
            return View(model);
        }
    }

}
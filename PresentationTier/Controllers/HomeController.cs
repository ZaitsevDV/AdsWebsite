using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        //Logger.Log.Debug("Debug message");
        //Logger.Log.Error("Error message");
        //Logger.Log.Info("Info message");

        public ActionResult Index()
        {
            //The exception created for testing of logging.
            try
            {
                string d = null;
                d.ToString();
            }
            catch (Exception error)
            {
                Logger.Log.Error(error.Message);
            }

            HomeViewModel model = new HomeViewModel { Message = Provider.GetMessage() };
            return View(model);
        }
    }
}
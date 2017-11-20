using System;
using System.Web.Mvc;
using LogicTier.Providers;
using PresentationTier.Models;

namespace PresentationTier.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestProvider _provider;

        public HomeController(ITestProvider providerInput)
        {
            _provider = providerInput;
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

            var model = new HomeViewModel { Message = _provider.GetMessage() };
            return View(model);
        }
    }
}
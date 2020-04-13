using Brackets;
using SqlDatabase;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BracketsUI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var tags = Configuration.GetWordsDictionary();
            var tagsList = new List<string>();

            foreach (var tag in tags)
                tagsList.Add(tag.Key + tag.Value);

            ViewBag.Tags = tagsList;

            return View();
        }
        
        public ActionResult Results()
        {
            var results = BracketsDataService.GetChecksHistoryList();

            return View(results);
        }
    }
}
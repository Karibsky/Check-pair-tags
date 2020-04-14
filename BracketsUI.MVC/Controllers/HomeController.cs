using Brackets;
using SqlDatabase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
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

        private string GetCheckResult(string text)
        {
            try
            {
                var isCorrect = CheckExpression.IsCorrect(text);
                BracketsDataService.SaveResultToDatabase(isCorrect);

                return $"Result of checking: { isCorrect }";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public string CheckFromUI(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "Check status: Text field is empty!";

            return GetCheckResult(text);
        }

        [HttpPost]
        public string CheckFromDatabase(string recordID)
        {
            try
            {
                if (!new Regex(@"^\d+$").IsMatch(recordID))
                    return "Check status: Only numbers allowed!";

                var text = BracketsDataService.GetTextByID(int.Parse(recordID));
                return GetCheckResult(text);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public string CheckFromFile()
        {
            try
            {
                var upload = Request.Files[Request.Files.GetKey(0)];

                if (upload == null)
                    return "Upload status: File not selected!";
                if (upload.ContentType != "text/plain")
                    return "Upload status: Only TXT files are accepted!";
                if (upload.ContentLength > 102400)
                    return "Upload status: The file has to be less than 100 kb!";

                using (StreamReader sr = new StreamReader(upload.InputStream, true))
                    return GetCheckResult(sr.ReadToEnd());
            }
            catch (Exception ex)
            {
                return "The following error occured: " + ex.Message;
            }
        }
    }
}
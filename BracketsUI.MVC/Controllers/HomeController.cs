using Brackets;
using SqlDatabase;
using System;
using System.Collections.Generic;
using System.IO;
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

        private bool GetCheckResult(string text)
        {
            var isCorrect = CheckExpression.IsCorrect(text);
            BracketsDataService.SaveResultToDatabase(isCorrect);

            return isCorrect;
        }

        [HttpPost]
        [ValidateInput(false)]
        public string CheckFromUI(string text)
        {
            var isCorrect = false;

            if (!string.IsNullOrWhiteSpace(text))
            {
                try
                {
                    isCorrect = GetCheckResult(text);
                }
                catch (Exception ex)
                {
                    return "The following error occured: " + ex.Message;
                }
            }
            else
                return "Check status: Text field is empty!";

            return $"Result of checking: {isCorrect}";
        }

        [HttpPost]
        public string CheckFromDatabase(string recordID)
        {
            Regex regex = new Regex(@"^\d+$");
            var isCorrect = false;

            if (regex.IsMatch(recordID))
            {
                try
                {
                    var text = BracketsDataService.GetTextByID(int.Parse(recordID));
                    isCorrect = GetCheckResult(text);
                }
                catch (Exception ex)
                {
                    return "The following error occured: " + ex.Message;
                }
            }
            else
                return "Check status: Only numbers allowed!";

            return $"Result of checking: {isCorrect}";
        }

        [HttpPost]
        public string CheckFromFile()
        {
            var isCorrect = false;

            try
            {
                foreach (string file in Request.Files)
                {
                    var upload = Request.Files[file];

                    if (upload != null)
                    {
                        if (upload.ContentType == "text/plain")
                        {
                            if (upload.ContentLength < 102400)
                            {
                                using (StreamReader sr = new StreamReader(upload.InputStream, true))
                                    isCorrect = GetCheckResult(sr.ReadToEnd());
                            }
                            else
                                return "Upload status: The file has to be less than 100 kb!";
                        }
                        else
                            return "Upload status: Only TXT files are accepted!";
                    }
                    else
                        return "Upload status: File not selected!";
                }
            }
            catch(Exception ex)
            {
                return "The following error occured: " + ex.Message;
            }

            return $"Result of checking: {isCorrect}";
        }
    }
}
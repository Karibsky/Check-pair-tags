using Brackets;
using SqlDatabase;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BracketsUI.WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var tags = Configuration.GetWordsDictionary();

                foreach (var tag in tags)
                {
                    TagsList.Items.Add(tag.Key + tag.Value);
                }
            }
        }

        protected void FileButton_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                try
                {
                    if (FileUpload.PostedFile.ContentType == "text/plain")
                    {
                        if (FileUpload.PostedFile.ContentLength < 102400)
                        {
                            string filename = Path.GetFileName(FileUpload.FileName);
                            string filepath = Server.MapPath("~/Upload/") + filename;
                            FileUpload.SaveAs(filepath);

                            var isCorrect = ParseFile(filepath);
                            BracketsDataService.SaveResultToDatabase(isCorrect);

                            StatusLabel.Text = $"Result of checking: {isCorrect}";
                        }
                        else
                            StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                        StatusLabel.Text = "Upload status: Only TXT files are accepted!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            else
                StatusLabel.Text = "Upload status: File not selected!";
        }

        private bool ParseFile(string path)
        {
            using (StreamReader sr = new StreamReader(path, true))
                while (sr.Peek() > 0)
                    return CheckExpression.IsCorrect(sr.ReadToEnd());
            return false;
        }

        protected void DatabaseButton_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");

            if (regex.IsMatch(RecordID.Text))
            {
                try
                {
                    var text = BracketsDataService.GetTextByID(int.Parse(RecordID.Text));
                    GetCheckResult(text);
                }
                catch(Exception ex)
                {
                    StatusLabel.Text = "The following error occured: " + ex.Message;
                }
            }
            else
                StatusLabel.Text = "Check status: Only numbers allowed!";
        }

        protected void UIButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Expression.Text))
            {
                try
                {
                    GetCheckResult(Expression.Text);
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "The following error occured: " + ex.Message;
                }
            }
            else
                StatusLabel.Text = "Check status: Text field is empty!";
        }

        private void GetCheckResult(string text)
        {
            var isCorrect = CheckExpression.IsCorrect(text);
            BracketsDataService.SaveResultToDatabase(isCorrect);

            StatusLabel.Text = $"Result of checking: {isCorrect}";
        }
    }
}
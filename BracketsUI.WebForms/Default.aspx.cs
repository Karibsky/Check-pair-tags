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
                            using (StreamReader sr = new StreamReader(FileUpload.PostedFile.InputStream, true))
                                GetCheckResult(sr.ReadToEnd());
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

        protected void DatabaseButton_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");

            if (regex.IsMatch(RecordID.Text))
            {
                var text = string.Empty;

                try
                {
                    text = BracketsDataService.GetTextByID(int.Parse(RecordID.Text));
                }
                catch(Exception ex)
                {
                    StatusLabel.Text = ex.Message;
                }

                GetCheckResult(text);
            }
            else
                StatusLabel.Text = "Check status: Only numbers allowed!";
        }

        protected void UIButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Expression.Text))
                GetCheckResult(Expression.Text);
            else
                StatusLabel.Text = "Check status: Text field is empty!";
        }

        private void GetCheckResult(string text)
        {
            try
            {
                var isCorrect = CheckExpression.IsCorrect(text);
                BracketsDataService.SaveResultToDatabase(isCorrect);

                StatusLabel.Text = $"Result of checking: {isCorrect}";
            }
            catch(Exception ex)
            {
                StatusLabel.Text = "The following error occured: " + ex.Message;
            }
        }
    }
}
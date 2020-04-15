using Brackets;
using Brackets.Data;
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
            try
            {
                if (!FileUpload.HasFile || FileUpload.PostedFile.ContentLength > 102400 || FileUpload.PostedFile.ContentType != "text/plain")
                    StatusLabel.Text = "Upload status: File is not valid! You can download only TXT files to be less than 100 kb!";
                else
                    using (StreamReader sr = new StreamReader(FileUpload.PostedFile.InputStream, true))
                        GetCheckResult(sr.ReadToEnd());
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }

        protected void DatabaseButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (new Regex(@"^\d+$").IsMatch(RecordID.Text))
                {
                    var text = BracketsDataService.GetTextByID(int.Parse(RecordID.Text));
                    GetCheckResult(text);
                }
                else
                    StatusLabel.Text = "Check status: Only numbers allowed!";
            }
            catch (Exception ex)
            {
                StatusLabel.Text = ex.Message;
            }
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
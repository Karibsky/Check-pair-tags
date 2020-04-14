using SqlDatabase;
using System;

namespace BracketsUI.WebForms
{
    public partial class Results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ResultsHistoryList.DataSource = BracketsDataService.GetChecksHistoryList();
            ResultsHistoryList.DataBind();
        }
    }
}
using BracketsDataServiceProvider;
using SqlDatabase;
using System;
using System.Linq;

namespace BracketsUI.WebForms
{
    public partial class Results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var results = BracketsDataService.GetChecksHistoryList();

            ResultsHistoryList.DataSource = results;
            ResultsHistoryList.DataBind();
        }
    }
}
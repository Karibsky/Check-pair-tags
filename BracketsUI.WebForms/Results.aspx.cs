using BracketsUI.WebForms.ViewModels;
using SqlDatabase;
using System;
using System.Linq;

namespace BracketsUI.WebForms
{
    public partial class Results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var results = BracketsDataService.GetChecksHistoryList().Select(x => new CheckResultViewModel
            {
                Id = x.LogID,
                Time = x.Time.ToShortDateString(),
                Result = x.Result
            });

            ResultsHistoryList.DataSource = results;
            ResultsHistoryList.DataBind();
        }
    }
}
using AutoMapper;
using Brackets.Data;
using Brackets.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BracketsUI.WebForms
{
    public partial class Results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dtos = BracketsDataService.GetChecksHistoryList();
            var viewModels = Mapper.Map<IEnumerable<CheckResultViewModel>, IEnumerable<LogDto>>(dtos);

            ResultsHistoryList.DataSource = viewModels;
            ResultsHistoryList.DataBind();
        }
    }
}
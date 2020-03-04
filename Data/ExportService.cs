using Radzen;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Web;

namespace PlanningSystem.Data
{
    public class ExportService
    {
        private readonly NavigationManager navigationManager;

        public ExportService(NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
        }
       

        public void Export(string table, string type, Query query = null)

        {

            navigationManager.NavigateTo(query != null ? query.ToUrl($"/export/data/{table}/{type}") : $"/export/data/{table}/{type}", true);

        }
    }
}

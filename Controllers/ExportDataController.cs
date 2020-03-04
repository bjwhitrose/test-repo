using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanningSystem.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlanningSystem.Controllers
{
    public partial class ExportDataController : ExportController
    {
        private readonly POAPP001Context context;

        public ExportDataController(POAPP001Context context)
        {
            this.context = context;
        }
        
        [HttpGet("/export/data/Dac.AccountResult/excel")]
        public FileStreamResult ExportCustomersToExcel()
        {

            return ToExcel(ApplyQuery(context.CustAssessResultTable, Request.Query));
        }
        [HttpGet("/export/data/CustAssessResultTable/excel")]
        public FileStreamResult ExportCustomers()
        {

            return ToExcel(ApplyQuery(context.CustAssessResultTable, Request.Query));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ApplicationLayer.Controllers
{
    public class ExportController : Controller
    {
        // GET: Export
        public FileContentResult DownloadCSV()
        {
            var service = new DAL.Services.ClientInformationService();

            var csv = service.ExportCSV();

            return File(Encoding.UTF8.GetBytes(csv.ToString()), "text/csv", "Client Information.csv");
        }
    }
}
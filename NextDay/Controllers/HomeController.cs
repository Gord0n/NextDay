using NextDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NextDay.Controllers
{
    public class HomeController : Controller
    {

        CostarEntities db = new CostarEntities();

        public ActionResult Index()
        {
            DateTime today = DateTime.Today;
            DateTime tempTime = new DateTime(2019, 01, 01);

            Documents docs = db.Documents.Where(o => o.AppointmentDate == tempTime).FirstOrDefault();

            DocumentTypes docTypes = db.DocumentTypes.FirstOrDefault();



            return View();
        }

    }
}
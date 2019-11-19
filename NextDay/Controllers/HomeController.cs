using NextDay.Models;
using NextDay.Models.Objects;
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
            DateTime nextWeek = tempTime.AddDays(7);

            List<Documents> docs = db.Documents.Where(o => o.OrderDate > tempTime && o.OrderDate < nextWeek).OrderBy(o => o.Document).OrderBy(o => o.AppointmentDate).ToList();
            List<DocumentDetails> docDetails = db.DocumentDetails.Where(o=>(o.ServiceDate > tempTime && o.ServiceDate < nextWeek) && (o.ProductTypeCategory == "TIRES" || o.Item == "TRST")).OrderBy(o=>o.Document).OrderBy(o=>o.ServiceDate).ToList();

            List<NextDayInformation> content = new List<NextDayInformation>();
            string prevDocument = "";

            foreach(DocumentDetails Details in docDetails)
            {
                //If it equals the previous than its still the same information and so we just add on to DocumentInformation
                if (prevDocument == Details.Document)
                {
                    content.Last().DocumentInformation.Add("Test");
                }
                else
                {
                    Documents currentDocument = docs.Where(o => o.Document == Details.Document).FirstOrDefault();
                    
                    DateTime apointStartTime = docs.Where(o => o.Document == Details.Document).FirstOrDefault().AppointmentTime ?? new DateTime(2000, 01, 01);
                    DateTime apointEndTime = docs.Where(o => o.Document == Details.Document).FirstOrDefault().PromisedTime ?? new DateTime(2000, 01, 01);
                    
                    content.Add(new NextDayInformation()
                    {
                        DocumentDate = (DateTime)Details.ServiceDate,
                        DocumentType = "" + Details.DocumentType + " " + Details.Document,
                        DocumentTime = "" + apointStartTime.Hour + " - " + apointEndTime.Hour,
                        CustomerInformation = currentDocument.Name,
                        CustomerVehicleInformation = currentDocument.VehicleYear + " " + currentDocument.VehicleMake + " " + currentDocument.VehicleModel                        
                    });

                    content.Last().DocumentInformation.Add(Details.Description);
                    
                }

                prevDocument = Details.Document;
            }       

            return View(content);
        }

    }
}
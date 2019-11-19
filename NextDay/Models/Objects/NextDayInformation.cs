using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NextDay.Models.Objects
{
    public class NextDayInformation
    {

        public NextDayInformation()
        {
            DocumentInformation = new List<string>();
        }

        public DateTime DocumentDate { get; set; }              //Date for invoice / WO / Apointment

        public string DocumentType { get; set; }                //Invoice, PO and document number

        public string DocumentTime { get; set; }                //Time slot for apointment

        public List<string> DocumentInformation { get; set; }   //Tire or storage, sure. Might need to split this up some more

        public string CustomerInformation { get; set; }         //Customer information

        public string CustomerVehicleInformation { get; set; }  //Customer vehicle info.

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForms.Models
{
    public class TravelWarrant
    {
        public int IDTravelWarrant { get; set; }
        public string WarrantStatus { get; set; }
        public int DriverID { get; set; }
        public int VehicleID { get; set; }
    }
}
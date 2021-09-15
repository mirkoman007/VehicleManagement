using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForms.Models
{
    public class Vehicle
    {
        public int IDVehicle { get; set; }
        public string Make { get; set; }
        public string VehicleType { get; set; }
        public int FirstRegistration { get; set; }
        public int Mileage { get; set; }
    }
}
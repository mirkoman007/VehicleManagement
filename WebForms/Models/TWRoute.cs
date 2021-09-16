using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForms.Models
{
    public class TWRoute
    {
        public int IDTWRoute { get; set; }
        public int Duration { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int StopX { get; set; }
        public int StopY { get; set; }
        public double Mileage { get; set; }
        public int AverageSpeed { get; set; }
        public int FuelConsumption { get; set; }
        public int TravelWarrantID { get; set; }
    }
}
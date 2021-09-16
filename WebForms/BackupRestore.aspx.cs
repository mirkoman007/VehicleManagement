using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Dao;
using WebForms.Models;

namespace WebForms
{
    public partial class BackupRestore : System.Web.UI.Page
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private const string BACKUP_ALL = "BACKUP_ALL";
        private const string XML_PATH = "baza.xml";
        private const string TRAVELWARRANT_ROUTE_RELATION = "travelWarrant_route_relation";
        private const string VEHICLE_TRAVELWARRANT_RELATION = "vehicle_travelWarrant_relation";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBackup_Click(object sender, EventArgs e)
        {
            CreateXml();
            lblInfo.Text = $"<div class=\"alert alert-success\" role=\"alert\">"+ "Backup completed successfully" + "</div>";
        }

        private void CreateXml()
        {
            DataSet ds = CreateDataSet();
            ds.WriteXml(MapPath(XML_PATH), XmlWriteMode.WriteSchema);

        }

        private DataSet CreateDataSet()
        {
            using (SqlConnection con=new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter(BACKUP_ALL, con);
                DataSet ds = new DataSet("DBBackup");
                da.Fill(ds);
                ds.Tables[0].TableName = nameof(Driver);
                ds.Tables[1].TableName = nameof(TravelWarrant);
                ds.Tables[2].TableName = nameof(TWRoute);
                ds.Tables[3].TableName = nameof(Vehicle);
                DataRelation travelWarrantRouteRelation = new DataRelation(
                    TRAVELWARRANT_ROUTE_RELATION,
                    ds.Tables[1].Columns[nameof(TravelWarrant.IDTravelWarrant)],
                    ds.Tables[2].Columns[nameof(TWRoute.TravelWarrantID)]);
                travelWarrantRouteRelation.Nested = true;
                ds.Relations.Add(travelWarrantRouteRelation);

                DataRelation vehicleTravelWarrantRelation = new DataRelation(
                    VEHICLE_TRAVELWARRANT_RELATION,
                    ds.Tables[3].Columns[nameof(Vehicle.IDVehicle)],
                    ds.Tables[1].Columns[nameof(TravelWarrant.VehicleID)]);
                vehicleTravelWarrantRelation.Nested = true;
                ds.Relations.Add(vehicleTravelWarrantRelation);

                DataRelation driverTravelWarrantRelation = new DataRelation(
                    "driver_travelWarrant_relation",
                    ds.Tables[0].Columns[nameof(Driver.IDDriver)],
                    ds.Tables[1].Columns[nameof(TravelWarrant.DriverID)]);
                //driverTravelWarrantRelation.Nested = true;
                ds.Relations.Add(driverTravelWarrantRelation);


                return ds;
            }
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            XMLtoSQL();
            lblInfo.Text = $"<div class=\"alert alert-success\" role=\"alert\">" + "Restore completed successfully" + "</div>";
        }

        private void XMLtoSQL()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(MapPath(XML_PATH));

            List<Driver> drivers=new List<Driver>();
            List<TWRoute> twRoutes = new List<TWRoute>();
            List<TravelWarrant> travelWarrants = new List<TravelWarrant>();
            List<Vehicle> vehicles = new List<Vehicle>();


            ds.Tables[0].Rows.Cast<DataRow>()
                .ToList()
                .ForEach(driverRow =>
                {
                    drivers.Add(new Driver
                    {
                        IDDriver = (int)driverRow[nameof(Driver.IDDriver)],
                        FirstName= driverRow[nameof(Driver.FirstName)].ToString(),
                        LastName= driverRow[nameof(Driver.LastName)].ToString(),
                        MobileNumber = driverRow[nameof(Driver.MobileNumber)].ToString(),
                        DriverLicenseNumber = driverRow[nameof(Driver.DriverLicenseNumber)].ToString()
                    });

                });


            ds.Tables[1].Rows.Cast<DataRow>()
                .ToList()
                .ForEach(vehicleRow =>
                {
                    vehicles.Add(new Vehicle
                    {
                        IDVehicle = (int)vehicleRow[nameof(Vehicle.IDVehicle)],
                        Make = vehicleRow[nameof(Vehicle.Make)].ToString(),
                        VehicleType = vehicleRow[nameof(Vehicle.VehicleType)].ToString(),
                        FirstRegistration = (int)vehicleRow[nameof(Vehicle.FirstRegistration)],
                        Mileage = (int)vehicleRow[nameof(Vehicle.Mileage)]
                    });
                    vehicleRow.GetChildRows(VEHICLE_TRAVELWARRANT_RELATION).Cast<DataRow>()
                        .ToList()
                        .ForEach(travelWarrantRow =>
                        {
                            travelWarrants.Add(new TravelWarrant
                            {
                                IDTravelWarrant = (int)travelWarrantRow[nameof(TravelWarrant.IDTravelWarrant)],
                                WarrantStatus = travelWarrantRow[nameof(TravelWarrant.WarrantStatus)].ToString(),
                                DriverID = (int)travelWarrantRow[nameof(TravelWarrant.DriverID)],
                                VehicleID = (int)travelWarrantRow[nameof(TravelWarrant.VehicleID)]
                            });
                            travelWarrantRow.GetChildRows(TRAVELWARRANT_ROUTE_RELATION).Cast<DataRow>()
                                .ToList()
                                .ForEach(routeRow =>
                                {
                                    twRoutes.Add(new TWRoute
                                    {
                                        IDTWRoute = (int)routeRow[nameof(TWRoute.IDTWRoute)],
                                        Duration = (int)routeRow[nameof(TWRoute.Duration)],
                                        StartX = (int)routeRow[nameof(TWRoute.StartX)],
                                        StartY = (int)routeRow[nameof(TWRoute.StartY)],
                                        StopX = (int)routeRow[nameof(TWRoute.StopX)],
                                        StopY = (int)routeRow[nameof(TWRoute.StopY)],
                                        Mileage = (double)routeRow[nameof(TWRoute.Mileage)],
                                        AverageSpeed = (int)routeRow[nameof(TWRoute.AverageSpeed)],
                                        FuelConsumption = (int)routeRow[nameof(TWRoute.FuelConsumption)],
                                        TravelWarrantID = (int)routeRow[nameof(TWRoute.TravelWarrantID)]
                                    });
                                });
                        });
                });




            vehicles.ForEach(v =>
            {
                int newVehicleId=SqlHandler.AddVehicle(v);
                travelWarrants.Where(x => x.VehicleID == v.IDVehicle).ToList().ForEach(y => y.VehicleID = newVehicleId);
            });

            drivers.ForEach(d =>
            {
                int newDriverId = SqlHandler.AddDriverWithReturn(d);
                travelWarrants.Where(x => x.DriverID == d.IDDriver).ToList().ForEach(y => y.DriverID = newDriverId);
            });

            travelWarrants.ForEach(tw =>
            {
                int newTravelWarrantId = SqlHandler.AddTravelWarrant(tw);
                twRoutes.Where(x => x.TravelWarrantID == tw.IDTravelWarrant).ToList().ForEach(y => y.TravelWarrantID = newTravelWarrantId);
            });

            twRoutes.ForEach(r =>
            {
                SqlHandler.AddTWRoute(r);
            });



        }

        protected void btnClearData_Click(object sender, EventArgs e)
        {
            using (var db = new ModelContainer())
            {


                db.TWRoutes.ToList().ForEach(item =>
                {

                    db.TWRoutes.Remove(item);
                });

                db.TravelWarrants.ToList().ForEach(item =>
                {

                    db.TravelWarrants.Remove(item);
                });

                db.Vehicles.ToList().ForEach(item =>
                {

                    db.Vehicles.Remove(item);
                });

                db.Drivers.ToList().ForEach(item =>
                {

                    db.Drivers.Remove(item);
                });

                db.SaveChanges();
            }
            lblInfo.Text = $"<div class=\"alert alert-success\" role=\"alert\">" + "Clear data completed successfully" + "</div>";

        }
    }
}
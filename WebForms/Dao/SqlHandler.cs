using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using WebForms.Models;

namespace WebForms.Dao
{
    public class SqlHandler
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private static SqlDatabase db = new SqlDatabase(cs);


        private const string SELECT_DRIVERS = "select * from Driver";
        private const string SELECT_DRIVER = "select * from Driver where IDDriver=";
        private const string DELETE_DRIVER = "delete from Driver where IDDriver=";
        private const string UPDATE_DRIVER = "update Driver set ";
        private const string INSERT_DRIVER = "INSERT INTO Driver (FirstName,LastName,MobileNumber,DriverLicenseNumber) VALUES";

        private const string ID_VEHICLE = "@idVehicle";
        private const string MAKE = "@make";
        private const string VEHICLE_TYPE = "@vehicleType";
        private const string FIRST_REGISTRATION = "@firstRegistration";
        private const string MILEAGE = "@mileage";

        internal static IEnumerable<Driver> GetDrivers()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SELECT_DRIVERS, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new Driver
                            {
                                IDDriver = (int)dr[0],
                                FirstName = dr[1].ToString(),
                                LastName = dr[2].ToString(),
                                MobileNumber = dr[3].ToString(),
                                DriverLicenseNumber = dr[4].ToString()
                            };
                        }
                    }

                }
            }
        }


        internal static Driver GetDriver(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SELECT_DRIVER + id.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new Driver
                            {
                                IDDriver = (int)dr[0],
                                FirstName = dr[1].ToString(),
                                LastName = dr[2].ToString(),
                                MobileNumber = dr[3].ToString(),
                                DriverLicenseNumber = dr[4].ToString()
                            };
                        }
                    }

                }
            }
            throw new Exception("No such driver");
        }

        internal static void AddDriver(Driver d)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(INSERT_DRIVER + $"('{d.FirstName}','{d.LastName}','{d.MobileNumber}','{d.DriverLicenseNumber}')", con);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal static void UpdateDriver(Driver d)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(UPDATE_DRIVER+$"FirstName='{d.FirstName}',LastName='{d.LastName}',MobileNumber='{d.MobileNumber}',DriverLicenseNumber='{d.DriverLicenseNumber}' where IDDriver={d.IDDriver}", con);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal static void DeleteDriver(int idDriver)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(DELETE_DRIVER + idDriver.ToString(), con);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }


        internal static IEnumerable<Vehicle> GetVehicles()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetVehicles);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new Vehicle
                            {
                                IDVehicle = (int)dr[0],
                                Make = dr[1].ToString(),
                                VehicleType = dr[2].ToString(),
                                FirstRegistration = (int)dr[3],
                                Mileage = (int)dr[4]
                            };
                        }
                    }
                }
            }
        }
        internal static Vehicle GetVehicle(int idVehicle)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetVehicle);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(ID_VEHICLE, idVehicle);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new Vehicle
                            {
                                IDVehicle = (int)dr[nameof(Vehicle.IDVehicle)],
                                Make = dr[nameof(Vehicle.Make)].ToString(),
                                VehicleType= dr[nameof(Vehicle.VehicleType)].ToString(),
                                FirstRegistration= (int)dr[nameof(Vehicle.FirstRegistration)],
                                Mileage=(int)dr[nameof(Vehicle.Mileage)]

                            };
                            
                        }
                    }

                }
            }
            throw new Exception("No such vehicle");
        }

        internal static int AddVehicle(Vehicle v)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(AddVehicle);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(MAKE, v.Make);
                    cmd.Parameters.AddWithValue(VEHICLE_TYPE, v.VehicleType);
                    cmd.Parameters.AddWithValue(FIRST_REGISTRATION, v.FirstRegistration);
                    cmd.Parameters.AddWithValue(MILEAGE, v.Mileage);
                    SqlParameter idVehicle = new SqlParameter(ID_VEHICLE, System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idVehicle);
                    cmd.ExecuteNonQuery();
                    return (int)(idVehicle.Value);
                }
            }
        }


        internal static int UpdateVehicle(Vehicle v)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(UpdateVehicle);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(ID_VEHICLE, v.IDVehicle);
                    cmd.Parameters.AddWithValue(MAKE, v.Make);
                    cmd.Parameters.AddWithValue(VEHICLE_TYPE, v.VehicleType);
                    cmd.Parameters.AddWithValue(FIRST_REGISTRATION, v.FirstRegistration);
                    cmd.Parameters.AddWithValue(MILEAGE, v.Mileage);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        internal static int DeleteVehicle(int idVehicle)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(DeleteVehicle);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(ID_VEHICLE, idVehicle);
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        //---------for XML backup

        internal static int AddDriverWithReturn(Driver d)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(AddDriverWithReturn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@firstName", d.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", d.LastName);
                    cmd.Parameters.AddWithValue("@mobileNumber", d.MobileNumber);
                    cmd.Parameters.AddWithValue("@driverLicenseNumber", d.DriverLicenseNumber);
                    SqlParameter idDriver = new SqlParameter("@idDriver", System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idDriver);
                    cmd.ExecuteNonQuery();
                    return (int)(idDriver.Value);
                }
            }
        }
        internal static int AddTravelWarrant(TravelWarrant tw)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(AddTravelWarrant);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@warrantStatus", tw.WarrantStatus);
                    cmd.Parameters.AddWithValue("@driverID", tw.DriverID);
                    cmd.Parameters.AddWithValue("@vehicleID", tw.VehicleID);
                    SqlParameter idTravelWarrant = new SqlParameter("@idTravelWarrant", System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idTravelWarrant);
                    cmd.ExecuteNonQuery();
                    return (int)(idTravelWarrant.Value);
                }
            }
        }
        internal static int AddTWRoute(TWRoute r) => db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name, r.Duration,r.StartX,r.StartY,r.StopX,r.StopY,r.Mileage,r.AverageSpeed,r.FuelConsumption,r.TravelWarrantID);

    }
}
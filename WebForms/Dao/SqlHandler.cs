using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebForms.Models;

namespace WebForms.Dao
{
    public class SqlHandler
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        private const string SELECT_DRIVERS = "select * from Driver";
        private const string SELECT_DRIVER = "select * from Driver where IDDriver=";
        private const string DELETE_DRIVER = "delete from Driver where IDDriver=";
        private const string UPDATE_DRIVER = "update Driver set ";
        private const string INSERT_DRIVER = "INSERT INTO Driver (FirstName,LastName,MobileNumber,DriverLicenseNumber) VALUES";


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
    }
}
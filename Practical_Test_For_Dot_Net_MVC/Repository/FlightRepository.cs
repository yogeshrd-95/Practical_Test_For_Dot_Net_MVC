using Practical_Test_For_Dot_Net_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_Test_For_Dot_Net_MVC.Repository
{
    public class FlightRepository
    {
        #region Variable
        private readonly string connectionString;
        #endregion

        #region Constructor
        public FlightRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        #endregion

        #region Methods

        #region GetFlights
        public List<Flight> GetFlights()
        {
            List<Flight> flights = new List<Flight>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Usp_GetFlights", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Flight flight = new Flight
                            {
                                FlightId = (int)reader["FlightId"],
                                FlightRef = reader["FlightRef"].ToString(),
                                DepDate = (DateTime)reader["DepDate"],
                                ArrDate = (DateTime)reader["ArrDate"],
                                FlightType = reader["FlightType"].ToString(),
                                DepTime = (TimeSpan)reader["DepTime"],
                                ArrTime = (TimeSpan)reader["ArrTime"],
                                FlightSupplier = reader["FlightSupplier"].ToString(),
                                Currency = reader["Currency"].ToString(),
                                FlightPrice = (decimal)reader["FlightPrice"]
                            };

                            flights.Add(flight);
                        }
                    }
                }
            }

            return flights;
        }
        #endregion

        #region CreateFlight
        public void CreateFlight(Flight flight)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Usp_InsertFlight", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FlightRef", flight.FlightRef);
                    command.Parameters.AddWithValue("@DepDate", flight.DepDate);
                    command.Parameters.AddWithValue("@ArrDate", flight.ArrDate);
                    command.Parameters.AddWithValue("@FlightType", flight.FlightType);
                    command.Parameters.AddWithValue("@DepTime", flight.DepTime);
                    command.Parameters.AddWithValue("@ArrTime", flight.ArrTime);
                    command.Parameters.AddWithValue("@FlightSupplier", flight.FlightSupplier);
                    command.Parameters.AddWithValue("@Currency", flight.Currency);
                    command.Parameters.AddWithValue("@FlightPrice", flight.FlightPrice);

                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region UpdateFlight
        public void UpdateFlight(Flight flight)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Usp_UpdateFlight", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FlightId", flight.FlightId);
                    command.Parameters.AddWithValue("@FlightRef", flight.FlightRef);
                    command.Parameters.AddWithValue("@DepDate", flight.DepDate);
                    command.Parameters.AddWithValue("@ArrDate", flight.ArrDate);
                    command.Parameters.AddWithValue("@FlightType", flight.FlightType);
                    command.Parameters.AddWithValue("@DepTime", flight.DepTime);
                    command.Parameters.AddWithValue("@ArrTime", flight.ArrTime);
                    command.Parameters.AddWithValue("@FlightSupplier", flight.FlightSupplier);
                    command.Parameters.AddWithValue("@Currency", flight.Currency);
                    command.Parameters.AddWithValue("@FlightPrice", flight.FlightPrice);

                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region DeleteFlight
        public void DeleteFlight(int flightId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Usp_DeleteFlight", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FlightId", flightId);
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region GetFlightById
        public Flight GetFlightById(int flightId)
        {
            Flight flight = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Ups_GetFlightById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@FlightId", flightId));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            flight = new Flight
                            {
                                FlightId = (int)reader["FlightId"],
                                FlightRef = reader["FlightRef"].ToString(),
                                DepDate = (DateTime)reader["DepDate"],
                                ArrDate = (DateTime)reader["ArrDate"],
                                FlightType = reader["FlightType"].ToString(),
                                DepTime = (TimeSpan)reader["DepTime"],
                                ArrTime = (TimeSpan)reader["ArrTime"],
                                FlightSupplier = reader["FlightSupplier"].ToString(),
                                Currency = reader["Currency"].ToString(),
                                FlightPrice = (decimal)reader["FlightPrice"]
                            };
                        }
                    }
                }
            }
            return flight;
        }
        #endregion

        #endregion

    }
}
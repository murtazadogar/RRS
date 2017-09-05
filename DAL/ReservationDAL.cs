using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Web;

using System.Data;
using System.Configuration;


namespace DAL
{
   public class ReservationDAL
    {
        /// <summary>
        /// Get and Set Connection String as public
        /// </summary>
        public static String Connection_String = string.Empty; ///Declare for database communication

        public ReservationDAL()
        {
            ///Get Global connection string
            Connection_String = UtilityFunctions.Connection_String;
        }

        public object GetAllReservations()
        {
           List<Reservation> At_List = new List<Reservation>();
            String FailureMessage = string.Empty;
            /// bool IsInValidUser = false;
            ///Declare and Set paramiterized query
            String queryString = "GetReservation_Report @Mode,@UserID,@DealID,@CountryID,@StatusID";
            ///Declare and Set paramiterized query
            using (SqlConnection connection = new SqlConnection(Connection_String))
            {
                ///Set SQL Command
                SqlCommand command = new SqlCommand(queryString, connection);
                ///Set parameters for paramiterized query
                command.Parameters.Add("@Mode", System.Data.SqlDbType.Int).Value = 0;
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).Id;
                command.Parameters.Add("@DealID", System.Data.SqlDbType.Int).Value = -1;
                command.Parameters.Add("@CountryID", System.Data.SqlDbType.Int).Value = -1;
                command.Parameters.Add("@StatusID", System.Data.SqlDbType.Int).Value = -1;
               
                try
                {
                    ///Open SQL Established connection
                    connection.Open();
                    ///Execute SQL Command and store return result in a SQL Reader
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Reservation objReservation = new Reservation();
                        objReservation.ID = dr.IsDBNull(dr.GetOrdinal("ReservationID")) ? -1 : dr.GetInt32(dr.GetOrdinal("ReservationID"));
                        objReservation.RestaurantDealDetails.Name = dr.IsDBNull(dr.GetOrdinal("Category")) ? "" : dr.GetString(dr.GetOrdinal("Category"));
                        objReservation.RestaurantDealDetails.StartDate = dr.IsDBNull(dr.GetOrdinal("StartDate")) ? null : dr.GetDateTime(dr.GetOrdinal("StartDate")).ToString(UtilityFunctions.Creation_Date_Format);
                        objReservation.RestaurantDealDetails.Discount = dr.IsDBNull(dr.GetOrdinal("Percentage")) ? -1 : dr.GetInt32(dr.GetOrdinal("Percentage"));
                        objReservation.NoOfPerson = dr.IsDBNull(dr.GetOrdinal("NumberOfPersons")) ? -1 : dr.GetInt32(dr.GetOrdinal("NumberOfPersons"));
                        objReservation.Customer.Email = dr.IsDBNull(dr.GetOrdinal("Email")) ? "" : dr.GetString(dr.GetOrdinal("Email"));
                        objReservation.Customer.Username = dr.IsDBNull(dr.GetOrdinal("Username")) ? "" : dr.GetString(dr.GetOrdinal("Username"));
                        objReservation.StatusDetais.Id = dr.IsDBNull(dr.GetOrdinal("StatusID")) ? -1 : dr.GetInt32(dr.GetOrdinal("StatusID"));
                        objReservation.StatusDetais.Name = dr.IsDBNull(dr.GetOrdinal("Status")) ? string.Empty : dr.GetString(dr.GetOrdinal("Status"));
                        At_List.Add(objReservation);
                    }
                }
                catch (Exception e)
                {
                }

            }
            return new { List_HTML = GenerateHTML(At_List) };
        }

        public object Filter_ReservationReport(Reservation objReservation)
        {
            List<Reservation> At_List = new List<Reservation>();
            String FailureMessage = string.Empty;
            /// bool IsInValidUser = false;
            ///Declare and Set paramiterized query
            String queryString = string.Empty;

            if (!string.IsNullOrEmpty(objReservation.RestaurantDealDetails.StartDate) && !string.IsNullOrEmpty(objReservation.RestaurantDealDetails.EndDate))
                 queryString = "GetReservation_Report @Mode,@UserID,@DealID,@CountryID,@StatusID,@StartDate,@EndDate";
            else
                queryString = "GetReservation_Report @Mode,@UserID,@DealID,@CountryID,@StatusID";



            ///Declare and Set paramiterized query
            using (SqlConnection connection = new SqlConnection(Connection_String))
            {
                ///Set SQL Command
                SqlCommand command = new SqlCommand(queryString, connection);


                ///Set parameters for paramiterized query
                if (objReservation.StatusDetais.Id > 0)
                {
                    if (objReservation.RestaurantDealDetails.Id > 0)
                    {
                        if (objReservation.CountryDetais.Id > 0)
                        {
                            ///Filter By Status,Country,Deal
                            command.Parameters.Add("@Mode", System.Data.SqlDbType.Int).Value = 5;
                            command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).Id;
                            command.Parameters.Add("@DealID", System.Data.SqlDbType.Int).Value = objReservation.RestaurantDealDetails.Id;
                            command.Parameters.Add("@CountryID", System.Data.SqlDbType.Int).Value = objReservation.CountryDetais.Id;
                            command.Parameters.Add("@StatusID", System.Data.SqlDbType.Int).Value = objReservation.StatusDetais.Id;
                        }
                        else
                        {
                            ///Filter by Status and deal
                            command.Parameters.Add("@Mode", System.Data.SqlDbType.Int).Value = 6;
                            command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).Id;
                            command.Parameters.Add("@DealID", System.Data.SqlDbType.Int).Value = objReservation.RestaurantDealDetails.Id;
                            command.Parameters.Add("@CountryID", System.Data.SqlDbType.Int).Value = -1;
                            command.Parameters.Add("@StatusID", System.Data.SqlDbType.Int).Value = objReservation.StatusDetais.Id;
                        }

                    }
                    else if (objReservation.CountryDetais.Id > 0)
                    {
                        ///Filter by Country and status
                        command.Parameters.Add("@Mode", System.Data.SqlDbType.Int).Value = 7;
                        command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).Id;
                        command.Parameters.Add("@DealID", System.Data.SqlDbType.Int).Value = -1;
                        command.Parameters.Add("@CountryID", System.Data.SqlDbType.Int).Value = objReservation.CountryDetais.Id;
                        command.Parameters.Add("@StatusID", System.Data.SqlDbType.Int).Value = objReservation.StatusDetais.Id;

                    }
                }
               else if (objReservation.RestaurantDealDetails.Id > 0)
                {
                    ///Filter by Deal

                    if (objReservation.CountryDetais.Id > 0)
                    {
                        ///Filter By Deal,Country
                        command.Parameters.Add("@Mode", System.Data.SqlDbType.Int).Value = 3;
                        command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).Id;
                        command.Parameters.Add("@DealID", System.Data.SqlDbType.Int).Value = objReservation.RestaurantDealDetails.Id;
                        command.Parameters.Add("@CountryID", System.Data.SqlDbType.Int).Value = objReservation.CountryDetais.Id;
                        command.Parameters.Add("@StatusID", System.Data.SqlDbType.Int).Value =  -1;
                    }
                    else
                    {
                        ///Filter by deal
                        command.Parameters.Add("@Mode", System.Data.SqlDbType.Int).Value = 1;
                        command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).Id;
                        command.Parameters.Add("@DealID", System.Data.SqlDbType.Int).Value = objReservation.RestaurantDealDetails.Id;
                        command.Parameters.Add("@CountryID", System.Data.SqlDbType.Int).Value = -1;
                        command.Parameters.Add("@StatusID", System.Data.SqlDbType.Int).Value = -1;

                    }
                }
                else if (objReservation.CountryDetais.Id > 0)
                {
                    ///Filetr by Country
                    command.Parameters.Add("@Mode", System.Data.SqlDbType.Int).Value = 8;
                    command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).Id;
                    command.Parameters.Add("@DealID", System.Data.SqlDbType.Int).Value = -1;
                    command.Parameters.Add("@CountryID", System.Data.SqlDbType.Int).Value = -1;
                    command.Parameters.Add("@StatusID", System.Data.SqlDbType.Int).Value = -1;

                }


                if (!string.IsNullOrEmpty(objReservation.RestaurantDealDetails.StartDate) && !string.IsNullOrEmpty(objReservation.RestaurantDealDetails.EndDate))
                {
                    command.Parameters.Add("@StartDate", System.Data.SqlDbType.DateTime).Value = UtilityFunctions.FormateDate(objReservation.RestaurantDealDetails.StartDate);
                    command.Parameters.Add("@EndDate", System.Data.SqlDbType.DateTime).Value = UtilityFunctions.FormateDate(objReservation.RestaurantDealDetails.EndDate);
                }



                try
                {
                    ///Open SQL Established connection
                    connection.Open();
                    ///Execute SQL Command and store return result in a SQL Reader
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Reservation objmod = new Reservation();
                        objmod.ID = dr.IsDBNull(dr.GetOrdinal("ReservationID")) ? -1 : dr.GetInt32(dr.GetOrdinal("ReservationID"));
                        objmod.RestaurantDealDetails.Name = dr.IsDBNull(dr.GetOrdinal("Category")) ? "" : dr.GetString(dr.GetOrdinal("Category"));
                        objmod.RestaurantDealDetails.StartDate = dr.IsDBNull(dr.GetOrdinal("StartDate")) ? null : dr.GetDateTime(dr.GetOrdinal("StartDate")).ToString(UtilityFunctions.Creation_Date_Format);
                        objmod.RestaurantDealDetails.Discount = dr.IsDBNull(dr.GetOrdinal("Percentage")) ? -1 : dr.GetInt32(dr.GetOrdinal("Percentage"));
                        objmod.NoOfPerson = dr.IsDBNull(dr.GetOrdinal("NumberOfPersons")) ? -1 : dr.GetInt32(dr.GetOrdinal("NumberOfPersons"));
                        objmod.Customer.Email = dr.IsDBNull(dr.GetOrdinal("Email")) ? "" : dr.GetString(dr.GetOrdinal("Email"));
                        objmod.Customer.Username = dr.IsDBNull(dr.GetOrdinal("Username")) ? "" : dr.GetString(dr.GetOrdinal("Username"));
                        objmod.StatusDetais.Id = dr.IsDBNull(dr.GetOrdinal("StatusID")) ? -1 : dr.GetInt32(dr.GetOrdinal("StatusID"));
                        objmod.StatusDetais.Name = dr.IsDBNull(dr.GetOrdinal("Status")) ? string.Empty : dr.GetString(dr.GetOrdinal("Status"));
                        At_List.Add(objmod);
                    }
                }
                catch (Exception e)
                {
                }

            }
            return new { List_HTML = GenerateHTML(At_List) };
        }

        public object GetTopReservations()
        {
            List<Reservation> At_List = new List<Reservation>();
            StringBuilder html = new StringBuilder();

            String FailureMessage = string.Empty;
            /// bool IsInValidUser = false;
            ///Declare and Set paramiterized query
            String queryString = "GetReservation_Report @Mode,@UserID,@DealID,@CountryID,@StatusID";
            ///Declare and Set paramiterized query
            using (SqlConnection connection = new SqlConnection(Connection_String))
            {
                ///Set SQL Command
                SqlCommand command = new SqlCommand(queryString, connection);
                ///Set parameters for paramiterized query
                command.Parameters.Add("@Mode", System.Data.SqlDbType.Int).Value = 9;
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).Id;
                command.Parameters.Add("@DealID", System.Data.SqlDbType.Int).Value = -1;
                command.Parameters.Add("@CountryID", System.Data.SqlDbType.Int).Value = -1;
                command.Parameters.Add("@StatusID", System.Data.SqlDbType.Int).Value = -1;

                try
                {
                    ///Open SQL Established connection
                    connection.Open();
                    ///Execute SQL Command and store return result in a SQL Reader
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Reservation objReservation = new Reservation();
                        objReservation.ID = dr.IsDBNull(dr.GetOrdinal("ReservationID")) ? -1 : dr.GetInt32(dr.GetOrdinal("ReservationID"));
                        objReservation.Customer.Username = dr.IsDBNull(dr.GetOrdinal("Username")) ? "" : dr.GetString(dr.GetOrdinal("Username"));

                        html.Append("<li><a href='#'>" + objReservation.Customer.Username + "</a></li>");

                        At_List.Add(objReservation);
                    }
                }
                catch (Exception e)
                {
                }

            }
            return new { TopReservationList_HTML = html.ToString() };
        }

        public int GetPendingReservations()
        {
            int pendingReservation = 0 ;
            StringBuilder html = new StringBuilder();

            String FailureMessage = string.Empty;
            /// bool IsInValidUser = false;
            ///Declare and Set paramiterized query
            String queryString = "GetReservation_Report @Mode,@UserID,@DealID,@CountryID,@StatusID";
            ///Declare and Set paramiterized query
            using (SqlConnection connection = new SqlConnection(Connection_String))
            {
                ///Set SQL Command
                SqlCommand command = new SqlCommand(queryString, connection);
                ///Set parameters for paramiterized query
                command.Parameters.Add("@Mode", System.Data.SqlDbType.Int).Value = 10;
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).Id;
                command.Parameters.Add("@DealID", System.Data.SqlDbType.Int).Value = -1;
                command.Parameters.Add("@CountryID", System.Data.SqlDbType.Int).Value = -1;
                command.Parameters.Add("@StatusID", System.Data.SqlDbType.Int).Value = -1;

                try
                {
                    ///Open SQL Established connection
                    connection.Open();
                    ///Execute SQL Command and store return result in a SQL Reader
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        pendingReservation = dr.IsDBNull(dr.GetOrdinal("pendingReservation")) ? 0 : dr.GetInt32(dr.GetOrdinal("pendingReservation"));                      
                    }
                }
                catch (Exception e)
                {
                }

            }
            return pendingReservation;
        }

        public String GenerateHTML(List<Reservation> AT_List)
        {
            StringBuilder html = new StringBuilder();
            int count = 0;

            try
            {
                html.Append("<table class='table table-bordered table-striped dataTable no-footer' id='RecordList'><thead><tr><th style='width:10%'>Reservation ID</th><th class='hidden-xs' style='width:20%'>Deal Name</th><th class='hidden-xs' style='width:10%'>Date</th><th class='hidden-xs' style='width:10%'>Discount</th><th class='hidden-xs' style='width:10%'>Persons</th><th class='hidden-xs' style='width:20%'>Name</th> <th class='hidden-xs' style='width:10%'>Email</th><th class='hidden-xs' style='width:10%'>Status</th></tr></thead><tbody>");

                ///Read SQLDataReader for get data 
                foreach (Reservation md in AT_List)
                {

                    if (md.StatusDetais.Id.Equals(1))
                        html.Append("<tr><td>" + md.ID + "</td><td class='hidden-xs'>" + md.RestaurantDealDetails.Name + "</td><td class='hidden-xs'>" + md.RestaurantDealDetails.StartDate + "</td><td class='hidden-xs'>" + md.RestaurantDealDetails.Discount + "</td><td class='hidden-xs'>" + md.NoOfPerson + "</td><td class='hidden-xs'>" + md.Customer.Username + "</td><td class='hidden-xs'><a href='#'>" + md.Customer.Email + "</a></td><td class='hidden-xs'><span class='label label-success'>" + md.StatusDetais.Name + "</span></td></tr>");
                    else if (md.StatusDetais.Id.Equals(2))
                        html.Append("<tr><td>" + md.ID + "</td><td class='hidden-xs'>" + md.RestaurantDealDetails.Name + "</td><td class='hidden-xs'>" + md.RestaurantDealDetails.StartDate + "</td><td class='hidden-xs'>" + md.RestaurantDealDetails.Discount + "</td><td class='hidden-xs'>" + md.NoOfPerson + "</td><td class='hidden-xs'>" + md.Customer.Username + "</td><td class='hidden-xs'><a href='#'>" + md.Customer.Email + "</a></td><td class='hidden-xs'><span class='label label-warning'>" + md.StatusDetais.Name + "</span></td></tr>");
                    else if (md.StatusDetais.Id.Equals(3))
                        html.Append("<tr><td>" + md.ID + "</td><td class='hidden-xs'>" + md.RestaurantDealDetails.Name + "</td><td class='hidden-xs'>" + md.RestaurantDealDetails.StartDate + "</td><td class='hidden-xs'>" + md.RestaurantDealDetails.Discount + "</td><td class='hidden-xs'>" + md.NoOfPerson + "</td><td class='hidden-xs'>" + md.Customer.Username + "</td><td class='hidden-xs'><a href='#'>" + md.Customer.Email + "</a></td><td class='hidden-xs'><span class='label label-danger'>" + md.StatusDetais.Name + "</span></td></tr>");

                    count++;
                }
                html.Append("</tbody></table>");
            }
            catch (Exception e)
            {

            }

            return html.ToString();
        }

    }
}

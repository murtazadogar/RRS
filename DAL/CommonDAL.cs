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
   public class CommonDAL
    {
        /// <summary>
        /// Get and Set Connection String as public
        /// </summary>
        public static String Connection_String = string.Empty; ///Declare for database communication

        public CommonDAL()
        {
            ///Get Global connection string
            Connection_String = UtilityFunctions.Connection_String;
        }
        public List<Status> GetStatusList()
        {
            List<Status> At_List = new List<Status>();

            ///Declare and Set paramiterized query
            String queryString = "LoadCommonDDL @Mode,@UserID";
            ///Declare and Set paramiterized query
            using (SqlConnection connection = new SqlConnection(Connection_String))
            {
                ///Set SQL Command
                SqlCommand command = new SqlCommand(queryString, connection);
                ///Set parameters for paramiterized query
                command.Parameters.Add("@Mode", System.Data.SqlDbType.Int).Value = 0;
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = -1;

                try
                {
                    ///Open SQL Established connection
                    connection.Open();
                    ///Execute SQL Command and store return result in a SQL Reader
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Status objStatus = new Status();
                        objStatus.Id = dr.IsDBNull(dr.GetOrdinal("ID")) ? -1 : dr.GetInt32(dr.GetOrdinal("ID"));
                        objStatus.Name = dr.IsDBNull(dr.GetOrdinal("Status")) ? "" : dr.GetString(dr.GetOrdinal("Status"));
                        At_List.Add(objStatus);
                    }
                }
                catch (Exception e)
                {
                }
            }
            return At_List;
        }

        public List<Country> LoadCustomerDDL()
        {
            List<Country> At_List = new List<Country>();

            ///Declare and Set paramiterized query
            String queryString = "LoadCommonDDL @Mode,@UserID";
            ///Declare and Set paramiterized query
            using (SqlConnection connection = new SqlConnection(Connection_String))
            {
                ///Set SQL Command
                SqlCommand command = new SqlCommand(queryString, connection);
                ///Set parameters for paramiterized query
                command.Parameters.Add("@Mode", System.Data.SqlDbType.Int).Value = 2;
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = -1;
                try
                {
                    ///Open SQL Established connection
                    connection.Open();
                    ///Execute SQL Command and store return result in a SQL Reader
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Country objCountry = new Country();
                        objCountry.Id = dr.IsDBNull(dr.GetOrdinal("ID")) ? -1 : dr.GetInt32(dr.GetOrdinal("ID"));
                        objCountry.Name = dr.IsDBNull(dr.GetOrdinal("Country")) ? "" : dr.GetString(dr.GetOrdinal("Country"));
                        At_List.Add(objCountry);
                    }
                }
                catch (Exception e)
                {
                }
            }
            return At_List;
        }

        public List<RestaurantDeal> LoadRestaurantDeal_List()
        {
            List<RestaurantDeal> At_List = new List<RestaurantDeal>();

            ///Declare and Set paramiterized query
            String queryString = "LoadCommonDDL @Mode,@UserID";
            ///Declare and Set paramiterized query
            using (SqlConnection connection = new SqlConnection(Connection_String))
            {
                ///Set SQL Command
                SqlCommand command = new SqlCommand(queryString, connection);
                ///Set parameters for paramiterized query
                command.Parameters.Add("@Mode", System.Data.SqlDbType.Int).Value = 1;
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).Id;
                try
                {
                    ///Open SQL Established connection
                    connection.Open();
                    ///Execute SQL Command and store return result in a SQL Reader
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        RestaurantDeal objRestaurantDeal = new RestaurantDeal();
                        objRestaurantDeal.Id = dr.IsDBNull(dr.GetOrdinal("ID")) ? -1 : dr.GetInt32(dr.GetOrdinal("ID"));
                        objRestaurantDeal.Name = dr.IsDBNull(dr.GetOrdinal("Description")) ? "" : dr.GetString(dr.GetOrdinal("Description"));
                        At_List.Add(objRestaurantDeal);
                    }
                }
                catch (Exception e)
                {
                }
            }
            return At_List;
        }
    }
}

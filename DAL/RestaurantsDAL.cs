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
   public class RestaurantsDAL
    {
        /// <summary>
        /// Get and Set Connection String as public
        /// </summary>
        public static String Connection_String = string.Empty; ///Declare for database communication

        public RestaurantsDAL()
        {
            ///Get Global connection string
            Connection_String = UtilityFunctions.Connection_String;
        }
      
    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using Common;

namespace DAL
{
    public class UserInfoDAL
    {
    
        /// <summary>
        /// Get and Set Connection String as public
        /// </summary>
        public static String Connection_String = string.Empty; ///Declare for database communication

        public UserInfoDAL()
        {
            ///Get Global connection string
            Connection_String = UtilityFunctions.Connection_String;
        }

        /// <summary>
        /// Autentication For user login
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="password"></param>    
        /// <returns>UserInformatio if Credntials are true</returns>
        public dynamic CheckIfUserExistsInDB(String Email, String password)
        {
            UserInfo objUserInfo = new UserInfo();
            String FailureMessage = string.Empty;
           /// bool IsInValidUser = false;
           ///Declare and Set paramiterized query
            String queryString = "UserLoginAuthentication @Param1, @Param2";
            ///Declare and Set paramiterized query
            using (SqlConnection connection = new SqlConnection(Connection_String))
            {
                ///Set SQL Command
                SqlCommand command = new SqlCommand(queryString, connection);
                ///Set parameters for paramiterized query
                command.Parameters.Add("@Param1", System.Data.SqlDbType.VarChar).Value = Email;
                command.Parameters.Add("@Param2", System.Data.SqlDbType.VarChar).Value = password;

                SqlDataReader reader = null;
                try
                {
                    ///Open SQL Established connection
                    connection.Open();
                    ///Execute SQL Command and store return result in a SQL Reader
                    reader = command.ExecuteReader();
                    ///Read SQLDataReader for get data 
                    while (reader.Read())
                    {

                        int Success = reader.IsDBNull(reader.GetOrdinal("FailureStatus")) ? -1 : reader.GetInt32(reader.GetOrdinal("FailureStatus"));
                         FailureMessage = reader.IsDBNull(reader.GetOrdinal("FailureMessage")) ? "" : reader.GetString(reader.GetOrdinal("FailureMessage"));
                        if (Success <= 0)                         
                        {
                            objUserInfo.Id = reader.IsDBNull(reader.GetOrdinal("ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("ID"));
                            objUserInfo.Username = reader.IsDBNull(reader.GetOrdinal("Username")) ? "" : reader.GetString(reader.GetOrdinal("Username"));
                            objUserInfo.Password = reader.IsDBNull(reader.GetOrdinal("Password")) ? "" : reader.GetString(reader.GetOrdinal("Password"));                          
                            objUserInfo.UserTypeID = reader.IsDBNull(reader.GetOrdinal("UserTypeID")) ? 0 : reader.GetInt32(reader.GetOrdinal("UserTypeID"));                          
                            objUserInfo.UserType = reader.IsDBNull(reader.GetOrdinal("UserType")) ? "" : reader.GetString(reader.GetOrdinal("UserType"));
                            objUserInfo.Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : reader.GetString(reader.GetOrdinal("Email"));
                            objUserInfo.RestaurantDetails.ID= reader.IsDBNull(reader.GetOrdinal("RestaurantID")) ? 0 : reader.GetInt32(reader.GetOrdinal("RestaurantID"));
                            objUserInfo.RestaurantDetails.Name = reader.IsDBNull(reader.GetOrdinal("Restaurant")) ? "" : reader.GetString(reader.GetOrdinal("Restaurant"));
                            objUserInfo.RestaurantDetails.MembershipDate = reader.IsDBNull(reader.GetOrdinal("MembershipDate")) ?"" : (reader.GetDateTime(reader.GetOrdinal("MembershipDate")).ToString("dd MMM yyyy"));
                            objUserInfo.LastLogin = reader.IsDBNull(reader.GetOrdinal("LastLogin")) ? "" : (reader.GetDateTime(reader.GetOrdinal("LastLogin")).ToString("dd MMM yyyy"));


                            FailureMessage = "";
                        }
                       break;
                    }

                }
                catch (Exception e)
                {
                }

            }
            return new { FailureMessage = FailureMessage, UserInfo = objUserInfo }; 
        }


        /// <summary>
        /// Used for Get Specific User details
        /// </summary>
        /// <param name="Record_ID"></param>
        /// <returns></returns>
        public UserInfo GetLoginUserDetails()
        {
            ///Declare and Set paramiterized query
            String queryString = "[SP_GetAllUserInfo] @Page,@RecsPerPage,@Record_ID,@Record_SearchText,@UserTypeID";
            UserInfo md = new UserInfo();

            ///Establish SQL Connection 
            using (SqlConnection connection = new SqlConnection(Connection_String))
            {
                ///Set SQL Command
                SqlCommand command = new SqlCommand(queryString, connection);
                ///Set parameters for paramiterized query
                command.Parameters.Add("@Page", System.Data.SqlDbType.Int).Value = 1;
                command.Parameters.Add("@RecsPerPage", System.Data.SqlDbType.Int).Value = 10000;
                command.Parameters.Add("@Record_ID", System.Data.SqlDbType.Int).Value = -1;
           
                try
                {
                    ///Open SQL Established connection
                    connection.Open();
                    ///Execute SQL Command and store return result in a SQL Reader
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {  
                        ///Set Record details in Employee Object
                        md.Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt64(dr.GetOrdinal("Id"));
                        md.Username = dr.IsDBNull(dr.GetOrdinal("Username")) ? null : dr.GetString(dr.GetOrdinal("Username"));
                        md.Email = dr.IsDBNull(dr.GetOrdinal("Email")) ? null : dr.GetString(dr.GetOrdinal("Email"));
                        md.Password = dr.IsDBNull(dr.GetOrdinal("Password")) ? null : dr.GetString(dr.GetOrdinal("Password"));
                        md.Password = UtilityFunctions.DecryptPassword(md.Password);
                        md.UpdatedDate = dr.IsDBNull(dr.GetOrdinal("UpdatedDate")) ? new DateTime() : dr.GetDateTime(dr.GetOrdinal("UpdatedDate"));
                        break;
                    }
                }
                catch (Exception e)
                {

                }
            }
            return md;
        }

        /// <summary>
        /// Used for Insert/Update Record
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Boolean SaveUserInfoData(UserInfo model)
        {
            ///Declare and Set paramiterized query
            String queryString = "[SP_InsertUpdateUserInfo] @UserID,@Username,@Email,@Password,@UserTypeID";
            List<UserInfo> AT_List = new List<UserInfo>();

            ///Establish SQL Connection 
            using (SqlConnection connection = new SqlConnection(Connection_String))
            {
                ///Set SQL Command
                SqlCommand command = new SqlCommand(queryString, connection);
                ///Set parameters for paramiterized query
            
                command.Parameters.Add("@UserID", System.Data.SqlDbType.BigInt).Value = model.Id;
                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar).Value = model.Username;
                command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = model.Email;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar).Value = model.Password;
                command.Parameters.Add("@UserTypeID", System.Data.SqlDbType.BigInt).Value = model.UserTypeID;
                try
                {
                    ///Open SQL Established connection
                    connection.Open();
                    ///Execute SQL Command and store return result in a SQL Reader
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
           
        }

        /// <summary>
        /// Used for Change User authentication
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="confirm_password"></param>
        public void ChangePassword(int UserID, String confirm_password)
        {
            ///Declare and Set paramiterized query
            String queryString = "[SP_ChangePassword] @UserId,@Password";
            List<UserInfo> AT_List = new List<UserInfo>();

            ///Establish SQL Connection 
            using (SqlConnection connection = new SqlConnection(Connection_String))
            {
                ///Set SQL Command
                SqlCommand command = new SqlCommand(queryString, connection);
                ///Set parameters for paramiterized query
                command.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = UserID;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar).Value = confirm_password;
                try
                {
                    ///Open SQL Established connection
                    connection.Open();
                    ///Execute SQL Command and store return result in a SQL Reader
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
            }
        }


/// <summary>
/// Check either user already exist or not
/// </summary>
/// <param name="email"></param>
/// <returns></returns>
        public Boolean IsValidUser(String email)
        {
            ///Declare and Set paramiterized query
            String queryString = "[SP_GetAllUserInfo] @Page,@RecsPerPage,@Record_ID,@Record_SearchText,@UserTypeID,@Mode";
            UserInfo md = new UserInfo();

            ///Establish SQL Connection 
            using (SqlConnection connection = new SqlConnection(Connection_String))
            {
                ///Set SQL Command
                SqlCommand command = new SqlCommand(queryString, connection);
                ///Set parameters for paramiterized query
                command.Parameters.Add("@Page", System.Data.SqlDbType.Int).Value = 1;
                command.Parameters.Add("@RecsPerPage", System.Data.SqlDbType.Int).Value = 10000;
                command.Parameters.Add("@Record_ID", System.Data.SqlDbType.Int).Value = -1;
                command.Parameters.Add("@Record_SearchText", System.Data.SqlDbType.VarChar).Value = email;
                command.Parameters.Add("@UserTypeID", System.Data.SqlDbType.VarChar).Value = -1;
                command.Parameters.Add("@Mode", System.Data.SqlDbType.Int).Value = 1;
                try
                {
                    ///Open SQL Established connection
                    connection.Open();
                    ///Execute SQL Command and store return result in a SQL Reader
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                        return true;
                    else
                        return false;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }


    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;
using DAL;
using System.Web.Services;

namespace RSS.Application_Code.Views
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Validating user Credntials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="CheckRememberme"></param>
        /// <returns>if failed, The message will have reason of failed from database</returns>
        [WebMethod(EnableSession = true)]
        public static object validateLoginAdmin(String username, String password, String CheckRememberme)
        {
            UserInfoDAL UMobject = new UserInfoDAL();
            object result = UMobject.CheckIfUserExistsInDB(username, UtilityFunctions.EncryptPassword(password));
            return result;

        }

        //protected void Login_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        UserInfoDAL UMobject = new UserInfoDAL();
        //        string u = username.Value;


        //       dynamic result = UMobject.CheckIfUserExistsInDB(username.Value, UtilityFunctions.EncryptPassword(password.Value));
        //       HttpContext.Current.Session["LoggedIn_User"] = (UserInfo)result.GetType().GetProperty("UserInfo").GetValue(result, null);

        //       // if ((string)result.GetType().GetProperty("FailureMessage").GetValue(result, null) == string.Empty)
        //           // Response.Redirect("~/Application_Code/Views/frmDashboard.aspx");
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}
    }
}
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

namespace RRS_UI.Appplication_Code.Views
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static void SaveUserInfoData(String hdnID, String user_name, String email, String password)
        {
            ///Declare Object of EmailTemplate Model
            UserInfo model = new UserInfo();

            ///Store User enter Record in EmailTemplate type object
            model.Id = string.IsNullOrEmpty(hdnID) ? 0 : int.Parse(hdnID);
            model.Username = user_name;
            model.Email = email;
            model.Password = password;
            model.UserTypeID = 2;

            UserInfoDAL objmodelDal = new UserInfoDAL();
            objmodelDal.SaveUserInfoData(model);
            objmodelDal.GetLoginUserDetails();
        }

        [WebMethod(EnableSession = true)]
        public static Boolean IsValidUser(String email)
        {
            ///Declare Object of EmailTemplate Model          
            UserInfoDAL objmodelDal = new UserInfoDAL();
            return objmodelDal.IsValidUser(email);
        }
    }
}
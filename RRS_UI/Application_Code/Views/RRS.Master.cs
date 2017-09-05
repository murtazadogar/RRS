using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;

namespace RRS_UI.Appplication_Code.Views
{
    public partial class RRS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["LoggedIn_User"] != null && (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).UserTypeID == 2)
            {
                ReservationDAL objdal = new ReservationDAL();
                lblusername.InnerText = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).RestaurantDetails.Name;
                lblLoginUser.InnerHtml = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).RestaurantDetails.Name;
                lblMembership.InnerText = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).RestaurantDetails.MembershipDate;
                lblGetPendingReservations.InnerText = objdal.GetPendingReservations().ToString();
                lblRestaurantName.InnerText = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).RestaurantDetails.Name;
                lblMemberShipDate.InnerText = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).RestaurantDetails.MembershipDate;
                lblLastLogin.InnerText = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).LastLogin;
            }
        }
    }
}
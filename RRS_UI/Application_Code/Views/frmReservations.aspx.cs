using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;

namespace RRS_UI.Application_Code.Views
{
    public partial class frmReservations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["LoggedIn_User"] == null)
            {
                Response.Redirect("~/Application_Code/Views/frmLogin.aspx");
            }
           
        }
        

        [WebMethod(EnableSession = true)]
        public static object GetAllReservations()
        {             
            ReservationDAL objmodelDal = new ReservationDAL();
            return objmodelDal.GetAllReservations();
        }


        [WebMethod(EnableSession = true)]
        public static object Filter_ReservationReport(string StatusID, string DealID, string CountryID, string startDate, string endDate)
        {
            Reservation objmod = new Reservation();
            objmod.StatusDetais.Id = string.IsNullOrEmpty(StatusID) ? -1 : Int32.Parse(StatusID);
            objmod.RestaurantDealDetails.Id = string.IsNullOrEmpty(DealID) ? -1 : Int32.Parse(DealID);
            objmod.CountryDetais.Id = string.IsNullOrEmpty(CountryID) ? -1 : Int32.Parse(CountryID);
            objmod.RestaurantDealDetails.StartDate = startDate;
            objmod.RestaurantDealDetails.EndDate = endDate;
 
            ReservationDAL objmodelDal = new ReservationDAL();
            return objmodelDal.Filter_ReservationReport(objmod);
        }

        [WebMethod(EnableSession = true)]
        public static object GetTopReservations()
        {
            ReservationDAL objmodelDal = new ReservationDAL();
            return objmodelDal.GetTopReservations();
        }
    }
}
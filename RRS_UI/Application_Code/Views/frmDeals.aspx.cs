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
    public partial class frmDeals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static object GetRestaurantDeals()
        {
            RestaurantsDAL objmodelDal = new RestaurantsDAL();
            return objmodelDal.GetRestaurantDeals();
        }
    }
}
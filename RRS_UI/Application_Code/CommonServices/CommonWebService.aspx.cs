using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;

namespace RRS_UI.Application_Code.CommonServices
{
    public partial class CommonWebService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static List<Status> LoadStatusDDL()
        {
            ///Declare Object of EmailTemplate Model          
            CommonDAL objmodelDal = new CommonDAL();
            return objmodelDal.GetStatusList();
        }

        [WebMethod(EnableSession = true)]
        public static List<RestaurantDeal> LoadRestaurantDealDDL()
        {
            ///Declare Object of EmailTemplate Model          
            CommonDAL objmodelDal = new CommonDAL();
            return objmodelDal.LoadRestaurantDeal_List();
        }

        [WebMethod(EnableSession = true)]
        public static List<Country> LoadCustomerDDL()
        {
            ///Declare Object of EmailTemplate Model          
            CommonDAL objmodelDal = new CommonDAL();
            return objmodelDal.LoadCustomerDDL();
        }
    }
}
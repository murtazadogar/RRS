using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using Common;

namespace RRS_UI.Application_Code.Views
{
    public partial class frmDeals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["LoggedIn_User"] == null)
            {
                Response.Redirect("~/Application_Code/Views/frmLogin.aspx");
            }
        }

        [WebMethod(EnableSession = true)]
        public static object GetRestaurantDeals()
        {
            RestaurantsDAL objmodelDal = new RestaurantsDAL();
            return objmodelDal.GetRestaurantDeals();
        }

        [WebMethod(EnableSession = true)]
        public static object SaveDealData(string hdnID, string Name, string NoOfPerson, string DaysOfWeek, string Dishs, string Description, string start_time1, string start_time2, string start_time3, string start_time4, string end_time1, string end_time2, string end_time3, string end_time4, string Discount1, string Discount2, string Discount3, string Discount4)
        {
            RestaurantDeal objmod = new RestaurantDeal();

            objmod.Id = string.IsNullOrEmpty(hdnID) ? 0 : Int32.Parse(hdnID);
            objmod.RestaurantId = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).RestaurantDetails.ID;
            objmod.Name = Name;
            objmod.NoOfPerson = string.IsNullOrEmpty(NoOfPerson) ? 0 : Int32.Parse(NoOfPerson);
            objmod.DaysOfWeek = DaysOfWeek;
            objmod.Description = Description;

            //////Set deal Timings
            if (!string.IsNullOrEmpty(start_time1) && !string.IsNullOrEmpty(end_time1) && !string.IsNullOrEmpty(Discount1))
            {
                DealDetails objDealDetails = new DealDetails();
                objDealDetails.Discount = Int32.Parse(Discount1);
                objDealDetails.StartTime = start_time1;
                objDealDetails.EndTime = end_time1;

                objmod.SpecificDealDetails.Add(objDealDetails);
            }

            if (!string.IsNullOrEmpty(start_time2) && !string.IsNullOrEmpty(end_time2) && !string.IsNullOrEmpty(Discount2))
            {
                DealDetails objDealDetails = new DealDetails();
                objDealDetails.Discount = Int32.Parse(Discount2);
                objDealDetails.StartTime = start_time2;
                objDealDetails.EndTime = end_time2;

                objmod.SpecificDealDetails.Add(objDealDetails);
            }

            if (!string.IsNullOrEmpty(start_time3) && !string.IsNullOrEmpty(end_time3) && !string.IsNullOrEmpty(Discount3))
            {
                DealDetails objDealDetails = new DealDetails();
                objDealDetails.Discount = Int32.Parse(Discount3);
                objDealDetails.StartTime = start_time3;
                objDealDetails.EndTime = end_time3;

                objmod.SpecificDealDetails.Add(objDealDetails);
            }

            if (!string.IsNullOrEmpty(start_time4) && !string.IsNullOrEmpty(end_time4) && !string.IsNullOrEmpty(Discount4))
            {
                DealDetails objDealDetails = new DealDetails();
                objDealDetails.Discount = Int32.Parse(Discount4);
                objDealDetails.StartTime = start_time4;
                objDealDetails.EndTime = end_time4;

                objmod.SpecificDealDetails.Add(objDealDetails);
            }

            ///////Set Deal Dishes

            if(!string.IsNullOrEmpty(Dishs))
            {
                string[] d_li = Dishs.Split(',');
                foreach (string d in d_li)
                {
                    Dish objDish = new Dish();
                    objDish.Id = Int32.Parse(d);
                    objmod.Dish_li.Add(objDish);
                }
            }

            ///Set Deal Images

           
            if (HttpContext.Current.Session["ImportFilesName"] != null)
            {
                //string CurrentFilePath = System.Web.HttpContext.Current.Server.MapPath(UtilityFunctions.ImportDocumentPath) + ((HttpContext.Current.Session["ImportFileName"] == null) ? "" : HttpContext.Current.Session["ImportFileName"].ToString());


                string[] images_li = HttpContext.Current.Session["ImportFilesName"].ToString().Split(',');
                foreach (string img in images_li)
                {
                    objmod.Img_path.Add(img);
                }
            }

                RestaurantsDAL objmodelDal = new RestaurantsDAL();
            return objmodelDal.SaveDealData(objmod,true);
        }
    }
}
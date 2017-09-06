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


        public object GetRestaurantDeals()
        {
            Restaurant objRestaurant = new Restaurant();

            List<RestaurantDeal> At_List = new List<RestaurantDeal>();
            List<RestaurantDeal> At_List_modifies = new List<RestaurantDeal>();

            ///Declare and Set paramiterized query
            String queryString = "GetRestaurantsDeals_Report @Mode,@RestaurantID,@RestaurantDealID";
            ///Declare and Set paramiterized query
            using (SqlConnection connection = new SqlConnection(Connection_String))
            {
                ///Set SQL Command
                SqlCommand command = new SqlCommand(queryString, connection);
                ///Set parameters for paramiterized query
                command.Parameters.Add("@Mode", System.Data.SqlDbType.Int).Value = 0;
                command.Parameters.Add("@RestaurantID", System.Data.SqlDbType.Int).Value = (HttpContext.Current.Session["LoggedIn_User"] as UserInfo).RestaurantDetails.ID;
                command.Parameters.Add("@RestaurantDealID", System.Data.SqlDbType.Int).Value = -1;
             
                try
                {
                    ///Open SQL Established connection
                    connection.Open();
                    ///Execute SQL Command and store return result in a SQL Reader
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        RestaurantDeal objmod = new RestaurantDeal();
                        objmod.Id = dr.IsDBNull(dr.GetOrdinal("RestaurantDealID")) ? -1 : dr.GetInt32(dr.GetOrdinal("RestaurantDealID"));
                        objmod.Description = dr.IsDBNull(dr.GetOrdinal("Description")) ? "" : dr.GetString(dr.GetOrdinal("Description"));
                        objmod.RestaurantId = dr.IsDBNull(dr.GetOrdinal("RestaurantID")) ? -1 : dr.GetInt32(dr.GetOrdinal("RestaurantID"));

                        objRestaurant.RestaurantDeal_li.Add(objmod);
                    }

                    foreach (RestaurantDeal d in objRestaurant.RestaurantDeal_li)
                    {
                   
                        RestaurantDeal objmod = new RestaurantDeal();
                        objmod = GetDeal_Details(d.RestaurantId, d.Id);
                        objmod.Id = d.Id;
                        objmod.Description = d.Description;
                        objmod.RestaurantId = d.RestaurantId;
                        At_List_modifies.Add(objmod);
                    }
                   
                    objRestaurant.RestaurantDeal_li = At_List_modifies;

                }
                catch (Exception e)
                {
                }

            }
            return new { DealsList_HTML = GenerateHTML_RestaurantDeals(At_List_modifies) };
        }


        public RestaurantDeal GetDeal_Details(int RestaurantID, int RestaurantDealID)
        {
            RestaurantDeal objRestaurantDeal = new RestaurantDeal();
          

            ///Declare and Set paramiterized query
            String queryString = "GetRestaurantsDeals_Report @Mode,@RestaurantID,@RestaurantDealID";
            ///Declare and Set paramiterized query
            using (SqlConnection connection = new SqlConnection(Connection_String))
            {
                ///Set SQL Command
                SqlCommand command = new SqlCommand(queryString, connection);
                ///Set parameters for paramiterized query
                command.Parameters.Add("@Mode", System.Data.SqlDbType.Int).Value = 1;
                command.Parameters.Add("@RestaurantID", System.Data.SqlDbType.Int).Value = RestaurantID;
                command.Parameters.Add("@RestaurantDealID", System.Data.SqlDbType.Int).Value = RestaurantDealID;

                try
                {
                    ///Open SQL Established connection
                    connection.Open();
                    ///Execute SQL Command and store return result in a SQL Reader
                    SqlDataReader dr = command.ExecuteReader();

                    ///Get Deal Dishes	
                    while (dr.Read())
                    {
                        Dish objDish = new Dish();
                        objDish.Id = dr.IsDBNull(dr.GetOrdinal("DishID")) ? -1 : dr.GetInt32(dr.GetOrdinal("DishID"));
                        objDish.Name = dr.IsDBNull(dr.GetOrdinal("Dish")) ? "" : dr.GetString(dr.GetOrdinal("Dish"));
                        objRestaurantDeal.Dish_li.Add(objDish);
                    }

                    ///Get Deal Images
                    if (dr.NextResult())
                    {
                        while (dr.Read())
                        {
                            string path = dr.IsDBNull(dr.GetOrdinal("ImagePath")) ? "" : dr.GetString(dr.GetOrdinal("ImagePath"));
                            if (!string.IsNullOrEmpty(path))
                                objRestaurantDeal.Img_path.Add(path);
                        }
                    }

                    if (dr.NextResult())
                    {
                        while (dr.Read())
                        {
                            objRestaurantDeal.QualityRating = dr.IsDBNull(dr.GetOrdinal("QualityRatting")) ? -1 : dr.GetInt32(dr.GetOrdinal("QualityRatting"));
                            objRestaurantDeal.PriceRating = dr.IsDBNull(dr.GetOrdinal("PriceRating")) ? -1 : dr.GetInt32(dr.GetOrdinal("PriceRating"));
                        }
                    }

                    ///Get Deal gernal details
                    if (dr.NextResult())
                    {
                        while (dr.Read())
                        {
                            DealDetails objDealDetails = new DealDetails();
                            objDealDetails.StartTime = dr.IsDBNull(dr.GetOrdinal("DealTimeFrom")) ? "" : dr.GetTimeSpan(dr.GetOrdinal("DealTimeFrom")).ToString("hh\\:mm\\:ss");
                            objDealDetails.Discount = dr.IsDBNull(dr.GetOrdinal("Percentage")) ? -1 : dr.GetInt32(dr.GetOrdinal("Percentage"));
                            objDealDetails.NoOfPerson = dr.IsDBNull(dr.GetOrdinal("NumberOfPersons")) ? -1 : dr.GetInt32(dr.GetOrdinal("NumberOfPersons"));

                            objRestaurantDeal.SpecificDealDetails.Add(objDealDetails);
                        }
                    }
                }
                catch (Exception e)
                {
                }
                return objRestaurantDeal;
            }
        }

        public String GenerateHTML_RestaurantDeals(List<RestaurantDeal> objRestaurantDeals)
        {
            StringBuilder html = new StringBuilder();
            int count = 1;

            try
            {
                //html.Append("<table class='table table-bordered table-striped dataTable no-footer' id='RecordList'><tbody>");

                ///Read SQLDataReader for get data 
                ///
                html.Append("<div class='col-md-12'>");

                foreach (RestaurantDeal md in objRestaurantDeals)
                {
                    //html.Append("<tr><td>");

                    ///Master Divs
                    html.Append("<div class='admin-deal-box'><div class='admin-deal-detail'>");
                    
                    ///Deal Name
                    html.Append("<h3><a class='#'>" + md.Name + "</a> <span class='pull-right save-deal'><a href = '#' ><i class='fa fa-heart' aria-hidden='true'></i></a></span></h3>");

                    ///row gutter-0 starting
                    html.Append("<div class='row gutter-0'>");

                    ////Deal images
                    html.Append("<div class='col-xs-4'>");
                    String d_img_div = string.Empty;
                    if (count <= 1)
                        d_img_div = "carousel-example-generic";
                    else
                        d_img_div = "carousel-example-generic"+ count;


                    html.Append("<div id = '"+ d_img_div + "' class='carousel slide' data-ride='carousel'>");

                    html.Append("<div class='fixed-logo'><img src = '../../Content/images/hotel-logo-sm.jpg' ></div> ");

                    html.Append("<ol class='carousel-indicators'>");
                    html.Append("<li data-target='#" + d_img_div + "' data-slide-to='0' class='active'></li>");
                    html.Append("<li data-target='#" + d_img_div + "' data-slide-to='1' class=''></li>");
                    html.Append("<li data-target='#" + d_img_div + "' data-slide-to='2' class=''></li>");
                    html.Append("<li data-target='#" + d_img_div + "' data-slide-to='3' class=''></li>");
                    html.Append("</ol>");

                    html.Append("<div class='carousel-inner'>");
                    int c_image = 0;
                    foreach (string p in md.Img_path)
                    {
                        if (c_image == 0)
                        {
                            html.Append("<div class='item active'>");
                            html.Append("<img src = '" + p + "' alt = '' style = 'width: 100%; height: 150px;' />");
                            html.Append("</div > ");
                        }
                        else
                        {
                            html.Append("<div class='item'>");
                            html.Append("<img src = '" + p + "' alt = '' style = 'width: 100%; height: 150px;' />");
                            html.Append("</div > ");
                        }
                        c_image = c_image + 1;

                    }
                    html.Append("</div>");
                    html.Append("</div>");
                    html.Append("</div>");

                    ///Restaurant rating Div
                    html.Append("<div class='col-xs-4'>");

                    ///Deal Raring div
                    html.Append("<div class='divText clearfix marTop30'>");
                    html.Append("<div class='text-left'>Deal Rating: </div>");
                    html.Append("<div class='text-right'>");
                    html.Append("<div class='box-price-gray'>");
                    html.Append("<div class='box-detail-price-yellow_b' style='width: 40%;'></div>");
                    html.Append("</div>");
                    html.Append("</div>");
                    html.Append("</div>");
           

                    ///Price Rating
                    html.Append("<div class='divText clearfix'>");
                    html.Append("<div class='text-left'>Price Rating:</div>");
                    html.Append("<div class='text-right'>");
                    html.Append("<div class='box-detail-rating-gray'>");
                    html.Append("<div class='box-detail-rating-yellow_b' style='width: 80%;'></div>");
                    html.Append("</div>");
                    html.Append("</div>");

                    html.Append("</div>");
                    html.Append("</div>");

                    ///Menu Dishes
                    html.Append("<div class='col-xs-4'>");
                    html.Append("<div class='admin-menu-list'>");
                    html.Append("<h4>Menu Dishes:</h4>");
                    html.Append("<ul>");
                    foreach (Dish d in md.Dish_li)
                    {
                        html.Append("<li>" + d.Name + "</li>");
                    }
                    html.Append("</ul>");
                    html.Append("</div>");
                    html.Append("</div>");

                    ///row gutter-0 ending
                    html.Append("</div>");

                    ///Discoun Slider
                    html.Append("<div class='borTop clearfix'>");
                    html.Append("<div class='col-xs-2 deal-head'>Deal List:</div>");
                    html.Append("<div class='col-xs-10'>");
                    html.Append("<div class='dealSlider dealsContainer'>");
                    foreach (DealDetails dd in md.SpecificDealDetails)
                    {
                        html.Append("<div>");
                        html.Append("<a href = '#' class='swiper-slide red-slide swiper-slide-visible swiper-slide-active' style='width: 82.6667px; height: 75px;'>");

                        html.Append("<div class='home-slot-time normal-font font-weight-bold'>");
                        html.Append(dd.StartTime);
                        html.Append("</div>");

                        html.Append("<div class='home-slot-discount'>");
                        html.Append("<h1 class='font-weight-bold'>");
                        html.Append("<span>-</span>" + dd.Discount + "</h1>");
                        html.Append("</div>");

                        html.Append("<div class='home-slot-discount-pc'>");
                        html.Append("%");
                        html.Append("</div>");

                        html.Append("<div class='home-slot-off'>");
                        html.Append("off");
                        html.Append("</div>");

                        html.Append("</a>");

                        html.Append("</div>");
                    }

                    html.Append("</div>");
                    html.Append("</div>");
                    html.Append("</div>");

                    ///Close master divs
                    html.Append("</div> </div>");
                
                    count = count + 1;
                }

                html.Append("</div>");
                //html.Append("</tbody></table>");
            }
            catch (Exception e)
            {

            }

            return html.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RestaurantDeal
    {
        int id,restaurantId, cuisineID, qualityRating, priceRating,discount, noOfPersons;
        string startDate, endDate, description, name, daysOfWeek;
        List<DealDetails> objDealDetails;
        List<string> img_path;
        List<Dish> dish_li;

        public RestaurantDeal()
        {
            id = -1;
            restaurantId = -1;
            cuisineID = -1;
            discount = 0;
              startDate = string.Empty;
            endDate = string.Empty;
            description = string.Empty;
            name = string.Empty;
            objDealDetails = new List<DealDetails>();
            img_path = new List<string>();
            dish_li = new List<Dish>();
            noOfPersons = 0;
            daysOfWeek = string.Empty;
        }

        public string DaysOfWeek
        {
            get
            {
                return daysOfWeek;
            }
            set
            {
                daysOfWeek = value;
            }
        }

        public int NoOfPerson
        {
            get
            {
                return noOfPersons;
            }
            set
            {
                noOfPersons = value;
            }
        }

        public int Discount
        {
            get
            {
                return discount;
            }
            set
            {
                discount = value;
            }

        }
        public List<Dish> Dish_li
        {
            get
            {
                return dish_li;
            }
            set
            {
                dish_li = value;
            }
        }

        public int QualityRating
        {
            get
            {
                return qualityRating;
            }
            set
            {
                qualityRating = value;
            }
        }
        public int PriceRating
        {
            get
            {
                return priceRating;
            }
            set
            {
                priceRating = value;
            }
        }
       

        public List<string> Img_path
        {
            get
            {
                return img_path;
            }
            set
            {
                img_path = value;
            }
        }
        public List<DealDetails> SpecificDealDetails
        {
            get
            {
                return objDealDetails;
            }
            set
            {
                objDealDetails = value;
            }
        }

        public int CuisineID
        {
            get
            {
                return cuisineID;
            }
            set
            {
                cuisineID = value;
            }
        }

        public int RestaurantId
        {
            get
            {
                return restaurantId;
            }
            set
            {
                restaurantId = value;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public string StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }
        public string EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }
}

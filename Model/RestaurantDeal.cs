using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RestaurantDeal
    {
        int id,restaurantId, cuisineID,discount;
        string startDate, endDate,description,name; 
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

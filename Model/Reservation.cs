using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Reservation
    {
        int id, userID,noOfPerson;
        Restaurant objRestaurant;
        RestaurantDeal objRestaurantDeal;
        UserInfo customer;
        Status objStatus;
        Country objCountry;
        public Reservation()
        {
            objRestaurant = new Restaurant();
            objRestaurantDeal = new RestaurantDeal();
            customer = new UserInfo();
            objStatus = new Status();
            objCountry = new Country();

        }
        public Country CountryDetais
        {
            get
            {
                return objCountry;
            }
            set
            {
                objCountry = value;
            }
        }
        public Status StatusDetais
        {
            get
            {
                return objStatus;
            }
            set
            {
                objStatus = value;
            }
        }
        public int NoOfPerson
        {
            get
            {
                return noOfPerson;
            }
            set
            {
                noOfPerson = value;
            }
        }
        public int ID
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

        public UserInfo Customer
        {
            get
            {
                return customer;
            }
            set
            {
                customer = value;
            }
        }

        public Restaurant RestaurantDetails
        {
            get
            {
                return objRestaurant;
            }
            set
            {
                objRestaurant = value;
            }
        }

        public RestaurantDeal RestaurantDealDetails
        {
            get
            {
                return objRestaurantDeal;
            }
            set
            {
                objRestaurantDeal = value;
            }
        }

    }
}

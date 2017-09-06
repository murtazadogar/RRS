using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Restaurant
    {
        int id, userID;
        string name, about, address, contactNumber, openingTime, closingTime,
               featuredPhotoLink, facebookLink, googlePlusLink, logo, profileImage, specialConditions,membershipDate;
        Country objcountry;
        City objcity;
        List<RestaurantDeal> objRestaurantDeal;


        public Restaurant()
        {
            id = -1;
            userID = -1;
            name = string.Empty;
            address = string.Empty;
            contactNumber = string.Empty;
            openingTime = string.Empty; 
            closingTime = string.Empty;
            featuredPhotoLink = string.Empty;
            specialConditions = string.Empty;
            facebookLink = string.Empty;
            googlePlusLink = string.Empty;
            logo = string.Empty;
            profileImage = string.Empty;
            membershipDate = string.Empty;
            objcountry = new Country();
            objcity = new City();
            objRestaurantDeal = new List<RestaurantDeal>();


        }

        public List<RestaurantDeal> RestaurantDeal_li
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

        public string MembershipDate
        {
            get
            {
                return membershipDate;
            }
            set
            {
                membershipDate = value;
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
        public string About
        {
            get
            {
                return about;
            }
            set
            {
                about = value;
            }
        }

        public string SpecialConditions
        {
            get
            {
                return specialConditions;
            }
            set
            {
                specialConditions = value;
            }
        }


        public string ContactNumber
        {
            get
            {
                return contactNumber;
            }
            set
            {
                contactNumber = value;
            }
        }



        public string OpeningTime
        {
            get
            {
                return openingTime;
            }
            set
            {
                openingTime = value;
            }
        }
        public string ClosingTime
        {
            get
            {
                return closingTime;
            }
            set
            {
                closingTime = value;
            }
        }
        public string FeaturedPhotoLink
        {
            get
            {
                return featuredPhotoLink;
            }
            set
            {
                featuredPhotoLink = value;
            }
        }
        public string FacebookLink
        {
            get
            {
                return FacebookLink;
            }
            set
            {
                facebookLink = value;
            }
        }
        public string GooglePlusLink
        {
            get
            {
                return googlePlusLink;
            }
            set
            {
                googlePlusLink = value;
            }
        }

        public string Logo
        {
            get
            {
                return logo;
            }
            set
            {
                logo = value;
            }
        }

        public string ProfileImage
        {
            get
            {
                return profileImage;
            }
            set
            {
                profileImage = value;
            }
        }

        public int UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
            }
        }
        public Country CountryDetails
        {
            get
            {
                return objcountry;
            }
            set
            {
                objcountry = value;
            }
        }
        public City CityDetails
        {
            get
            {
                return objcity;
            }
            set
            {
                objcity = value;
            }
        }
    }
}

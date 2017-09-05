using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserInfo
    {
        /// <summary>
        /// Declare variables for Get/Set Properties
        /// </summary>
        private Int64 id;
        private string userName, email, password;
        private bool active;
        private DateTime inActiveDate, createdDate, updatedDate;
        private String userType, lastLogin;
        private int userTypeId;
        private Restaurant objRestaurant;


        public UserInfo()
        {
            ///Set Default value for all variables
            id = -1;
            userName = string.Empty;
            email = string.Empty;
            userType = string.Empty;
            lastLogin = string.Empty;
            active = true;
            objRestaurant = new Restaurant();
        }
        public String LastLogin
        {
            get
            {
                return lastLogin;
            }
            set
            {
                lastLogin = value;
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


        /// <summary>
        ///  Used for Get/Set User Type ID
        /// </summary>
        public int UserTypeID
        {
            get
            {
                return userTypeId;
            }
            set
            {
                userTypeId = value;
            }
        }

        /// <summary>
        ///  Used for Get/Set User Type
        /// </summary>
        public String UserType
        {
            get
            {
                return userType;
            }
            set
            {
                userType = value;
            }
        }

        /// <summary>
        ///  Used for Get/Set User ID
        /// </summary>
        public Int64 Id
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

        /// <summary>
        ///  Used for Get/Set User Email Address
        /// </summary>
        public String Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }  

        /// <summary>
        ///  Used for Get/Set User Name
        /// </summary>
        public string Username
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

    
        /// <summary>
        ///  Used for Get/Set User Password
        /// </summary>
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        /// <summary>
        ///  Used for Check wather Record is Active or not
        /// </summary>
        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }

        /// <summary>
        ///  Used for Get/Set Inactive Record Date
        /// </summary>
        public DateTime InActiveDate
        {
            get
            {
                return inActiveDate;
            }
            set
            {
                inActiveDate = value;
            }
        }

        /// <summary>
        ///  Used for Get/Set Record Created Date
        /// </summary>
        public DateTime CreatedDate
        {
            get
            {
                return createdDate;
            }
            set
            {
                createdDate = value;
            }
        }

        /// <summary>
        ///  Used for Get/Set Updated Record Date
        /// </summary>
        public DateTime UpdatedDate
        {
            get
            {
                return updatedDate;
            }
            set
            {
                updatedDate = value;
            }
        }
    }
}

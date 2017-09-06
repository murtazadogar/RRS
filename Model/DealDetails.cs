using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class DealDetails
    {
        string startTime, endTime;
        int discount,noOfPersons;
      

        public DealDetails()
        {
            startTime = string.Empty;
            endTime = string.Empty;
            discount = 0;
            noOfPersons = 0;


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

        public string StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }
        public string EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
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

    }
}

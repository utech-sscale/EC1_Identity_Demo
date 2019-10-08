using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EC1_Database_Demo_1.App_Code
{
    public class Product
    {
        public int productID { get; set; }

        public string productName { get; set; }

        public string productDescription { get; set; } 

        public float unitPrice { get; set; }

        public string imageURL { get; set; }

        public int CategoryID { get; set; }

    }
}
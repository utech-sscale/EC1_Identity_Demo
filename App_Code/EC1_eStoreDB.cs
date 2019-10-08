using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EC1_Database_Demo_1.App_Code
{
    [DataObject(true)]
    public class EC1_eStoreDB
    {

        static string constring = System.Configuration.ConfigurationManager.ConnectionStrings["EC1_eStoreDB"].ConnectionString;

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IEnumerable GetAllCategories()
        {
            //STEP 1: create connection
            SqlConnection conn = new SqlConnection(constring);

            //STEP 2: create SqlCommand
            string sql = "SELECT CategoryID, CategoryDescription FROM ProductCategory";
            SqlCommand cmd = new SqlCommand(sql, conn);

            //STEP 3: Open Connection and execute command
            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            return dr;
        }



        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Product> GetProducts()
        {

            List<Product> productList = new List<Product>();

            //STEP 1: create connection
            SqlConnection conn = new SqlConnection(constring);

            //STEP 2: create SqlCommand and Parameter
            string sql = "SELECT productID, productName, productDescription, unitPrice, imageURL FROM Product";
            SqlCommand cmd = new SqlCommand(sql, conn);
            //cmd.Parameters.Add("CategoryID", ProductCategoryID);

            //STEP 3: Open Connection and execute command
            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            Product prod;

            while(dr.Read())
            {
                prod = new Product();
                prod.productID = Convert.ToInt32(dr["productID"].ToString());
                prod.productName = dr["productName"].ToString();
                prod.productDescription = dr["productDescription"].ToString();
                prod.imageURL = dr["imageURL"].ToString();
                prod.unitPrice = Convert.ToSingle(dr["unitPrice"].ToString());
                productList.Add(prod);
            }

            return productList;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Product> GetProductList()
        {

            List<Product> productList = new List<Product>();

            //STEP 1: create connection
            SqlConnection conn = new SqlConnection(constring);

            //STEP 2: create SqlCommand and Parameter
            string sql = "SELECT productID, productName, productDescription, unitPrice, imageURL FROM Product";
            SqlCommand cmd = new SqlCommand(sql, conn);
            //cmd.Parameters.Add("CategoryID", ProductCategoryID);

            //STEP 3: Open Connection and execute command
            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            Product prod;

            while (dr.Read())
            {
                prod = new Product();
                prod.productID = Convert.ToInt32(dr["productID"].ToString());
                prod.productName = dr["productName"].ToString();
                prod.productDescription = dr["productDescription"].ToString();
                prod.imageURL = dr["imageURL"].ToString();
                prod.unitPrice = Convert.ToSingle(dr["unitPrice"].ToString());
                productList.Add(prod);
            }

            return productList;
        }


        //Insert method for Products

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void AddProduct(string productName , string productDescription, float unitPrice, string imageURL, int CategoryID)
        {

             //STEP 1: create connection
            SqlConnection conn = new SqlConnection(constring);

            //STEP 2: create SqlCommand and Parameter
            string sql = "INSERT INTO Product ( productName, productDescription, unitPrice, imageURL, CategoryID) values (@productName, @productDescription, @unitPrice, @imageURL, @CategoryID)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@productDescription", productDescription);
            cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmd.Parameters.AddWithValue("@imageURL", imageURL);
            cmd.Parameters.AddWithValue("@CategoryID", CategoryID);

            //STEP 3: Open Connection and execute command
            conn.Open();

            cmd.ExecuteNonQuery();

        }



        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateProduct(string productName, string productDescription, float unitPrice, int productID, string imageURL, int CategoryID, int original_productID)
        {

            //STEP 1: create connection
            SqlConnection conn = new SqlConnection(constring);

            //STEP 2: create SqlCommand and Parameter
            string sql = "UPDATE Product " +
                            "SET productName = @productName, " +
                                "productDescription = @productDescription, " +
                                "unitPrice = @unitPrice " +
                                "WHERE productID = @productID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("productName", productName);
            cmd.Parameters.AddWithValue("productDescription", productDescription);
            cmd.Parameters.AddWithValue("unitPrice", unitPrice);
            cmd.Parameters.AddWithValue("productID", original_productID);

            //STEP 3: Open Connection and execute command
            conn.Open();

            cmd.ExecuteNonQuery();

        }


        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteProduct( int productID, int original_productID)
        {

            //STEP 1: create connection
            SqlConnection conn = new SqlConnection(constring);

            //STEP 2: create SqlCommand and Parameter
            string sql = "DELETE  Product " +
        
                                "WHERE productID = @productID";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("productID", original_productID);

            //STEP 3: Open Connection and execute command
            conn.Open();

            cmd.ExecuteNonQuery();

        }

    }
}
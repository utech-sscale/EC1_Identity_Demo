using EC1_Database_Demo_1.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EC1_Database_Demo_1
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            // We are checking against the "ADD"

            if (e.CommandName == "Insert")

            {
                ObjectDataSource1.Insert();
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*List<Product> productList = EC1_eStoreDB.GetProductList();

            var products = from prod in productList
                           select new Product
                           {
                               productID = prod.productID,
                               productName = prod.productName,
                               productDescription = prod.productDescription,
                               imageURL = prod.imageURL,
                               CategoryID = prod.CategoryID
                           };

            LinqDataSource1.ContextTypeName = "EC1_eStoreDB";
            LinqDataSource1.TableName = "GetProductList";

            GridView1.DataSource = LinqDataSource1;
            */

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LINQ demo here
        }

        protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e) 
        {
            TextBox txtProductName = (TextBox)GridView1.FooterRow.FindControl("txtProductName");
            TextBox txtProductDescription = (TextBox)GridView1.FooterRow.FindControl("txtProductDescription");
            TextBox txtUnitPrice = (TextBox)GridView1.FooterRow.FindControl("txtUnitPrice");
            TextBox txtImageURL = (TextBox)GridView1.FooterRow.FindControl("txtImageURL");
            TextBox txtCategoryID = (TextBox)GridView1.FooterRow.FindControl("txtCategoryID");

            e.InputParameters["productName"] = txtProductName.Text;
            e.InputParameters["productDescription"] = txtProductDescription.Text;
            e.InputParameters["unitPrice"] = Convert.ToSingle(txtUnitPrice.Text);
            e.InputParameters["imageURL"] = txtImageURL.Text;
            e.InputParameters["CategoryID"] = Convert.ToInt32(txtCategoryID.Text);

        }
    }
}
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

            // We are checking for the command name Insert, the attribute we set for the ADD button

            if (e.CommandName == "Insert")

            {
                ObjectDataSource1.Insert();
            }

        }


        protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e) 
        {

        //retrieve textbox object from GridView Footer Row
        TextBox txtProductName = (TextBox)GridView1.FooterRow.FindControl("txtProductName");
        TextBox txtProductDescription = (TextBox)GridView1.FooterRow.FindControl("txtProductDescription");
        TextBox txtUnitPrice = (TextBox)GridView1.FooterRow.FindControl("txtUnitPrice");
        TextBox txtImageURL = (TextBox)GridView1.FooterRow.FindControl("txtImageURL");
        TextBox txtCategoryID = (TextBox)GridView1.FooterRow.FindControl("txtCategoryID");


        //add textBox values to ObjectDataSource parameters
        e.InputParameters["productName"] = txtProductName.Text;
        e.InputParameters["productDescription"] = txtProductDescription.Text;
        e.InputParameters["unitPrice"] = Convert.ToSingle(txtUnitPrice.Text);
        e.InputParameters["imageURL"] = txtImageURL.Text;
        e.InputParameters["CategoryID"] = Convert.ToInt32(txtCategoryID.Text);
            //end
        }
    }
}
 
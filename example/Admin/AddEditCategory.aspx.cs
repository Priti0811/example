using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using example.Cart;

namespace example.Admin
{
    public partial class AddEditCategory : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ShoppingCart k = new ShoppingCart
            {
               CategoryName = txtCategoryName.Text
            };

            

           k.AddNewCategory();
            txtCategoryName.Text = string.Empty;
            Response.Redirect("~/Admin/AddNewProducts.aspx");
        }
    }
  }


    



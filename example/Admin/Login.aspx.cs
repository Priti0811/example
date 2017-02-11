using System;
using System.Web.Configuration;


namespace example.Admin

{
    public partial class Login : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Loginid = WebConfigurationManager.AppSettings["AdminLoginid"];
            string Password = WebConfigurationManager.AppSettings["AdminPassword"];

            if (TextBox1.Text == Loginid && TextBox2.Text == Password)
                {
                Session["exampleAdmin"] = "exampleAdmin";
                Response.Redirect("~/Admin/AddNewProducts.aspx");
                }
            else
            {
                lblAlert.Text = "Incorrect Loginid/Password";
            }
        }
    }
}
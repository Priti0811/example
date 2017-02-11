using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using example.Cart;

namespace example.Admin

{
    public partial class AddNewProducts : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCategories();
                AddSubmitEvent();
                
                if(Request.QueryString["alert"] == "success")
                {
                   Response.Write("<script>alert(Record Saved Successfully.');</script>");
                }
            }
        }

        private void AddSubmitEvent()
       {
            UpdatePanel updatePanel = Page.FindControl("AdminUpdatePanel") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = Button1.UniqueID;
            

         //  updatePanel.Triggers.Add(trigger);
      }

        private void GetCategories()
        {
            ShoppingCart k = new ShoppingCart();
            DataTable dt = k.GetCategories();

            if (dt.Rows.Count > 0)
            {
               ddlCategory.DataValueField = "CategoryID";
               ddlCategory.DataTextField = "CategoryName";
               ddlCategory.DataSource = dt;
               ddlCategory.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(uploadProductPhoto.PostedFile != null)
            {
                 SaveProductPhoto();

                ShoppingCart k = new ShoppingCart()
                {
                    ProductName = TextBox1.Text,
                    ImageUrl = "~/ProductImage/" + uploadProductPhoto.FileName,
                    ProductPrice = TextBox2.Text,
                    
                    CategoryID = Convert.ToInt32(ddlCategory.SelectedValue),
                    TotalProducts = Convert.ToInt32(TextBox3.Text)
                };

                k.AddNewProducts();
                ClearText();
                Response.Redirect("~/Admin/AddNewProducts.aspx?alert=success");
            }
            else
            {
                Response.Write("<script>alert('Upload Product Photo');</script>");

           }
        }

        private void SaveProductPhoto()
        {
            if (uploadProductPhoto.PostedFile != null)
            {
               // HttpPostedFile PostedFile = uploadProductPhoto.PostedFile;
               // string filename = Path.GetFileName(PostedFile.FileName);
               // string fileExt = Path.GetExtension(filename);
               // int filesize = PostedFile.ContentLength;

                string filename = uploadProductPhoto.PostedFile.ToString();
                string fileExt = System.IO.Path.GetExtension(uploadProductPhoto.FileName);

                if (filename.Length > 96)
                {
                    //Alert.Show("Upload Product Photo");
                }
                else if (fileExt != ".jpeg" && fileExt != ".jpg" && fileExt != ".png" && fileExt != ".bmp")
                {
                    //Alert.Show("Upload Product Photo");
                }
                else if (uploadProductPhoto.PostedFile.ContentLength > 400000000)
                {
                    //Alert.Show("Upload Product Photo");
                }
                else
                {
                    uploadProductPhoto.SaveAs(Server.MapPath("~/ProductImage/" + filename));
                }
            }
            }

        private void ClearText()
        {
               
       
            uploadProductPhoto = null;
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
      
    }

        
    }
}
using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.IO;
using example.Cart;



namespace example

{
    public partial class Default : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                // lblCategoryName.Text = "Grocery Product";
                lblCategoryName.Text = "Grocery Product";
                GetCategory();
                GetProducts(0); // get all products
            }
            lblAvailableStockAlert.Text = string.Empty;
        }
        private void GetCategory()
        {
            ShoppingCart k = new ShoppingCart();
            dlCategories.DataSource = null;
            dlCategories.DataSource = k.GetCategories();
            dlCategories.DataBind();
        }
        private void GetProducts(int CategoryID)
        {
            ShoppingCart k = new ShoppingCart();
            {

                CategoryID = CategoryID;

            };

            dlProducts.DataSource = null;
            dlProducts.DataSource = k.GetAllProduct();
            dlProducts.DataBind();

        }


        protected void lbtnCategory_Click(object sender, EventArgs e)
        {
            pnlMyCart.Visible = false;
            pnlProducts.Visible = true;
           int CategoryID = Convert.ToInt16((((LinkButton)sender).CommandArgument));
            GetProducts(CategoryID);
            HighlightCartProducts();
        }

        protected void btnAddToCart_click(object sender, EventArgs e)
        {
            string ProductID = Convert.ToInt16((((Button)sender).CommandArgument)).ToString();
            string ProductQuantity = "1";

            DataListItem currentItem = (sender as Button).NamingContainer as DataListItem;
            Label lblAvailableStock = currentItem.FindControl("lblAvailableStock") as Label;

            if (Session["MyCart"] != null)
            {
                DataTable dt = (DataTable)Session["MyCart"];
                var checkProduct = dt.AsEnumerable().Where(r => r.Field<string>("ProductID") == ProductID);
                if (checkProduct.Count() == 0)
                {
                    string query = "Select * from Products where ProductID = " + ProductID + "";
                    DataTable dtProducts = GetData(query);

                    DataRow dr = dt.NewRow();
                    dr["ProductID"] = ProductID;
                    dr["ProductName"] = Convert.ToString(dtProducts.Rows[0]["ProductName"]);
                    dr["ProductPrice"] = Convert.ToString(dtProducts.Rows[0]["ProductPrice"]);
                    dr["ImageUrl"] = Convert.ToString(dtProducts.Rows[0]["ImageUrl"]);
                    dr["ProductQuantity"] = ProductQuantity;
                    dr["AvailableStock"] = lblAvailableStock.Text;

                    dt.Rows.Add(dr);

                    Session["MyCart"] = dt;
                    btnShoppingCart.Text = dt.Rows.Count.ToString();

                }
            }
            else
            {
                string query = "select * from Products where ProductID = " + ProductID + "";
                DataTable dtProducts = GetData(query);

                DataTable dt = new DataTable();

                dt.Columns.Add("ProductID", typeof(String));
                dt.Columns.Add("ProductName", typeof(String));
                dt.Columns.Add("ProductPrice", typeof(String));
                dt.Columns.Add("ImageUrl", typeof(String));
                dt.Columns.Add("ProductQuantity", typeof(String));
                dt.Columns.Add("AvailableStock", typeof(String));

                DataRow dr = dt.NewRow();
                dr["ProductID"] = ProductID;
                dr["ProductName"] = Convert.ToString(dtProducts.Rows[0]["ProductName"]);
                dr["ProductPrice"] = Convert.ToString(dtProducts.Rows[0]["ProductPrice"]);
                dr["ImageUrl"] = Convert.ToString(dtProducts.Rows[0]["ImageUrl"]);
                dr["ProductQuantity"] = ProductQuantity;
                dr["AvailableStock"] = lblAvailableStock.Text;

                dt.Rows.Add(dr);

                Session["MyCart"] = dt;
                btnShoppingCart.Text = dt.Rows.Count.ToString();

            }

            HighlightCartProducts();


        }

        private void HighlightCartProducts()
        {

            if (Session["MyCart"] != null)
            {
                DataTable dtProductsAddToCart = (DataTable)Session["MyCart"];
                if (dtProductsAddToCart.Rows.Count > 0)
                {
                    foreach (DataListItem item in dlProducts.Items)
                    {
                        HiddenField hfProductID = item.FindControl("hfProductID") as HiddenField;
                        if (dtProductsAddToCart.AsEnumerable().Any(row => hfProductID.Value == row.Field<String>("ProductID")))
                        {
                            Button btnAddToCart = item.FindControl("btnAddToCart") as Button;
                            btnAddToCart.BackColor = System.Drawing.Color.Green;
                            btnAddToCart.Text = "Added To Cart";
                        }
                    }
                }
            }
        }

        private DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            string conn = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection con = new SqlConnection(conn);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);

            con.Close();
            return dt;
        }

        protected void btnShoppingCart_Click(object sender, EventArgs e)
        {
            GetMyCart();
            lblCategoryName.Text = "Products in Shopping Cart";
            lblProducts.Text = "SaveCustomerProducts";
          //  dlCartProducts.Visible = true;
        }



        protected void txtProductQuantity_TextChanged(object sender, EventArgs e)
        {
            TextBox txtQuantity = (sender as TextBox);

            DataListItem currentItem = (sender as TextBox).NamingContainer as DataListItem;
            HiddenField ProductID = currentItem.FindControl("hfProductID") as HiddenField;
            Label lblAvailableStock = currentItem.FindControl("lblAvailableStock") as Label;

            if (txtQuantity.Text == string.Empty || txtQuantity.Text == "0" || txtQuantity.Text == "1")

            {
                txtQuantity.Text = "1";
            }
            else
            {
                if (Session["MyCart"] != null)
                {
                    if (Convert.ToInt32(txtQuantity.Text) <= Convert.ToInt32(lblAvailableStock.Text))
                    {
                        DataTable dt = (DataTable)Session["MyCart"];
                        DataRow[] rows = dt.Select("ProductID='" + ProductID.Value + "'");
                        int index = dt.Rows.IndexOf(rows[0]);
                        dt.Rows[index]["ProductQuantity"] = txtQuantity.Text;

                        Session["MyCart"] = dt;
                    }
                    else
                    {
                        lblAvailableStock.Text = "Alert: product should not be more than stock!!";
                        txtQuantity.Text = "1";
                    }
                }
            }
            UpdateTotalBill();
        }
        private void UpdateTotalBill()
        {
            long TotalProducts = 0;
            long TotalPrice = 0;

            foreach (DataListItem item in dlCartProducts.Items)
            {
                Label PriceLabel = item.FindControl("lblPrice") as Label;
                TextBox ProductQuantity = item.FindControl("txtProductQuantity") as TextBox;
                long ProductPrice = Convert.ToInt64(PriceLabel.Text) * Convert.ToInt64(ProductQuantity.Text);
                TotalProducts = TotalProducts + Convert.ToInt32(ProductQuantity.Text);
                TotalPrice = TotalPrice + ProductPrice;
                
            }
            txtTotalProducts.Text = Convert.ToString(TotalProducts);
            txtTotalPrice.Text = Convert.ToString(TotalPrice);
            
        }

        protected void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            string ProductID = Convert.ToInt16((((Button)sender).CommandArgument)).ToString();
            if (Session["MyCart"] != null)
            {
                DataTable dt = (DataTable)Session["MyCart"];
                DataRow drr = dt.Select("ProductID=" + ProductID + " ").FirstOrDefault();

                if (drr != null)
                {
                    dt.Rows.Remove(drr);

                    Session["MyCart"] = dt;
                }
                GetMyCart();
            }
        }



        private void GetMyCart()
        {
            DataTable dtProducts;
            if (Session["MyCart"] != null)
            {
                dtProducts = (DataTable)Session["MyCart"];
            }
            else
            {
                dtProducts = new DataTable();
            }

            if (dtProducts.Rows.Count > 0)
            {
                txtTotalProducts.Text = dtProducts.Rows.Count.ToString();
                btnShoppingCart.Text = dtProducts.Rows.Count.ToString();
                dlCartProducts.DataSource = dtProducts;
                dlCartProducts.DataBind();
                UpdateTotalBill();

                pnlCheckout.Visible = true;
                pnlMyCart.Visible = true;
                pnlCategories.Visible = false;
                pnlProducts.Visible = false;
                pnlEmptyCart.Visible = false;
            }
            else
            {
                pnlEmptyCart.Visible = true;
                pnlCheckout.Visible = false;
                pnlMyCart.Visible = false;
                pnlCategories.Visible = false;
                pnlProducts.Visible = false;

              //  dlCartProducts.Visible = true;
                dlCartProducts.DataSource = null;
                dlCartProducts.DataBind();
                txtTotalProducts.Text = "0";
                txtTotalPrice.Text = "0";
                btnShoppingCart.Text = "0";
            }
        }

        protected void dlCartProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //    protected void Button_Click(object sender, EventArgs e)
        //    {
        //        DataTable dt;

        //  if (Session["MyCart"] != null)
        //     {
        //         dt = (DataTable)Session["MyCart"];

        //        ShoppingCart k = new ShoppingCart()
        //        {
        //            TotalPrice = Convert.ToInt32(txtTotalPrice.Text),
        //            TotalProducts = Convert.ToInt32(txtTotalProducts.Text),

        // };

        // k.SaveCustomerProducts();

        // for (int i = 0; i < dt.Rows.Count; i++)
        //   {
        //ShoppingCart save = new ShoppingCart()
        //{
        //  ID = Convert.ToInt32(dtResult.Rows[0][0]);
        //      ProductID = Convert.ToInt32(dt.Rows[i]["ProductsID"]),
        //        TotalProducts = Convert.ToInt32(dt.Rows[i]["ProductQuantity"])

        //      };

        //        save.SaveCustomerProducts();
        //      }



        //        Session.Clear();
        //         GetMyCart();
        //     }
        //  }


    }
}

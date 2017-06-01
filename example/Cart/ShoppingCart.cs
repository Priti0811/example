using System.Data.SqlClient;
using System.Data;

namespace example.Cart
{
    public class ShoppingCart : System.Web.UI.Page
     
    {
        public string CategoryName;
        public int CategoryID;
   

        public int ProductID;

        public string ProductName;
        public string ImageUrl;
        public string ProductPrice;
        public int ProductQuantity;

        public int TotalProducts;
        public int TotalPrice;
        public int StockType;
       


        public void AddNewCategory()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParamater("@CategoryName", CategoryName, System.Data.SqlDbType.VarChar, 200);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_AddNewCategory", parameters);

        }

        public void AddNewProducts()
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = DataLayer.DataAccess.AddParamater("@ProductName", ProductName, System.Data.SqlDbType.VarChar, 300);
            parameters[1] = DataLayer.DataAccess.AddParamater("@ImageUrl", ImageUrl, System.Data.SqlDbType.VarChar, 500);
            parameters[2] = DataLayer.DataAccess.AddParamater("@ProductPrice", ProductPrice, System.Data.SqlDbType.VarChar, 300);
            parameters[3] = DataLayer.DataAccess.AddParamater("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 100);
            parameters[4] = DataLayer.DataAccess.AddParamater("@ProductQuantity", TotalProducts, System.Data.SqlDbType.Int, 100);

            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_AddNewProducts", parameters);
        }

        public DataTable GetAllProduct()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParamater("@CategoryID", CategoryID, System.Data.SqlDbType.Int, 100);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetAllProduct", parameters);
            return dt;
        }



        public DataTable GetCategories()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetAllCategories", parameters);
            return dt;
        }

    //    internal void SaveCustomerProducts()
    //    {
     //       SqlParameter[] parameters = new SqlParameter[4];
           // parameters[0] = DataLayer.DataAccess.AddParamater("@ID", ID, System.Data.SqlDbType.Int, 100);
    //        parameters[1] = DataLayer.DataAccess.AddParamater("@ProductID", ProductID, System.Data.SqlDbType.Int, 100);
      //      parameters[2] = DataLayer.DataAccess.AddParamater("@TotalProducts", TotalProducts, System.Data.SqlDbType.Int, 100);
            //  parameters[3] = DataLayer.DataAccess.AddParamater("TotalPrice", TotalPrice, System.Data.SqlDbType.Int, 100);
     //       DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_Customer", parameters);
    //    }

    }
}


using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web.UI;

namespace example.DataLayer

{
    public class DataAccess : System.Web.UI.Page
     {
        public static string connectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString.ToString();
            }
        }


        public static SqlParameter AddParamater(String ParameterName, Object value, SqlDbType DbType, int size)
        {
            SqlParameter Param = new SqlParameter();
            Param.ParameterName = ParameterName;
            Param.Value = value.ToString();
            Param.SqlDbType = DbType;
            Param.Size = size;
            Param.Direction = ParameterDirection.Input;
            return Param;
        }

        public static DataTable ExecuteDTByProcedure(String ProcedureName, SqlParameter[] Params)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = ProcedureName;
            cmd.Parameters.AddRange(Params);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            try
            {
                adpt.Fill(dTable);
            }
            catch(Exception)
            {

            }


            finally
            {
              
                adpt.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
            }
            return dTable;
        }
    }

}
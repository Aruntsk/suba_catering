using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace suba_catering.Models
{
    public class CommonFn
    {
        public class CommonFnx 
        { 
            SqlConnection con= new SqlConnection(ConfigurationManager.ConnectionStrings["cateringcs"].ConnectionString);
            public void Query(string Query)
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                  SqlCommand cmd = new SqlCommand(Query, con);
                 cmd.ExecuteNonQuery();
                 con.Close();
            }
            public DataTable fetch(string query)
            {   
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                 SqlCommand cmd= new SqlCommand(query, con);
                 SqlDataAdapter sda= new SqlDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 sda.Fill(dt);
                 return dt;
            }
        }

    }
}
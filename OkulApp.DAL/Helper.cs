using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulApp.DAL
{
    public class Helper:IDisposable
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cstr"].ConnectionString);
        SqlCommand cmd=null;

        public void Dispose()
        {
            if (cn!=null&&cmd!=null)
            {
               cn.Dispose();
                cmd.Dispose();
            }
            
        }

        public int ExecuteNonQuery(string cmdText, SqlParameter[] p = null)
        {

            cmd = new SqlCommand(cmdText, cn);
                
                    if (p != null)
                    {
                        cmd.Parameters.AddRange(p);
                    }
                    cn.Open();
                    return cmd.ExecuteNonQuery(); 
            
        }
        public SqlDataReader ExecuteReader(string cmdtext, SqlParameter[] p = null)
        {
            
             cmd = new SqlCommand(cmdtext, cn);
            if (p!=null)
            {
                cmd.Parameters.AddRange(p);
            }
            cn.Open();
            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

        }

        public DataTable MyDataTable(string cmdtext,SqlParameter[] p=null)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmdtext, cn);
                if (p != null)
                {
                    da.SelectCommand.Parameters.AddRange(p);
                }
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

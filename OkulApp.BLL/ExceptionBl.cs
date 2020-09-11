using OkulApp.DAL;
using OkulApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulApp.BLL
{
   public class ExceptionBl
    {

        public bool ExceptionEkle(ExceptionModel ex)
        {

            Helper hlp = new Helper();
            SqlParameter[] p =
                {

                 new SqlParameter("@Message",ex.Message),
                 new SqlParameter("@Tarih",ex.Tarih),
                 new SqlParameter("@StackTrace",ex.StackTrace)

            };
         
            return hlp.ExecuteNonQuery("Insert into tblExceptions Values(@Message,@Tarih,@StackTrace)", p) > 0;

        }

        
    }
}

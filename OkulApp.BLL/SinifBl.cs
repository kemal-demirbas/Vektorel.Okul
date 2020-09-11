using OkulApp.DAL;
using OkulApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulApp.BLL
{
   public class SinifBl:IDisposable
    {
        Helper hlp = new Helper();

        public void Dispose()
        {
            ((IDisposable)hlp).Dispose();
        }

        public bool SinifEkle(Sinif sinif)
        {

          

            SqlParameter[] p = {

            new SqlParameter("@Sinifad",sinif.Sinifad),
            new SqlParameter("@Kontenjan",sinif.Kontenjan),

            };

            return hlp.ExecuteNonQuery("Insert into tblSiniflar Values(@Sinifad,@Kontenjan)", p)>0;

        }
        public List<Sinif> SinifListesi()
        {
            List<Sinif> lst = null;
           
            SqlDataReader dr = hlp.ExecuteReader("Select SinifAd,SinifId from tblSiniflar");

            if (dr.HasRows)
            {
                lst = new List<Sinif>();
                while (dr.Read())
                {
                    lst.Add(new Sinif { Sinifad = dr["SinifAd"].ToString(), Sinifid = Convert.ToInt32(dr["SinifId"]) });
                }
                dr.Close();
            }
            return lst;
            
        }

        public DataTable SinifTablosu() => hlp.MyDataTable("Select SinifId,SinifAd,Kontenjan from tblSiniflar");

        public bool SinifGuncelle(Sinif sinif)
        {
            SqlParameter[] p = {

            new SqlParameter("@Sinifad",sinif.Sinifad),
            new SqlParameter("@Kontenjan",sinif.Kontenjan),
            new SqlParameter("@Sinifid",sinif.Sinifid)
            };

            return hlp.ExecuteNonQuery("Update tblSiniflar Set SinifAd=@SinifAd,Kontenjan=@Kontenjan where SinifId=@Sinifid", p) > 0;

        }


    }
}

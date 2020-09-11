using OkulApp.DAL;
using OkulApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulApp.BLL
{
    public class OgrenciBl:IDisposable
    {
        Helper hlp = new Helper();

        public void Dispose()
        {
            ((IDisposable)hlp).Dispose();
        }

        public bool OgrenciEkle(Ogrenci ogr)
        {
            //using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cstr"].ConnectionString))
            //{

                //SqlCommand cmd = new SqlCommand("Insert into tblOgrenciler values ('" + txtAd.Text + "','" + txtSoyad.Text + "'," + txtNumara.Text + ")", cn);
                //using (SqlCommand cmd = new SqlCommand("Insert into tblOgrenciler values (@Ad,@Soyad,@Numara)", cn))
                //{
                //    SqlParameter[] p = { new SqlParameter("@Ad", ogr.Ad), new SqlParameter("@Soyad", ogr.Soyad), new SqlParameter("@Numara", ogr.Numara) };
                //    cmd.Parameters.AddRange(p);

                //    cn.Open();
                //    int sayi = cmd.ExecuteNonQuery();
                //    cn.Close();
                //    return sayi > 0;

                //}

                
                SqlParameter[] p ={
                    new SqlParameter("@Ad", ogr.Ad),
                    new SqlParameter("@Soyad", ogr.Soyad),
                    new SqlParameter("@Numara", ogr.Numara),
                    new SqlParameter("@SinifId",ogr.SinifId)
                };
                
                return hlp.ExecuteNonQuery("Insert into tblOgrenciler Values(@Ad,@Soyad,@Numara,@SinifId)", p) > 0;


                //cmd.Parameters.Add(p);
                //cmd.Parameters.Add(p1);
                //cmd.Parameters.Add(p2);


                //finally
                //{

                //    if (cn != null && cn.State != ConnectionState.Closed)
                //    {
                //        cn.Close();
                //    }
            //    //} 
            //}


        }
    }
}

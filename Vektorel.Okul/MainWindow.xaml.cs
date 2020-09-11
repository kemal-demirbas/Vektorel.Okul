using OkulApp.BLL;
using OkulApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input; 
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vektorel.Okul
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OgrenciBl ob = new OgrenciBl();
            ExceptionBl bl = new ExceptionBl();
            
            try
            {
                MessageBox.Show(ob.OgrenciEkle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = Convert.ToInt32(txtNumara.Text.Trim()), SinifId=(int)cmbSiniflar.SelectedValue}) ? "Ekleme Başraılı" : "Ekleme Başarısız");

            }
           

            catch (SqlException ex)
            {
                bl.ExceptionEkle(new ExceptionModel { Message = ex.Message, Tarih = DateTime.Now, StackTrace = ex.StackTrace });

                switch (ex.Number)
                {
                    case 2601:
                        MessageBox.Show("bu numara daha önce eklenmiş");
                        break;
                    default:
                        throw;
                        MessageBox.Show("veritabanı hatası");
                        break;
                }

            }

            catch (Exception ex)
            {
                bl.ExceptionEkle(new ExceptionModel { Message = ex.Message, Tarih = DateTime.Now, StackTrace = ex.StackTrace });


                MessageBox.Show("bilinmayen hata");
            }
            ob.Dispose();

        }

        void SinifListesi()
        {
            //List<Sinif> lst = new List<Sinif>();
            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cstr"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("Select SinifId,SinifAd from tblSiniflar", cn);
            //cn.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    lst.Add(new Sinif { Sinifad = dr["SinifAd"].ToString(), Sinifid = Convert.ToInt32(dr["SinifId"]) });


            //}
            //dr.Close();
            //cn.Close();
            //lst.Capacity = lst.Count;
            SinifBl sb = new SinifBl();
            List<Sinif> lst=  sb.SinifListesi();

            if (lst!=null)
            {
                cmbSiniflar.DataContext = lst;
            }
            else
            {
                MessageBox.Show("Sinif Bulunamadı");
            }
            sb.Dispose();
            


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SinifListesi();
        }
    }
}

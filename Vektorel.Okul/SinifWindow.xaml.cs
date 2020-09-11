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
using System.Windows.Shapes;

namespace Vektorel.Okul
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        SinifBl sb = new SinifBl();
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            


            MessageBox.Show(sb.SinifEkle(new Sinif { Sinifad = txtSinifad.Text.ToUpper().Trim(), Kontenjan = Convert.ToInt32(txtKontenjan.Text.Trim()) }) ? "ekleme başarılı" : "başarısızz");

        }

        //void SinifTablosu()
        //{
        //    SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cstr"].ConnectionString);
        //    SqlDataAdapter da = new SqlDataAdapter("Select SinifId,SinifAd,Kontenjan from tblSiniflar", cn);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    grdSiniflar.DataContext = dt;
        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            grdSiniflar.DataContext = sb.SinifTablosu();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SinifBl sb = new SinifBl();
            foreach(DataRow item in ((DataTable)grdSiniflar.DataContext).Rows)
            {
                switch (item.RowState)
                {
                    
                   
                    case DataRowState.Added:
                        sb.SinifEkle(new Sinif { Sinifad = item[1].ToString(), Kontenjan = Convert.ToInt32(item[2]) });
                        break;
                    case DataRowState.Deleted:
                        break;
                    case DataRowState.Modified:
                        sb.SinifGuncelle(new Sinif { Sinifad = item[1].ToString(), Kontenjan = Convert.ToInt32(item[2]),Sinifid=Convert.ToInt32( item[0] )});
                        break;
                    default:
                        break;
                }
                sb.Dispose();



            }


        }
    }
}

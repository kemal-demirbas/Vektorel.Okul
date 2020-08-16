using System;
using System.Collections.Generic;
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
            SqlConnection cn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=OkulDB;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("Insert into tblOgrenciler values ('" + txtAd.Text + "','" + txtSoyad.Text + "'," + txtNumara.Text + ")", cn);
            cn.Open();
           int sayi= cmd.ExecuteNonQuery();
            if (sayi>0)
            {
                MessageBox.Show("Ekleme başarılı");
            }
            cn.Close();

        }
    }
}

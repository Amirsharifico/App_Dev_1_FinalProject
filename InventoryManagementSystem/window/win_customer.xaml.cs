using DataModelLayer;
using System;
using System.Collections.Generic;
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

namespace IMSBeta.window
{
    /// <summary>
    /// Interaction logic for win_customer.xaml
    /// </summary>
    public partial class win_customer : Window
    {
        public win_customer()
        {
            InitializeComponent();
        }
        //-- Db instantiation
        inventorydbEntities database = new inventorydbEntities();

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {// LINQ syntax: 
            //var query = from u in database.Vw_Users select u;
            //var user =query.ToList();
            //DataGridUser.ItemsSource = user;
            ShowUserInfo();


        }
        // Connect to Db and Show in datagrid 
        private void ShowUserInfo()
        {
            var query = database.Database.SqlQuery<Vw_Customer>("Select * From Vw_Customer");
            var u = query.ToList();
            DataGridCustomer.ItemsSource = u;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}

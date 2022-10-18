using DataModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for win_productprice.xaml
    /// </summary>
    /// 
    public partial class win_productprice : Window
    {
        public win_productprice()
        {
            InitializeComponent();
        }



        //-- Db instantiation
        inventorydbEntities database = new inventorydbEntities();

        public string ProductName;
        public int ProductID;
        
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {// LINQ syntax:
            //var query = from u in database.Vw_Users select u;
            //var user =query.ToList();
            //DataGridUser.ItemsSource = user;
            Lbl_Product.Content = ProductName;
            ShowUserInfo();

        }
        //------------

        private void ShowUserInfo()
        {
            var query = database.Database.SqlQuery<Vw_ProductPrice>("Select * From Vw_ProductPrice Where 1=1 and productId = " + ProductID);

            var u = query.ToList();
            DataGridProductPrice.ItemsSource = u;
        }



        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}




///////////////////
//    public partial class win_productprice : Window
//    {
//        public win_productprice()
//        {
//            InitializeComponent();
//        }

//        //-- Db instantiation
//        inventorydbEntities database = new inventorydbEntities();

//        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
//        {
//            this.DragMove();
//        }

//        private void Window_Loaded(object sender, RoutedEventArgs e)
//        {// LINQ syntax: 
//         //var query = from u in database.Vw_Users select u;
//         //var user =query.ToList();
//         //DataGridUser.ItemsSource = user;
//            ShowPriceInfo();


//        }
//        // Connect to Db and Show in datagrid 
//        private void ShowPriceInfo()
//        {
//            var query = database.Database.SqlQuery<Vw_ProductPrice>("Select * From Vw_ProductPrice");
//            var u = query.ToList();
//            DataGridProduct.ItemsSource = u;
//        }

//        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
//        {
//            this.Close();
//        }
//    }
//}

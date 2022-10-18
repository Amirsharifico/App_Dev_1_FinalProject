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
    /// Interaction logic for win_product.xaml
    /// </summary>
    /// 


    public partial class win_product : Window
    {
        public win_product()
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
            var query = database.Database.SqlQuery<Vw_Product>("Select * From Vw_Product");
            var u = query.ToList();
            DataGridProduct.ItemsSource = u;
        }



        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }



        private void Btn_ProductPrice_Click(object sender, RoutedEventArgs e)
        {

            object item = DataGridProduct.SelectedItem;

            win_productprice W_price = new win_productprice();

            W_price.ProductName = (DataGridProduct.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            W_price.ProductID = Convert.ToInt32((DataGridProduct.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                       
            W_price.ShowDialog();
        }

        private void BtnShowInventory_Click(object sender, RoutedEventArgs e)
        {

            object item = DataGridProduct.SelectedItem;

            win_inventory W_price = new win_inventory();

            W_price.ProductName = (DataGridProduct.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            W_price.ProductID = Convert.ToInt32((DataGridProduct.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

            W_price.ShowDialog();
        }





        
    }
}

  
//    public partial class win_product : Window
//    {
//        public win_product()
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
//            //var query = from u in database.Vw_Users select u;
//            //var user =query.ToList();
//            //DataGridUser.ItemsSource = user;
//            ShowUserInfo();


//        }
//        // Connect to Db and Show in datagrid 
//        private void ShowUserInfo()
//        {
//            var query = database.Database.SqlQuery<Vw_Product>("Select * From Vw_Product");
//            var u = query.ToList();
//            DataGridProduct.ItemsSource = u;
//        }

//        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
//        {
//            this.Close();
//        }

//        private void Btn_ProductPrice_Click(object sender, RoutedEventArgs e)
//        {
//            win_productprice w_price = new win_productprice();
//            w_price.ShowDialog();
//        }
//    }
//}

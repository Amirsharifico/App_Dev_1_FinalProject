using System;
using System.Collections.Generic;
using System.IO;
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
using IMSBeta.Module;
using Microsoft.Win32;
using DataModelLayer;

namespace IMSBeta.window
{
    /// <summary>
    /// Interaction logic for win_add_edit_product.xaml
    /// </summary>
    public partial class win_add_edit_product : Window
    {
        public win_add_edit_product()
        {
            InitializeComponent();
        }
        string strName, imageName;
        inventorydbEntities1 database = new inventorydbEntities1();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_username.Content = PublicVariable.gUserName + " " + PublicVariable.gUserFamily;

        }

        private bool CheckNullable()
        {
            if (txt_productname.Text == "")
            {
                MessageBox.Show("Enter the product name");
                txt_productname.Focus();
                return false;
            }
            if (txt_desc.Text == "")
            {
                MessageBox.Show("Enter the product description");
                txt_desc.Focus();
                return false;
            }


            return true;
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckNullable())
            {
                return;
            }
            try
            {
                if (imageName != null)
                {
                    //// change type of image to String
                    FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);
                    byte[] imgByteArr = new byte[fs.Length];
                    fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
                    fs.Close();


                    /////////////Save in DB
                    database.Sp_ins_product(txt_productname.Text.Trim(), txt_desc.Text.Trim(), imgByteArr, PublicVariable.gUserId);
                    database.SaveChanges();

                    MessageBox.Show("Information saved successfully");
                }
                else
                {
                    MessageBox.Show("Please select an image for the new item");
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Close();
            }





        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
        this.Close();   
        }

        private void image_close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void image_product_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                FileDialog filedlg = new OpenFileDialog();
                filedlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                filedlg.ShowDialog();
                {
                    strName = filedlg.SafeFileName;
                    imageName = filedlg.FileName;

                    if (imageName != "")
                    {
                        ImageSourceConverter isc = new ImageSourceConverter();
                        image_product.SetValue(System.Windows.Controls.Image.SourceProperty, isc.ConvertFromString(imageName));
                    }
                }
                filedlg = null;
            }
            catch
            {
                MessageBox.Show("An error has occurred, please check");
            }

        }
    }
}

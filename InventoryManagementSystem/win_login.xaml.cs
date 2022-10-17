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
using IMSBeta.window;
using Microsoft.Win32;

namespace IMSBeta
{
    /// <summary>
    /// Interaction logic for win_login.xaml
    /// </summary>
    public partial class win_login : Window
    {
        public win_login()
        {
            InitializeComponent();
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
          
            System.Environment.Exit(0);
        }

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (TbxUserName.Text == "a" && TbxPassword.Password == "1234")

            {
                RegistryKey UserNameKey = Registry.CurrentUser.CreateSubKey("software\\IMSBeta");
                try
                {
                    UserNameKey.SetValue("UserNameRegister", TbxUserName.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Error Happenend for user login");
                }
                finally
                {
                    UserNameKey.Close();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Credentials");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ////////////////////////////////Registery
            RegistryKey masterkey = Registry.CurrentUser.CreateSubKey("software\\IMSBeta");
            TbxUserName.Text = (string)masterkey.GetValue("UserNameRegister");
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}

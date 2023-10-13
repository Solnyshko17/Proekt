using Prilozenie.DB;
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

namespace Prilozenie
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void cbPassword_Click(object sender, RoutedEventArgs e)
        {
            if (cbPassword.IsChecked == true)
            {
                tbPassword.Text = pbPassword.Password;
                pbPassword.Visibility = Visibility.Hidden;
                tbPassword.Visibility = Visibility.Visible;
            }
            else
            {
                pbPassword.Password = tbPassword.Text;
                tbPassword.Visibility = Visibility.Hidden;
                pbPassword.Visibility = Visibility.Visible;
            }
        }

        private void WindowMain(int Id_Role)
        {
            BaseWindow baseWindow = new BaseWindow(Id_Role);
            baseWindow.Show();
            Close();
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            using (KrossEntities2 DB = new KrossEntities2())
            {
                var users = DB.User.FirstOrDefault(p => p.Login == tbLogin.Text );

                if (users == null)
                {
                    MessageBox.Show("Введите корректный логин!", "Ошибка");
                    return;
                }
                if (users.Password == tbPassword.Text || users.Password == pbPassword.Password)
                {
                    if (users.Id_Role == 1)
                    {
                        WindowMain(1);
                    }
                    if (users.Id_Role == 2)
                    {
                        WindowMain(2);
                    }
                    if (users.Id_Role == 3)
                    {
                        WindowMain(3);
                    }

                }
            

                
                else
                {
                    MessageBox.Show("Введите корректный пароль!", "Ошибка");
                }
            }
        }
    }
}

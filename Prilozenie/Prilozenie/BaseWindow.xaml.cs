using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Prilozenie.DB;
using Prilozenie.UI;

namespace Prilozenie
{
    /// <summary>
    /// Логика взаимодействия для BaseWindow.xaml
    /// </summary>
    public partial class BaseWindow : Window
    {
        public BaseWindow(int Id_Role)
        {
            InitializeComponent();
            if (Id_Role == 1)
                MainFrame.Navigate(new AdminPage());
            if(Id_Role == 2)
                MainFrame.Navigate(new JournalPage());
            if (Id_Role == 3)
                MainFrame.Navigate(new SeePage());

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            Close();
        }
    }
}

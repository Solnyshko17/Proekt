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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Prilozenie.Class;
using System.Reflection;

namespace Prilozenie.UI
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {


        public AddPage()
        {
            InitializeComponent();

        }

        private void btnAddinBd_Click(object sender, RoutedEventArgs e)
        {
           if(tbId.Text == "" || tbOborydovanie.Text == "" || tbPl.Text == "" || tbPr.Text == "" || tbAbon.Text == "" || tbApparat.Text == "" 
                || tbSPl.Text == "" || tbSPr.Text == ""
                || tbLPl.Text == "" || tbLPr.Text == "" || tbCabel.Text == "" || tbCount.Text == "" || tbName.Text == "" || PtbLPl.Text == "" 
                || PtbLPr.Text == "" || tbPlaces.Text == "" || tbPrim.Text == "")
            {
                MessageBox.Show("Заполните все поля", "Ошибка!");
                return;
            }

           using(KrossEntities2 db = new KrossEntities2())
            {
                Kross kross = new Kross();
                {
                    Name = tbName.Text;
                    
                    

                }
            }
                
        }

        private void btnHazad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new JournalPage());
        }
    }
}

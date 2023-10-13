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
using Prilozenie.DB;

namespace Prilozenie.UI
{
    /// <summary>
    /// Логика взаимодействия для JournalPage.xaml
    /// </summary>
    public partial class JournalPage : Page
    {
        public JournalPage()
        {
            InitializeComponent();
            DGridJournal.ItemsSource = KrossEntities2.GetContext().Kross.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
          NavigationService.Navigate(new AddPage());

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var journalForRemoving = DGridJournal.SelectedItems.Cast<Kross>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {journalForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    KrossEntities2.GetContext().Kross.RemoveRange(journalForRemoving);
                    KrossEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridJournal.ItemsSource = KrossEntities2.GetContext().Kross.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}

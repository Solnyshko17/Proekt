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
using Prilozenie.VM;

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

            // устанавливаем DataContext c помощью VM (cмотри в папке VM)
            DataContext = new KrossVM()
            {
                Equipment = new Equipment(),
                CableType = new CableType(),
                Linear = new Linear(),
                Place = new Place(),
                Station = new Station()               
            };
        }

        // метод ассинхронный для быстроты действия (потом почитай про это, штука важная при разработке)
        private async void btnAddinBd_Click(object sender, RoutedEventArgs e)
        {
            if (tbOborydovanie.Text == "" || tbPl.Text == "" || tbPr.Text == "" || tbAbon.Text == "" || tbApparat.Text == ""
                 || tbSPl.Text == "" || tbSPr.Text == ""
                 || tbLPl.Text == "" || tbLPr.Text == "" || tbCabel.Text == "" || tbCount.Text == "" || tbName.Text == "" || PtbLPl.Text == ""
                 || PtbLPr.Text == "" || tbPlaces.Text == "" || tbPrim.Text == "")
            {
                MessageBox.Show("Заполните все поля", "Ошибка!");
                return;
            }

            var callbackData = (KrossVM)DataContext; // получаем все данные, введённые с формы            
            using(KrossEntities2 db = new KrossEntities2())
            {
                // из данных получаем объект для каждой таблицы
                db.Equipment.Add(callbackData.Equipment);
                db.Station.Add(callbackData.Station);
                db.CableType.Add(callbackData.CableType);
                db.Linear.Add(callbackData.Linear);
                db.Place.Add(callbackData.Place);                

                try
                {
                    await db.SaveChangesAsync(); // делаем сохранение, чтобы объекты выше появились в БД

                    // добавляем новый Кросс, используя ID объектов, которые были добавлены последними
                    db.Kross.Add(new Kross
                    {
                        Id_Equipment = db.Entry(callbackData.Equipment).Property(u => u.Id_Equipment).CurrentValue,
                        Id_CableType = db.Entry(callbackData.CableType).Property(u => u.Id_CableType).CurrentValue,
                        Id_Linear = db.Entry(callbackData.Linear).Property(u => u.Id_Linear).CurrentValue,
                        Id_Place = db.Entry(callbackData.Place).Property(u => u.Id_Place).CurrentValue,
                        Id_Station = db.Entry(callbackData.Station).Property(u => u.Id_Station).CurrentValue,
                    });

                    await db.SaveChangesAsync(); // сохраняем
                    LoopVisualTree(this); // очищаем textbox
                    MessageBox.Show("Данные успешно добавлены!", "Инфорамация");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }

            return;
        }

        // метод для очищения всех textbox на странице (вместо ручного очищения)
        void LoopVisualTree(DependencyObject obj)//обнуление текст боксов
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                if (obj is TextBox)
                {
                    ((TextBox)obj).Text = null;
                }
                LoopVisualTree(VisualTreeHelper.GetChild(obj, i));
            }
        }

        private void btnHazad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new JournalPage());
        }
    }
}

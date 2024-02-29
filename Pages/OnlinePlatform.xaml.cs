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

namespace OnlinePlatforms_EX_StasIvan.Pages
{
    /// <summary>
    /// Логика взаимодействия для OnlinePlatform.xaml
    /// </summary>
    public partial class OnlinePlatform : Page
    {
        public OnlinePlatform()
        {
            InitializeComponent();
            GridOnlinePlatforms.ItemsSource = OnlineOrderHomesEntities.GetContext().OnlinePlatforms.ToList();
        }

        private void butAddState_Click(object sender, RoutedEventArgs e)
        {
            Manager.myFrame.Navigate(new Pages.AddOnlinePlatform());
        }

        private void butDeleteState_Click(object sender, RoutedEventArgs e)
        {
            var DelPlatform = GridOnlinePlatforms.SelectedItems.Cast<OnlinePlatforms>().ToList();
            try
            {
                if (MessageBox.Show($"Вы уверены что хотите удалить {DelPlatform.Count()} элементов?", "Ошибка", 
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    OnlineOrderHomesEntities.GetContext().OnlinePlatforms.RemoveRange(DelPlatform);
                    OnlineOrderHomesEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    GridOnlinePlatforms.ItemsSource = OnlineOrderHomesEntities.GetContext().OnlinePlatforms.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void butRedState_Click(object sender, RoutedEventArgs e)
        {
            //Manager.myFrame.Navigate(new Pages.AddOnlinePlatform((sender as Button).DataContext as OnlinePlatforms));
        }

        private void butNavEstates_Click(object sender, RoutedEventArgs e)
        {
            Manager.myFrame.Navigate(new Pages.EstatesPage());
        }
    }
}

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
    /// Логика взаимодействия для EstatesPage.xaml
    /// </summary>
    public partial class EstatesPage : Page
    {
        public EstatesPage()
        {
            InitializeComponent();
            GridEstates.ItemsSource = OnlineOrderHomesEntities.GetContext().Estates.ToList();
        }

        private void butRedState_Click(object sender, RoutedEventArgs e)
        {
            //Manager.myFrame.Navigate(new Pages.AddEstate((sender as Button).DataContext as Estates));
        }

        private void butAddState_Click(object sender, RoutedEventArgs e)
        {
            Manager.myFrame.Navigate(new Pages.AddEstate());
        }

        private void butDeleteState_Click(object sender, RoutedEventArgs e)
        {
            var DelEstate = GridEstates.SelectedItems.Cast<Estates>().ToList();
            try
            {
                if (MessageBox.Show($"Вы уверены что хотите удалить {DelEstate.Count()} элементов?", "Ошибка",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    OnlineOrderHomesEntities.GetContext().Estates.RemoveRange(DelEstate);
                    OnlineOrderHomesEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    GridEstates.ItemsSource = OnlineOrderHomesEntities.GetContext().Estates.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void butBack_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.myFrame.CanGoBack)
            {
                Manager.myFrame.GoBack();
            }
        }
    }
}

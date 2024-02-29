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
    /// Логика взаимодействия для AddOnlinePlatform.xaml
    /// </summary>
    public partial class AddOnlinePlatform : Page
    {
        public AddOnlinePlatform()
        {
            InitializeComponent();
        }

        private void butAddPlatform_Click(object sender, RoutedEventArgs e)
        {
            if (OnlineOrderHomesEntities.GetContext().OnlinePlatforms.Count(a => a.NamePlatform == NamePlatform.Text)>0)
            {
                MessageBox.Show("Такая платформа уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                OnlinePlatforms addPlatform = new OnlinePlatforms()
                {
                    NamePlatform = NamePlatform.Text,
                    Site = NameSite.Text,
                    CountUsers = int.Parse(CountPeoples.Text),
                    Telephone = TextTelephon.Text,
                    AuthorLogin = NameLoginAuthor.Text,
                    id_Estate = int.Parse(idPlatform.Text)
                };
                OnlineOrderHomesEntities.GetContext().OnlinePlatforms.Add(addPlatform);
                OnlineOrderHomesEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные заполнены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                OnlineOrderHomesEntities.GetContext().OnlinePlatforms.ToList();
            }
            catch
            {
                MessageBox.Show("Данные не заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void butback_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.myFrame.CanGoBack)
            {
                Manager.myFrame.GoBack();
            }
        }
    }
}

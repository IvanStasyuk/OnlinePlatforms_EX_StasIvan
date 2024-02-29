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
    /// Логика взаимодействия для AddEstate.xaml
    /// </summary>
    public partial class AddEstate : Page
    {
        public AddEstate()
        {
            InitializeComponent();
        }


        private void butback_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.myFrame.CanGoBack)
            {
                Manager.myFrame.GoBack();
            }
        }

        private void butAddEstate_Click(object sender, RoutedEventArgs e)
        {
            if (OnlineOrderHomesEntities.GetContext().Estates.Count(a => a.NameEstate == NameEstateCode.Text) > 0)
            {
                MessageBox.Show("Такая недвижимость уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                Estates addEstate = new Estates()
                {
                    id_Estate = int.Parse(idestate.Text),
                    NameEstate = NameEstateCode.Text,
                    City = CityEstate.Text,
                    YearBuilding = DateTime.Parse(YearBuilding.Text),
                    Telephone = TextTelephonCode.Text,
                    PriceEstate = int.Parse(PriceEstateCode.Text),
                    Purchase = PurchaseEstate.Text
                };
                OnlineOrderHomesEntities.GetContext().Estates.Add(addEstate);
                OnlineOrderHomesEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные заполнены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                OnlineOrderHomesEntities.GetContext().Estates.ToList();
            }
            catch
            {
                MessageBox.Show("Данные не заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}

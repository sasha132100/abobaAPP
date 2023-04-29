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

namespace abobaAPP
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
            LoadComponent("No");
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            discountComboBox.Items.Add("Скидка 0-9.99%");
            discountComboBox.Items.Add("Скидка 10-14.99%");
            discountComboBox.Items.Add("Скидка 15 и выше");
        }

        private void LoadComponent(string isChanged)
        {
            using (var db = new user25Entities())
            {
                if (isChanged == "No")
                    dataGrid.ItemsSource = db.Product.ToList();
                else
                {
                    if (discountComboBox.SelectedItem.ToString() == "Скидка 0-9.99%")
                    {
                        dataGrid.ItemsSource = db.Product.Where(d => d.ProductDiscountAmount > 0 && d.ProductDiscountAmount < 10).ToList();
                    }
                    else if (discountComboBox.SelectedItem.ToString() == "Скидка 10-14.99%")
                    {
                        dataGrid.ItemsSource = db.Product.Where(d => d.ProductDiscountAmount >= 10 && d.ProductDiscountAmount < 15).ToList();
                    }
                    else
                    {
                        dataGrid.ItemsSource = db.Product.Where(d => d.ProductDiscountAmount >= 15).ToList();
                    }
                }
            }
            if (!SystemContext.isGuest)
            {
                userNameTextBlock.Text = SystemContext.user.UserLogin;
            }
            else
            {
                userNameTextBlock.Text = "Guest";
                addButton.IsEnabled = false;
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void myOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow ordersWindow = new OrdersWindow();
            this.Close();
            ordersWindow.ShowDialog();
        }

        private void discount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadComponent("Yes");
        }
    }
}

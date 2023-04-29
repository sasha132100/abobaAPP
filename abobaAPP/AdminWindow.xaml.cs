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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            LoadComponent();
        }

        private void LoadComponent()
        {
            using (var db = new user25Entities())
            {
                dataGrid.ItemsSource = db.Product.ToList();
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
    }
}

using SoftServis.Memory;
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

namespace WpfApp.View
{
    /// <summary>
    /// Логика взаимодействия для WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        private const string Login = "TheCotOfTehas";
        private const string Password = "1234";
        private readonly DataServes dataServes;
        public WindowLogin()
        {
            InitializeComponent();
            dataServes = new DataServes();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == Login && PasswordTextBox.Password == Password)
            {
                MainWindow mainWindow = new();
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        /// <summary>
        /// Активация кнопки авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginTextBox.Text))
            {
                ButtonAuthorization.IsEnabled = true;
            }
        }
    }
}

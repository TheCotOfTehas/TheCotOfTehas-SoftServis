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

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        private const string Login = "TheCotOfTehas";
        private const string Password = "1234";
        private readonly DataServis dataServis;
        public WindowLogin()
        {
            InitializeComponent();
            //var lesson3 = new Lesson3();
            //lesson3.Show();
            var lesson4 = new LessonFour();
            lesson4.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == Login && PasswordTextBox.Password == Password)
            {
                MainWindow mainWindow = new MainWindow(dataServis);
                mainWindow.Show();
                this.Close();
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

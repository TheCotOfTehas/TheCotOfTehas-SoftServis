using SoftServis;
using SoftServis.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.View;

namespace WpfApp.ViewModels
{
    internal class WindowLoginModel : ViewModel
    {
        private const string Login = "TheCotOfTehas";
        private const string Password = "1234";

        private string LoginProperty;
        private string PasswordProperty;
        private string AuthorizationProperty;

        public string LoginTextBox
        {
            get => LoginProperty;
            set => Set(ref LoginProperty, value);
        }

        public string PasswordTextBox
        {
            get => PasswordProperty;
            set => Set(ref PasswordProperty, value);
        }

        public string AuthorizationTextBox
        {
            get => AuthorizationProperty;
            set => Set(ref AuthorizationProperty, value);
        }

        public WindowLoginModel()
        {
            PasswordChangedCommand = new LambdaCommand(PasswordTextBox_PasswordChanged);
            AuthorizationCommand = new LambdaCommand(OnAuthorization);
        }

        public ICommand PasswordChangedCommand {  get; }
        public ICommand AuthorizationCommand { get; }

        private void OnAuthorization(object sender) //Added loginWindow Parameter
        {
            if (LoginProperty == Login && PasswordTextBox == Password)
            {
                MainWindow mainWindow = new();
                mainWindow.Show();
                CloseAction();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        /// <summary>
        /// Активация кнопки авторизации
        /// </summary>
        /// <param name = "sender" ></ param >
        /// < param name="e"></param>
        private void PasswordTextBox_PasswordChanged(object sender)
        {
            if (!string.IsNullOrEmpty(LoginTextBox))
            {
                AuthorizationTextBox = "true";
            }
        }
    }
}

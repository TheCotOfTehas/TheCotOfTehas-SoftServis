using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для lesson4.xaml
    /// </summary>
    public partial class LessonFour : Window
    {
        public LessonFour()
        {
            InitializeComponent();
        }

        private void Button_ReadText(object sender, RoutedEventArgs e)
        {
            if (File.Exists("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\ПапкаИстроийКомпаний\\Текст.txt"))
            {
                using StreamReader strRdrText = new StreamReader("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\ПапкаИстроийКомпаний\\Текст.txt");
                string text = strRdrText.ReadToEnd();
                OutputBox.Text = text;
            }
            else
            {
                MessageBox.Show("Файла для записи не существует");
            }
        }

        private void Button_WriteText(object sender, RoutedEventArgs e)
        {
            if (File.Exists("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\ПапкаИстроийКомпаний\\Текст.txt"))
            {
                string text = InputBox.Text.ToString();
                using StreamWriter strWriter = new StreamWriter("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\ПапкаИстроийКомпаний\\Текст.txt", true);
                strWriter.WriteLine(text);
            }
            else
            {
                MessageBox.Show("Файла для чтения не существует");
            }
        }
    }
}

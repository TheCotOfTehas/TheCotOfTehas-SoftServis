using Microsoft.Data.SqlClient;
using SoftServis;
using SoftServis.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
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
    /// Логика взаимодействия для WindowCompany.xaml
    /// </summary>
    public partial class WindowCompany : Window
    {
        Company CompanyCurrent {  get; set; }
        public WindowCompany(Company company)
        {
            InitializeComponent();
            FullName.Text = company.LongName;
            ShortName.Text = company.ShortName;
            Mails.Text = company.Mailes.First().MailName;
            INN.Text =  company.Id.ToString();
            CompanyCurrent = company;
            HistoriBlock.Text = ReadText(company.Id);
        }

        private void Button_Send_Messeg(object sender, RoutedEventArgs e)
        {
            var text = HistoriBox.Text;
            var date = DateTime.Now;
            HistoriBlock.Text += $"{text}  {date} ";
            WriteText(CompanyCurrent.Id, text, date);
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new())
            {
                var dd = db.companies.Where(x => x.Id == CompanyCurrent.Id).FirstOrDefault();
                if (CompanyCurrent != null)
                {
                    dd.LongName = FullName.Text;
                    dd.ShortName = ShortName.Text;
                    dd.Id = int.Parse(INN.Text);
                    dd.Mailes.Add(new Mail() { MailName = Mails.Text });

                    db.SaveChanges();
                    MessageBox.Show("Информация сохранена");
                }
            }
        }
        private string ReadText(int INN)
        {
            string text = "";
            if (File.Exists($"C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\ПапкаИсторийКомпаний\\{INN}.txt"))
            {
                using StreamReader strRdrText = new StreamReader($"C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\ПапкаИсторийКомпаний\\{INN}.txt");
                text = strRdrText.ReadToEnd();
            }
            else
            {
                MessageBox.Show("Файла для записи не существует");
                File.Create($"C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\ПапкаИсторийКомпаний\\{INN}.txt");
            }

            return text;
        }

        private void WriteText(int INN, string text, DateTime dateTime)
        {
            if (File.Exists($"C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\ПапкаИсторийКомпаний\\{INN}.txt"))
            {
                using StreamWriter strWriter = new StreamWriter($"C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\ПапкаИсторийКомпаний\\{INN}.txt", true);
                strWriter.WriteLine($"{text} + {dateTime}");
            }
            else
            {
                MessageBox.Show("Файла для чтения не существует. Был Создан новый");
                File.Create($"C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\ПапкаИсторийКомпаний\\{INN}.txt");
            }
        }
    }
}

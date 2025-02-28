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
            var mail = company.Mailes;
            if (mail != null && mail.Count > 0)
                Mails.Text = mail.First().MailName;
            else 
                Mails.Text = "Не задано";

            INN.Text =  company.INN.ToString();
            CompanyCurrent = company;
            HistoriBlock.Text = ReadText(company.Id);
        }

        private void Button_Send_Messeg(object sender, RoutedEventArgs e)
        {
            var text = HistoriBox.Text;
            var date = DateTime.Now;
            HistoriBlock.Text += $"{text}  {date} \r\n";
            WriteText(CompanyCurrent.Id, text, date);
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new())
            {
               
                if (CompanyCurrent != null)
                {
                    var company = db.companies.Where(x => x.INN == CompanyCurrent.INN).FirstOrDefault();
                    company.LongName = FullName.Text;
                    company.ShortName = ShortName.Text;
                    company.INN = long.Parse(INN.Text);
                    company.Mailes.Add(new Mail() { MailName = Mails.Text });

                    db.SaveChanges();
                    MessageBox.Show("Информация сохранена");
                }
            }
        }
        private string ReadText(long INN)
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

        private void WriteText(long INN, string text, DateTime dateTime)
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

        private void Mails_TextChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}

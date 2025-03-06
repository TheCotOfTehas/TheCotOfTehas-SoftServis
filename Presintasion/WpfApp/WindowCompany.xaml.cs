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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для WindowCompany.xaml
    /// </summary>
    public partial class WindowCompany : Window
    {
        Company CompanyCurrent { get { return DataBase.Companies.Where(company => company.Id == IdCompany).FirstOrDefault(); }}
        ApplicationContext DataBase {  get; set; }

        int IdCompany {  get; set; }

        public WindowCompany(ApplicationContext dataBase,  int idCompany)
        {
            InitializeComponent();
            DataBase = dataBase;
            IdCompany = idCompany;
            //CompanyCurrent = DataBase.Companies.Where(company => company.Id == idCompany).FirstOrDefault();
            FillOutForm();
            IDUser.Text = "ID Company- (" + CompanyCurrent.Id.ToString() + ")";
        }

        private void FillOutForm()
        {
            FullName.Text = CompanyCurrent.LongName;
            ShortName.Text = CompanyCurrent.ShortName;
            CompanyName.Text = $"Компания {CompanyCurrent.ShortName}";
            var mail = CompanyCurrent.Mailes;

            if (mail != null && mail.Count > 0)
                Mails.Text = mail.First().MailName;
            else
                Mails.Text = "Не задано";

            INN.Text = CompanyCurrent.INN.ToString();
            HistoriBlock.Text = ReadText();
        }

        private void Button_Send_Messed(object sender, RoutedEventArgs e)
        {
            var text = HistoriBox.Text;
            var date = DateTime.Now;
            var historyCompany = new HistoryCompany() { Message = "text" };
            CompanyCurrent.Historys.Add(historyCompany);
            DataBase.SaveChanges();
            HistoriBlock.Text += $"{text}  {historyCompany.DateMessage} \r\n";
            WriteText(text, date);
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {              
            if (CompanyCurrent != null)
            {
                var company = DataBase.Companies.Where(x => x.INN == CompanyCurrent.INN).FirstOrDefault();
                company.LongName = FullName.Text;
                company.ShortName = ShortName.Text;
                company.INN = long.Parse(INN.Text);
                company.Mailes.Add(new Mail() { MailName = Mails.Text });
                DataBase.SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
        }

        private string ReadText()
        {
            string message = "";
            List<HistoryCompany> historyCompanyes = CompanyCurrent.Historys;
            foreach (HistoryCompany item in historyCompanyes)
            {
                //var r = item.Message;
                message += $"{item.Message}    {item.DateMessage} \r\n";
            }
            
            return message;
        }
        private void WriteText(string text, DateTime dateTime)
        {
            var history = new HistoryCompany() 
            { 
                Message = text,
                DateMessage = dateTime,
            };
            CompanyCurrent.Historys.Add(history);
            DataBase.SaveChanges();
        }

        private static string ReadWithFileText(long INN)
        {
            string text = "";
            if (File.Exists($"C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\ПапкаИсторийКомпаний\\{INN}.txt"))
            {
                using StreamReader strRdrText = new($"C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\ПапкаИсторийКомпаний\\{INN}.txt");
                text = strRdrText.ReadToEnd();
            }
            else
            {
                MessageBox.Show("Файла для записи не существует");
                File.Create($"C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\ПапкаИсторийКомпаний\\{INN}.txt");
            }

            return text;
        }

        private static void WriteInFileText(long INN, string text, DateTime dateTime)
        {
            if (File.Exists($"C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\ПапкаИсторийКомпаний\\{INN}.txt"))
            {
                using StreamWriter strWriter = new($"C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\ПапкаИсторийКомпаний\\{INN}.txt", true);
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
            var addMails = new AddMails();
            addMails.Show();
        }

        private void Button_Send_Message(object sender, RoutedEventArgs e)
        {

        }
    }
}

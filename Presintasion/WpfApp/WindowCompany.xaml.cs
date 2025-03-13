using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для WindowCompany.xaml
    /// </summary>
    public partial class WindowCompany : Window
    {
        Company CompanyCurrent { get; set;}
        ApplicationContext DataBase {  get; set; }

        public WindowCompany(ApplicationContext dataBase,  int idCompany)
        {
            InitializeComponent();
            DataBase = dataBase;

            var companyCurrent  = DataBase
                        .Companies
                        .Include(company => company.Histories)
                        .Include(company => company.Mails)
                        .Include(company => company.Products)
                        .Where(x => x.Id == idCompany)
                        .FirstOrDefault();

            CompanyCurrent = companyCurrent != null ? companyCurrent : new Company();
            FillOutForm();
        }


        private void Button_Send_Messed(object sender, RoutedEventArgs e)
        {
            var text = HistoriBox.Text;
            var date = DateTime.Now;
            var historyCompany = new HistoryCompany(text);
            HistoriBlock.Text += $"{historyCompany.Message}  {historyCompany.DateMessage} \r\n";
            CompanyCurrent.Histories.Add(historyCompany);
            DataBase.SaveChanges();
        }

        private void FillOutForm()
        {
            IDUser.Text = "ID Company- (" + CompanyCurrent.Id.ToString() + ")";
            FullName.Text = CompanyCurrent.LongName;
            ShortName.Text = CompanyCurrent.ShortName;
            CompanyName.Text = $"Компания {CompanyCurrent.ShortName}";
            var mail = CompanyCurrent.Mails;

            if (mail != null && mail.Count > 0)
                Mails.Text = mail.First().MailName;
            else
                Mails.Text = "Не задано";

            INN.Text = CompanyCurrent.INN.ToString();
            var historiBlock = string.IsNullOrEmpty(HistoriBlock.Text) ? $"Это начало истории компании \r\n {DateTime.Now} \r\n" : HistoriBlock.Text;
            HistoriBlock.Text = historiBlock;
            HistoriBlock.Text += ReadText();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {              
            CompanyCurrent.LongName = FullName.Text != null ? FullName.Text : "Не указано";
            CompanyCurrent.ShortName = ShortName.Text;
            CompanyCurrent.INN = long.Parse(INN.Text);
            CompanyCurrent.Mails.Add(new Mail() { MailName = Mails.Text });
            DataBase.SaveChanges();
            MessageBox.Show("Информация сохранена");
        }

        private string ReadText()
        {
            string message = "";
            foreach (HistoryCompany item in CompanyCurrent.Histories)
                message += $"{item.Message}    {item.DateMessage} \r\n";
            
            return message;
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

        private void GetListProduct(object sender, RoutedEventArgs e)
        {
            var list = new WindowListProduct(DataBase, CompanyCurrent);
            list.Show();
        }
    }
}

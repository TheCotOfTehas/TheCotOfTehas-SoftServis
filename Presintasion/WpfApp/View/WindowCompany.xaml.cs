using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SoftServis;
using SoftServis.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp.View
{
    /// <summary>
    /// Логика взаимодействия для WindowCompany.xaml
    /// </summary>
    public partial class WindowCompany : Window
    {
        Company CompanyCurrent { get; set;}
        ApplicationContext DataBase {  get; set; }
        DataServes Serves { get; set; }

        public WindowCompany(ApplicationContext dataBase, DataServes dataServes, int idCompany)
        {
            InitializeComponent();
            DataBase = dataBase;
            Serves = dataServes;
            CompanyCurrent = Serves.GetCompany(idCompany);
            FillOutForm();
        }

        private void Button_Send_Messed(object sender, RoutedEventArgs e)
        {
            var text = HistoriBox.Text;
            var date = DateTime.Now;
            var historyCompany = new HistoryCompany(text);
            CompanyCurrent.Histories.Add(historyCompany);
            var currentHistory = new PartialPage(DataBase, Serves, CompanyCurrent);
            currentHistory.CurrentMassegBox.Text = text;
            currentHistory.CurrentDate.Text = $"{date.Day}.{date.Month}.{date.Year}";
            currentHistory.CurrentTime.Text = $"{date.Hour}:{date.Minute}";
            currentHistory.Uid = $"{CompanyCurrent.Histories.Count() - 1}";
            StackPanelHistori.Children.Add(currentHistory);
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
            AddHistoryOnPage();
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

        private void AddHistoryOnPage()
        {
            foreach (HistoryCompany item in CompanyCurrent.Histories)
            {
                var currentHistory = new PartialPage(DataBase, Serves, CompanyCurrent);
                currentHistory.CurrentMassegBox.Text = item.Message;
                currentHistory.CurrentDate.Text = $"{item.DateMessage.Day}.{item.DateMessage.Month}.{item.DateMessage.Year}";
                currentHistory.CurrentTime.Text = $"{item.DateMessage.Hour}:{item.DateMessage.Minute}";
                currentHistory.Uid = $"{item.Id}";
                StackPanelHistori.Children.Add(currentHistory);
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

        public void RefreshChangesHistory()
        {
            StackPanelHistori.Children.Clear();
            AddHistoryOnPage();
        }
    }
}

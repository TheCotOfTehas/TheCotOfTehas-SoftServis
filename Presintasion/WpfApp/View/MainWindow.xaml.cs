using SoftServis;
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
using WpfApp.Model;

namespace WpfApp.View
{
    /// <summary>
    /// Логика взаимодействия для NewWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext DataBase { get; set; }

        private readonly DataServes Servis;
        public MainWindow(DataServes dataServes)
        {
            InitializeComponent();
            Servis = dataServes;
            Servis = new DataServes();
            DataBase = new ApplicationContext();
            //MyInitBD();
            DataBase.SaveChanges();
        }

        private void MyInitBD()
        {
            DataBase.Database.EnsureDeleted();
            DataBase.Database.EnsureCreated();
            List<Company> companies = WorkClass.GetContentBD();
            DataBase.AddRange(companies.ToArray());
        }

        private void Window_LoadedEmails(object sender, RoutedEventArgs e)
        {
            DataContext = DataBase.Companies.Local.ToObservableCollection();
        }

        private void GetCompanies_Click(object sender, RoutedEventArgs e)
        {
            var ListCompany = DataBase.Companies.Select(x => x.ShortName);

            foreach (var company in ListCompany)
            {
                InnerBox.Text += "\r\n" + company;
            }
        }

        private void GetEmail_Click(object sender, RoutedEventArgs e)
        {
            var mails = Servis.GetAllMail();
            //var ListMails = DataBase.Companies.Select(x => x.Mails);
            foreach (var mail in mails)
            {
                InnerBox.Text += "\r\n" + mail.MailName;
            }
        }

        private void Button_Click_Add_Company(object sender, RoutedEventArgs e)
        {
            AddCompany addCompany = new(DataBase);
            addCompany.Show();
        }

        private void Button_Click_Add_Mails(object sender, RoutedEventArgs e)
        {

        }

        private void Button_OpenWindowCompany(object sender, RoutedEventArgs e)
        {
            WindowCompany windowCompany = new(DataBase, Servis, 0);
            windowCompany.Show();
        }

        private void OpenCompany_Click(object sender, RoutedEventArgs e)
        {
            var listCompany = DataBase.Companies;
            var nameCompany = NewOpenCompany.Text.ToString();
            var company = listCompany.FirstOrDefault(x => x.ShortName.CompareTo(nameCompany) == 0);
            if (company != null)
            {
                var windowCompany = new WindowCompany(DataBase, Servis, company.Id);
                windowCompany.Show();
            }
            else
            {
                MessageBox.Show("Данная Компания в базе не найдена попробуйте снова!!!");
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SoftServis;
using SoftServis.Memory;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();

        private readonly DataServis dataServis;
        public MainWindow(DataServis dataServis)
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            db.Database.EnsureCreated();

            List<Company> сompanies =
            [
                new Company()
                {
                    LongName = "имяДлинное1",
                    ShortName = "имяКороткое1",
                    Description = "Описание1",
                    AddresCompany = new Address(),
                    Telephones = new List<Telephone>(),
                    Mailes = new List<Mail>(){ new Mail() {MailName = "Mail1@mail.ru" } }
                },
                new Company()
                {
                    LongName = "имяДлинное2",
                    ShortName = "имяКороткое2",
                    Description = "Описание2",
                    AddresCompany = new Address(),
                    Telephones = new List<Telephone>(),
                    Mailes = new List<Mail>(){ new Mail() {MailName = "Mail2@mail.ru" } }
                },
                new Company()
                {
                    LongName = "имяДлинное3",
                    ShortName = "имяКороткое3",
                    Description = "Описание3",
                    AddresCompany = new Address(),
                    Telephones = new List<Telephone>(),
                    Mailes = new List<Mail>(){ new Mail() {MailName = "Mail3@mail.ru" } }
                }
            ];

            db.AddRange(сompanies.ToArray());
            db.SaveChanges();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db.Database.EnsureCreated();
            db.companies.Load();
            DataContext = db.companies.Local.ToObservableCollection();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
           //User mainWindow = new user(new Company());
        }

        private void GetEmail_Click(object sender, RoutedEventArgs e)
        {
            ExecuteReport();
        }

        private void ExecuteReport()
        {
            var ListMails = db.companies.Select(x => x.Mailes);
            foreach (var mails in ListMails)
            {
                foreach (var mail in mails)
                {
                    InnerBox.Text += " " + mail.MailName + "\r\n";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

        }
    }
}
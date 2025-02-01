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

        //private readonly DataServis dataServis;
        public MainWindow(DataServis dataServis)
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            List<Company> сompanies = WorkClass.GetContentBD();

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
            var longName = LongName.Text;
            var shortName = ShortName.Text;
            var description = Description.Text;
            int telephone = int.Parse(Telephone.Text);
            var currentCompany = new Company() 
            {
                LongName = longName,
                ShortName = shortName,
                Description = description        
            };
            var tellephone = new Telephone();
            tellephone.Numder = telephone;
            currentCompany.Telephones.Add(tellephone);
            db.Add(currentCompany);
            db.SaveChanges();
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
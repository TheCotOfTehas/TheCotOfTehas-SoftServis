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
using WpfApp.Model;

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
            this.dataServis = dataServis;
            Loaded += Window_LoadedEmails;
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            List<Company> сompanies = WorkClass.GetContentBD();

            db.AddRange(сompanies.ToArray());
            db.SaveChanges();
        }

        private void Window_LoadedEmails(object sender, RoutedEventArgs e)
        {
            DataContext = db.companies.Local.ToObservableCollection();
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

        private void Button_Click_Add_Company(object sender, RoutedEventArgs e)
        {
            AddCompany addCompany = new AddCompany(dataServis);
            addCompany.Show();
        }

        private void Button_Click_Add_Mails(object sender, RoutedEventArgs e)
        {

        }

        private void Button_OpenLessonFour(object sender, RoutedEventArgs e)
        {
            LessonFour lessonFour = new LessonFour();
            lessonFour.Show();
        }

        private void Button_OpenLessonThree(object sender, RoutedEventArgs e)
        {
            LessonThree lessonThree = new LessonThree();
            lessonThree.Show();
        }
    }
}
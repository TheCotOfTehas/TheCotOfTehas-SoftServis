using Microsoft.EntityFrameworkCore;
using SoftServis;
using SoftServis.Memory;
using System.Printing;
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
        ApplicationContext DataBase{ get; set; }

        private readonly DataServis DataServis;
        public MainWindow(DataServis dataServis)
        {
            InitializeComponent();
            this.DataServis = dataServis;
            DataBase = new ApplicationContext();
            //DataBase.Database.EnsureDeleted();
            //DataBase.Database.EnsureCreated();
            //List<Company> сompanies = WorkClass.GetContentBD();
            //DataBase.AddRange(сompanies.ToArray());
            DataBase.SaveChanges();
        }

        private void Window_LoadedEmails(object sender, RoutedEventArgs e)
        {
            DataContext = DataBase.Companies.Local.ToObservableCollection();
        }

        private void GetCompanys_Click(object sender, RoutedEventArgs e)
        {
            var ListCompany = DataBase.Companies.Select(x => x.ShortName);

            foreach (var company in ListCompany) 
            {
                InnerBox.Text += " " + company + "\r\n";
            }
        }

        private void GetEmail_Click(object sender, RoutedEventArgs e)
        {
            var ListMails = DataBase.Companies.Select(x => x.Mailes);
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
            AddCompany addCompany = new AddCompany(DataBase);
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

        private void Button_OpenLessonFive(object sender, RoutedEventArgs e)
        {
            LessonFive lessonFive = new LessonFive();
            lessonFive.Show();
        }

        private void Button_OpenWindowCompany(object sender, RoutedEventArgs e)
        {
            WindowCompany windowCompany = new WindowCompany(DataBase, 0);
            windowCompany.Show();
        }

        private void OpenCompany_Click(object sender, RoutedEventArgs e)
        {
            var listCompany = DataBase.Companies;
            var nameCompany = OpenCompany.Text.ToString();
            var company = listCompany.FirstOrDefault(x =>x.ShortName.CompareTo(nameCompany) == 0);
            if (company != null)
            {
                var r = new WindowCompany(DataBase, company.Id);
                r.Show();
            }
            else
            {
                MessageBox.Show("Данная Компания в базе не найдена попробуйте снова!!!");
            }
        }
    }
}
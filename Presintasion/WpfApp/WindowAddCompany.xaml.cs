using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для AddCompany.xaml
    /// </summary>
    public partial class AddCompany : Window
    {
        ApplicationContext db = new ApplicationContext();
        DataServis dataServis;
        public AddCompany(DataServis dataServis)
        {
            InitializeComponent();
            //this.dataServis = dataServis;
            Loaded += AddCompany_Loaded;
            List<Company> сompanies = WorkClass.GetContentBD();
            db.AddRange(сompanies.ToArray());
            db.SaveChanges();
        }

        private void AddCompany_Loaded(object sender, RoutedEventArgs e)
        {
            db.Database.EnsureCreated();
            db.companies.Load();
            DataContext = db.companies.Local.ToObservableCollection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var company = new Company();
            var longName = LongName.Text;
            var shortName = ShortName.Text;
            var description = Description.Text;
            var telephone = Telephone.Text;
            company.LongName = longName;
            company.ShortName = shortName;
            company.Description = description;

            if (ValidityPhone(telephone))
            {
                var digits  = int.Parse(telephone);
                var currentTelephone = new Telephone();
                currentTelephone.Numder = digits;
                company.Telephones.Add(currentTelephone);
            }

            db.companies.Add(company);
            db.SaveChanges();
            this.Close();
            MessageBox.Show("Вы добавили данные в базу");
        }

        private bool ValidityPhone(string telephone)
        {
            if (telephone.IsNullOrEmpty())
                return false;

            foreach (var symbol in telephone)
                if (!char.IsDigit(symbol))
                    return false;

            return true;
        }
    }
}

using SoftServis;
using SoftServis.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Model;

namespace WpfApp.ViewModels
{
    internal class MainWindowModel : ViewModel
    {
        ApplicationContext DataBase { get; set; }

        private readonly DataServes Servis;
        public MainWindowModel(DataServes servis)
        {
            Servis = new DataServes();
            DataBase = new ApplicationContext();
            //MyInitBD();
            DataBase.SaveChanges();
            //GetCompaniesCommand = new LambdaCommand();
        }

        private void MyInitBD()
        {
            DataBase.Database.EnsureDeleted();
            DataBase.Database.EnsureCreated();
            List<Company> companies = WorkClass.GetContentBD();
            DataBase.AddRange(companies.ToArray());
        }
        public ICommand GetCompaniesCommand { get; }

        private void GetCompanies_Click(object sender, RoutedEventArgs e)
        {
            var ListCompany = DataBase.Companies.Select(x => x.ShortName);

            foreach (var company in ListCompany)
            {
                //InnerBox.Text += "\r\n" + company;
            }
        }
    }
}

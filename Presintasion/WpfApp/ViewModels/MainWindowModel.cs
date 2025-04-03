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

        private string f_Text;

        public string GetEmail
        {
            get => f_Text;
            set => Set(ref f_Text, value);
        }

        //public MainWindowModel(DataServes servis)
        //{
        //    Servis = new DataServes();
        //    DataBase = new ApplicationContext();
        //    //MyInitBD();
        //    DataBase.SaveChanges();
        //    GetCompaniesCommand = new LambdaCommand(OnGetCompanies);
        //}

        public MainWindowModel()
        {
            Servis = new DataServes();
            DataBase = new ApplicationContext();
            DataBase.SaveChanges();
            GetCompaniesCommand = new LambdaCommand(OnGetCompanies);
        }

        private void MyInitBD()
        {
            DataBase.Database.EnsureDeleted();
            DataBase.Database.EnsureCreated();
            List<Company> companies = WorkClass.GetContentBD();
            DataBase.AddRange(companies.ToArray());
        }
        public ICommand GetCompaniesCommand { get; }

        private void OnGetCompanies(object sender)
        {
            var ListCompany = DataBase.Companies.Select(x => x.ShortName);

            var mails = Servis.GetAllMail();

            foreach (var company in ListCompany)
            {
                f_Text += "\r\n" + company;
            }
        }
    }
}

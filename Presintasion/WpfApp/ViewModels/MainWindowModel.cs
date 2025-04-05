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

        private string DialogTextBoxProperty;

        public string DialogTextBox
        {
            get => DialogTextBoxProperty;
            set => Set(ref DialogTextBoxProperty, value);
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
            GetCompanyCommand = new LambdaCommand(OnGetCompany);
            GetMailsCommand = new LambdaCommand(OnGetMails);
        }

        private void MyInitBD()
        {
            DataBase.Database.EnsureDeleted();
            DataBase.Database.EnsureCreated();
            List<Company> companies = WorkClass.GetContentBD();
            DataBase.AddRange(companies.ToArray());
        }
        public ICommand GetCompanyCommand { get; }
        public ICommand GetMailsCommand { get; }

        private void OnGetCompany(object sender)
        {
            var ListCompany = DataBase.Companies.Select(x => x.ShortName);
            DialogTextBox = "";

            foreach (var company in ListCompany)
                DialogTextBox += "\r\n" + company;
        }

        private void OnGetMails(object obj)
        {
            var mails = Servis.GetAllMail();
            DialogTextBox = "";

            foreach (var mail in mails)
                DialogTextBox += "\r\n" + mail.MailName;
        }
    }
}

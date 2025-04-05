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
using WpfApp.View;

namespace WpfApp.ViewModels
{
    internal class MainWindowModel : ViewModel
    {
        ApplicationContext DataBase { get; set; }

        private readonly DataServes Servis;

        private string DialogTextBoxProperty;
        private string InputDialogTextBoxProperty;

        public string DialogTextBox
        {
            get => DialogTextBoxProperty;
            set => Set(ref DialogTextBoxProperty, value);
        }

        public string InputDialogTextBox
        {
            get => InputDialogTextBoxProperty;
            set  => Set(ref InputDialogTextBoxProperty, value);
        }

        public MainWindowModel()
        {
            Servis = new DataServes();
            DataBase = new ApplicationContext();
            DataBase.SaveChanges();
            GetCompanyCommand = new LambdaCommand(OnGetCompany);
            GetMailsCommand = new LambdaCommand(OnGetMails);
            AddCompanyCommand = new LambdaCommand(OnAddCompany);
            OpenCompanyCommand = new LambdaCommand(OnOpenWindowCompany);
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
        public ICommand AddCompanyCommand { get; }
        public  ICommand OpenCompanyCommand { get; }

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

        private void OnAddCompany(object obj)
        {
            AddCompany addCompany = new(DataBase);
            addCompany.Show();
        }

        private void OnOpenWindowCompany(object obj)
        {
            var listCompany = DataBase.Companies;
            var nameCompany = InputDialogTextBoxProperty;
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

using Microsoft.IdentityModel.Tokens;
using SoftServis.Memory;
using SoftServis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.ViewModels
{
    internal class AddCompanyModel : ViewModel
    {
        private string LongNameProperty = "Полное имя организации";

        public string LongName
        {
            get => LongNameProperty;
            set => Set(ref LongNameProperty, value);
        }

        private string ShortNameProperty = "Краткое имя организации";

        public string ShortName
        {
            get => ShortNameProperty;
            set => Set(ref ShortNameProperty, value);
        }

        private string DescriptionProperty = "Ваше описание организации";

        public string Description
        {
            get => DescriptionProperty;
            set => Set(ref DescriptionProperty, value);
        }

        private string TelephoneProperty = "Контактный телефон";

        public string Telephone
        {
            get => TelephoneProperty;
            set => Set(ref TelephoneProperty, value);
        }

        public AddCompanyModel()
        {
            OnAddCompanyCommand = new LambdaCommand(OnAddCompany);
        }

        public ICommand OnAddCompanyCommand {  get; }
        private void OnAddCompany(object sender)
        {
            var company = new Company();
            company.LongName = LongName;
            company.ShortName = ShortName;
            company.Description = Description;

            if (ValidityPhone(Telephone))
            {
                var digits = int.Parse(Telephone);
                var currentTelephone = new Telephone();
                currentTelephone.Numder = digits;
                company.Telephones.Add(currentTelephone);
            }

            DataBase.Companies.Add(company);
            DataBase.SaveChanges();
            //this.Close();
            MessageBox.Show("Вы добавили данные в базу");
            //UpdateLayout();
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

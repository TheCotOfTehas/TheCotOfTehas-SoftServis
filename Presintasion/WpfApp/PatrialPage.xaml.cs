using Microsoft.EntityFrameworkCore;
using SoftServis;
using SoftServis.Memory;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для PatrialPage.xaml
    /// </summary>
    public partial class PatrialPage : UserControl
    {
        ApplicationContext DataBase {  get; set; }
        Company CompanyCurrent { get; set; }

        DataServis Servis { get; set; }


        public PatrialPage(ApplicationContext dataBase, DataServis dataServis, Company companyCurrent)
        {
            InitializeComponent();
            DataBase = dataBase;
            Servis = dataServis;
            CompanyCurrent = companyCurrent;
        }

        private void DeleteMessage(object sender, RoutedEventArgs e)
        {
            var one = int.Parse(this.Uid);
            var three = int.Parse(CompanyCurrent.Histories.First().Id.ToString());
            var id = one - three;
            CompanyCurrent.Histories.RemoveAt(id);
            MessageBox.Show("Сообщение удалено");
            DataBase.SaveChanges();
            //Далие хрень не рабочая
            WindowCompany windowCompany = new WindowCompany(DataBase, Servis, CompanyCurrent.Id);
            windowCompany.Show();
        }
    }
}

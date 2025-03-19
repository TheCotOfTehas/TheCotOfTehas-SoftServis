using Microsoft.EntityFrameworkCore;
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
        public PatrialPage(ApplicationContext dataBase, Company companyCurrent)
        {
            InitializeComponent();
            DataBase = dataBase;
            CompanyCurrent = companyCurrent;
        }

        private void DeleteMessage(object sender, RoutedEventArgs e)
        {
           
            var histore = CompanyCurrent.Histories;
        }
    }
}

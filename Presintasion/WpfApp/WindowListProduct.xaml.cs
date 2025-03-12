using SoftServis;
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

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для WindowListProduct.xaml
    /// </summary>
    public partial class WindowListProduct : Window
    {
        public Company CompanyCurrent {  get; set; }
        public WindowListProduct(Company companyCurrent)
        {
            InitializeComponent();
            CompanyCurrent = companyCurrent;
            var listProduct = CompanyCurrent.Products;
            foreach (var product in listProduct) 
            {
                NameProgram.Text = product.Name;
                DataSell.Text = product.DatePurchase.ToString();
                LicenseValidity.Text = product.LicenseValidity.ToString();
                NameManager.Text = "Цебро Е.В.";
            }
        }
    }
}

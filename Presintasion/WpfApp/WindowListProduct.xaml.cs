using SoftServis;
using SoftServis.Memory;
using System;
using System.Collections.Generic;
using System.Data;
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
        ApplicationContext DataBase { get; set; }
        public WindowListProduct(ApplicationContext dataBase ,Company companyCurrent)
        {
            InitializeComponent();
            CompanyCurrent = companyCurrent;
            DataBase = dataBase;
            var listProduct = CompanyCurrent.Products;
            foreach (var product in listProduct) 
            {
                NameProgram.Text = product.Name;
                DataSell.Text = product.DatePurchase.ToString();
                LicenseValidity.Text = product.LicenseValidity.ToString();
                NameManager.Text = "Цебро Е.В.";
            }
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var nameProgram = NameProgramIn.Text;
            var nameManagerIn = NameManagerIn.Text;
            var dataSellIn = DataSellIn.Text;
            var licenseValidity = LicenseValidity.Text;

            var newProduct = new Product { Name = nameProgram, LicenseValidity = DateTime.Now, DatePurchase = DateTime.Now }; 
            CompanyCurrent.Products.Add(newProduct);
            MessageBox.Show("Куппленный продукт добавлен");
            DataBase.SaveChanges();
        }
    }
}

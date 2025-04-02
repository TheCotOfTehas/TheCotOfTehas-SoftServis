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
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp.View
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
            //foreach (var product in listProduct) 
            //{
            //    NameProgram.Text = product.Name;
            //    DataSell.Text = product.DatePurchase.ToString();
            //    LicenseValidity.Text = product.LicenseValidity.ToString();
            //    NameManager.Text = "Цебро Е.В.";
            //}

            for (int i = 0; i < listProduct.Count; i++)
            {
                Border borderBig = new Border();

                StackPanel stackPanelBig = new StackPanel() 
                { 
                    Orientation = Orientation.Horizontal,
                    Name = "NameProgram" + 5 + "Inner",
                };
                TextBox boxNameProgram = new TextBox() 
                {
                    Name = "NameProgram" + 5, 
                    Text = listProduct[i].Name, 
                    Width = 300,
                };
                TextBox boxDataSell = new TextBox()
                {
                    Name = "DataSell" + 5,
                    Text = listProduct[i].DatePurchase.ToString(),
                    Width = 100,
                };

                TextBox boxLicenseValidity = new TextBox()
                {
                    Name = "LicenseValidity" + 5,
                    Text = listProduct[i].LicenseValidity.ToString(),
                    Width = 100,
                };

                TextBox boxNameManager = new TextBox()
                {
                    Name = "NameManager" + 5,
                    Text = "Цебро Е.В.",
                    Width = 70,
                };

                var borderNameProgram = GetElementTable(boxNameProgram);
                var borderDataSell = GetElementTable(boxDataSell);
                var borderLicenseValidity = GetElementTable(boxLicenseValidity);
                var borderNameManager = GetElementTable(boxNameManager);
                borderBig.Child = stackPanelBig;
                stackPanelBig.Children.Add(borderNameProgram);
                stackPanelBig.Children.Add(borderDataSell);
                stackPanelBig.Children.Add(borderLicenseValidity);
                stackPanelBig.Children.Add(borderNameManager);
                //stackPanelBig.Children.Add(new PatrialPage());
                //stackPanelBig.Children.Add(new PatrialPage());
                //stackPanelBig.Children.Add(new PatrialPage());
                GGWP.Children.Add(borderBig);
                //GGWP.Children.Add(new PatrialPage());
            }
        }

        private static Border GetElementTable(TextBox textBox)
        {
            Border borderNameProgram = new Border();
            borderNameProgram.Child = textBox;
            return borderNameProgram;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var nameProgram = NameProgramIn.Text;
            var nameManagerIn = NameManagerIn.Text;
            var dataSellIn = DataSellIn.Text;
            var licenseValidity = LicenseValidityIn.Text;

            var newProduct = new Product { Name = nameProgram, LicenseValidity = DateTime.Now, DatePurchase = DateTime.Now }; 
            CompanyCurrent.Products.Add(newProduct);
            MessageBox.Show("Куппленный продукт добавлен");
            DataBase.SaveChanges();
        }
    }
}

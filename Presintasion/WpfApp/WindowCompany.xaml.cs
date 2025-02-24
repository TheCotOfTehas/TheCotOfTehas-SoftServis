using Microsoft.Data.SqlClient;
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
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для WindowCompany.xaml
    /// </summary>
    public partial class WindowCompany : Window
    {
        Company CompanyCurrent {  get; set; }
        public WindowCompany(Company company)
        {
            InitializeComponent();
            FullName.Text = company.LongName;
            ShortName.Text = company.ShortName;
            Mails.Text = company.Mailes.First()?.MailName;
            INN.Text =  company.Id.ToString();
            CompanyCurrent = company;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var text = HistoriBox.Text;
            var date = DateTime.Now;
            HistoriBlock.Text += $"{text}  {date} ";
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {

            using (ApplicationContext db = new())
            {
                var dd = db.companies.Where(x => x.Id == CompanyCurrent.Id).FirstOrDefault();
                if (CompanyCurrent != null)
                {
                    dd.LongName = FullName.Text;
                    dd.ShortName = ShortName.Text;
                    dd.Id = int.Parse(INN.Text);
                    dd.Mailes.Add(new Mail() { MailName = Mails.Text });

                    db.SaveChanges();
                }
            }

            //db.Database.
            //string connectionString = @"Data Source=(localdb)\mssqllocaldb; Database=dbCompany; Trusted_Connection=True;";
            //string sqlExpression = $"UPDATE сompanies SET Age={20} WHERE ShortName = {CompanyCurrent.ShortName}";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlCommand command = new SqlCommand(sqlExpression, connection);
            //    int number = command.ExecuteNonQuery();
            //    Console.WriteLine("Удалено объектов: {0}", number);
            //}
        }
    }
}

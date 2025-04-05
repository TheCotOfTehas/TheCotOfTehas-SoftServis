using Microsoft.Win32;
using SoftServis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp
{
    //internal class OpenDialog : Freezable
    //{

    //    public static readonly DependencyProperty GetEmailProperty = DependencyProperty.Register(
    //        nameof(GetEmail),
    //        typeof(string),
    //        typeof(OpenDialog),
    //        new PropertyMetadata(default(string)));
    //    public string GetEmail
    //    {
    //        get => (string)GetValue(GetEmailProperty);
    //        set => SetValue(GetEmailProperty, value);
    //    }

    //    public ICommand GetEmailsCommand { get; }

    //    public OpenDialog() 
    //    {
    //        GetEmailsCommand = new LambdaCommand(OnGetEmails);
    //    }

    //    protected override Freezable CreateInstanceCore()
    //    {
    //        return new OpenDialog();
    //    }

    //    private void OnGetEmails(object sender)
    //    {
    //        //var ListCompany = DataBase.Companies.Select(x => x.ShortName);

    //        //var mails = Servis.GetAllMail();

    //        //foreach (var company in ListCompany)
    //        //{
    //        //    GetEmailProperty += "\r\n" + company;
    //        //}

    //        //GetEmail += mails;

    //        var dlg = new OpenFileDialog
    //        {
    //            Title = "Title1",
    //            Filter = "Filter1",
    //            RestoreDirectory = true,
    //            InitialDirectory = Environment.CurrentDirectory
    //        };

    //        if (dlg.ShowDialog() != true) return;

    //        GetEmail += "Азазазазазазаззаз";
    //    }
    //}
}

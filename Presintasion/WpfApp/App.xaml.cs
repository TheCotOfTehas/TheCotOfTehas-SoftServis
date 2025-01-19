using Microsoft.Extensions.DependencyInjection;
using SoftServis.Memory;
using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ServiceCollection serviceCollection;
        ServiceProvider serviceProvider;
        protected override void OnStartup(StartupEventArgs e)
        {
            serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<DataServis>();    
            serviceCollection.AddScoped<MainWindow>();
            serviceProvider = serviceCollection.BuildServiceProvider();
            base.OnStartup(e);

            MainWindow mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}

using SoftServis;
using System.Windows;
using WpfApp.ViewModels;

namespace WpfApp.View
{
    public partial class WindowLogin : Window, ICloseable
    {
        public WindowLogin()
        {
            InitializeComponent();// это рисует View
            WindowLoginModel vm = new WindowLoginModel(); // это создает экземпляр ViewModel
            DataContext = vm; // это устанавливает недавно созданную ViewModel в качестве DataContext для View
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => this.Close());
        }
    }
}

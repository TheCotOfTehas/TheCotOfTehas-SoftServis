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
    internal class LambdaCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private readonly Action<object> f_Exequte;
        private readonly Func<object, bool> f_CanExecute;

        public LambdaCommand(Action<object> Exequte, Func<object, bool> CanExecute = null)
        {
            f_Exequte = Exequte ?? throw new ArgumentNullException(nameof(Execute));
            f_CanExecute = CanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return f_CanExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object? parameter)
        {
            f_Exequte.Invoke(parameter);
        }
    }
}

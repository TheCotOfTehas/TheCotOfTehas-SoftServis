﻿using GalaSoft.MvvmLight.Command;
using SoftServis;
using SoftServis.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp
{
    internal class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected static DataServes Serves { get; set; }
        protected static ApplicationContext DataBase { get; set; }
        public Action CloseAction { get; set; }

        static ViewModel() 
        {
            Serves = new DataServes();
            DataBase = new ApplicationContext();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}

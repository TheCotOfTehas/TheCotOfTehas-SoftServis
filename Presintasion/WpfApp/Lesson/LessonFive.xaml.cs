﻿using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для LessonFive.xaml
    /// </summary>
    public partial class LessonFive : Window
    {
        public LessonFive()
        {
            InitializeComponent();
        }

        private void Button_ReadText(object sender, RoutedEventArgs e)
        {
            if (File.Exists("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\Текст.txt"))
            {
                using StreamReader strRdrText = new StreamReader("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\Текст.txt");
                string text = strRdrText.ReadToEnd();
                OutputBox.Text = text;
            }
            else
            {
                MessageBox.Show("Файла для записи не существует");
            }
        }

        private void Button_WriteText(object sender, RoutedEventArgs e)
        {
            if (File.Exists("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\Текст.txt"))
            {
                string text = InputBox.Text.ToString();
                using StreamWriter strWriter = new StreamWriter("C:\\Users\\tsebr\\OneDrive\\Рабочий стол\\Текст.txt", true);
                strWriter.WriteLine(text);
            }
            else
            {
                MessageBox.Show("Файла для чтения не существует");
            }
        }
    }
}

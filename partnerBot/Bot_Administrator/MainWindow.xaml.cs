using Bot_Administrator.CRUD;
using Microsoft.Win32;
using partnerBot;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bot_Administrator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Teacher temp = new Teacher();
        public MainWindow()
        {
            InitializeComponent();
            //Background = new ImageBrush(new BitmapImage(new Uri("..\\..\\LogoLNU.gif")));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //partnerBot.Teacher temp = new partnerBot.Teacher();
            temp.Name = NameBox.Text;
            temp.Surname = SurnameBox.Text;
            temp.Fathername = FatherBox.Text;
            temp.Position = PositionBox.Text;
            temp.Depart = DepartBox.Items[DepartBox.SelectedIndex].ToString();
        }

        private void BiographyBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BiographyBox.Text = "";
        }

        private void PhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            dialog.Multiselect = false;
            dialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            temp.Photo = "D:\\Studying\\Курсова\\LNUBot\\partnerBot\\Teacher\\" + Transliter.GetTranslit(dialog.FileName);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DeleteTCanvas.Visibility = Visibility.Hidden;
        }
    }
}

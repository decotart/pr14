using System;
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

namespace pr13
{
    /// <summary>
    /// Логика взаимодействия для Parameters.xaml
    /// </summary>
    public partial class Parameters : Window
    {

        public Parameters()
        {
            InitializeComponent();
        }

        private void btnCreateNewPassword_Click(object sender, RoutedEventArgs e)
        {
            CreateNewPassword pasWindow = new();
            pasWindow.Owner = this;
            pasWindow.Show();
        }

        private void btnSaveSize_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int m = Convert.ToInt32(tbM.Text),
                    n = Convert.ToInt32(tbN.Text);

                MessageBoxResult result = MessageBox.Show("Сохранить этот размер?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    ArrayMod.SaveFile(ConfigFile.Path, $"{m}\n{n}");

                    tbN.Clear();
                    tbM.Clear();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Размер может быть только целочисленным!");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
        }
    }
}

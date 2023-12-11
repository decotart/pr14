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
            pasWindow.Show();
        }

        private void btnSaveSize_Click(object sender, RoutedEventArgs e)
        {
            bool f1 = int.TryParse(tbM.Text, out int m),
                f2 = int.TryParse(tbN.Text, out int n);

            if (f1 && f2)
            {
                ArrayMod.SaveFile(ConfigFile.Path, $"{m}\n{n}");
            }
            else
            {
                MessageBox.Show("Размер может иметь только целочисленные значения!");
            }
        }
    }
}

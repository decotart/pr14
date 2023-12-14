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
using System.IO;

namespace pr13
{
    /// <summary>
    /// Логика взаимодействия для CreateNewPassword.xaml
    /// </summary>
    public partial class CreateNewPassword : Window
    {
        public CreateNewPassword()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Сохранить этот пароль?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                StreamWriter file = new(PasswordFile.Path);

                file.WriteLine(tbPassword.Text, true);

                file.Close();

                Owner.Close();
                Owner.Owner.Hide();
                Owner.Owner.Owner.Show();
            }
        }
    }
}

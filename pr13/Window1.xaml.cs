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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {     
        public Window1()
        {
            InitializeComponent();
        }

        MainWindow main = new();

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader file = new(PasswordFile.Path);

                string password = file.ReadLine(),
                    enteredPassword = tbEnteredPassword.Text;

                if (enteredPassword == password)
                {
                    this.Close();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Пароль не верный");
                    tbEnteredPassword.Clear();
                }
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Что-то пошло не так! {ex.Message}");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

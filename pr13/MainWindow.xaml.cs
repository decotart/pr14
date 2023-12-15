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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace pr13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int[,] matrix;

        DispatcherTimer timer;
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                matrix = ArrayMod.OpenFile(ConfigFile.Path);
                dataGid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
            catch { }

            timer = new();
            timer.Tick += Timer_Tick;
            timer.Interval = new(0, 0, 0, 1, 0);
            timer.IsEnabled = true;

            tbNumber.Text = "Практическая работа №13";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            tbTime.Text = date.ToString("HH:mm:ss");
            tbDate.Text = date.ToString("dd.MM.yyyy");
        }

        private void btnFIll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ArrayMod.FillRandon(ref matrix);
                dataGid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
            catch
            {
                MessageBox.Show("Таблица не была создана");
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(tbN.Text),
                    m = Convert.ToInt32(tbM.Text);

                matrix = new int[m, n];

                dataGid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
            catch (FormatException)
            {
                MessageBox.Show("Вводите только целочисленные значения");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int result = Soluiton.GetResult(matrix);

                tbResult.Text = result.ToString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Таблица не была создана");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("О программе");
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ArrayMod.Save(matrix);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Таблица не была создана");
            }
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                matrix = ArrayMod.Open();
                dataGid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void dataGrid_CellEditing(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                int index0 = e.Column.DisplayIndex;
                int index1 = e.Row.GetIndex();

                int value = int.Parse(((TextBox)e.EditingElement).Text);
                matrix[index1, index0] = value;
            }
            catch (FormatException)
            {
                MessageBox.Show("Вводите только целочисленные значения");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }

            tbResult.Clear();
        }

        private void btnParameters_Click(object sender, RoutedEventArgs e)
        {
            Parameters pramWindow = new();
            pramWindow.Owner = this;
            pramWindow.Show();
        }

        private void btnOpenSavedTable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                matrix = ArrayMod.OpenFile(ConfigFile.Path);
                dataGid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            }
            catch 
            {
                MessageBox.Show("Что-то пошло не так!");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}

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

namespace ValueConverter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Индекс 0
        /// <summary>
        /// Список измерений объёма.
        /// </summary>
        static List<string> cubMetres = new List<string>
        {
            "Милиметры, куб", "Cантиметры, куб", "Километры, куб"
        };

        // Индекс 1
        /// <summary>
        /// Список измерений расстояния.
        /// </summary>
        static List<string> metres = new List<string>
        {
            "Милиметры", "Cантиметры", "Километры"
        };

        // Индекс 2
        /// <summary>
        /// Список измерений массы.
        /// </summary>
        static List<string> weight = new List<string>
        {
            "Милиграммы", "Граммы", "Килограммы", 
            "Центнеры", "Тонны", "Килотонны"
        };

        // Индекс 3
        /// <summary>
        /// Список измерений времени.
        /// </summary>
        static List<string> time = new List<string>
        {
            "Милисекунды", "Секунды", "Минуты",
            "Часы", "Дни", "Годы"
        };

        public MainWindow()
        {
            InitializeComponent();
            comboBoxForm.SelectedIndex = 0;

            if(comboBoxForm.SelectedIndex == 0)
            {
                comboBoxForm.ItemsSource = null;
                comboBoxDefault.ItemsSource = cubMetres;
                comboBoxDefault.SelectedIndex = 0;

                comboBoxTarget.ItemsSource = cubMetres;
                comboBoxTarget.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Изменяет comboBox в зависимости от формы конвертации.
        /// </summary>
        private void comboBoxForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxDefault.ItemsSource = null;
            if (comboBoxForm.SelectedIndex == 0)
            {
                comboBoxDefault.Items.Clear();
                comboBoxDefault.ItemsSource = cubMetres;
                comboBoxDefault.SelectedIndex = 0;

                comboBoxTarget.ItemsSource = cubMetres;
                comboBoxTarget.SelectedIndex = 0;
            }
            if (comboBoxForm.SelectedIndex == 1)
            {
                comboBoxDefault.Items.Clear();
                comboBoxDefault.ItemsSource = metres;
                comboBoxDefault.SelectedIndex = 0;

                comboBoxTarget.ItemsSource = metres;
                comboBoxTarget.SelectedIndex = 0;
            }
            if (comboBoxForm.SelectedIndex == 2)
            {
                comboBoxDefault.Items.Clear();
                comboBoxDefault.ItemsSource = weight;
                comboBoxDefault.SelectedIndex = 0;

                comboBoxTarget.ItemsSource = weight;
                comboBoxTarget.SelectedIndex = 0;
            }
            if (comboBoxForm.SelectedIndex == 3)
            {
                comboBoxDefault.Items.Clear();
                comboBoxDefault.ItemsSource = time;
                comboBoxDefault.SelectedIndex = 0;

                comboBoxTarget.ItemsSource = time;
                comboBoxTarget.SelectedIndex = 0;
            }
        }

        private void button_1_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "1";
        }

        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "2";
        }

        private void button_3_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "3";
        }

        private void button_4_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "4";
        }

        private void button_5_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "5";
        }

        private void button_6_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "6";
        }

        private void button_7_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "7";
        }

        private void button_8_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "8";
        }

        private void button_9_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "9";
        }

        private void button_0_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "0";
        }

        private void button_addit_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "+";
        }

        private void button_sub_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "-";
        }

        private void button_mult_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "*";
        }

        private void button_divid_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "/";
        }

        private void button_C_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
        }

        private void button_point_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += ",";
        }

        private void button_del_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
        }
    }
}

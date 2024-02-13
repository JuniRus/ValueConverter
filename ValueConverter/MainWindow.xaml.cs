using System;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;

namespace ValueConverter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Lists
        // Индекс 0
        /// <summary>
        /// Список измерений объёма.
        /// </summary>
        static List<string> cubMetres = new List<string>
        {
            "Cантиметры^2", "Метры^2", "Километры^2"
        };

        // Индекс 1
        /// <summary>
        /// Список измерений расстояния.
        /// </summary>
        static List<string> metres = new List<string>
        {
            "Милиметры", "Cантиметры", "Дециметры", "Метры", "Километры"
        };

        // Индекс 2
        /// <summary>
        /// Список измерений массы.
        /// </summary>
        static List<string> weight = new List<string>
        {
            "Милиграммы", "Граммы", "Килограммы", 
            "Центнеры", "Тонны"
        };

        // Индекс 3
        /// <summary>
        /// Список измерений времени.
        /// </summary>
        static List<string> time = new List<string>
        {
            "Милисекунды", "Секунды", "Минуты",
            "Часы", "Дни"
        };
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            comboBoxForm.SelectedIndex = 0;
            textBox.Focus();

            // В самом начале отобразить форму в виде площади.
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
        private void ComboBoxForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxDefault.ItemsSource = null;
            // Отобразить форму площади.
            if (comboBoxForm.SelectedIndex == 0)
            {
                comboBoxDefault.Items.Clear();
                comboBoxDefault.ItemsSource = cubMetres;
                comboBoxDefault.SelectedIndex = 0;

                comboBoxTarget.ItemsSource = cubMetres;
                comboBoxTarget.SelectedIndex = 0;
            }
            // Отобразить форму расстояния.
            if (comboBoxForm.SelectedIndex == 1)
            {
                comboBoxDefault.Items.Clear();
                comboBoxDefault.ItemsSource = metres;
                comboBoxDefault.SelectedIndex = 0;

                comboBoxTarget.ItemsSource = metres;
                comboBoxTarget.SelectedIndex = 0;
            }
            // Отобразить форму массы.
            if (comboBoxForm.SelectedIndex == 2)
            {
                comboBoxDefault.Items.Clear();
                comboBoxDefault.ItemsSource = weight;
                comboBoxDefault.SelectedIndex = 0;

                comboBoxTarget.ItemsSource = weight;
                comboBoxTarget.SelectedIndex = 0;
            }
            // Отобразить форму времени.
            if (comboBoxForm.SelectedIndex == 3)
            {
                comboBoxDefault.Items.Clear();
                comboBoxDefault.ItemsSource = time;
                comboBoxDefault.SelectedIndex = 0;

                comboBoxTarget.ItemsSource = time;
                comboBoxTarget.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Конвертация величин.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_enter_Click(object sender, RoutedEventArgs e)
        {
            double value;
            // Установить надпись состояния в false.s
            statusLabel.Content = "";

            // Если строка пустая.
            if(textBox.Text == "" || textBox.Text == null)
            {
                e.Handled = true;
                return;
            }

            // Если в строке есть буквы.
            if(textBox.Text.Any(c => char.IsLetter(c)))
            {
                statusLabel.Content = "Ввод не должен содержать букв!";
                e.Handled = true;
                return;
            }

            try
            {
                // Посчитать числовое выражение и вывести его.
                DataTable dataTable = new DataTable();
                value = Convert.ToDouble(dataTable.Compute(textBox.Text, ""));
                textBox.Text = value.ToString();
            }
            catch (SyntaxErrorException)
            {
                e.Handled = true;
                statusLabel.Content = "Разделителем должна выступать точка или неверное" +
                                      " использование арифметических операторов.";
                return;
            }
            catch(Exception)
            {
                e.Handled = true;
                statusLabel.Content = "Произошла неизвестная ошибка.";
                return;
            }

            // При выборке площади.
            if(comboBoxForm.SelectedIndex == 0)
            {
                double result;

                // Площадь.
                #region Santimetres
                // Сантиметры --> Метры
                if (comboBoxDefault.SelectedIndex == 0 && comboBoxTarget.SelectedIndex == 1)
                {
                    result = value / 10000;
                    textBox.Text = result.ToString();
                }
                // Сантиметры --> Километры
                else if (comboBoxDefault.SelectedIndex == 0 && comboBoxTarget.SelectedIndex == 2)
                {
                    result = value / Math.Pow(10, 10);
                    textBox.Text = result.ToString();
                }
                #endregion

                #region Metres
                // Метры --> Сантиметры
                else if (comboBoxDefault.SelectedIndex == 1 && comboBoxTarget.SelectedIndex == 0)
                {
                    result = value * 10000;
                    textBox.Text = result.ToString();
                }
                // Метры --> Километры
                else if (comboBoxDefault.SelectedIndex == 1 && comboBoxTarget.SelectedIndex == 2)
                {
                    result = value / 1000000;
                    textBox.Text = result.ToString();
                }
                #endregion

                #region Kilometres
                // Километры --> Сантиметры
                else if (comboBoxDefault.SelectedIndex == 2 && comboBoxTarget.SelectedIndex == 0)
                {
                    result = value * Math.Pow(10, 10);
                    textBox.Text = result.ToString();
                }
                // Километры --> Метры
                else if (comboBoxDefault.SelectedIndex == 2 && comboBoxTarget.SelectedIndex == 1)
                {
                    result = value * 1000000;
                    textBox.Text = result.ToString();
                }
                #endregion
            }

            // При выборке расстояния.
            if(comboBoxForm.SelectedIndex == 1)
            {
                double result;

                #region Milimetres
                // Милиметры в сантиметры.
                if (comboBoxDefault.SelectedIndex == 0 && comboBoxTarget.SelectedIndex == 1)
                {
                    result = value / 10;
                    textBox.Text = result.ToString();
                }
                // Милиметры в дециметры.
                else if(comboBoxDefault.SelectedIndex == 0 && comboBoxTarget.SelectedIndex == 2)
                {
                    result = value / 100;
                    textBox.Text = result.ToString();
                }
                // Милиметры в метры.
                else if (comboBoxDefault.SelectedIndex == 0 && comboBoxTarget.SelectedIndex == 3)
                {
                    result = value / 1000;
                    textBox.Text = result.ToString();
                }
                // Милиметры в километры.
                else if (comboBoxDefault.SelectedIndex == 0 && comboBoxTarget.SelectedIndex == 4)
                {
                    result = value / 1000000;
                    textBox.Text = result.ToString();
                }
                #endregion

                #region Santymetres
                // Сантиметры в милиметры.
                if (comboBoxDefault.SelectedIndex == 1 && comboBoxTarget.SelectedIndex == 0)
                {
                    result = value * 10;
                    textBox.Text = result.ToString();
                }
                // Сантиметры в дециметры.
                else if (comboBoxDefault.SelectedIndex == 1 && comboBoxTarget.SelectedIndex == 2)
                {
                    result = value / 10;
                    textBox.Text = result.ToString();
                }
                // Сантиметры в метры.
                else if (comboBoxDefault.SelectedIndex == 1 && comboBoxTarget.SelectedIndex == 3)
                {
                    result = value / 100;
                    textBox.Text = result.ToString();
                }
                // Сантиметры в километры.
                else if (comboBoxDefault.SelectedIndex == 1 && comboBoxTarget.SelectedIndex == 3)
                {
                    result = value / 100000;
                    textBox.Text = result.ToString();
                }
                #endregion

                #region Decimetres
                // Дециметры в милиметры.
                if (comboBoxDefault.SelectedIndex == 2 && comboBoxTarget.SelectedIndex == 0)
                {
                    result = value * 100;
                    textBox.Text = result.ToString();
                }
                // Дециметры в сантиметры.
                else if(comboBoxDefault.SelectedIndex == 2 && comboBoxTarget.SelectedIndex == 1)
                {
                    result = value * 10;
                    textBox.Text = result.ToString();
                }
                // Дециметры в метры.
                else if(comboBoxDefault.SelectedIndex == 2 && comboBoxTarget.SelectedIndex == 3)
                {
                    result = value / 10;
                    textBox.Text = result.ToString();
                }
                // Дециметры в километры.
                else if(comboBoxDefault.SelectedIndex == 2 && comboBoxTarget.SelectedIndex == 4)
                {
                    result = value / 10000;
                    textBox.Text = result.ToString();
                }
                #endregion

                #region Metres
                // Метры --> милиметры
                if (comboBoxDefault.SelectedIndex == 3 && comboBoxTarget.SelectedIndex == 0)
                {
                    result = value * 1000;
                    textBox.Text = result.ToString();
                }
                // Метры --> сантиметры
                else if (comboBoxDefault.SelectedIndex == 3 && comboBoxTarget.SelectedIndex == 1)
                {
                    result = value * 100;
                    textBox.Text = result.ToString();
                }
                // Метры --> дециметры
                else if (comboBoxDefault.SelectedIndex == 3 && comboBoxTarget.SelectedIndex == 2)
                {
                    result = value * 10;
                    textBox.Text = result.ToString();
                }
                // Метры --> километры
                else if (comboBoxDefault.SelectedIndex == 3 && comboBoxTarget.SelectedIndex == 4)
                {
                    result = value / 1000;
                    textBox.Text = result.ToString();
                }
                #endregion

                #region Kilometres
                // Километры --> милиметры
                if (comboBoxDefault.SelectedIndex == 4 && comboBoxTarget.SelectedIndex == 0)
                {
                    result = value * 1000000;
                    textBox.Text = result.ToString();
                }
                // Километры --> сантиметры
                else if (comboBoxDefault.SelectedIndex == 4 && comboBoxTarget.SelectedIndex == 1)
                {
                    result = value * 100000;
                    textBox.Text = result.ToString();
                }
                // Километры --> дециметры
                else if (comboBoxDefault.SelectedIndex == 4 && comboBoxTarget.SelectedIndex == 2)
                {
                    result = value * 10000;
                    textBox.Text = result.ToString();
                }
                // Километры --> метры
                else if (comboBoxDefault.SelectedIndex == 4 && comboBoxTarget.SelectedIndex == 3)
                {
                    result = value * 1000;
                    textBox.Text = result.ToString();
                }
                #endregion
            }

            // При выборке массы.
            if(comboBoxForm.SelectedIndex == 2)
            {
                double result;

                #region Milligrams
                // Милиграммы в граммы.
                if (comboBoxDefault.SelectedIndex == 0 && comboBoxTarget.SelectedIndex == 1)
                {
                    result = value / 1000;
                    textBox.Text = result.ToString();
                }

                // Милиграммы в килограммы.
                else if (comboBoxDefault.SelectedIndex == 0 && comboBoxTarget.SelectedIndex == 2)
                {
                    result = value / Math.Pow(10, 6);
                    textBox.Text = result.ToString();
                }

                // Милиграммы в центнеры.
                else if (comboBoxDefault.SelectedIndex == 0 && comboBoxTarget.SelectedIndex == 3)
                {
                    result = value / Math.Pow(10, 8);
                    textBox.Text = result.ToString();
                }

                // Милиграммы в тонны.
                else if (comboBoxDefault.SelectedIndex == 0 && comboBoxTarget.SelectedIndex == 4)
                {
                    result = value / Math.Pow(10, 9);
                    textBox.Text = result.ToString();
                }
                #endregion

                #region Grams
                // Граммы --> милиграммы.
                if (comboBoxDefault.SelectedIndex == 1 && comboBoxTarget.SelectedIndex == 0)
                {
                    result = value * 1000;
                    textBox.Text = result.ToString();
                }

                // Граммы --> килограммы.
                else if(comboBoxDefault.SelectedIndex == 1 && comboBoxTarget.SelectedIndex == 2)
                {
                    result = value / 1000;
                    textBox.Text = result.ToString();
                }

                // Граммы --> центнеры.
                else if (comboBoxDefault.SelectedIndex == 1 && comboBoxTarget.SelectedIndex == 3)
                {
                    result = value / 100000;
                    textBox.Text = result.ToString();
                }

                // Граммы --> Тонны.
                else if (comboBoxDefault.SelectedIndex == 1 && comboBoxTarget.SelectedIndex == 4)
                {
                    result = value / Math.Pow(10, 6);
                    textBox.Text = result.ToString();
                }
                #endregion

                #region Kilograms
                // Килограммы --> милиграммы.
                if (comboBoxDefault.SelectedIndex == 2 && comboBoxTarget.SelectedIndex == 0)
                {
                    result = value * Math.Pow(10, 6);
                    textBox.Text = result.ToString();
                }

                // Килограммы --> граммы.
                else if (comboBoxDefault.SelectedIndex == 2 && comboBoxTarget.SelectedIndex == 1)
                {
                    result = value * 1000;
                    textBox.Text = result.ToString();
                }

                // Килограммы --> центнеры.
                else if (comboBoxDefault.SelectedIndex == 2 && comboBoxTarget.SelectedIndex == 3)
                {
                    result = value / 100;
                    textBox.Text = result.ToString();
                }

                // Килограммы --> тонны.
                else if (comboBoxDefault.SelectedIndex == 2 && comboBoxTarget.SelectedIndex == 4)
                {
                    result = value / 1000;
                    textBox.Text = result.ToString();
                }
                #endregion

                #region Centers
                // Центнеры --> милиграммы.
                if (comboBoxDefault.SelectedIndex == 3 && comboBoxTarget.SelectedIndex == 0)
                {
                    result = value * Math.Pow(10, 8);
                    textBox.Text = result.ToString();
                }

                // Центнеры --> граммы.
                else if (comboBoxDefault.SelectedIndex == 3 && comboBoxTarget.SelectedIndex == 1)
                {
                    result = value * Math.Pow(10, 5);
                    textBox.Text = result.ToString();
                }

                // Центнеры --> килограммы.
                else if (comboBoxDefault.SelectedIndex == 3 && comboBoxTarget.SelectedIndex == 2)
                {
                    result = value * 100;
                    textBox.Text = result.ToString();
                }

                // Центнеры --> Тонны.
                else if (comboBoxDefault.SelectedIndex == 3 && comboBoxTarget.SelectedIndex == 4)
                {
                    result = value / 10;
                    textBox.Text = result.ToString();
                }
                #endregion

                #region Kilograms
                // Тонны --> милиграммы.
                if (comboBoxDefault.SelectedIndex == 4 && comboBoxTarget.SelectedIndex == 0)
                {
                    result = value * Math.Pow(10, 9);
                    textBox.Text = result.ToString();
                }

                // Тонны --> граммы.
                if (comboBoxDefault.SelectedIndex == 4 && comboBoxTarget.SelectedIndex == 1)
                {
                    result = value * Math.Pow(10, 6);
                    textBox.Text = result.ToString();
                }

                // Тонны --> килограммы.
                if (comboBoxDefault.SelectedIndex == 4 && comboBoxTarget.SelectedIndex == 2)
                {
                    result = value * 1000;
                    textBox.Text = result.ToString();
                }

                // Тонны --> Центнеры.
                if (comboBoxDefault.SelectedIndex == 4 && comboBoxTarget.SelectedIndex == 3)
                {
                    result = value * 10;
                    textBox.Text = result.ToString();
                }
                #endregion
            }

            // При выборке времени.
            if(comboBoxForm.SelectedIndex == 3)
            {
                double result;

                #region Milliseconds
                // Милисекунды --> Секунды.
                if (comboBoxDefault.SelectedIndex == 0 && comboBoxTarget.SelectedIndex == 1)
                {
                    result = value / 1000;
                    textBox.Text = result.ToString();
                }

                // Милисекунды --> Минуты.
                else if (comboBoxDefault.SelectedIndex == 0 && comboBoxTarget.SelectedIndex == 2)
                {
                    result = value / 60000;
                    textBox.Text = result.ToString();
                }

                // Милисекунды --> Часы.
                else if (comboBoxDefault.SelectedIndex == 0 && comboBoxTarget.SelectedIndex == 3)
                {
                    result = value / (36 * Math.Pow(10, 5));
                    textBox.Text = result.ToString();
                }

                // Милисекунды --> Дни.
                else if (comboBoxDefault.SelectedIndex == 0 && comboBoxTarget.SelectedIndex == 4)
                {
                    result = value / (864 * Math.Pow(10, 5));
                    textBox.Text = result.ToString();
                }
                #endregion

                #region Seconds
                // Секунды --> милисекунды.
                if (comboBoxDefault.SelectedIndex == 1 && comboBoxTarget.SelectedIndex == 0)
                {
                    result = value * 1000;
                    textBox.Text = result.ToString();
                }

                // Секунды --> минуты.
                else if (comboBoxDefault.SelectedIndex == 1 && comboBoxTarget.SelectedIndex == 2)
                {
                    result = value / 60;
                    textBox.Text = result.ToString();
                }

                // Секунды --> часы.
                else if (comboBoxDefault.SelectedIndex == 1 && comboBoxTarget.SelectedIndex == 3)
                {
                    result = value / 3600;
                    textBox.Text = result.ToString();
                }

                // Секунды --> дни.
                else if (comboBoxDefault.SelectedIndex == 1 && comboBoxTarget.SelectedIndex == 4)
                {
                    result = value / 86400;
                    textBox.Text = result.ToString();
                }
                #endregion

                #region Minutes
                // Минуты --> Милисекунды.
                if (comboBoxDefault.SelectedIndex == 2 && comboBoxTarget.SelectedIndex == 0)
                {
                    result = value * 60000;
                    textBox.Text = result.ToString();
                }

                // Минуты --> секунды.
                else if (comboBoxDefault.SelectedIndex == 2 && comboBoxTarget.SelectedIndex == 1)
                {
                    result = value * 60;
                    textBox.Text = result.ToString();
                }

                // Минуты --> часы.
                else if (comboBoxDefault.SelectedIndex == 2 && comboBoxTarget.SelectedIndex == 3)
                {
                    result = value / 60;
                    textBox.Text = result.ToString();
                }

                // Минуты --> дни.
                else if (comboBoxDefault.SelectedIndex == 2 && comboBoxTarget.SelectedIndex == 4)
                {
                    result = value / 1440;
                    textBox.Text = result.ToString();
                }
                #endregion

                #region Hours
                // Часы --> милисекунды.
                if (comboBoxDefault.SelectedIndex == 3 && comboBoxTarget.SelectedIndex == 0)
                {
                    result = value * (36 * Math.Pow(10, 5));
                    textBox.Text = result.ToString();
                }

                // Часы --> секунды.
                else if (comboBoxDefault.SelectedIndex == 3 && comboBoxTarget.SelectedIndex == 1)
                {
                    result = value * 3600;
                    textBox.Text = result.ToString();
                }

                // Часы --> минуты.
                else if (comboBoxDefault.SelectedIndex == 3 && comboBoxTarget.SelectedIndex == 2)
                {
                    result = value * 60;
                    textBox.Text = result.ToString();
                }

                // Часы --> Дни.
                else if (comboBoxDefault.SelectedIndex == 3 && comboBoxTarget.SelectedIndex == 4)
                {
                    result = value / 24;
                    textBox.Text = result.ToString();
                }
                #endregion

                #region Days
                // Дни --> милисекунды.
                if (comboBoxDefault.SelectedIndex == 4 && comboBoxTarget.SelectedIndex == 0)
                {
                    result = value * (864 * Math.Pow(10, 5));
                    textBox.Text = result.ToString();
                }

                // Дни --> секунды.
                else if (comboBoxDefault.SelectedIndex == 4 && comboBoxTarget.SelectedIndex == 1)
                {
                    result = value * 86400;
                    textBox.Text = result.ToString();
                }

                // Дни --> минуты.
                else if (comboBoxDefault.SelectedIndex == 4 && comboBoxTarget.SelectedIndex == 2)
                {
                    result = value * 1440;
                    textBox.Text = result.ToString();
                }

                // Дни --> часы.
                else if (comboBoxDefault.SelectedIndex == 4 && comboBoxTarget.SelectedIndex == 3)
                {
                    result = value * 24;
                    textBox.Text = result.ToString();
                }
                #endregion
            }
        }

        #region Buttons
        private void button_1_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "1";
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "2";
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void button_3_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "3";
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void button_4_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "4";
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void button_5_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "5";
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void button_6_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "6";
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void button_7_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "7";
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void button_8_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "8";
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void button_9_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "9";
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void button_0_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "0";
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void button_addit_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "+";
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void button_sub_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "-";
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void button_mult_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "*";
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void button_divid_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "/";
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void button_C_Click(object sender, RoutedEventArgs e)
        {
            statusLabel.Content = "";
            textBox.Text = "";
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void button_point_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += ".";
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void button_del_Click(object sender, RoutedEventArgs e)
        {
            statusLabel.Content = "";
            textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }
        #endregion
    }
}

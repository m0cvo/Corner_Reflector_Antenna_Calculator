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

namespace Corner_Reflector_Antenna_Calculator
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();
            this.Hide();
        }

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double freqIn;
                //
                //Test for valid input
                //if (freqBox.Text == null) { MessageBox.Show("Please enter a numerical value for the frequency!"); }                    
                bool isNumeric = double.TryParse(freqBox.Text, out double n);
                if (isNumeric == false) { MessageBox.Show("please enter numerical value only!"); }
                
                //convert text input to numerical double
                freqIn = double.Parse(freqBox.Text);
                //adn ensure value is greater than 0
                if(freqIn <= 0) { MessageBox.Show("Please enter a frequency > 0!"); }

                //Radio button selection
                if (RBtn1.IsChecked == true)
                    gainBox.Text = "3.33";
                else if (RBtn2.IsChecked == true)
                    gainBox.Text = "5";
                else if (RBtn3.IsChecked == true)
                    gainBox.Text = "6.67";
                //Test for valid selection
                else if (RBtn1.IsChecked == false && RBtn2.IsChecked == false && RBtn3.IsChecked == false)
                    MessageBox.Show("Please select angle!");

                //Do calculations
                double dipole = ((300 / freqIn) / 2) * 0.96;
                double dip2 = Math.Round(dipole, 2);
                DipBox.Text = dip2.ToString(); 
                double length = ((300 / freqIn) * 2);
                double length2 = Math.Round(length, 2);
                sideBox.Text = length2.ToString();
                double space = ((300 / freqIn) / 2);
                double space2 = Math.Round(space, 2);
                spaceBox.Text = space2.ToString();
                double width = length2;
                WidthBox.Text = width.ToString();
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

        }
    }
}

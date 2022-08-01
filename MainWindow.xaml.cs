using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GAZ.CSCourse.Lab2.WpfApplication
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

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double NumberDouble;// get double from TextBox
            if (!Double.TryParse(InputTextBox.Text, out NumberDouble))
            {
                MessageBox.Show("Please enter double");
                return;
            }
            //check number positive or not
            if (NumberDouble <= 0)
            {
                MessageBox.Show("Positive number");
                return;
            }
            //use the .NET Framework math.sqrt method
            Double SquareRoot = Math.Sqrt(NumberDouble);
            {
                //format the result and display
                FrameworkLabel.Content = string.Format(("{0} (Using .NET Framework)"), SquareRoot);
            }
            //Newton method
            //get user input as a decimal
            decimal NumberDecimal;
            if (!decimal.TryParse(InputTextBox.Text, out NumberDecimal))
            {
                MessageBox.Show("Please enter decimal");
                return;
            }
            {
                //specify 10 to power of -28 as the minimum delta between
                //estimates. This is the minimum range supported by the decimal type.
                //when the difference between 2 estimates is less than thits value, then stop
                decimal delta = Convert.ToDecimal(Math.Pow(10, -28));
                //take an initial guess at an answer to get started
                decimal guess = NumberDecimal / 2;
                //estimate result for the first itteration 
                decimal result = ((NumberDecimal / guess) + guess / 2);
                //while the difference between values for each current iteration
                //is not less than delta, then perform another iteration to
                //refine the answer.
                while (Math.Abs(result - guess) > delta)
                {
                    //
                    //
                    guess = result;
                    //try again
                    result = ((NumberDecimal / guess) + guess) / 2;
                }
                //display result
                NewtonLabel.Content = string.Format("{0} (Using Newton)", result);
            }
        }
    }
}

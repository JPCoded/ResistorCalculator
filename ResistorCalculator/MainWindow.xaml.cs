using System;
using System.Windows;
using System.Windows.Input;

namespace ResistorCalculator
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TbPrev1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rb1.PreviousColor();
            UpdateValue();
        }

        private void TbNext5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RbTolerance.NextColor();
            UpdateValue();
        }

        private void TbPrev5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RbTolerance.PreviousColor();
            UpdateValue();
        }

        private void TbPrev2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rb2.PreviousColor();
            UpdateValue();
        }

        private void TbPrev3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rb3.PreviousColor();
            UpdateValue();
        }

        private void TbPrev4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rb4.PreviousColor();
            UpdateValue();
        }

        private void TbNext1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rb1.NextColor();
            UpdateValue();
        }

        private void TbNext2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rb2.NextColor();
            UpdateValue();
        }

        private void TbNext3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rb3.NextColor();
            UpdateValue();
        }

        private void TbNext4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rb4.NextColor();
            UpdateValue();
        }

        private void UpdateValue()
        {
  
            if (Rb4.GetMultiplier() == -1 || Rb3.GetMultiplier() == -1)

            {
                lblValue.Content = "ERROR: INCORRECT VALUE";
            }
            else
            {
                var multiplier = Rb4.IsRbVisible() ? Rb4.GetMultiplier() : Rb3.GetMultiplier();
                var currentValue = Rb1.GetValue() + Rb2.GetValue().ToString() + (Rb4.IsRbVisible() ? Rb3.GetValue().ToString() : "");
                currentValue = (Convert.ToInt32(currentValue)*multiplier).ToString("N0");
                lblValue.Content = currentValue + "\u2126  " + RbTolerance.GetTolerance() + "%";

              
            }
        }
    }
}
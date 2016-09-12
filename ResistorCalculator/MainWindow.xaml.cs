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
            var multiplier = Rb4.IsRbVisible() ? Rb4.GetMultiplier() : Rb3.GetMultiplier();
  
            if (multiplier == -1)

            {
                lblValue.Content = "ERROR: INCORRECT VALUE";
            }
            else
            {
                
                double currentValue;
                if (Rb4.IsRbVisible())
                {
                    currentValue = (Rb1.GetValue()*100) + (Rb2.GetValue()*10) + Rb3.GetValue();
                }
                else
                {
                    currentValue = (Rb1.GetValue()*10) + Rb2.GetValue();
                }

                currentValue *= multiplier;
                lblValue.Content = currentValue.ToString("N0") + "\u2126  " + RbTolerance.GetTolerance() + "%";
                if (currentValue > 10000 && currentValue < 100000)
                {
                    lblValueShort.Content = (currentValue/10000).ToString();
                }
              
            }
        }
    }
}
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
        private const string Ohm = "\u2126";

        public MainWindow()
        {
            InitializeComponent();
            CbR1.StatusUpdated += CbR1OnStatusUpdated;
            CbR2.StatusUpdated += CbR2OnStatusUpdated;
            CbR3.StatusUpdated += CbR3OnStatusUpdated;
            CbR4.StatusUpdated += CbR4OnStatusUpdated;
            CbRTolerance.StatusUpdated += CbRToleranceOnStatusUpdated;

            CbR1.ResistorBand = true;
            CbR2.ResistorBand = true;
            CbR3.ResistorBand = true;
            
        }

        private void CbRToleranceOnStatusUpdated(object sender, EventArgs eventArgs)
        {
            RbTolerance.SetColor(CbRTolerance.BrushColor);
        }

        private void CbR4OnStatusUpdated(object sender, EventArgs eventArgs)
        {
            Rb4.SetColor(CbR4.BrushColor);
        }

        private void CbR3OnStatusUpdated(object sender, EventArgs eventArgs)
        {
            Rb3.SetColor(CbR3.BrushColor);
        }

        private void CbR2OnStatusUpdated(object sender, EventArgs eventArgs)
        {
            Rb2.SetColor(CbR2.BrushColor);
        }

        private void CbR1OnStatusUpdated(object sender, EventArgs eventArgs)
        {
          
          Rb1.SetColor(CbR1.BrushColor);
           
        }


        private void UpdateValue()
        {
            var multiplier = Rb4.IsRbVisible() ? Rb4.GetMultiplier() : Rb3.GetMultiplier();

            if ( multiplier == 8 || multiplier == 9)

            {
                LblValueLong.Content = "ERROR: INCORRECT VALUE";
                LblValueShort.Content = "ERROR: INCORRECT VALUE";
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

                currentValue *= Math.Pow(10, multiplier);

                LblValueLong.Content = currentValue.ToString("N0") + Ohm + " " + RbTolerance.GetTolerance() + "%";


                LblValueShort.Content = currentValue.GetOhmage() + Ohm + " " + RbTolerance.GetTolerance() + "%";
            }
        }

        private void chkFourthBand_Unchecked(object sender, RoutedEventArgs e)
        {
          
        Rb4.Visibility = Visibility.Hidden;
            CbR4.Visibility = Visibility.Hidden;
            CbR3.ResistorBand = false;
        }

        private void chkFourthBand_Checked(object sender, RoutedEventArgs e)
        {
             Rb4.Visibility = Visibility.Visible;
            CbR4.Visibility = Visibility.Visible;
            CbR3.ResistorBand = true;
        }
    }
}
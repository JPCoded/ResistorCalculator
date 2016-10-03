using System;
using System.Windows;

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
            CbRTolerance.ToleranceBand = true;
        }

        private void CbRToleranceOnStatusUpdated(object sender, EventArgs eventArgs)
        {
            RbTolerance.SetColor(CbRTolerance.BrushColor);
            UpdateValue();
        }

        private void CbR4OnStatusUpdated(object sender, EventArgs eventArgs)
        {
            Rb4.SetColor(CbR4.BrushColor);
            UpdateValue();
        }

        private void CbR3OnStatusUpdated(object sender, EventArgs eventArgs)
        {
            Rb3.SetColor(CbR3.BrushColor);
            UpdateValue();
        }

        private void CbR2OnStatusUpdated(object sender, EventArgs eventArgs)
        {
            Rb2.SetColor(CbR2.BrushColor);
            UpdateValue();
        }

        private void CbR1OnStatusUpdated(object sender, EventArgs eventArgs)
        {
            Rb1.SetColor(CbR1.BrushColor);
            UpdateValue();
        }

        private void UpdateValue()
        {
            var multiplier = (bool)ChkFourthBand.IsChecked ? CbR4.GetMultiplier : CbR3.GetMultiplier;


            var currentValue = Rb4.IsRbVisible()
                ? GetCurrentValue(CbR1.GetMultiplier, CbR2.GetMultiplier, CbR3.GetMultiplier)
                : GetCurrentValue(CbR1.GetMultiplier, CbR2.GetMultiplier);
           

            currentValue *= Math.Pow(10, multiplier);

            LblValueLong.Content = currentValue.ToString("N0") + Ohm + " " + CbRTolerance.GetTolerance + "%";


            LblValueShort.Content = currentValue.GetOhmage() + Ohm + " " + CbRTolerance.GetTolerance + "%";
        }

        private void ChkFourthBand_Click(object sender, RoutedEventArgs e)
        {
            Rb4.Visibility = (bool) ChkFourthBand.IsChecked ? Visibility.Visible : Visibility.Hidden;
            CbR4.Visibility = (bool) ChkFourthBand.IsChecked ? Visibility.Visible : Visibility.Hidden;
            CbR3.ResistorBand = (bool) ChkFourthBand.IsChecked;
            UpdateValue();
        }

        private static double GetCurrentValue(double value1, double value2, double value3)
        {
            return (value1*100) + (value2*10) +value3;
        }

        private static double GetCurrentValue(double value1, double value2)
        {
            return (value1 * 10) + value2;
        }
    }
}
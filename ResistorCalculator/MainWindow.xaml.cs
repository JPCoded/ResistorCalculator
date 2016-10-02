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
            var multiplier = Rb4.IsRbVisible() ? CbR4.GetMultiplier : CbR3.GetMultiplier;


            double currentValue;
            if (Rb4.IsRbVisible())
            {
                currentValue = (CbR1.GetMultiplier*100) + (CbR2.GetMultiplier*10) + CbR3.GetMultiplier;
            }
            else
            {
                currentValue = (CbR1.GetMultiplier*10) + CbR2.GetMultiplier;
            }

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
    }
}
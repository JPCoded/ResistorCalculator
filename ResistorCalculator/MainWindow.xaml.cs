﻿using System;
using System.Windows;

namespace ResistorCalculator
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    internal sealed partial class MainWindow
    {
        private const string Ohm = "\u2126";

        private readonly Func<double, string> _getToleranceString = b => $"{Ohm} {b}%";
       
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
            CbR4.MulitiplierBand = true;
            CbRTolerance.ToleranceBand = true;
            //Comment out to show debug label.
            LblDebug.Visibility = Visibility.Hidden;
            UpdateValue();
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
            var ohmTolerance = _getToleranceString.Invoke(CbRTolerance.GetTolerance);

            var multiplier = (bool) ChkFourthBand.IsChecked ? CbR4.GetMultiplier : CbR3.GetMultiplier;
            var currentValue = Rb4.IsRbVisible()
                ? GetCurrentValue(CbR1.GetMultiplier, CbR2.GetMultiplier, CbR3.GetMultiplier)
                : GetCurrentValue(CbR1.GetMultiplier, CbR2.GetMultiplier);

            currentValue *= (Math.Abs(multiplier) < 0) || (multiplier >= 1) ? Math.Pow(10, multiplier) : multiplier;
            LblDebug.Content = (Math.Abs(multiplier) < 0) || (multiplier >= 1) ? "Yes" : "No";
            LblValueLong.Content = currentValue + ohmTolerance;
            LblValueShort.Content = currentValue.GetOhmage() + ohmTolerance;
        }

        private void ChkFourthBand_Click(object sender, RoutedEventArgs e)
        {
           
            if (ChkFourthBand.IsChecked != null)
            {
                Rb4.Visibility =  (bool) ChkFourthBand.IsChecked ? Visibility.Visible : Visibility.Hidden;
                CbR4.Visibility = (bool) ChkFourthBand.IsChecked ? Visibility.Visible : Visibility.Hidden;
                CbR4.MulitiplierBand = (bool) ChkFourthBand.IsChecked;
                CbR3.MulitiplierBand = !(bool) ChkFourthBand.IsChecked;
                CbR3.ResistorBand = (bool) ChkFourthBand.IsChecked;
            }
            UpdateValue();
        }

        private static double GetCurrentValue(double value1, double value2, double value3) => (value1*100) + (value2*10) + value3;

        private static double GetCurrentValue(double value1, double value2) => (value1*10) + value2;
    }
}
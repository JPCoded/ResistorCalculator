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
                lblValue.Content = "ERROR: INCORRECT VALUE";
                lblValueShort.Content = "ERROR: INCORRECT VALUE";
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

                lblValue.Content = currentValue.ToString("N0") + Ohm + " " + RbTolerance.GetTolerance() + "%";


                lblValueShort.Content = currentValue.GetOhmage() + Ohm + " " + RbTolerance.GetTolerance() + "%";
            }
        }

    }
}
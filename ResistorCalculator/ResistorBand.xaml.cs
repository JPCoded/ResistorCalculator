using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ResistorCalculator
{
    /// <summary>
    ///     Interaction logic for ResistorBand.xaml
    /// </summary>
    public partial class ResistorBand : UserControl
    {
        public static readonly DependencyProperty AllowInvisibility = DependencyProperty.Register(
            "AllowInvis", typeof (bool), typeof (ResistorBand));

        public static readonly DependencyProperty IsTolerance = DependencyProperty.Register(
            "AllowTolerance", typeof (bool), typeof (ResistorBand));

        private int _currentMultiplier;
        private readonly Dictionary<int, SolidColorBrush> _rbColors = new Dictionary<int, SolidColorBrush>();
        private readonly List<double> _rbMulipliers = new List<Double>(new double[] {1,10,100,100,10000,100000,1000000,10000000,1,1,0.1,0.01});
        
        public ResistorBand()
        {
            InitializeComponent();
            _rbColors.Add(0, Brushes.Black);
            _rbColors.Add(1, Brushes.Brown);
            _rbColors.Add(2, Brushes.Red);
            _rbColors.Add(3, Brushes.Orange);
            _rbColors.Add(4, Brushes.Yellow);
            _rbColors.Add(5, Brushes.Green);
            _rbColors.Add(6, Brushes.Blue);
            _rbColors.Add(7, Brushes.Purple);
            _rbColors.Add(8, Brushes.Gray);
            _rbColors.Add(9, Brushes.White);
            _rbColors.Add(10, Brushes.Gold);
            _rbColors.Add(11, Brushes.Silver);
            ResistorBands.Fill = Brushes.Black;
        }

        public bool AllowInvis
        {
            get { return (bool) GetValue(AllowInvisibility); }
            set { SetValue(AllowInvisibility, value); }
        }

        public bool AllowTolerance
        {
            get { return (bool) GetValue(IsTolerance); }
            set { SetValue(IsTolerance, value); }
        }

        public bool IsRbVisible()
        {
            return ResistorBands.Visibility == Visibility.Visible;
        }

        public void PreviousColor()
        {
            if (_currentMultiplier > 0)
            {
                ResistorBands.Fill = _rbColors[_currentMultiplier - 1];
                _currentMultiplier -= 1;
            }

            else if (IsRbVisible() && AllowInvis)
            {
                ResistorBands.Visibility = Visibility.Hidden;
            }
        }

        public void NextColor()
        {
            if (_currentMultiplier < 9 && IsRbVisible())
            {
                ResistorBands.Fill = _rbColors[_currentMultiplier + 1];
                _currentMultiplier += 1;
            }
            else if (AllowTolerance && _currentMultiplier < 11)
            {
                ResistorBands.Fill = _rbColors[_currentMultiplier + 1];
                _currentMultiplier += 1;
            }
            else if (IsRbVisible() == false)
            {
                ResistorBands.Visibility = Visibility.Visible;
                ResistorBands.Fill = _rbColors[0];
                _currentMultiplier = 0;
            }
        }

        public double GetMultiplier()
        {
            return _rbMulipliers[_currentMultiplier];
        }
    }
}
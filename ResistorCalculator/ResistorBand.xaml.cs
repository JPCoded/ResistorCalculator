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
        private int _currentTolerance;

        //4-band -- M - Black, Brown, Red, Orange, Yellow, Green, Blue, Gold, Silver -- T - Brown, Red, Gold, Silver
        //5-band -- M -  Black, Brown, Red, Orange, Yellow, Gold, Silver -- T - Brown, Red, Gold, Silver


        private readonly List<SolidColorBrush> _rbColors =
            new List<SolidColorBrush>(new[]
            {
                Brushes.Black, Brushes.Brown, Brushes.Red, Brushes.Orange, Brushes.Yellow
                , Brushes.Green, Brushes.Blue, Brushes.Purple, Brushes.Gray, Brushes.White, Brushes.Gold, Brushes.Silver
            });

        private readonly List<int> _rbMulipliers =
            new List<int>(new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, -1, -2});

        private readonly List<double> _rbTolerance =
            new List<double>(new[] {1, 2, 0.5, 0.25, 0.1, 0.05, 5, 10});

        private readonly List<SolidColorBrush> _rbToleranceColors =
            new List<SolidColorBrush>(new[]
            {
                Brushes.Brown, Brushes.Red, Brushes.Green, Brushes.Blue, Brushes.Purple, Brushes.Gray, Brushes.Gold,
                Brushes.Silver
            });

        public ResistorBand()
        {
            InitializeComponent();

            ResistorBands.Fill = Brushes.Black;
            _currentMultiplier = 0;
        }

        public bool AllowInvis
        {
            private get { return (bool) GetValue(AllowInvisibility); }
            set { SetValue(AllowInvisibility, value); }
        }

        public bool AllowTolerance
        {
            private get { return (bool) GetValue(IsTolerance); }
            set { SetValue(IsTolerance, value); }
        }

        public bool IsRbVisible()
        {
            return ResistorBands.Visibility == Visibility.Visible;
        }

        public void PreviousColor()
        {
            if (_currentMultiplier > 0 && !AllowTolerance)
            {
                ResistorBands.Fill = _rbColors[_currentMultiplier - 1];
                _currentMultiplier -= 1;
            }
            else if (_currentTolerance > 0 && AllowTolerance)
            {
                ResistorBands.Fill = _rbToleranceColors[_currentTolerance - 1];
                _currentTolerance -= 1;
            }
            else if (IsRbVisible() && AllowInvis)
            {
                ResistorBands.Visibility = Visibility.Hidden;
            }
        }

        public void NextColor()
        {
            if (_currentMultiplier < 9 && IsRbVisible() && !AllowTolerance)
            {
                ResistorBands.Fill = _rbColors[_currentMultiplier + 1];
                _currentMultiplier += 1;
            }
            else if (AllowTolerance && _currentTolerance < 7)
            {
                ResistorBands.Fill = _rbToleranceColors[_currentTolerance + 1];
                _currentTolerance += 1;
            }
            else if (IsRbVisible() == false)
            {
                ResistorBands.Visibility = Visibility.Visible;
                ResistorBands.Fill = _rbColors[0];
                _currentMultiplier = 0;
            }
        }

        public int GetMultiplier()
        {
            return _rbMulipliers[_currentMultiplier];
        }

        public double GetTolerance()
        {
            return _rbTolerance[_currentTolerance];
        }

        public int GetValue()
        {
            return _currentMultiplier;
        }
    }
}
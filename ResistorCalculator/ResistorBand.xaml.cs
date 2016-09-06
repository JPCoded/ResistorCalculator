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
            "ToleranceBand", typeof (bool), typeof (ResistorBand));

        private int _currentMultiplier;
        private int _currentTolerance = 10;
        private readonly Dictionary<int, SolidColorBrush> _rbColors = new Dictionary<int, SolidColorBrush>();

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
            ResistorBands.Fill = ToleranceBand ? Brushes.Gold : Brushes.Black;
        }

        public bool AllowInvis
        {
            get { return (bool) GetValue(AllowInvisibility); }
            set { SetValue(AllowInvisibility, value); }
        }

        public bool ToleranceBand
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
            if (_currentMultiplier > 0 && !ToleranceBand)
            {
                ResistorBands.Fill = _rbColors[_currentMultiplier - 1];
                _currentMultiplier -= 1;
            }
            else if (ToleranceBand && _currentTolerance == 11)
            {
                ResistorBands.Fill = _rbColors[10];
            }
            else if (IsRbVisible() && AllowInvis)
            {
                ResistorBands.Visibility = Visibility.Hidden;
            }
        }

        public void NextColor()
        {
            if (_currentMultiplier < 9 && IsRbVisible() && !ToleranceBand)
            {
                ResistorBands.Fill = _rbColors[_currentMultiplier + 1];
                _currentMultiplier += 1;
            }
            else if (ToleranceBand && _currentTolerance == 10)
            {
                ResistorBands.Fill = _rbColors[11];
                _currentTolerance = 11;
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
            return _currentMultiplier;
        }
    }
}
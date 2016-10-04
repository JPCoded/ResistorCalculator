using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ResistorCalculator
{
    /// <summary>
    ///     Interaction logic for ColorBox.xaml
    /// </summary>
    public partial class ColorBox
    {
        private bool _resistorBand;
        private bool _toleranceBand;
        private readonly List<Rectangle> _colorList = new List<Rectangle>();

        public ColorBox()
        {
            InitializeComponent();
            GetTolerance = 1;
            GetMultiplier = 1;
            CrBrown.StrokeThickness = 2.5;
            _colorList.Add(CrBlack);
            _colorList.Add(CrBrown);
            _colorList.Add(CrRed);
            _colorList.Add(CrOrange);
            _colorList.Add(CrYellow);
            _colorList.Add(CrGreen);
            _colorList.Add(CrBlue);
            _colorList.Add(CrPurple);
            _colorList.Add(CrGrey);
            _colorList.Add(CrWhite);
            _colorList.Add(CrGold);
            _colorList.Add(CrSilver);
        }

        public int GetMultiplier { get; private set; }
        public double GetTolerance { get; private set; }

        public bool ToleranceBand
        {
            private get { return _toleranceBand; }
            set
            {
                _toleranceBand = value;
                ToleranceChange();
            }
        }

        public bool ResistorBand
        {
            private get { return _resistorBand; }
            set
            {
                _resistorBand = value;
                BandChanged();
            }
        }

        public SolidColorBrush BrushColor { get; private set; }

        private void ToleranceChange()
        {
            CrBlack.Visibility = ToleranceBand ? Visibility.Hidden : Visibility.Visible;
            CrOrange.Visibility = ToleranceBand ? Visibility.Hidden : Visibility.Visible;
            CrYellow.Visibility = ToleranceBand ? Visibility.Hidden : Visibility.Visible;
            CrGrey.Visibility = ToleranceBand ? Visibility.Hidden : Visibility.Visible;
            CrWhite.Visibility = ToleranceBand ? Visibility.Hidden : Visibility.Visible;
        }

        private void BandChanged()
        {
            CrSilver.Visibility = ResistorBand ? Visibility.Hidden : Visibility.Visible;
            CrGold.Visibility = ResistorBand ? Visibility.Hidden : Visibility.Visible;
        }

        public event EventHandler StatusUpdated;

        private void ColorChangedEvent()
        {
            //Null check makes sure the main page is attached to the event
            StatusUpdated?.Invoke(new object(), new EventArgs());
        }

        private void SetStrokeThickness(object sender)
        {
            foreach (var x in _colorList)
            {
                x.StrokeThickness = Equals(x, (Rectangle) sender) ? 2.5 : 1;
                x.Stroke = Equals(x, (Rectangle) sender) ? Equals(x, CrBlack) ? Brushes.DarkGray : Brushes.Black: Brushes.Black;
            }
        }

        private void CrBlack_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Black;
            GetMultiplier = 0;
            SetStrokeThickness(sender);
            ColorChangedEvent();
        }

        private void CrBrown_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Brown;
            GetMultiplier = 1;
            GetTolerance = 1;
            SetStrokeThickness(sender);
            ColorChangedEvent();
        }

        private void CrRed_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Red;
            GetMultiplier = 2;
            GetTolerance = 2;
            SetStrokeThickness(sender);
            ColorChangedEvent();
        }

        private void CrOrange_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Orange;
            GetMultiplier = 3;
            SetStrokeThickness(sender);
            ColorChangedEvent();
        }

        private void CrYellow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Yellow;
            GetMultiplier = 4;
            SetStrokeThickness(sender);
            ColorChangedEvent();
        }

        private void CrGreen_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Green;
            GetMultiplier = 5;
            GetTolerance = .5;
            SetStrokeThickness(sender);
            ColorChangedEvent();
        }

        private void CrBlue_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Blue;
            GetMultiplier = 6;
            GetTolerance = .25;
            SetStrokeThickness(sender);
            ColorChangedEvent();
        }

        private void CrPurple_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Purple;
            GetMultiplier = 7;
            GetTolerance = .1;
            SetStrokeThickness(sender);
            ColorChangedEvent();
        }

        private void CrGrey_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Gray;
            GetMultiplier = 8;
            SetStrokeThickness(sender);
            ColorChangedEvent();
        }

        private void CrWhite_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.White;
            GetMultiplier = 9;
            SetStrokeThickness(sender);
            ColorChangedEvent();
        }

        private void CrGold_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Gold;
            GetMultiplier = -1;
            GetTolerance = 5;
            SetStrokeThickness(sender);
            ColorChangedEvent();
        }

        private void CrSilver_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Silver;
            GetMultiplier = -2;
            GetTolerance = 10;
            SetStrokeThickness(sender);
            ColorChangedEvent();
        }
    }
}
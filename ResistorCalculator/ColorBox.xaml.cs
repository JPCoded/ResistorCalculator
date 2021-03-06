﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ResistorCalculator
{
    /// <summary>
    ///     Interaction logic for ColorBox.xaml
    /// </summary>
    internal sealed partial class ColorBox
    {
        private bool _resistorBand;
        private bool _toleranceBand;
        private bool _multiplierBand;
        private readonly IEnumerable<Rectangle> _colorList;

        public ColorBox()
        {
            InitializeComponent();
            GetTolerance = 1;
            GetMultiplier = 1;
            CrBrown.StrokeThickness = 2.5;
            _colorList = FindLogicalChildren<Rectangle>(ColorBoxWindow).Where(rect => rect.Name.StartsWith("Cr"));
           
        }

        public double GetMultiplier { get; private set; }
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

        public bool MulitiplierBand
        {
            private get { return _multiplierBand; }
            set
            {
                _multiplierBand = value;
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
            CrWhite.Visibility = MulitiplierBand ? Visibility.Hidden : Visibility.Visible;
            CrGrey.Visibility = MulitiplierBand ? Visibility.Hidden : Visibility.Visible;
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
                //Checks if current selected rectangle is black, if it is, set border color to different color, else color is black
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
            GetMultiplier = 0.1;
            GetTolerance = 5;
            SetStrokeThickness(sender);
            ColorChangedEvent();
        }

        private void CrSilver_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Silver;
            GetMultiplier = 0.01;
            GetTolerance = 10;
            SetStrokeThickness(sender);
            ColorChangedEvent();
        }

        private static IEnumerable<T> FindLogicalChildren<T>(DependencyObject obj) where T : DependencyObject
        {
            if (obj != null)
            {
                if (obj is T)
                {
                    yield return (T)obj;
                }

                foreach (
                    var c in
                        LogicalTreeHelper.GetChildren(obj).OfType<DependencyObject>().SelectMany(FindLogicalChildren<T>)
                    )
                {
                    yield return c;
                }
            }
        }
    }
}
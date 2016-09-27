using System;
using System.Windows.Input;
using System.Windows.Media;

namespace ResistorCalculator
{
    /// <summary>
    ///     Interaction logic for ColorBox.xaml
    /// </summary>
    public partial class ColorBox
    {
        public ColorBox()
        {
            InitializeComponent();
            ColorChangedEvent();
            //   BrushColor = Brushes.Brown;
        }

        public SolidColorBrush BrushColor { get; private set; }
        public event EventHandler StatusUpdated;

        private void ColorChangedEvent()
        {
            //Null check makes sure the main page is attached to the event
            StatusUpdated?.Invoke(new object(), new EventArgs());
        }

        private void CrBlack_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Black;
            ColorChangedEvent();
        }

        private void CrBrown_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Brown;
            ColorChangedEvent();
        }

        private void CrRed_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Red;
            ColorChangedEvent();
        }

        private void CrOrange_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Orange;
            ColorChangedEvent();
        }

        private void CrYellow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Yellow;
            ColorChangedEvent();
        }

        private void CrGreen_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Green;
            ColorChangedEvent();
        }

        private void CrBlue_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Blue;
            ColorChangedEvent();
        }

        private void CrPurple_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Purple;
            ColorChangedEvent();
        }

        private void CrGrey_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Gray;
            ColorChangedEvent();
        }

        private void CrWhite_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.White;
            ColorChangedEvent();
        }

        private void CrGold_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Gold;
            ColorChangedEvent();
        }

        private void CrSilver_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushColor = Brushes.Silver;
            ColorChangedEvent();
        }
    }
}
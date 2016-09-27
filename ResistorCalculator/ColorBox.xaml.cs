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
        public event EventHandler StatusUpdated;

        private void ColorChangedEvent()
        {
            //Null check makes sure the main page is attached to the event
            StatusUpdated?.Invoke(new object(), new EventArgs());
        }    

        public SolidColorBrush BrushColor { get; private set; }

        public ColorBox()
        {
            InitializeComponent();
            ColorChangedEvent();
         //   BrushColor = Brushes.Brown;
        }

        private void CrBlack_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
     
           
            ColorChangedEvent();
            BrushColor = Brushes.Black;
            e.Handled = true;
        }

        private void CrBrown_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorChangedEvent();
            BrushColor = Brushes.Brown;
        }

        private void CrRed_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorChangedEvent();
            BrushColor = Brushes.Red;
        }

        private void CrOrange_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorChangedEvent();
            BrushColor = Brushes.Orange;
        }

        private void CrYellow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorChangedEvent();
            BrushColor = Brushes.Yellow;
        }

        private void CrGreen_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorChangedEvent();
            BrushColor = Brushes.Green;
        }

        private void CrBlue_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorChangedEvent();
            BrushColor = Brushes.Blue;
        }

        private void CrPurple_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorChangedEvent();
            BrushColor = Brushes.Purple;
        }

        private void CrGrey_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorChangedEvent();
            BrushColor = Brushes.Gray;
        }

        private void CrWhite_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorChangedEvent();
            BrushColor = Brushes.White;
        }

        private void CrGold_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorChangedEvent();
            BrushColor = Brushes.Gold;
        }

        private void CrSilver_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorChangedEvent();
            BrushColor = Brushes.Silver;
        }
    }
}
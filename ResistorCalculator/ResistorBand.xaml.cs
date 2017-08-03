using System.Windows;
using System.Windows.Media;

namespace ResistorCalculator
{
    /// <summary>
    ///     Interaction logic for ResistorBand.xaml
    /// </summary>
    internal sealed partial class ResistorBand
    {
        public ResistorBand()
        {
            InitializeComponent();

            ResistorBands.Fill = Brushes.Brown;
        }

        public bool IsRbVisible() => ResistorBands.Visibility == Visibility.Visible;

        public void SetColor(SolidColorBrush brushColor)
        {
            ResistorBands.Fill = brushColor;
        }
    }
}
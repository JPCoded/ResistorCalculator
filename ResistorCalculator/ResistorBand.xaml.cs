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


        public ResistorBand()
        {
            InitializeComponent();

            ResistorBands.Fill = Brushes.Brown;
        
        }

        public bool IsRbVisible()
        {
            return ResistorBands.Visibility == Visibility.Visible;
        }

        public void SetColor(SolidColorBrush brushColor)
        {
            ResistorBands.Fill = brushColor;
        }

     

    }
}
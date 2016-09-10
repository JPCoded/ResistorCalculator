using System.Windows;
using System.Windows.Input;

namespace ResistorCalculator
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TbPrev1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rb1.PreviousColor();
        }

        private void TbNext5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RbTolerance.NextColor();
        }

        private void TbPrev5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RbTolerance.PreviousColor();
        }

        private void TbPrev2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rb2.PreviousColor();
        }

        private void TbPrev3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rb3.PreviousColor();
        }

        private void TbPrev4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rb4.PreviousColor();
        }

        private void TbNext1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rb1.NextColor();
        }

        private void TbNext2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rb2.NextColor();
        }

        private void TbNext3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rb3.NextColor();
        }

        private void TbNext4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rb4.NextColor();
        }
    }
}
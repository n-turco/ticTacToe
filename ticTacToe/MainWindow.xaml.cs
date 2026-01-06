using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ticTacToe
{
    public partial class MainWindow : Window
    {
       static readonly Player player1 = new();
       static readonly Player player2 = new();
       static readonly string? currentPlayer;
        public MainWindow()
        {
            InitializeComponent();        
            StatusBar.Content = "Player Ones Turn";

        }

        /////////////////     Button Click events     ////////////////////
        private void TopLeft_Click(object sender, RoutedEventArgs e)
        {
              
        }
        private void TopCenter_Click(object sender, RoutedEventArgs e)
        {

        }
        private void TopRight_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MiddleLeft_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MiddleCenter_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MiddleRight_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BottomLeft_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BottomCenter_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BottomRight_Click(object sender, RoutedEventArgs e)
        {

        }

        public static void GameSequence()
        {
            
        }
        public static void YouWin()
        {

        }
    }
}
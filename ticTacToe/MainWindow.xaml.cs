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
        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            //create button object to get the row and column
            Button btn = (Button)sender;

            int row = Grid.GetRow(btn);
            int col = Grid.GetColumn(btn);
            
            if (!GameLogic.MakeMove(row, col))
                return;
            //update the button with the players choice
            btn.Content = GameLogic.SelectedPlayer == GameLogic.CurrentPlayer.O ? "X" : "O";
            //update the status bar
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            switch (GameLogic.CurrentGameState)
            {
                case GameLogic.GameState.Inprogress:
                    StatusBar.Content = $"Turn: {GameLogic.SelectedPlayer}";
                    break;
                case GameLogic.GameState.Xwins:
                    StatusBar.Content = "X wins";
                    break;
                case GameLogic.GameState.Owins:
                    StatusBar.Content = "O wins";
                    break;
                case GameLogic.GameState.Draw:
                    StatusBar.Content = "Draw";
                    break;
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ticTacToe
{
    class GameLogic
    {
        public enum CurrentPlayer
        {
            X,
            O
        }
        public enum CellState
        {
            None,
            X,
            O
        }
        public enum GameState
        {
            Inprogress,
            Xwins,
            Owins,
            Draw
        }

        static readonly CellState[,] board = new CellState[3, 3];
        public static CurrentPlayer SelectedPlayer { get; set; }
        public static GameState CurrentGameState { get; set; }
        public static CellState CurrentCellState { get; set; }


        //determine the status of the game
        public static bool CheckGameForWinner()
        {
            return HorizontalWin() || VerticalWin() || DiagonalWin();
        }

        public static bool MakeMove(int row, int column)
        {
            if(CurrentGameState != GameState.Inprogress)
            {
                Logger.Log($"Game Over.", Logger.LogType.INFO);
                return false;
            }
            if (board[row, column] != CellState.None)
            {
                Logger.Log($"Cell is already selected.", Logger.LogType.INFO);
                return false;
            }
            //determine if X or O should be written to the cell
            board[row, column] = SelectedPlayer == CurrentPlayer.X ? CellState.X : CellState.O;
            //check for winner
            if (CheckGameForWinner())
            {
                CurrentGameState = SelectedPlayer == CurrentPlayer.X ? GameState.Xwins : GameState.Owins;
                Logger.Log($"{SelectedPlayer} Wins.", Logger.LogType.INFO);
            }
            else if (CheckForDraw()) 
            {
                CurrentGameState = GameState.Draw;
                Logger.Log($"Game was a draw.", Logger.LogType.INFO);
            }
            else
            {
               // ChangePlayer();
            }
            return true;
        }

        public static void ChangePlayer() 
        {
            if (SelectedPlayer == CurrentPlayer.X)
            {
                SelectedPlayer = CurrentPlayer.O;
            }
            else 
            {
                SelectedPlayer = CurrentPlayer.X;
            }
        }
        public static bool HorizontalWin()
        {
            bool winner = false;
            //check if the first cell in each row is equal to the second and third
            for (int i = 0; i < 3; i++)
            {
                if (board[i,0] != CellState.None && 
                    board[i,0] == board[i,1] &&
                    board[i,0] == board[i,2])
                {
                    winner = true;
                }
            }
            return winner;
        }
        public static bool VerticalWin() 
        {
            bool winner = false;
            //check if the first cell in each column is equal to the second and third
            for (int i = 0; i < 3; i++) 
            {
                if (board[0,i] != CellState.None && 
                    board[0,i] == board[1,i] &&
                    board[1,i] == board[2,i]) 
                {
                winner |= true;
                }
            }
            return winner;
        }

        public static bool DiagonalWin()
        {
            bool winner = false;
            //check if the middle cell is not empty then check that the corner cells have the same character
            if (board[1,1] != CellState.None)
            {
                if (board[0,0] == board[1,1] &&
                    board[1,1]  == board[2,2])
                {
                    winner = true; 
                } 
                else if (board[0,2] == board[1,1] &&
                    board[1,1] == board[2, 0])
                {
                    winner = true;
                }
            }
            return winner;
        }
        public static bool CheckForDraw()
        {
            bool draw = true;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i,j] == CellState.None)
                    {
                        draw = false;
                    }
                }
            }
            return draw;
        }
        public static void ResetGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = CellState.None;

                }
            }          
            SelectedPlayer = CurrentPlayer.X;
            CurrentGameState = GameState.Inprogress;
            Logger.Log($"Game has reset.", Logger.LogType.INFO);
        }

    }
}

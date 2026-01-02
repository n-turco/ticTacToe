using System;
using System.Collections.Generic;
using System.Linq;
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
        public static string? XandO {  get; set; }
        public static CurrentPlayer SelectedPlayer { get; set; }
        public static GameState CurrentGameState { get; set; }
        public static CellState CurrentCellState { get; set; }

        //determine which player is choosing
        public static string CheckPlayer (CurrentPlayer SelectedPlayer)
        {
            if(XandO == null)
            {
                //default assignment
                XandO = "x";
            }
            if (SelectedPlayer == CurrentPlayer.X) 
            {
                XandO = "x";
            }
            if (SelectedPlayer == CurrentPlayer.O) 
            {  
                XandO = "o";
            }
            return XandO;
        }
        //determine the status of the game
        public static bool CheckGameForWinner()
        {
            return HorizontalWin() || VerticalWin() || DiagonalWin();
        }


        public static bool ValidatePlayerChoice(CellState CurrentCell) 
        {
            bool validInput = true;
            if (CurrentCell != CellState.None)
            {
                validInput = false;
            }
            else
            {
             
            }
                return validInput;
        }
        public static void ChangePlayer() 
        {
            if (CurrentGameState == GameState.Inprogress)
            {
                if (SelectedPlayer == CurrentPlayer.X)
                {
                    SelectedPlayer = CurrentPlayer.O;
                    XandO = "o";
                }
                else if (SelectedPlayer == CurrentPlayer.O) 
                {
                    SelectedPlayer = CurrentPlayer.X;
                    XandO = "x";
                }
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
    }
}

namespace MinesweeperGame
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        public static void Main(string[] arguments)
        {
            const int MAX = 35;

            string command = string.Empty;
            List<CalculatePoints> topPlayers = new List<CalculatePoints>(6);
            char[,] board = CreateBoard();
            char[,] bombs = GenerateNewBombsOnTheBoard();
            int row = 0;
            int col = 0;
            int counter = 0;
            bool startNewGame = true;
            bool winGame = false;
            bool loseGame = false;

            do
            {
                if (startNewGame)
                {
                    Console.WriteLine(
                        "Let's play the game 'Minesweeper'!." + Environment.NewLine +
                        "Try to find all cells without bombs!" + Environment.NewLine +
                        "Command 'top' - shows Highscores, 'restart' - start new game, 'exit'- leave the game!");

                    ShowBoard(board);
                    startNewGame = false;
                }

                Console.Write("Enter row and col separated by space : ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= board.GetLength(0) &&
                        col <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Highscores(topPlayers);
                        break;
                    case "restart":
                        ResetBoard(ref board, ref bombs, ref counter, ref startNewGame, ref loseGame);
                        break;
                    case "exit":
                        Console.WriteLine("Goodbye!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                NextTurn(board, bombs, row, col);
                                counter++;
                            }

                            if (MAX == counter)
                            {
                                winGame = true;
                            }
                            else
                            {
                                ShowBoard(board);
                            }
                        }
                        else
                        {
                            loseGame = true;
                        }

                        break;
                    default:
                        Console.WriteLine(Environment.NewLine + "Invalid command! Try again!" + Environment.NewLine);
                        break;
                }

                if (loseGame)
                {
                    ShowBoard(bombs);
                    Console.WriteLine("GAME OVER. You won {0} points. Enter your name, please: ", counter);
                    string nickname = Console.ReadLine();

                    CalculatePoints currentPlayer = new CalculatePoints(nickname, counter);
                    if (topPlayers.Count < 5)
                    {
                        topPlayers.Add(currentPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < topPlayers.Count; i++)
                        {
                            if (topPlayers[i].Points < currentPlayer.Points)
                            {
                                topPlayers.Insert(i, currentPlayer);
                                topPlayers.RemoveAt(topPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    topPlayers.Sort((CalculatePoints r1, CalculatePoints r2) => r2.Name.CompareTo(r1.Name));
                    topPlayers.Sort((CalculatePoints r1, CalculatePoints r2) => r2.Points.CompareTo(r1.Points));
                    Highscores(topPlayers);

                    ResetBoard(ref board, ref bombs, ref counter, ref startNewGame, ref loseGame);
                }

                if (winGame)
                {
                    Console.WriteLine(Environment.NewLine + "GOOD JOB! You guessed all 35 cells.");
                    ShowBoard(bombs);

                    Console.WriteLine("Enter you name, please: ");
                    string nameOfCurrentPlayer = Console.ReadLine();

                    CalculatePoints pointsOfCurrentPlayer = new CalculatePoints(nameOfCurrentPlayer, counter);
                    topPlayers.Add(pointsOfCurrentPlayer);
                    Highscores(topPlayers);

                    ResetBoard(ref board, ref bombs, ref counter, ref startNewGame, ref loseGame);
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria");
            Console.Read();
        }

        private static void ResetBoard(ref char[,] board, ref char[,] bombs, ref int counter, ref bool startNewGame, ref bool loseGame)
        {
            board = CreateBoard();
            bombs = GenerateNewBombsOnTheBoard();
            counter = 0;
            loseGame = false;
            startNewGame = true;
        }

        private static void Highscores(List<CalculatePoints> allPoints)
        {
            Console.WriteLine("\nHIGHSCORES:");
            if (allPoints.Count > 0)
            {
                for (int i = 0; i < allPoints.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells", i + 1, allPoints[i].Name, allPoints[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("empty ranking\n");
            }
        }

        private static void NextTurn(char[,] board, char[,] bombs, int row, int col)
        {
            char numberOfBombs = CalculateNumberOfBombs(bombs, row, col);
            bombs[row, col] = numberOfBombs;
            board[row, col] = numberOfBombs;
        }

        private static void ShowBoard(char[,] board)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < row; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < col; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateBoard()
        {
            int row = 5;
            int col = 10;
            char[,] board = new char[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] GenerateNewBombsOnTheBoard()
        {
            int rows = 5;
            int cols = 10;
            char[,] board = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> generatedBombs = new List<int>();

            while (generatedBombs.Count < 15)
            {
                Random random = new Random();
                int rnd = random.Next(50);
                if (!generatedBombs.Contains(rnd))
                {
                    generatedBombs.Add(rnd);
                }
            }

            foreach (int bomb in generatedBombs)
            {
                int col = bomb / cols;
                int row = bomb % cols;
                if (row == 0 && bomb != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                board[col, row - 1] = '*';
            }

            return board;
        }

        private static void Calculations(char[,] board)
        {
            int col = board.GetLength(0);
            int row = board.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (board[i, j] != '*')
                    {
                        char numberOfBombs = CalculateNumberOfBombs(board, i, j);
                        board[i, j] = numberOfBombs;
                    }
                }
            }
        }

        private static char CalculateNumberOfBombs(char[,] board, int row, int col)
        {
            int counter = 0;
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, col] == '*')
                {
                    counter++;
                }
            }

            if (row + 1 < rows)
            {
                if (board[row + 1, col] == '*')
                {
                    counter++;
                }
            }

            if (col - 1 >= 0)
            {
                if (board[row, col - 1] == '*')
                {
                    counter++;
                }
            }

            if (col + 1 < cols)
            {
                if (board[row, col + 1] == '*')
                {
                    counter++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (board[row - 1, col - 1] == '*')
                {
                    counter++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (board[row - 1, col + 1] == '*')
                {
                    counter++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (board[row + 1, col - 1] == '*')
                {
                    counter++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (board[row + 1, col + 1] == '*')
                {
                    counter++;
                }
            }

            return char.Parse(counter.ToString());
        }
    }
}

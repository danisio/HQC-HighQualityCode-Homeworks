using System;

public class Bishop
{
    private static string[,] commands;
    private static int[,] chessboard;
    
    public static void Main()
    {
        string input = Console.ReadLine();
        string[] dim = input.Split(' ');
        int row = int.Parse(dim[0]);
        int col = int.Parse(dim[1]);

        chessboard = FiilMatrix(row, col);

        int numberOfCommands = int.Parse(Console.ReadLine());

        int currRow = row - 1;
        int currCol = 0;

        int sum = 0;

        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] line = Console.ReadLine().Split(' ');
            string currentCommand = line[0];
            int currentStep = int.Parse(line[1]);
            
            switch (currentCommand)
            {
                case "RU":
                case "UR":
                    for (int j = 0; j < currentStep; j++)
                    {
                        sum += chessboard[currRow, currCol];
                        chessboard[currRow, currCol] = 0;
                        if (j < currentStep - 1)
                        {
                            if (currRow != 0 && currCol != col - 1)
                            {
                                currRow--;
                                currCol++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    } 
                    
                    break;

                case "RD":
                case "DR":
                    for (int j = 0; j < currentStep; j++)
                    {
                        sum += chessboard[currRow, currCol];
                        chessboard[currRow, currCol] = 0;

                        if (j < currentStep - 1)
                        {
                            if (currRow != row - 1 && currCol != col - 1)
                            {
                                currRow++;
                                currCol++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    } 
                    
                    break;

                case "LU":
                case "UL":
                    for (int j = 0; j < currentStep; j++)
                    {
                        sum += chessboard[currRow, currCol];
                        chessboard[currRow, currCol] = 0;
                        if (j < currentStep - 1)
                        {
                            if (currRow != 0 && currCol != 0)
                            {
                                currRow--;
                                currCol--;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    
                    break;

                case "LD":
                case "DL":
                    for (int j = 0; j < currentStep; j++)
                    {
                        sum += chessboard[currRow, currCol];
                        chessboard[currRow, currCol] = 0;

                        if (j < currentStep - 1)
                        {
                            if (currRow != row - 1 && currCol != 0)
                            {
                                currRow++;
                                currCol--;
                            }
                            else
                            {
                                break;
                            }
                        }
                    } 
                    
                    break;
            }
        }

        Console.WriteLine(sum);
    }

    private static int[,] FiilMatrix(int row, int col)
    {
        int value = 1;
        int currValue = 0;
        int[,] matrix = new int[row, col];

        for (int i = row - 1; i >= 0; i--, value++)
        {
            for (int j = 0; j < col; j++)
            {
                matrix[i, j] = currValue;
                currValue += 3;
            }

            currValue = value * 3;
        }

        return matrix;
    }
}

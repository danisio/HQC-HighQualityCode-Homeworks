using System;

public class MathProblem
{
    public static void Main()
    {
        string message = Console.ReadLine();

        long result = 0;

        string[] messageToArr = message.Split(' ');

        for (int i = 0; i < messageToArr.Length; i++)
        {
            int position = messageToArr[i].Length - 1;
            string currentWord = messageToArr[i];
            
            for (int j = 0; j < currentWord.Length; j++)
            {
                result += ConvertMessageToInt(currentWord[j].ToString()) * Power(position);
                position--;
            }
        }

        message = ConvertIntToMessage(result);

        Console.WriteLine("{0} = {1}", message, result);
    }

    private static string ConvertIntToMessage(long result)
    {
        string message = string.Empty;

        while (result > 0)
        {
            long currentdigit = result % 19;
            message = ConvertToMessageAgain(currentdigit) + message;
            result = result / 19;
        }

        return message;
    }

    private static long Power(int number)
    {
        long result = 1;

        for (long i = 0; i < number; i++)
        {
            result *= 19;
        }

        return result;
    }

    private static string ConvertToMessageAgain(long currentDigit)
    {
        string[] array = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s" };

        return array[currentDigit];
    }

    private static int ConvertMessageToInt(string currentChar)
    {
        switch (currentChar)
        {
            case "a": return 0;
            case "b": return 1;
            case "c": return 2;
            case "d": return 3;
            case "e": return 4;
            case "f": return 5;
            case "g": return 6;
            case "h": return 7;
            case "i": return 8;
            case "j": return 9;
            case "k": return 10;
            case "l": return 11;
            case "m": return 12;
            case "n": return 13;
            case "o": return 14;
            case "p": return 15;
            case "q": return 16;
            case "r": return 17;
            case "s": return 18;
        }

        return 0;
    }
}

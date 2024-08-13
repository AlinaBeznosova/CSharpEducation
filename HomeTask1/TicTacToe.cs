using System;
using System.Runtime.CompilerServices;

namespace HomeTask1
{
    class TicTacToe
    {
        public static char[,] field = new char[3, 3];
        public const char x = 'x';
        public const char o = 'o';
        public static int player = 0;
        
        
        public static void PrintField()
        {
            Console.WriteLine($"-------------");
            Console.WriteLine($"| {field[2, 0]} | {field[2, 1]} | {field[2, 2]} |");
            Console.WriteLine($"-------------");
            Console.WriteLine($"| {field[1, 0]} | {field[1, 1]} | {field[1, 2]} |");
            Console.WriteLine($"-------------");
            Console.WriteLine($"| {field[0, 0]} | {field[0, 1]} | {field[0, 2]} |");
            Console.WriteLine($"-------------");
        }

        public static void PlayerMove()
        {
            while (true)
            {
                Console.WriteLine($"Игрок {player % 2 + 1}, ваш ход, введите цифру (1-9) :");

                if (int.TryParse(Console.ReadLine(), out int move) && move >= 1 && move <= 9)
                {
                    int row = (move - 1) / 3;
                    int col = (move - 1) % 3;
                    if (field[row,col] == x || field[row,col] == o)
                    {
                        Console.WriteLine("Позиция уже занята. Попробуйте снова.");
                        
                    }
                    else
                    {
                        field[row, col] = (player % 2 == 0) ? x : o ;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Введите цифру от 1 до 9.");
                }
            }
        }
        public static bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if ((field[i, 0] == field[i, 1] && field[i, 1] == field[i, 2])||
                    (field[0, i] == field[1, i] && field[1, i] == field[2, i]))
                {
                    TicTacToe.PrintField();
                    Console.WriteLine($"Игрок {player % 2 + 1} победил!");
                    return true;
                }
                if ((field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2]) ||
                    (field[0, 2] == field[1, 1] && field[1, 1] == field[2, 0]))
                {
                    TicTacToe.PrintField();
                    Console.WriteLine($"Игрок {player % 2 + 1} победил!");
                    return true;
                }
            }
            return false;
        }

        public static bool CheckDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j] >= '1' && field[i, j] <= '9')
                        return false;
                }
            }
            TicTacToe.PrintField();
            Console.WriteLine("Ничья!");
            return true;
        }
        public static void Start()
        {
            char count = '1';
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    field[i, j] = count;
                    count++;
                }
            }
        }
        public static void ChangePlayer()
        {
            if (player % 2 == 0)
            {
                player++;
            }
            else if (player % 2 != 0)
            {
                player++;
            }
        }
    }
  
}

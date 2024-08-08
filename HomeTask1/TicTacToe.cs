/*Игра «Крестики-Нолики» (TicTacToe).
Игрок против игрока.
Отрисовка поля 3*3 в консоли.
Считывание хода игрока.
Проверка корректности хода.
Проверка победной комбинации хода.
Проверка на ничью.*/

using System;
class HomeTask1
{
    public static void printField(char[,] field)
    {

        Console.WriteLine($"-------------");
        Console.WriteLine($"| {field[2, 0]} | {field[2, 1]} | {field[2, 2]} |");
        Console.WriteLine($"-------------");
        Console.WriteLine($"| {field[1, 0]} | {field[1, 1]} | {field[1, 2]} |");
        Console.WriteLine($"-------------");
        Console.WriteLine($"| {field[0, 0]} | {field[0, 1]} | {field[0, 2]} |");
        Console.WriteLine($"-------------");
    }

public static void playerMove(char[,] field, char player)
    {
        while (true)
        {
            Console.Write($"Игрок {player}, ваш ход, введите цифру (1-9) : ");
            if (int.TryParse(Console.ReadLine(), out int move) && move >= 1 && move <= 9)
            {
                int row = (move - 1) / 3;
                int col = (move - 1) % 3;
                if (checkMove( field, move))
                {
                    field[row, col] = player;
                    break;
                }
                else
                {
                    Console.WriteLine("Позиция уже занята. Попробуйте снова.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Введите цифру от 1 до 9.");
            }
        }
    }

   public static bool checkMove(char[,] field, int move)
    {
        int row = (move - 1) / 3;
        int col = (move - 1) % 3;
        if (field[row, col] >= '1' && field[row, col] <= '9')
            return true;
        return false;
    }

    public static bool checkWin(char[,] field, char player)
    {

        for (int i = 0; i < 3; i++)
        {
            if (field[i, 0] == player && field[i, 1] == player && field[i, 2] == player)
                return true;
            if (field[0, i] == player && field[1, i] == player && field[2, i] == player)
                return true;
        }


        if ((field[0, 0] == player && field[1, 1] == player && field[2, 2] == player) ||
            (field[0, 2] == player && field[1, 1] == player && field[2, 0] == player))
            return true;

        return false;
    }
    public static bool checkDraw(char[,] field)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (field[i, j] >= '1' && field[i, j] <= '9')
                    return false;
            }
        }
        return true;
    }

    static void Main()
    {
        char[,] field = new char[3, 3];
        char count = '1';
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                field[i, j] = count;
                count++;
            }

        }

        char player = 'x';
        while (true)
        {
            printField(field);
            playerMove(field, player);
            if (checkWin(field, player))
            {
                printField(field);
                Console.WriteLine($"Игрок {player} победил!");
                break;
            }
            if (checkDraw(field))
            {
                printField(field);
                Console.WriteLine("Ничья!");
                break;
            }
            if (player == 'x')
            {
                player = 'o';
            }
            else
            {
                player = 'x';
            }
        }
    }

}
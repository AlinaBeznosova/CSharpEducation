/*Игра «Крестики-Нолики» (TicTacToe).
Игрок против игрока.
Отрисовка поля 3*3 в консоли.
Считывание хода игрока.
Проверка корректности хода.
Проверка победной комбинации хода.
Проверка на ничью.*/

using System;
using System.Numerics;
using HomeTask1;

class Program
{ 
    static void Main()
    {
        TicTacToe.Start();

        while (true)
        {
            TicTacToe.PrintField();
            TicTacToe.PlayerMove();

            if (TicTacToe.CheckWin())
            {
                break;
            }

            if (TicTacToe.CheckDraw())
            {
                break;
            }

            TicTacToe.ChangePlayer();
        }

    }

}

using HomeTask5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
  static void Main()
  {
    var user = new UserManager();
    
    while(true)
    {
      Console.WriteLine("1. Добавить пользователя");
      Console.WriteLine("2. Удалить пользователя");
      Console.WriteLine("3. Найти пользователя по id");
      Console.WriteLine("4. Вывести весь список пользователей");
      Console.WriteLine("5. Выход");

      Console.Write("Выберите действие: ");
      string choise = Console.ReadLine();
      Console.WriteLine();

      switch (choise)
      {
        case "1":
          try
          {
            Console.WriteLine("Введите id пользователя: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите имя пользователя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите электронную почту пользователя: ");
            string email = Console.ReadLine();
            user.AddUser(new User(id, name, email));
            Console.WriteLine("Пользователь добавлен");
            Console.WriteLine();
          }
          catch (UserAlreadyExistsException ex)
          {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.WriteLine();
          }
          break;

        case "2":
          try
          {
            Console.WriteLine("Введите id пользователя для удаления:");
            int id2 = Convert.ToInt32(Console.ReadLine());
            user.RemoveUser(id2);
            Console.WriteLine("Пользователь удален");
            Console.WriteLine();
          }
          catch(UserNotFoundException ex)
          {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.WriteLine();
          }
          break;

        case "3":
          try
          {
            Console.WriteLine("Введите id пользователя для поиска:");
            int id3 = Convert.ToInt32(Console.ReadLine());
            user.GetUser(id3);
            Console.WriteLine();
          }
          catch(UserNotFoundException ex)
          {
            Console.WriteLine($"Ошибка: {ex.Message}");
          }
          break;

        case "4":
          user.ListUsers();
          Console.WriteLine();
          break;

        case "5":
          return;

        default:
          Console.WriteLine("Некорректный ввод. Попробуйте еще раз. Введите цифру от 1 до 5");
          break;
      }
    }
  }
}
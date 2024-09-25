using HomeTask4;


class Program
{
  static void Main(string[] args)
  {

    var manager = new EmployeeManager<Employee>();


    while (true)
    {
      Console.WriteLine("1. Добавить полного сотрудника");
      Console.WriteLine("2. Добавить частичного сотрудника");
      Console.WriteLine("3. Получить информацию о сотруднике");
      Console.WriteLine("4. Обновить данные сотрудника");
      Console.WriteLine("5. Выйти");

      Console.Write("Выберите действие: ");
      string choiceAction = Console.ReadLine();
      Console.WriteLine();

      switch (choiceAction)
      {
        case "1":
          Console.WriteLine("Введите имя полного сотрудника:");
          var name = Console.ReadLine();
          Console.WriteLine("Введите его зарплату:");
          var salary = Convert.ToDecimal(Console.ReadLine());
          manager.Add(new FullTimeEmployee(name, salary));
          Console.WriteLine("Полный сотрудник добавлен");
          Console.WriteLine();
          break;

        case "2":
          Console.WriteLine("Введите имя частичного сотрудника:");
          name = Console.ReadLine();
          Console.WriteLine("Введите его почасовую ставку:");
          var rate = Convert.ToDecimal(Console.ReadLine());
          Console.WriteLine("Введите количество отработанных часов:");
          var hours = Convert.ToInt32(Console.ReadLine());
          manager.Add(new PartTimeEmployee(name, rate, hours));
          Console.WriteLine("Частичный сотрудник добавлен");
          Console.WriteLine();
          break;

        case "3":
          Console.Write("Введите имя сотрудника: ");
          name = Console.ReadLine();
          var employee = manager.Get(name);

          if (employee != null)
            Console.WriteLine($"Зарплата: {employee.CalculateSalary()}");
          else
          {
            Console.WriteLine("Сотрудник не найден.");
          }
          break;

        case "4":
          Console.WriteLine("Введите имя сотрудника:");
          name = Console.ReadLine();
          employee = manager.Get(name);

          if (employee != null)
          {
            if (employee is FullTimeEmployee fullTimeEmployee)
            {
              Console.WriteLine("Введите новую зарплату: ");
              fullTimeEmployee.BaseSalary = Convert.ToDecimal(Console.ReadLine());
            }
            else if (employee is PartTimeEmployee partTimeEmployee)
            {
              Console.WriteLine("Введите новую почасовую ставку: ");
              partTimeEmployee.HourlyRate = Convert.ToDecimal(Console.ReadLine());
              Console.WriteLine("Введите новое количество отработанных часов: ");
              partTimeEmployee.HoursWorked = Convert.ToInt32(Console.ReadLine());
            }
            manager.Update(employee);
            Console.WriteLine("Данные сотрудника обновлены.");
            Console.WriteLine();
          }
          else
          {
            Console.WriteLine("Сотрудник не найден.");
          }
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


namespace HomeTask4
{
  /// <summary>
  /// Класс для управления коллекцией сотрудников.
  /// </summary>
  /// <typeparam name="T">Тип сотрудника.</typeparam>
  public class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
  {
    #region Поля и свойства

    /// <summary>
    /// Список сотрудников.
    /// </summary>
    private List<T> employees = new List<T>();

    #endregion

    #region Методы
    
    /// <summary>
    /// Добавление нового сотрудника в список.
    /// </summary>
    /// <param name="employee">Сотрудник.</param>
    public void Add(T employee)
    {
      employees.Add(employee);
    }

    /// <summary>
    /// Получение информации о сотруднике по имени.
    /// </summary>
    /// <param name="name">Имя сотрудника.</param>
    /// <returns></returns>
    public T Get(string name)
    {
      return employees.Find(e => e.Name == name);

    }

    /// <summary>
    /// Обновление данных о сотруднике.
    /// </summary>
    /// <param name="employee">Имя сотрудника.</param>
    public void Update(T employee)
    {
      var existingEmployee = Get(employee.Name);
      if (existingEmployee == null)
      {
        employees.Remove(existingEmployee);
        employees.Add(employee);
      }
    }

    #endregion
  }
}

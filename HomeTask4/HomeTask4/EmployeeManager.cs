namespace HomeTask4
{
  /// <summary>
  /// Управление коллекцией сотрудников.
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
    
    public void Add(T employee)
    {
      employees.Add(employee);
    }

    public T Get(string name)
    {
      return employees.Find(e => e.Name == name);
    }

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

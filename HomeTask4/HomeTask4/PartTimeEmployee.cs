using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeTask4
{
  /// <summary>
  /// Класс сотрудник с почасовой оплатой.
  /// </summary>
  public class PartTimeEmployee : Employee
  {
    #region Поля и свойства

    /// <summary>
    /// Имя сотрудника.
    /// </summary>
    private string name;

    /// <summary>
    /// Почасовая ставка.
    /// </summary>
    private decimal hourlyRate;

    /// <summary>
    /// Количество отработанных часов.
    /// </summary>
    private int hoursWorked;

    /// <summary>
    /// Свойство.
    /// </summary>
    public override string Name
    {
      get { return name; }
      set { name = value; }
    }

    /// <summary>
    /// Свойство.
    /// </summary>
    public override decimal BaseSalary
    {
      get { return hourlyRate * hoursWorked; }
      set { }
      
    }

    /// <summary>
    /// Свойство.
    /// </summary>
    public decimal HourlyRate
    {
      get { return hourlyRate; }
      set {hourlyRate = value; }
    }

    /// <summary>
    /// Свойство.
    /// </summary>
    public int HoursWorked
    {
      get { return hoursWorked; }
      set { hoursWorked = value; }
    }

    #endregion

    #region Методы

    /// <summary>
    /// Расччет зарплаты.
    /// </summary>
    /// <returns></returns>
    public override decimal CalculateSalary()
    {
      return hourlyRate * hoursWorked;
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя сотрудника.</param>
    /// <param name="hourlyRate">Почасовая ставка.</param>
    /// <param name="hoursWorked">Количество отработанных часов.</param>
    public PartTimeEmployee(string name, decimal hourlyRate, int hoursWorked)
    {
      Name = name;
      HourlyRate = hourlyRate;
      HoursWorked = hoursWorked;
    }
    #endregion
  }
}

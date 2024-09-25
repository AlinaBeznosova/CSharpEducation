using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeTask4
{
  /// <summary>
  /// Сотрудник с почасовой оплатой.
  /// </summary>
  public class PartTimeEmployee : Employee
  {
    #region Поля и свойства

    private string name;

    private decimal baseSalary;

    /// <summary>
    /// Почасовая ставка.
    /// </summary>
    private decimal hourlyRate;

    /// <summary>
    /// Количество отработанных часов.
    /// </summary>
    private int hoursWorked;

    public override string Name { get; set; }

    public override decimal BaseSalary
    {
      get { return hourlyRate * hoursWorked; }
      set { baseSalary = value; }
    }

    /// <summary>
    /// Свойство, представляющее почасовую ставку.
    /// </summary>
    public decimal HourlyRate { get; set; }

    /// <summary>
    /// Свойство, представляющее отработанные часы.
    /// </summary>
    public int HoursWorked { get; set; }

    #endregion

    #region Методы

    public override decimal CalculateSalary()
    {
      return HourlyRate * HoursWorked;
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Инициализирует новый объект класса.
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

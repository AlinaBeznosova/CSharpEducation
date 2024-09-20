using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeTask4
{
  /// <summary>
  /// Класс сотрудник с фиксированной зарплатой.
  /// </summary>
  public class FullTimeEmployee : Employee
  {
    #region Поля и свойства

    /// <summary>
    /// Имя сотрудника.
    /// </summary>
    private string name;

    /// <summary>
    /// Зарплата сотрудника.
    /// </summary>
    private decimal baseSalary;

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
      get { return baseSalary; }
      set { baseSalary = value; }
    }

    #endregion

    #region Методы

    /// <summary>
    /// Расчет зарплаты.
    /// </summary>
    /// <returns></returns>
    public override decimal CalculateSalary()
    {
      return baseSalary; 
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя сотрудника.</param>
    /// <param name="baseSalary">Зарплата сотрудника.</param>

    public FullTimeEmployee(string name, decimal baseSalary)
    {
      Name = name;
      BaseSalary = baseSalary;
    }

    #endregion
  }
}

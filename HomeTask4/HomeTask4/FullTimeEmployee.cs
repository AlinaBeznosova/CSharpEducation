using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeTask4
{
  /// <summary>
  /// Сотрудник с фиксированной зарплатой.
  /// </summary>
  public class FullTimeEmployee : Employee
  {
    #region Поля и свойства

    private string name;

    private decimal baseSalary;

    public override string Name { get; set; }

    public override decimal BaseSalary { get; set; }

    #endregion

    #region Методы

    public override decimal CalculateSalary()
    {
      return BaseSalary; 
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Инициализирует новый объект класса.
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

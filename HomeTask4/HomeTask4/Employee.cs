using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
  /// <summary>
  /// Сотрудник.
  /// </summary>
  public abstract class Employee
  {
    /// <summary>
    /// Свойство, представляющее имя сотрудника.
    /// </summary>
    public abstract string Name { get; set; }

    /// <summary>
    /// Свойство, представляюзее зарплату сотрудника.
    /// </summary>
    public abstract decimal BaseSalary {  get; set; }

    /// <summary>
    /// Рассчитать зарплату сотрудника.
    /// </summary>
    /// <returns>Зарплата сотрудника.</returns>
    public abstract decimal CalculateSalary();
  }
}

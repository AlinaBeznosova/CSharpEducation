using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
  /// <summary>
  /// Абстрактный класс сотрудник.
  /// </summary>
  public abstract class Employee
  {
    public abstract string Name { get; set; }
    public abstract decimal BaseSalary {  get; set; }
    public abstract decimal CalculateSalary();

  }
}

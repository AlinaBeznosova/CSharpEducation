using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
  /// <summary>
  /// Интерфейс для управления коллекцией сотрудников.
  /// </summary>
  /// <typeparam name="T">Тип сотрудника.</typeparam>
  internal interface IEmployeeManager<T>
  {
    void Add(T employee);

    T Get(string name);

    void Update(T employee);
  }
}

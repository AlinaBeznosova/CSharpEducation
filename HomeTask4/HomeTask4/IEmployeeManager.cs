using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
  /// <summary>
  /// Контракт для управления коллекцией сотрудников.
  /// </summary>
  /// <typeparam name="T">Тип сотрудника.</typeparam>
  internal interface IEmployeeManager<T>
  {
    /// <summary>
    /// Добавление нового сотрудника в коллекцию.
    /// </summary>
    /// <param name="employee">Сотрудник.</param>
    void Add(T employee);

    /// <summary>
    /// Поиск сотрудника по имени.
    /// </summary>
    /// <param name="name">Имя сотрудника.</param>
    /// <returns>Сотрудник.</returns>
    T Get(string name);

    /// <summary>
    /// Изменение данных о сотруднике.
    /// </summary>
    /// <param name="employee">Имя сотрудника.</param>
    void Update(T employee);
  }
}

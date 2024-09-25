using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
  /// <summary>
  /// Исключение, возникающее при поиске несуществующего пользователя.
  /// </summary>
  class UserNotFoundException : Exception
  {
    /// <summary>
    /// Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="message">Сообщение, описываюшее исключение.</param>
    public UserNotFoundException(string message)
      : base(message) { }
  }
}

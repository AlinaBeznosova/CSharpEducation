using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
  /// <summary>
  /// Исключение, возникающее при попытке создать пользователя, который уже существует.
  /// </summary>
  class UserAlreadyExistsException : Exception
  {
    /// <summary>
    /// Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="message">Сообщение, описывающее исключение.</param>
    public UserAlreadyExistsException(string message)
      : base(message) { }
  }
}

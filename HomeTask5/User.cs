using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
  /// <summary>
  /// Пользователь.
  /// </summary>
  class User
  {
    #region Поля и свойства

    /// <summary>
    /// Id пользователя.
    /// </summary>
    private int id;

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    private string name;

    /// <summary>
    /// Электронная почта пользователя.
    /// </summary>
    private string email;

    /// <summary>
    /// Свойство, представляющее id пользователя.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Свойство, представляющее имя пользователя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Свойство, представялющее электронную почту пользователя.
    /// </summary>
    public string Email { get; set; }

    #endregion

    #region Конструктор

    /// <summary>
    /// Инициализирует новый объект класса.
    /// </summary>
    /// <param name="id">Id пользвателя.</param>
    /// <param name="name">Имя пользователя.</param>
    /// <param name="email">Электронная почта пользователя.</param>
    public User(int id, string name, string email)
    {
      Id = id;
      Name = name;
      Email = email;
    }

    #endregion
  }
}

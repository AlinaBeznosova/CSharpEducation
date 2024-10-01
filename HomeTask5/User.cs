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
  public class User
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
    /// Id пользователя.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Электронная почта пользователя.
    /// </summary>
    public string Email { get; set; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
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

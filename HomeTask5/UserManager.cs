using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeTask5
{
  /// <summary>
  /// Управление коллекцией пользователей.
  /// </summary>
   class UserManager
  {
    #region Поля

    /// <summary>
    /// Список пользователей.
    /// </summary>
    List<User> users = new List<User>();

    #endregion

    #region Методы

    /// <summary>
    /// Добавить нового пользователя.
    /// </summary>
    /// <param name="user">Пользователь.</param>
    /// <exception cref="UserAlreadyExistsException">Исключение, при добавлении уже существующего пользователя.</exception>
    public void AddUser(User user)
    {
      foreach (var u in users)
        if (u.Id == user.Id)
          throw new UserAlreadyExistsException("Пользователь с таким id уже существует.");
      users.Add(user);
    }

    /// <summary>
    /// Удалить пользоваеля.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <exception cref="UserNotFoundException">Исключение, при удалении несуществующего пользователя.</exception>
    public void RemoveUser (int id)
    {
      var userToRemove = users.Find(u => u.Id == id);
      if ( userToRemove !=null)
        users.Remove(userToRemove);
      else
        throw new UserNotFoundException("Пользователь не найден.");
    }

    /// <summary>
    /// Найти пользователя по id.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <exception cref="UserNotFoundException">Исключение, при поиске несуществующего пользователя.</exception>
    public void GetUser (int id)
    {
      var userToFind = users.Find(u => u.Id == id);
        if (userToFind != null)
          Console.WriteLine($"Id: {id} Имя: {userToFind.Name} Почта: {userToFind.Email}");
        else
          throw new UserNotFoundException("Пользователь не найден.");
    }

    /// <summary>
    /// Вывести весь список пользователей.
    /// </summary>
    public void ListUsers()
    {
      foreach (var user in users)
        Console.WriteLine($"Id: {user.Id} Имя: {user.Name} Почта: {user.Email}");
    }

    #endregion
  }
}

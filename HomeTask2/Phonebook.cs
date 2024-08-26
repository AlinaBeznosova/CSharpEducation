namespace HomeTask3
{
/// <summary>
/// Телефонная книга.
/// </summary>
	class Phonebook
	{
		#region Поля
		/// <summary>
		/// Текстовый файл, в который записывается телефонна книга.
		/// </summary>
		private const string txtFile = "phonebook.txt";
		
		/// <summary>
		/// Телефонная книга.
		/// </summary>
		private static Phonebook phonebook;

		/// <summary>
		/// Коллекция абонентов.
		/// </summary>
		private List<Abonent> abonents;
		#endregion

		#region Методы
		/// <summary>
		/// Создание класса одиночки.
		/// </summary>
		/// <returns></returns>
		public static Phonebook Singleton()
		{
			if (phonebook == null)
				phonebook = new Phonebook();
			return phonebook;
		}
		/// <summary>
		/// Чтение данных из текстового файла.
		/// </summary>
		/// <returns></returns>
		private List<Abonent> LoadFromFile()
		{
			if (File.Exists(txtFile))
			{
				string[] lines = File.ReadAllLines(txtFile);
				foreach (string line in lines)
				{
					string[] parts = line.Split(':');
					if (parts.Length == 2)
					{
						abonents.Add(new Abonent(parts[0], parts[1]));
					}
				}

			}
			return abonents;
		}

		/// <summary>
		/// Сохранение данных в текстовый файл.
		/// </summary>
		private void SaveToFile()
		{
			string[] lines = abonents.Select(a => $"{a.Name}:{a.PhoneNumber}").ToArray();
			File.WriteAllLines(txtFile, lines);
		}

		/// <summary>
		/// Добавление нового абонента.
		/// </summary>
		/// <param name="abonentToAdd">Абонент, которого добавляем.</param>
		/// <exception cref="Exception">Исключение, если пытаемся создать уже существующего абонента.</exception>
		public void AddAbonent(Abonent abonentToAdd)
		{

			foreach (Abonent abonent in abonents.ToList())
			{
				if (abonent.PhoneNumber == abonentToAdd.PhoneNumber)
				{
					throw new Exception("Абонент с таким номером уже существует");
				}
			}
			abonents.Add(abonentToAdd);
			SaveToFile();
		}

		/// <summary>
		/// Удаление абонента.
		/// </summary>
		/// <param name="phoneNumber">Номер телефона абонента, которого нужно удалить.</param>
		/// <returns></returns>
		public bool RemoveAbonent(string phoneNumber)
		{
			int count = 0;
			foreach (Abonent abonentToRemove in abonents.ToList())
			{
				if (abonentToRemove.PhoneNumber == phoneNumber)
				{
					abonents.Remove(abonentToRemove);
					SaveToFile();
					count++;
				}

			}
			if (count != 0)
				return true;
			else return false;

		}

		/// <summary>
		/// Поиск абонента по номеру телефона.
		/// </summary>
		/// <param name="phoneNumber">Номер телефона абонента, который ищем.</param>
		/// <returns></returns>
		public string GetAbonentByPhoneNumber(string phoneNumber)
		{

			foreach (Abonent abonent in abonents)
			{
				if (abonent.PhoneNumber == phoneNumber)
				{
					return abonent.Name;

				}
			}
			return String.Empty;
		}

		/// <summary>
		/// Поиск абонента по имени.
		/// </summary>
		/// <param name="name">Имя, которое ищем.</param>
		/// <returns></returns>
		public string GetPhoneNumberByName(string name)
		{
			foreach (Abonent abonent in abonents)
			{
				if (abonent.Name == name)
				{
					return abonent.PhoneNumber;

				}
			}
			return String.Empty;
		}

		/// <summary>
		/// Вывод данных текстового файла в консоль.
		/// </summary>
		public void OutputFile()
		{
			String line;
			StreamReader sr = new StreamReader(txtFile);

			line = sr.ReadLine();

			while (line != null)
			{
				Console.WriteLine(line);
				line = sr.ReadLine();
			}
			sr.Close();

		}
#endregion

#region Конструкторы
		/// <summary>
		/// Создание коллекции с абонентами.
		/// </summary>
		private Phonebook()
		{
			abonents = new List<Abonent>();
			LoadFromFile();
		}
		#endregion
	}
}

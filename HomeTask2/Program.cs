using HomeTask3;

class Program
{

	static void Main(string[] args)
	{
		

		Phonebook phonebook = Phonebook.Singleton();

		while (true)
		{
			Console.WriteLine("1. Добавить абонента");
			Console.WriteLine("2. Удалить абонента");
			Console.WriteLine("3. Найти абонента по номеру");
			Console.WriteLine("4. Найти номер по имени");
			Console.WriteLine("5. Вывести содержимое телефонной книги");
			Console.WriteLine("6. Выход");

			Console.Write("Выберите действие: ");
			string choiceAction = Console.ReadLine();
			Console.WriteLine();
			
			switch (choiceAction)
			{
				case "1":
					Console.Write("Введите имя: ");
					string name = Console.ReadLine();
					Console.Write("Введите номер телефона: ");
					string phoneNumber = Console.ReadLine();
					phonebook.AddAbonent(new Abonent(name, phoneNumber));
					Console.WriteLine("Абонент добавлен");
					Console.WriteLine();
					break;

				case "2":
					Console.Write("Введите номер телефона для удаления: ");
					string phoneNumberToRemove = Console.ReadLine();
					if (phonebook.RemoveAbonent(phoneNumberToRemove))
						Console.WriteLine("Абонент удален");
					else
						Console.WriteLine("Абонент не найден");
					Console.WriteLine();
					break;

				case "3":
					Console.Write("Введите номер телефона для поиска: ");
					string phoneNumberToFind = Console.ReadLine();
					name = phonebook.GetAbonentByPhoneNumber(phoneNumberToFind);
					if (name == String.Empty)
						Console.WriteLine("Абонент не найден");
					else
						Console.WriteLine(name);
					Console.WriteLine();
					break;

				case "4":
					Console.Write("Введите имя для поиска: ");
					string nameToFind = Console.ReadLine();
					phoneNumber = phonebook.GetPhoneNumberByName(nameToFind);
					if (phoneNumber == String.Empty)
						Console.WriteLine("Абонент не найден"); 
					else
						Console.WriteLine(phoneNumber);
					Console.WriteLine();
					break;

				case "5":
					phonebook.OutputFile();
					Console.WriteLine();
					break;

				case "6":
					return;

				default:
					Console.WriteLine("Некорректный ввод. Попробуйте еще раз. Введите цифру от 1 до 5");
					break;

			}
		}
	}

}


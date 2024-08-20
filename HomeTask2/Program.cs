/*Должен уметь принимать от пользователя номер и имя телефона.
Сохранять номер в файле phonebook.txt. (При завершении программы либо при добавлении).
Вычитывать из файла сохранённые номера. (При старте программы).
Удалять номера.
Получать абонента по номеру телефона.
Получать номер телефона по имени абонента.

Обращение к Phonebook должно быть как к классу-одиночке.
Внутри должна быть коллекция с абонентами.
Для обращения с абонентами нужно завести класс Abonent. С полями «номер телефона», «имя».
Не дать заносить уже записанного абонента.*/


using System;
using System.IO;
using HomeTask3;

class Program
{

    static void Main(string[] args)
    {

        Phonebook phonebook = Phonebook.Instance;

        while (true)
        {
            Console.WriteLine("1. Добавить абонента");
            Console.WriteLine("2. Удалить абонента");
            Console.WriteLine("3. Найти абонента по номеру");
            Console.WriteLine("4. Найти номер по имени");
            Console.WriteLine("5. Вывести содержимое телефонной книги");
            Console.WriteLine("6. Выход");

            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите имя: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите номер телефона: ");
                    string phoneNumber = Console.ReadLine();
                    phonebook.AddAbonent(new Abonent(name, phoneNumber));
                    break;

                case "2":
                    Console.Write("Введите номер телефона для удаления: ");
                    string phoneNumberToRemove = Console.ReadLine();
                    phonebook.RemoveAbonent(phoneNumberToRemove);
                    break;

                case "3":
                    Console.Write("Введите номер телефона для поиска: ");
                    string phoneNumberToFind = Console.ReadLine();
                    phonebook.GetAbonentByPhoneNumber(phoneNumberToFind);
                    break;

                case "4":
                    Console.Write("Введите имя для поиска: ");
                    string nameToFind = Console.ReadLine();
                    phonebook.GetPhoneNumberByName(nameToFind);
                    break;

                case "5":
                    phonebook.OutputFile();
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


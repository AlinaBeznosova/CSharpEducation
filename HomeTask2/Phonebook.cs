namespace HomeTask3
{
    class Phonebook
    {

        private static Phonebook instance;
        private static readonly object _lock = new object();
        private List<Abonent> abonents;

        private Phonebook()
        {
            abonents = new List<Abonent>();
            LoadFromFileSync();
        }

        public static Phonebook Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null)
                        {
                            instance = new Phonebook();
                        }
                    }
                }
                return instance;
            }
        }


        public List<Abonent> LoadFromFileSync()
        {
            if (File.Exists("phonebook.txt"))
            {
                string[] lines = File.ReadAllLines("phonebook.txt");
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

        private void SaveToFileSync()
        {
            string[] lines = abonents.Select(a => $"{a.Name}:{a.PhoneNumber}").ToArray();
            File.WriteAllLines("phonebook.txt", lines);
        }

        public void AddAbonent(Abonent abonentToAdd)
        {

            foreach (Abonent abonent in abonents.ToList())
            {
                if (abonent.PhoneNumber == abonentToAdd.PhoneNumber)
                {
                    Console.WriteLine("Абонент с таким номером уже существует.");
                    Console.WriteLine();
                    return;
                }
            }
            abonents.Add(abonentToAdd);
            SaveToFileSync();
            Console.WriteLine("Абонент добавлен");
            Console.WriteLine();
        }

        public void RemoveAbonent(string phoneNumber)
        {
            int count = 0;
            foreach (Abonent abonentToRemove in abonents.ToList())
            {
                if (abonentToRemove.PhoneNumber == phoneNumber)
                {
                    abonents.Remove(abonentToRemove);
                    SaveToFileSync();
                    Console.WriteLine("Абонент удален");
                    Console.WriteLine();
                    count++;
                }

            }
            if (count == 0)
                Console.WriteLine("Абонент не найден");
            Console.WriteLine();

        }

        public void GetAbonentByPhoneNumber(string phoneNumber)
        {
            int count = 0;
            foreach (Abonent abonent in abonents)
            {
                if (abonent.PhoneNumber == phoneNumber)
                {
                    Console.WriteLine($"Имя: {abonent.Name}");
                    Console.WriteLine();
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Абонент не найден");
                Console.WriteLine();
            }

        }

        public void GetPhoneNumberByName(string name)
        {
            int count = 0;
            foreach (Abonent abonent in abonents)
            {
                if (abonent.Name == name)
                {
                    Console.WriteLine($"Телефон: {abonent.PhoneNumber}");
                    Console.WriteLine();
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Абонент не найден");
                Console.WriteLine();
            }
        }

        public void OutputFile()
        {
            String line;

            StreamReader sr = new StreamReader("phonebook.txt");

            line = sr.ReadLine();

            while (line != null)
            {
                Console.WriteLine(line);

                line = sr.ReadLine();
            }
            sr.Close();
            Console.WriteLine();
        }


    }
}

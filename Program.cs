using System;
using System.IO; 

namespace SmartAlarm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            AlarmManager manager = new AlarmManager();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== РОЗУМНИЙ БУДИЛЬНИК ===");
                Console.WriteLine("1. Показати всі будильники");
                Console.WriteLine("2. Додати новий будильник");
                Console.WriteLine("3. Видалити будильник");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAlarms(manager);
                        break;
                    case "2":
                        AddAlarmUI(manager);
                        break;
                    case "3":
                        DeleteAlarmUI(manager);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір!");
                        break;
                }
            }
        }

        static void ShowAlarms(AlarmManager manager)
        {
            Console.WriteLine("\n--- Список будильників ---");
            var list = manager.AlarmsList;
            if (list.Count == 0)
            {
                Console.WriteLine("Список порожній.");
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    string smartInfo = list[i].IsSmartAwakening ? "(Розумний)" : "";
                    Console.WriteLine($"{i + 1}. {list[i].AlarmTime:HH:mm} - ♫ {list[i].MelodyPath} {smartInfo}");
                }
            }
            Console.WriteLine("\nНатисніть Enter...");
            Console.ReadLine();
        }

        static void AddAlarmUI(AlarmManager manager)
        {
            Console.WriteLine("\n--- Новий будильник ---");
            try
            {
                Console.Write("Введіть час (ГГ:ХХ): ");
                DateTime time = DateTime.Parse(Console.ReadLine());

                string melody = ChooseMelodyUI();
                Console.WriteLine($"Встановлено мелодію: {melody}");

                Console.Write("Увімкнути розумне пробудження? (y/n): ");
                string smartInput = Console.ReadLine();
                bool isSmart = smartInput.ToLower() == "y";

                manager.CreateAlarm(time, melody, isSmart);
                Console.WriteLine("Будильник успішно збережено!");
            }
            catch
            {
                Console.WriteLine("Помилка введення даних!");
            }
            Console.ReadLine();
        }

        static void DeleteAlarmUI(AlarmManager manager)
        {
            ShowAlarms(manager);
            Console.Write("Введіть номер для видалення: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                manager.DeleteAlarm(num - 1);
            }
        }

        static string ChooseMelodyUI()
        {
            Console.WriteLine("\n--- Вибір мелодії ---");

            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Melodies");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Увага: Папка 'Melodies' не знайдена (була створена автоматично).");
                Console.WriteLine("Мелодій немає. Встановлено стандартний звук.");
                Console.ResetColor();
                return "Standard_Beep.mp3";
            }

            string[] files = Directory.GetFiles(folderPath);

            if (files.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("У папці 'Melodies' немає файлів.");
                Console.WriteLine("Встановлено стандартний звук.");
                Console.ResetColor();
                return "Standard_Beep.mp3";
            }

            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}");
            }

            Console.Write("Оберіть номер мелодії: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= files.Length)
            {
                return Path.GetFileName(files[choice - 1]);
            }

            Console.WriteLine("Невірний вибір. Встановлено першу мелодію зі списку.");
            return Path.GetFileName(files[0]);
        }
    }
}
using System.Text.Json;

namespace ClassLibraryAuthor
{
    /// <summary>
    /// Represents the main program for managing authors and their books.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The list of authors.
        /// </summary>
        public static List<Author> authors = new List<Author>();
        
        /// <summary>
        /// The AutoSaver instance for automatic saving.
        /// </summary>
        private static AutoSaver autoSaver;
        
        /// <summary>
        /// The file path for loading and saving data.
        /// </summary>
        private static string filePath;

        /// <summary>
        /// The main entry point of the program.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            // Initialize AutoSaver with the provided file path and list of authors.
            autoSaver = new AutoSaver(filePath, authors);

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Загрузить данные из файла");
                Console.WriteLine("2. Отсортировать данные");
                Console.WriteLine("3. Редактировать данные автора");
                Console.WriteLine("4. Вывести данные");
                Console.WriteLine("5. Сохранить данные в файл");
                Console.WriteLine("6. Изменить доход книги");
                Console.WriteLine("7. Выход");

                string choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            authors = FileHandler.LoadData(filePath, autoSaver);
                            break;
                        case "2":
                            authors = SortHandler.SortData(authors);
                            break;
                        case "3":
                            authors = AuthorEditor.EditAuthorData(authors);
                            break;
                        case "4":
                            DisplayData();
                            break;
                        case "5":
                            FileHandler.SaveDataToFile(authors);
                            break;
                        case "6":
                            BookEditor.EditBookEarnings(authors);
                            break;
                        case "7":
                            Console.WriteLine("Завершение работы.");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Неизвестная команда. Попробуйте еще раз.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
            }
        }
        
        /// <summary>
        /// Displays data for all authors.
        /// </summary>
        static void DisplayData()
        {
            if (authors.Count == 0)
            {
                Console.WriteLine("Нет загруженных данных.");
                return;
            }
            
            foreach (var author in authors)
            {
                string json = author.ToJSON();
                Console.WriteLine(json);
            }
        }
    }
}

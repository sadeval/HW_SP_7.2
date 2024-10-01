using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите путь к директории:");
        string? currentDirectory = Console.ReadLine();

        if (Directory.Exists(currentDirectory))
        {
            while (true)
            {
                Console.WriteLine($"\nСодержимое директории: {currentDirectory}");

                // Вывод папок
                string[] directories = Directory.GetDirectories(currentDirectory);
                Console.WriteLine("\nПапки:");
                foreach (string dir in directories)
                {
                    Console.WriteLine("  " + Path.GetFileName(dir));
                }

                // Вывод файлов
                string[] files = Directory.GetFiles(currentDirectory);
                Console.WriteLine("\nФайлы:");
                foreach (string file in files)
                {
                    Console.WriteLine("  " + Path.GetFileName(file));
                }

                Console.WriteLine("\nВведите имя папки для перехода (или '..' для возврата назад, 'exit' для выхода):");
                string? input = Console.ReadLine();

                // Команда выхода
                if (input.ToLower() == "exit")
                {
                    break;
                }

                // Переход на уровень выше
                if (input == "..")
                {
                    // Если это корневая директория, возвращение невозможно
                    if (Directory.GetParent(currentDirectory) != null)
                    {
                        currentDirectory = Directory.GetParent(currentDirectory).FullName;
                    }
                    else
                    {
                        Console.WriteLine("Вы находитесь в корневой директории.");
                    }
                }
                else
                {
                    // Формируем новый путь на основе введённого имени
                    string newDirectory = Path.Combine(currentDirectory, input);

                    if (Directory.Exists(newDirectory))
                    {
                        currentDirectory = newDirectory; // Переход в выбранную папку
                    }
                    else
                    {
                        Console.WriteLine("Папка не найдена, пожалуйста, введите корректное название.");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Указанная директория не существует.");
        }
    }
}

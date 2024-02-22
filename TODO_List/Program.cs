using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.Unicode;
        // В этом задании вам нужно создать список дел.
        // Исплоьзуйте массив или лист для хранения списка дел.
        // При запуске программа должна выводить меню на экран и ждать дальнейших действий пользователя.
        // После выполнения действия программа должна снова выводить меню и ждать дальнейших действий пользователя.
        // Все действия должны выполняться до тех пор, пока пользователь не выберет пункт "Выход".


        List<string> todoList = new List<string>();
        while (true)
        {
            // Вывод списка задач
            if (todoList.Count > 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Список задач:");
                int i = 0;
                foreach (string item in todoList)
                {
                    i++;
                    Console.WriteLine($"{i}. {item}");
                }
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Удалить задачу");
            Console.WriteLine("3. Вывести список задач");
            Console.WriteLine("0. Выход");

            Console.WriteLine("Введите номер нужного пункта меню: ");
            byte.TryParse(Console.ReadLine(), out byte menuId);
            Console.ResetColor();

            // Выход из программы по запросу пользователя
            if (menuId == 0)
            {
                Console.WriteLine("Спасибо за использование нашего продукта!");
                break;
            }

            // Обработака пользовательского выбора пункта меню
            switch (menuId)
            {
                case 1:
                    Console.WriteLine("\nВведите задачу:");
                    todoList.Add(Console.ReadLine());
                    break;

                case 2:
                    int taskId;
                    if (todoList.Count > 0)
                    {
                        while (true)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Введите номер задачи для удаления или 0(ноль) для выхода в главное меню:");
                            Console.ResetColor();

                            if (!int.TryParse(Console.ReadLine(), out taskId))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Введено некорректное значение.");
                                Console.ResetColor();
                                continue;
                            }
                            else if (taskId > todoList.Count())
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Такой задачи нет.");
                                Console.ResetColor();
                                Console.WriteLine();
                                
                                // Вывод списка задач
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Список задач:");
                                int i = 0;
                                foreach (string item in todoList)
                                {
                                    i++;
                                    Console.WriteLine($"{i}. {item}");
                                }
                                Console.ResetColor();
                                continue;
                            }
                            else if (taskId == 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                todoList.RemoveAt(taskId - 1);
                                Console.WriteLine($"\nЗадача {taskId} удалена.");
                                Console.ResetColor();
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Список задач пуст, пока нечего удалять.");
                        Console.ResetColor();
                    }
                    break;

                case 3:
                    if (todoList.Count == 0)
                    {
                        Console.Clear();    
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Список задач пустой");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Clear();
                    }
                    break;

                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введено некорректное значение, повторите выбор.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
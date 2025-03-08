namespace View
{
    public class ViewMessage
    {
        public static void ShowEror(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ошибка: {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ShowMessage(string message, string color)
        {
            if (color == "Red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (color == "Green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        public static void ShowMessage(bool message)
        {
            Console.WriteLine(message);
        }

        public static void ShowMessage(double message)
        {
            Console.WriteLine(message);
        }

        #region Оптимизация вывода
        public static void ClearConsole()
        {
            Console.Clear();
        }
        #endregion

        #region Вывод меню
        public static void PrintMenu()
        {
            Console.WriteLine("-------Параметры меню-------");
            Console.WriteLine("1 - Создать объект типа Plant с клавиатуры и вывести его");
            Console.WriteLine("2 - Создать объект типа Tree с клавиатуры и вывести его");
            Console.WriteLine("3 - Создать объект типа Flower с клавиатуры и вывести его");
            Console.WriteLine("4 - Создать объект типа Rose с клавиатуры и вывести его");
            Console.WriteLine("5 - Создать массив с объектами разных типов и вывести его (Только из иерархии)");
            Console.WriteLine("6 - Показать Розы, у которых нет Шипов");
            Console.WriteLine("7 - Показать самое низкое дерево");
            Console.WriteLine("8 - Показать Цветы с определённым запахом");
            Console.WriteLine("9 - Узнать информацию о кол-ве объектов");
            Console.WriteLine("10 - Создать массив с объектами разных типов и вывести его");
            Console.WriteLine("0 - Закончить работу");
        }
        #endregion

    }
}

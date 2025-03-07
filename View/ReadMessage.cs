using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class ReadMessage
    {
        public static string ReadStringFromConsole(string message)
        {
            string inputString;
            do
            {
                Console.Write($"{message}");
                inputString = Console.ReadLine();
                if (string.IsNullOrEmpty(inputString))
                {
                    ViewMessage.ShowEror("Ошибка: строка не может быть пустой. Попробуйте снова.");
                }
            } while (string.IsNullOrEmpty(inputString));

            return inputString; // Возвращаем только непустую строку
        }

        public static bool ReadBooleanFromConsole(string message)
        {
            string inputString;
            do
            {
                Console.Write($"{message}");
                inputString = Console.ReadLine();
                if (string.IsNullOrEmpty(inputString))
                {
                    ViewMessage.ShowEror("Ошибка: строка не может быть пустой. Попробуйте снова.");
                }
                if (inputString != "Да" && inputString != "Нет")
                {
                    ViewMessage.ShowEror("Ошибка: Введите только Да или Нет");
                }
            } while (string.IsNullOrEmpty(inputString) || (inputString!="Да" && inputString != "Нет"));
            if (inputString == "Да") return true;
            else return false;
        }
        public static int ReadIntPositiveFromConsole(string message)
        {
            int number;
            bool validInput;
            do
            {
                Console.Write($"{message}"); // Выводим переданное сообщение
                string input = Console.ReadLine(); // Читаем строку с клавиатуры

                // Проверяем, является ли ввод корректным целым числом и неотрицательным
                validInput = int.TryParse(input, out number) && number >= 0;

                if (!validInput)
                {
                    ViewMessage.ShowEror("Ошибка: введите корректное целое неотрицательное число.");
                }
            } while (!validInput); // Повторяем, пока ввод не станет корректным

            return number; // Возвращаем проверенное число
        }
    }
}

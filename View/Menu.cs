using Controller;
using Model;
using System.Drawing;
using System.Threading.Channels;
namespace View
{
    public class Menu
    {
        public static void StartMenu()
        {
            IRandomInit[] arrayOfPLant = new Plant[20];
            IRandomInit[] randomElement = new IRandomInit[100];
            string nextAction;
            bool continueRaning = true;
            do
            {
                ViewMessage.PrintMenu();
                nextAction = ReadMessage.ReadStringFromConsole("Введите число для работы:");
                switch (nextAction)
                {
                    case "1":
                        {
                            bool correctRunning = false;
                            do
                            {
                                try
                                {
                                    string nameOfPlant, colorOfPlant;
                                    nameOfPlant = ReadMessage.ReadStringFromConsole("Введите название растения:");
                                    colorOfPlant = ReadMessage.ReadStringFromConsole("Введите цвет растения:");
                                    Plant_Checking checking = new Plant_Checking();
                                    IInit plant_1;
                                    plant_1 = checking.TryInitPlant("plant", nameOfPlant, colorOfPlant);
                                    ViewMessage.ShowMessage(checking.ShowPlant((IShow)plant_1));
                                    //ViewMessage.ShowMessage(checking.ShowPlantNonVirtual(plant_1));
                                    correctRunning = true;
                                }
                                catch (ArgumentException ex)
                                {
                                    ViewMessage.ShowEror(ex.Message);
                                    correctRunning = false;
                                }

                            } while (!correctRunning);
                            break;
                        }
                    case "2":
                        {
                            bool correctRunning = false;
                            do
                            {
                                try
                                {
                                    string nameOfPlant, colorOfPlant;
                                    int heightOfPlant;
                                    nameOfPlant = ReadMessage.ReadStringFromConsole("Введите название дерева:");
                                    colorOfPlant = ReadMessage.ReadStringFromConsole("Введите цвет дерева:");
                                    heightOfPlant = ReadMessage.ReadIntPositiveFromConsole("Высоту дерева:");
                                    IInit tree_1;
                                    Plant_Checking checking = new Plant_Checking();
                                    tree_1 = checking.TryInitPlant("tree", nameOfPlant, colorOfPlant, heightOfPlant);
                                    ViewMessage.ShowMessage(checking.ShowPlant((IShow)tree_1));
                                    //ViewMessage.ShowMessage(checking.ShowPlantNonVirtual(tree_1));
                                    correctRunning = true;
                                }
                                catch (ArgumentException ex)
                                {
                                    ViewMessage.ShowEror(ex.Message);
                                    correctRunning = false;
                                }

                            } while (!correctRunning);
                            break;
                        }
                    case "3":
                        {
                            bool correctRunning = false;
                            do
                            {
                                try
                                {
                                    string nameOfPlant, colorOfPlant, smellOfPlant;
                                    nameOfPlant = ReadMessage.ReadStringFromConsole("Введите название цветка:");
                                    colorOfPlant = ReadMessage.ReadStringFromConsole("Введите цвет цветка:");
                                    smellOfPlant = ReadMessage.ReadStringFromConsole("Введите запах цветка:");
                                    IInit flower_1;
                                    Plant_Checking checking = new Plant_Checking();
                                    flower_1 = checking.TryInitPlant("flower", nameOfPlant, colorOfPlant, null, smellOfPlant);
                                    ViewMessage.ShowMessage(checking.ShowPlant((IShow)flower_1));
                                    //ViewMessage.ShowMessage(checking.ShowPlantNonVirtual(flower_1));
                                    correctRunning = true;
                                }
                                catch (ArgumentException ex)
                                {
                                    ViewMessage.ShowEror(ex.Message);
                                    correctRunning = false;
                                }
                            } while (!correctRunning);
                            break;
                        }
                    case "4":
                        {
                            bool correctRunning = false;
                            do
                            {
                                try
                                {
                                    string nameOfPlant, colorOfPlant, smellOfPlant;
                                    bool hasThorns;
                                    nameOfPlant = ReadMessage.ReadStringFromConsole("Введите название Розы: ");
                                    colorOfPlant = ReadMessage.ReadStringFromConsole("Введите цвет Розы: ");
                                    smellOfPlant = ReadMessage.ReadStringFromConsole("Введите запах Розы: ");
                                    hasThorns = ReadMessage.ReadBooleanFromConsole("Есть шипы? Да/Нет: ");
                                    IInit rose_1;
                                    Plant_Checking checking = new Plant_Checking();
                                    rose_1 = checking.TryInitPlant("rose", nameOfPlant, colorOfPlant, null, smellOfPlant, hasThorns);
                                    ViewMessage.ShowMessage(checking.ShowPlant((IShow)rose_1));
                                    //ViewMessage.ShowMessage(checking.ShowPlantNonVirtual(rose_1));
                                    correctRunning = true;
                                }
                                catch (ArgumentException ex)
                                {
                                    ViewMessage.ShowEror(ex.Message);
                                    correctRunning = false;
                                }
                            } while (!correctRunning);
                            break;
                        }
                    case "5":
                        {
                            Plant_Checking checking = new Plant_Checking();
                            for (int i = 0; i < 5; i++)
                            {
                                arrayOfPLant[i] = new Plant();
                                arrayOfPLant[i] = checking.RandominitPlant(arrayOfPLant[i]);
                            }
                            for (int i = 5; i < 10; i++)
                            {
                                arrayOfPLant[i] = new Tree();
                                arrayOfPLant[i] = checking.RandominitPlant(arrayOfPLant[i]);
                            }
                            for (int i = 10; i < 14; i++)
                            {
                                arrayOfPLant[i] = new Flower();
                                arrayOfPLant[i] = checking.RandominitPlant(arrayOfPLant[i]);
                            }
                            for (int i = 15; i < 20; i++)
                            {
                                arrayOfPLant[i] = new Rose();
                                arrayOfPLant[i] = checking.RandominitPlant(arrayOfPLant[i]);
                            }
                            arrayOfPLant[14] = new Flower("Тестовый", "Цветок", "Тест", 14);
                            ViewMessage.ShowMessage("------------Виртуальный Show------------", "Green");
                            foreach (var p in arrayOfPLant)//Можно var
                            {
                                ViewMessage.ShowMessage(checking.ShowPlant((IShow)p));
                            }
                            //ViewMessage.ShowMessage("------------НЕВиртуальный Show------------", "Red");
                            //foreach (var p in arrayOfPLant)//Можно var
                            //{
                            //    ViewMessage.ShowMessage(checking.ShowPlantNonVirtual(p));
                            //}
                            break;
                        }
                    case "6":
                        {
                            if (arrayOfPLant.All(item => item == null))
                            {
                                ViewMessage.ShowEror("Массив пуст, для начала заполните его нажмите (5)");
                                break;
                            }
                            IRandomInit[] requstedPlant = PlantRequests.RoseWithoutThorns(arrayOfPLant);
                            if (requstedPlant.All(item => item == null))
                            {
                                ViewMessage.ShowMessage("Ни один элемент не найден попробуйте пересоздать массив");
                                break;
                            }
                            Plant_Checking checking = new Plant_Checking();
                            ViewMessage.ShowMessage("Розы у которых нет Шипов:", "Green");
                            foreach (var p in requstedPlant)//Можно var
                            {
                                ViewMessage.ShowMessage(checking.ShowPlant((IShow)p));
                            }
                            //foreach (var p in requstedPlant)//Можно var
                            //{
                            //    ViewMessage.ShowMessage(checking.ShowPlantNonVirtual(p));
                            //}
                            break;
                        }
                    case "7":
                        {
                            if (arrayOfPLant.All(item => item == null))
                            {
                                ViewMessage.ShowEror("Массив пуст, для начала заполните его нажмите (5)");
                                break;
                            }
                            IRandomInit[] requstedPlant = PlantRequests.TheLessTree(arrayOfPLant);
                            Tree.countOfTree--;//Если успею через метод т.к. инкапсуляция
                            Plant.countOfPlants--;//Если успею через метод т.к. инкапсуляция
                            if (requstedPlant[0] == new Tree("Заглушка", "Заглушка", 12, 0))
                            {
                                ViewMessage.ShowMessage("Ни один элемент не найден попробуйте пересоздать массив");
                                break;
                            }
                            Plant_Checking checking = new Plant_Checking();
                            ViewMessage.ShowMessage("Самое маленькое дерево:", "Green");

                            foreach (var p in requstedPlant)//Можно var
                            {
                                ViewMessage.ShowMessage(checking.ShowPlant((IShow)p));
                            }
                            //foreach (var p in requstedPlant)//Можно var
                            //{
                            //    ViewMessage.ShowMessage(checking.ShowPlantNonVirtual(p));
                            //}
                            break;
                        };
                    case "8":
                        {
                            if (arrayOfPLant.All(item => item == null))
                            {
                                ViewMessage.ShowEror("Массив пуст, для начала заполните его нажмите (5)");
                                break;
                            }
                            ViewMessage.ShowMessage("Сладкий, Пряный, Свежий, Горький, Нейтральный", "Green");
                            string smellOfPlant = ReadMessage.ReadStringFromConsole("Введите один из перечисленных запахов по которому хотите найти цветы: ");
                            IRandomInit[] requstedPlant = PlantRequests.FlowerWithTheSmell(arrayOfPLant, smellOfPlant);
                            if (requstedPlant.All(item => item == null))
                            {
                                ViewMessage.ShowMessage("Ни один элемент не найден попробуйте пересоздать массив или ввести другой запах", "Red");
                                break;
                            }
                            Plant_Checking checking = new Plant_Checking();
                            ViewMessage.ShowMessage($"Найденные цветы по запаху '{smellOfPlant}'", "Green");
                            //foreach (var p in requstedPlant)//Можно var
                            //{
                            //    ViewMessage.ShowMessage(checking.ShowPlantNonVirtual(p));
                            //}
                            foreach (var p in requstedPlant)//Можно var
                            {
                                ViewMessage.ShowMessage(checking.ShowPlant((IShow)p));
                            }
                            break;
                        }
                    case "9":
                        {
                            ViewMessage.ShowMessage($"Количество созданных объектов типа Plant = {Plant.GetCountOfItem()}", "Green");
                            ViewMessage.ShowMessage($"Количество созданных объектов типа Tree = {Tree.GetCountOfItem()}", "Green");
                            ViewMessage.ShowMessage($"Количество созданных объектов типа Flower = {Flower.GetCountOfItem()}", "Green");
                            ViewMessage.ShowMessage($"Количество созданных объектов типа Rose = {Rose.GetCountOfItem()}", "Green");
                            ViewMessage.ShowMessage($"Количество созданных объектов типа Post = {Post.GetCountOfItem()}", "Green");
                            break;
                        }
                    case "10":
                        {
                            Random random = new Random();
                            Plant_Checking checking = new Plant_Checking(); 
                            for (int i = 0; i < randomElement.Length; i++)
                            {
                                int nextElement = random.Next(5);
                                switch (nextElement)
                                {
                                    case 0:
                                        {
                                            randomElement[i] = new Plant();
                                            randomElement[i] = checking.RandominitPlant(randomElement[i]);
                                            break;
                                        }
                                    case 1:
                                        {
                                            randomElement[i] = new Tree();
                                            randomElement[i] = checking.RandominitPlant(randomElement[i]);
                                            break;
                                        }
                                    case 2:
                                        {
                                            randomElement[i] = new Flower();
                                            randomElement[i] = checking.RandominitPlant(randomElement[i]);
                                            break;
                                        }
                                    case 3:
                                        {
                                            randomElement[i] = new Rose();
                                            randomElement[i] = checking.RandominitPlant(randomElement[i]);
                                            break;
                                        }
                                    case 4:
                                        {
                                            randomElement[i] = new Post();
                                            randomElement[i] = checking.RandominitPlant(randomElement[i]);
                                            break;
                                        }
                                }
                            }
                            foreach(IShow elem in randomElement)
                            {
                                ViewMessage.ShowMessage(checking.ShowPlant(elem));
                            }
                            break;
                        }
                    case "11":
                        {
                            if (arrayOfPLant.All(item => item == null))
                            {
                                ViewMessage.ShowEror("Массив пуст, для начала заполните его нажмите (5)");
                                break;
                            }
                            Plant_Checking checking = new Plant_Checking();
                            ViewMessage.ShowMessage("----------------------До сортировки----------------------", "Red");
                            foreach (IShow elem in arrayOfPLant)
                            {
                                ViewMessage.ShowMessage(checking.ShowPlant(elem));
                            }
                            Array.Sort(arrayOfPLant);
                            ViewMessage.ShowMessage("----------------------После сортировки----------------------", "Green");
                            foreach (IShow elem in arrayOfPLant)
                            {
                                ViewMessage.ShowMessage(checking.ShowPlant(elem));
                            }
                            Flower.countOfFlower--;//Если успею через метод т.к. инкапсуляция
                            Plant.countOfPlants--;//Если успею через метод т.к. инкапсуляция
                            ViewMessage.ShowMessage($"Объект Flower(\"Тестовый\", \"Цветок\", \"Тест\") имеет индекс: {Array.BinarySearch(arrayOfPLant, new Flower("Тестовый", "Цветок", "Тест", 0))}");
                            break;
                        }
                    case "12":
                        {
                            if (arrayOfPLant.All(item => item == null))
                            {
                                ViewMessage.ShowEror("Массив пуст, для начала заполните его нажмите (5)");
                                break;
                            }
                            Plant_Checking checking = new Plant_Checking();
                            ViewMessage.ShowMessage("----------------------До сортировки----------------------", "Red");
                            foreach (IShow elem in arrayOfPLant)
                            {
                                ViewMessage.ShowMessage(checking.ShowPlant(elem));
                            }
                            Array.Sort(arrayOfPLant, new ColorComparer());
                            ViewMessage.ShowMessage("----------------------После сортировки----------------------", "Green");
                            foreach (IShow elem in arrayOfPLant)
                            {
                                ViewMessage.ShowMessage(checking.ShowPlant(elem));
                            }
                            Flower.countOfFlower--;//Если успею через метод т.к. инкапсуляция
                            Plant.countOfPlants--;//Если успею через метод т.к. инкапсуляция
                            ViewMessage.ShowMessage($"Объект Flower(\"Тестовый\", \"Цветок\", \"Тест\") имеет индекс: {Array.BinarySearch(arrayOfPLant, new Flower("Тестовый", "Цветок", "Тест", 0))}");
                            break;
                        }
                    case "13":
                        {
                            Plant_Checking checking = new Plant_Checking();
                            ViewMessage.ShowMessage("Проверка клонирования");
                            Plant originplant = new Plant("Адиска", "Редиска", 52);
                            Plant shallowCopy = originplant.ShallowCopy();
                            Plant deepCopy = (Plant)originplant.Clone();

                            ViewMessage.ShowMessage($"Оригинал: \n{checking.ShowPlant((IShow)originplant)}");
                            ViewMessage.ShowMessage($"Поверхностная копия:  \n{checking.ShowPlant((IShow)shallowCopy)}");
                            ViewMessage.ShowMessage($"Глубокая копия:  \n{checking.ShowPlant((IShow)deepCopy)}");
                            ViewMessage.ShowMessage($"Изменим id у оригинала");
                            originplant.idOfPlants.Number = 3000;
                            ViewMessage.ShowMessage("После изменения Id:");
                            ViewMessage.ShowMessage($"Оригинал:  \n{checking.ShowPlant((IShow)originplant)}");
                            ViewMessage.ShowMessage($"Поверхностная копия:  \n{checking.ShowPlant((IShow)shallowCopy)}");
                            ViewMessage.ShowMessage($"Глубокая копия:  \n{checking.ShowPlant((IShow)deepCopy)}");
                            break;
                        }

                    case "0":
                        ViewMessage.ShowMessage("Конец работы программы", "Red");
                        continueRaning = false;
                        break;
                    default:
                        break;
                }
            } while (continueRaning);
        }
    }
}


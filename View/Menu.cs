using Controller;
using Model;
using System.Threading.Channels;
namespace View
{
    public class Menu
    {
        public static void StartMenu()
        {
            Plant[] arrayOfPLant = new Plant[20];
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
                                    Plant plant_1;
                                    plant_1 = checking.TryInitPlant("plant", nameOfPlant, colorOfPlant);
                                    ViewMessage.ShowMessage(checking.ShowPlant(plant_1));
                                    ViewMessage.ShowMessage(checking.ShowPlantNonVirtual(plant_1));
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
                                    Plant tree_1;
                                    Plant_Checking checking = new Plant_Checking();
                                    tree_1 = checking.TryInitPlant("tree", nameOfPlant, colorOfPlant, heightOfPlant);
                                    ViewMessage.ShowMessage(checking.ShowPlant(tree_1));
                                    ViewMessage.ShowMessage(checking.ShowPlantNonVirtual(tree_1));
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
                                    Plant flower_1;
                                    Plant_Checking checking = new Plant_Checking();
                                    flower_1 = checking.TryInitPlant("flower", nameOfPlant, colorOfPlant, null, smellOfPlant);
                                    ViewMessage.ShowMessage(checking.ShowPlant(flower_1));
                                    ViewMessage.ShowMessage(checking.ShowPlantNonVirtual(flower_1));
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
                                    Plant rose_1;
                                    Plant_Checking checking = new Plant_Checking();
                                    rose_1 = checking.TryInitPlant("rose", nameOfPlant, colorOfPlant, null, smellOfPlant, hasThorns);
                                    ViewMessage.ShowMessage(checking.ShowPlant(rose_1));
                                    ViewMessage.ShowMessage(checking.ShowPlantNonVirtual(rose_1));
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
                            for (int i = 10; i < 15; i++)
                            {
                                arrayOfPLant[i] = new Flower();
                                arrayOfPLant[i] = checking.RandominitPlant(arrayOfPLant[i]);
                            }
                            for (int i = 15; i < 20; i++)
                            {
                                arrayOfPLant[i] = new Rose();
                                arrayOfPLant[i] = checking.RandominitPlant(arrayOfPLant[i]);
                            }
                            ViewMessage.ShowMessage("------------Виртуальный Show------------", "Green");
                            foreach (var p in arrayOfPLant)//Можно var
                            {
                                ViewMessage.ShowMessage(checking.ShowPlant(p));
                            }
                            ViewMessage.ShowMessage("------------НЕВиртуальный Show------------", "Red");
                            foreach (var p in arrayOfPLant)//Можно var
                            {
                                ViewMessage.ShowMessage(checking.ShowPlantNonVirtual(p));
                            }
                            break;
                        }
                    case "6":
                        {
                            if (arrayOfPLant.All(item => item == null))
                            {
                                ViewMessage.ShowEror("Массив пуст, для начала заполните его нажмите (5)");
                                break;
                            }
                            Plant[] requstedPlant = PlantRequests.RoseWithoutThorns(arrayOfPLant);
                            if (requstedPlant.All(item => item == null))
                            {
                                ViewMessage.ShowMessage("Ни один элемент не найден попробуйте пересоздать массив");
                                break;
                            }
                            Plant_Checking checking = new Plant_Checking();
                            ViewMessage.ShowMessage("Розы у которых нет Шипов:", "Green");
                            foreach (var p in requstedPlant)//Можно var
                            {
                                ViewMessage.ShowMessage(checking.ShowPlantNonVirtual(p));
                            }
                            break;
                        }
                    case "7":
                        {
                            if (arrayOfPLant.All(item => item == null))
                            {
                                ViewMessage.ShowEror("Массив пуст, для начала заполните его нажмите (5)");
                                break;
                            }
                            Plant[] requstedPlant = PlantRequests.TheLessTree(arrayOfPLant);
                            if (requstedPlant[0].Name == "Заглушка")
                            {
                                ViewMessage.ShowMessage("Ни один элемент не найден попробуйте пересоздать массив");
                                break;
                            }
                            Plant_Checking checking = new Plant_Checking();
                            ViewMessage.ShowMessage("Самое маленькое дерево:", "Green");
                            foreach (var p in requstedPlant)//Можно var
                            {
                                ViewMessage.ShowMessage(checking.ShowPlantNonVirtual(p));
                            }
                            break;
                        }
                    case "8":
                        {
                            if (arrayOfPLant.All(item => item == null))
                            {
                                ViewMessage.ShowEror("Массив пуст, для начала заполните его нажмите (5)");
                                break;
                            }
                            ViewMessage.ShowMessage("Сладкий, Пряный, Свежий, Горький, Нейтральный", "Green");
                            string smellOfPlant = ReadMessage.ReadStringFromConsole("Введите один из перечисленных запахов по которому хотите найти цветы: ");
                            Plant[] requstedPlant = PlantRequests.FlowerWithTheSmell(arrayOfPLant, smellOfPlant);
                            if (requstedPlant.All(item => item == null))
                            {
                                ViewMessage.ShowMessage("Ни один элемент не найден попробуйте пересоздать массив или ввести другой запах", "Red");
                                break;
                            }
                            Plant_Checking checking = new Plant_Checking();
                            ViewMessage.ShowMessage($"Найденные цветы по запаху '{smellOfPlant}'", "Green");
                            foreach (var p in requstedPlant)//Можно var
                            {
                                ViewMessage.ShowMessage(checking.ShowPlantNonVirtual(p));
                            }
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


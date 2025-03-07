using Model;

namespace Controller
{
    public class Plant_Checking
    {
        public Plant TryInitPlant(string type, string name, string color, int? height = null, string smell = null, bool? hasThorns = null)
        {
            switch (type.ToLower())
            {
                case "plant": // Обычное растение
                    Plant plant = new Plant();//Вроде лишняя память, но мы создаём и сразу меняем
                    plant.Init(name, color);
                    return plant;
                case "tree": // Дерево
                    Tree tree = new Tree();
                    tree.Init(name, color, height);
                    return tree;
                case "flower": // Цветок
                    Flower flower = new Flower();
                    flower.Init(name, color, smell);
                    return flower;
                case "rose": // Роза
                    Rose rose = new Rose();
                    rose.Init(name, color, smell, hasThorns);
                    return rose;
                default: // Если тип неизвестен
                    throw new ArgumentException("Неизвестный тип растения");
            }
        }

        public string ShowPlant(Plant plant)//В функции используем Виртуальный, который сам переопределяться согласно типу
        {
            if (plant == null)
                throw new ArgumentException("Ошибка: растения не существует");
            string[] data = plant.Show();
            string result = $"------{plant.GetType().Name}------\n";
            for (int i = 0; i < data.Length; i += 2)
            {
                result += $"{data[i]}: {data[i + 1]}\n";
            }
            return result; // Возвращаем готовую строку
        }

        public string ShowPlantNonVirtual(Plant plant)//В функции используем Невиртуальный метод следовательно нужна проверка на тип
        {
            string[] data;
            if (plant == null)
                throw new ArgumentException("Ошибка: растения не существует");
            if (plant is Rose rose)
            {
                data = rose.ShowNoVirtual();
            }
            else if (plant is Tree tree)
            {
                data = tree.ShowNoVirtual();
            }
            else if (plant is Flower flower)
            {
                data = flower.ShowNoVirtual();
            }
            else 
            {
                data = plant.ShowNoVirtual();
            }
            string result = $"------{plant.GetType().Name}------\n";
            for (int i = 0; i < data.Length; i += 2)
            {
                result += $"{data[i]}: {data[i + 1]}\n";
            }
            return result;
        }
        public Plant RandominitPlant(Plant plant)//В функции используем Невиртуальный метод следовательно нужна проверка на тип
        {
            Plant result;
            if (plant == null)
                throw new ArgumentException("Ошибка: растения не существует");
            if (plant is Rose rose)
            {
                rose.RandomInit();
                result = rose;
            }
            else if (plant is Tree tree)
            {
                tree.RandomInit();
                result = tree;
            }
            else if (plant is Flower flower)
            {
                flower.RandomInit();
                result = flower;
            }
            else
            {
                plant.RandomInit();
                result = plant;
            }
            return result;
        }
    }
}
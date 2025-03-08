namespace Model
{
    public class PlantRequests
    {
        public static IRandomInit[] RoseWithoutThorns(IRandomInit[] plants) 
        {
            Plant[] currentArray = new Plant[plants.Length];
            uint countOfItem = 0;
            foreach (var plant in plants)
            {
                if (plant == null)
                {
                    continue;
                }
                Rose r = plant as Rose;
                if (r != null)
                {
                    if (r.HasThorns == false)
                    {
                        currentArray[countOfItem++] = r;
                    }
                }
            }
            Plant[] resultArray = new Plant[countOfItem];
            Array.Copy(currentArray, resultArray, countOfItem);
            return (IRandomInit[])resultArray;
        }

        public static IRandomInit[] TheLessTree(IRandomInit[] plants)
        {
            int theLessHeight = 999999;
            uint countOfItem = 0;
            Plant currentPlant = new Tree("Заглушка", "Заглушка", 12);
            Tree.countOfTree--;//Если успею через метод т.к. инкапсуляция
            Plant.countOfPlants--;//Если успею через метод т.к. инкапсуляция
            Plant[] currentArray = new Plant[plants.Length];
            foreach (var plant in plants)
            {
                if (plant == null)
                {
                    continue;
                }
                Tree t = plant as Tree;
                if (t != null)
                {
                    if (t.Height < theLessHeight)
                    {
                        theLessHeight = t.Height;
                    }
                }
            }
            foreach (var plant in plants)
            {
                if (plant == null)
                {
                    continue;
                }
                Tree t = plant as Tree;
                if (t != null)
                {
                    if (t.Height == theLessHeight)
                    {
                        currentArray[countOfItem++] = t;
                    }
                }
            }
            Plant[] resultArray = new Plant[countOfItem];
            Array.Copy(currentArray, resultArray, countOfItem);
            return (IRandomInit[])resultArray;
        }

        public static IRandomInit[] FlowerWithTheSmell(IRandomInit[] plants, string smell)
        {
            Plant[] currentArray = new Plant[plants.Length];
            uint countOfItem = 0;
            foreach (var plant in plants)
            {
                if (plant == null)
                {
                    continue;
                }
                Flower f = plant as Flower;
                if (f != null)
                {
                    if (f.Smell == smell)
                    {
                        currentArray[countOfItem++] = f;
                    }
                }
            }
            Plant[] resultArray = new Plant[countOfItem];
            Array.Copy(currentArray, resultArray, countOfItem);
            return (IRandomInit[])resultArray;
        }

    }
}

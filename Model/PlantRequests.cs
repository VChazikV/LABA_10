namespace Model
{
    public class PlantRequests
    {
        public static Plant[] RoseWithoutThorns(Plant[] plants) 
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
            return resultArray;
        }

        public static Plant[] TheLessTree(Plant[] plants)
        {
            int theLessHeight = 999999;
            uint countOfItem = 0;
            Plant currentPlant = new Tree("Заглушка", "Заглушка", 12);
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
            return resultArray;
        }

        public static Plant[] FlowerWithTheSmell(Plant[] plants, string smell)
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
            return resultArray;
        }

    }
}

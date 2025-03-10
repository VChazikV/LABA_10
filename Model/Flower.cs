namespace Model
{
    public class Flower : Plant
    {
        #region Поля

        public static readonly string[] ARROFFLOWERS =
        {
            "Роза", "Лилия", "Тюльпан", "Орхидея",
            "Пион", "Гортензия", "Нарцисс", "Жасмин",
            "Гладиолус", "Астра", "Ромашка", "Хризантема",
            "Гвоздика", "Фиалка", "Эустома"
        };

        public static readonly string[] ARROFSMELL =
        {
            "Сладкий", "Пряный", "Свежий", "Горький", "Нейтральный"
        };

        public static uint countOfFlower = 0;

        /// <summary>
        /// Запах Цветка
        /// </summary>
        protected string smellOfPlant;

        #endregion

        #region Свойства
        public string Smell
        {
            get => smellOfPlant;
            protected set
            {
                if (!string.IsNullOrEmpty(value.Trim()))
                {
                    smellOfPlant = value.Trim();
                }
                else
                {
                    throw new ArgumentException(nameof(Smell), "Запах не может быть пустым");
                }

            }
        }
        #endregion

        #region Конструкторы

        public Flower() : base()
        {
            Smell = "Нет запаха";
            countOfFlower++;
        }

        public Flower(string nameOfPlant, string colorOfPlant, string smellOfPlant, int id) : base(nameOfPlant, colorOfPlant, id)
        {
            Smell = smellOfPlant;
            countOfFlower++;
        }

        public Flower(Flower f) : base(f)
        {
            Smell = f.Smell;
            countOfFlower++;
        }
        #endregion

        #region Методы Стандартные

        public new string[] ShowNoVirtual()
        {
            return ["Name", Name.ToString(), "Color", Color.ToString(), "Smell", Smell.ToString()];//Дублируем все что было
        }
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
            {
                return false;
            }
            Flower other = (Flower)obj;
            return Smell == other.Smell;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Smell);
        }

        public new static uint GetCountOfItem()
        {
            return countOfFlower;
        }

        #endregion

        #region Методы для реализации интерфейсов

        #region Методы Интерфейса IInit

        public void Init(string nameOfPlant, string colorOfPlant, string smellOfPlant)
        {
            Init(nameOfPlant, colorOfPlant);//Используем базовый метод
            Smell = smellOfPlant;//Добавляем новое поле
        }

        #endregion

        #region Методы Интерфейса IRandomInit

        public new void RandomInit()//Лучше убрать и сделать не виртуальный с корректными случайными данными закинуть в Интерфйес легко
        {
            Name = ARROFFLOWERS[random.Next(ARROFFLOWERS.Length - 1)];
            Color = ARROFCOLOR[random.Next(ARROFCOLOR.Length - 1)];
            Smell = ARROFSMELL[random.Next(ARROFSMELL.Length - 1)];
        }

        #endregion

        #region Методы Интерфейса IClonable

        public new Flower Clone()
        {
            return new Flower(this.Name, this.Color, this.Smell, this.idOfPlants.Number);
        }

        #endregion

        #region Методы Интерфейса IShow

        public override string[] Show()
        {
            return [.. base.Show(), "Smell", Smell];
        }

        #endregion

        #endregion
    }
}
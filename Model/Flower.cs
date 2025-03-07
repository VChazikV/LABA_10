namespace Model
{
    public class Flower : Plant
    {
        #region Поля
        private static uint countOfFlower = 0;
        protected string smellOfPlant;
        protected static readonly string[] ARROFFLOWERS =
        {
            "Роза", "Лилия", "Тюльпан", "Орхидея",
            "Пион", "Гортензия", "Нарцисс", "Жасмин",
            "Гладиолус", "Астра", "Ромашка", "Хризантема",
            "Гвоздика", "Фиалка", "Эустома"
        };
        protected static readonly string[] ARROFSMELL =
        {
            "Сладкий", "Пряный", "Свежий", "Горький", "Нейтральный"
        };
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
        

        public Flower(string nameOfPlant, string colorOfPlant, string smellOfPlant) : base(nameOfPlant, colorOfPlant)
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

        #region Методы
        public override string[] Show()
        {
            return [.. base.Show(), "Smell", Smell];
        }
        public new string[] ShowNoVirtual()
        {
            return ["Name", Name.ToString(), "Color", Color.ToString(), "Smell", Smell.ToString()];//Дублируем все что было
        }

        public void Init(string nameOfPlant, string colorOfPlant, string smellOfPlant)
        {
            Init(nameOfPlant, colorOfPlant);//Используем базовый метод
            Smell = smellOfPlant;//Добавляем новое поле
        }

        public new void RandomInit()//Лучше убрать и сделать не виртуальный с корректными случайными данными закинуть в Интерфйес легко
        {
            Name = ARROFFLOWERS[random.Next(ARROFFLOWERS.Length-1)];
            Color = ARROFCOLOR[random.Next(ARROFCOLOR.Length-1)]; 
            Smell = ARROFSMELL[random.Next(ARROFSMELL.Length-1)];
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
        #endregion
    }
}
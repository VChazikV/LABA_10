namespace Model
{
    public class Rose : Flower
    {
        #region Поля
        protected static readonly string[] ARROFROSES =
        {
            "Чайная роза", "Флорибунда", "Плетистая роза", "Миниатюрная роза",
            "Парковая роза", "Гибридная роза", "Почвопокровная роза", "Английская роза",
            "Дикая роза", "Шраб", "Грандифлора", "Бурбонская роза",
            "Дамасская роза", "Мускусная роза", "Полиантовая роза"
        };
        protected bool hasThorns;
        private static uint countOfRose = 0;
        #endregion

        #region Свойства
        public bool HasThorns
        {
            get => hasThorns;
            protected set => hasThorns = value;
        }
        #endregion

        #region Конструкторы
        public Rose() : base()
        {
            HasThorns = false;
            countOfRose++;
        }

        public Rose(string nameOfPlant, string colorOfPlant, string smell, bool hasThorns)
            : base(nameOfPlant, colorOfPlant, smell)
        {
            HasThorns = hasThorns;
            countOfRose++;
        }

        public Rose(Rose r) : base(r)
        {
            HasThorns = r.HasThorns;
            countOfRose++;
        }
        #endregion

        #region Методы
        public override string[] Show()
        {
            return [.. base.Show(), "Has Thorns", HasThorns.ToString()];
        }
        public new string[] ShowNoVirtual()
        {
            return ["Name", Name.ToString(), "Color", Color.ToString(), "Smell", Smell.ToString(), "HasThorns", HasThorns.ToString()];//Дублируем все что было
        }

        public void Init(string nameOfPlant, string colorOfPlant, string smellOfPlant, bool? hasThrons)
        {
            Init(nameOfPlant, colorOfPlant, smellOfPlant);//Используем базовый метод
            HasThorns = (bool)hasThrons;//Добавляем новое поле
        }

        public new void RandomInit()//Лучше убрать и сделать не виртуальный с корректными случайными данными закинуть в Интерфйес легко
        {
            Name = ARROFROSES[random.Next(ARROFROSES.Length - 1)];
            Color = ARROFCOLOR[random.Next(ARROFCOLOR.Length - 1)];
            Smell = ARROFSMELL[random.Next(ARROFSMELL.Length - 1)];
            HasThorns = random.Next(2) == 1;
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) return false;
            Rose other = (Rose)obj;
            return HasThorns == other.HasThorns;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), HasThorns);
        }

        public new static uint GetCountOfItem()
        {
            return countOfRose;
        }
        #endregion
    }
}
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

        /// <summary>
        /// Наличие шипов Розы
        /// </summary>
        protected bool hasThorns;

        public static uint countOfRose = 0;
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

        public Rose(string nameOfPlant, string colorOfPlant, string smell, bool hasThorns, int id)
            : base(nameOfPlant, colorOfPlant, smell, id)
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

        #region Методы стандартные
        
        public new string[] ShowNoVirtual()
        {
            return ["Name", Name.ToString(), "Color", Color.ToString(), "Smell", Smell.ToString(), "HasThorns", HasThorns.ToString()];//Дублируем все что было
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
            {
                return false;
            }
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

        #region Методы для реализации интерфейсов

        #region Методы Интерфейса IInit

        public void Init(string nameOfPlant, string colorOfPlant, string smellOfPlant, bool? hasThrons)
        {
            Init(nameOfPlant, colorOfPlant, smellOfPlant);//Используем базовый метод
            HasThorns = (bool)hasThrons;//Добавляем новое поле
        }

        #endregion

        #region Методы Интерфейса IRandomInit

        public new void RandomInit()//Лучше убрать и сделать не виртуальный с корректными случайными данными закинуть в Интерфйес легко
        {
            Name = ARROFROSES[random.Next(ARROFROSES.Length - 1)];
            Color = ARROFCOLOR[random.Next(ARROFCOLOR.Length - 1)];
            Smell = ARROFSMELL[random.Next(ARROFSMELL.Length - 1)];
            HasThorns = random.Next(2) == 1;
        }

        #endregion

        #region Методы Интерфейса IClonable

        public new Rose Clone()
        {
            return new Rose(this.Name, this.Color, this.Smell, this.HasThorns, this.idOfPlants.Number);
        }

        #endregion

        #region Методы Интерфейса IShow

        public override string[] Show()
        {
            return [.. base.Show(), "Has Thorns", HasThorns.ToString()];
        }

        #endregion

        #endregion
    }
}
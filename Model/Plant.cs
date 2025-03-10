using System.Xml.Linq;

namespace Model
{
    public class Plant : IInit, IShow, IRandomInit, IComparable, ICloneable
    {
        #region Поля
        protected static Random random = new Random();

        public static readonly string[] ARROFNAME =
        {
        "Ранункулюс", "Лилия", "Тюльпан", "Эустома", "Малина",
    "Дуб", "Берёза", "Сосна", "Клён", "Куст сирени",
    "Алоэ", "Папоротник", "Роза", "Гвоздика", "Фиалка",
    "Орхидея", "Пион", "Гортензия", "Нарцисс", "Жасмин",
    "Гладиолус", "Астра", "Ромашка", "Хризантема", "Гибискус",
    "Фикус", "Монстера", "Каланхоэ", "Ферн", "Суккулент",
    "Бонсай", "Кипарис", "Олива", "Бамбук", "Кактус",
    "Гранат", "Яблоня", "Вишня", "Слива", "Груша"
        };

        public static readonly string[] ARROFCOLOR =
        {
        "Зелёный", "Красный", "Жёлтый", "Синий", "Фиолетовый",
        "Оранжевый", "Розовый", "Белый", "Чёрный", "Коричневый"
        };

        public static uint countOfPlants = 0;

        /// <summary>
        /// Название Растения
        /// </summary>
        protected string nameOfPlant;  //Название Растения

        /// <summary>
        /// Цвет Растения
        /// </summary>
        protected string colorOfPlant; //Цвет Растения

        /// <summary>
        /// ID Растения
        /// </summary>
        public IdNumber idOfPlants;

        #endregion

        #region Свойства
        /// <summary>
        /// Свойство для обработки бизнес-правил для Название Растения
        /// </summary>
        public string Name
        {
            get => nameOfPlant;

            set
            {
                if (!string.IsNullOrEmpty(value.Trim()))
                {
                    nameOfPlant = value.Trim();
                }
                else
                {
                    throw new ArgumentException(nameof(Name), "Введено пустое название растения");
                }
            }
        }

        /// <summary>
        /// Свойство для обработки бизнес-правил для Цвета Растения
        /// </summary>
        public string Color
        {
            get => colorOfPlant;

            set
            {
                if (!string.IsNullOrEmpty(value.Trim()))
                {
                    colorOfPlant = value.Trim();
                }
                else
                {
                    throw new ArgumentException(nameof(Color), "Введён пустой цвет растения");
                }
            }
        }

        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор без атрибутов
        /// </summary>
        public Plant()
        {
            Name = $"Растение #{countOfPlants + 1}";
            Color = $"Цвет {countOfPlants + 1}";
            idOfPlants = new IdNumber();
            countOfPlants++;
        }

        /// <summary>
        /// Конструктор c параметрами
        /// </summary>
        public Plant(string nameOfPlant, string colorOfPlant, int id)
        {
            Name = nameOfPlant;
            Color = colorOfPlant;
            idOfPlants = new IdNumber(id);
            countOfPlants++;
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        public Plant(Plant p)
        {
            Name = p.Name;
            Color = p.Color;
            countOfPlants++;
        }

        #endregion

        #region Методы стандартные

        public string[] ShowNoVirtual()//Не виртуальный вывод
        {
            return ["Name", Name.ToString(), "Color", Color.ToString()];
        }

        public static uint GetCountOfItem()//Кол-во объектов типа
        {
            return countOfPlants;
        }

        public Plant ShallowCopy()//Копирование не глубокое
        {
            return (Plant)this.MemberwiseClone();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            Plant other = (Plant)obj;
            return Name == other.Name &&
                   Color == other.Color;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Color);
        }

        #endregion

        #region Методы для реализации интерфейсов

        #region Методы Интерфейса IInit
        public void Init(string nameOfPlant, string colorOfPlant)//Изменение данных с клавиатуры
        {
            Name = nameOfPlant;
            Color = colorOfPlant;
        }

        public void Init(string nameOfPlant, string colorOfPlant, int? heightOfTree)
        {
            //Все методы абстрактного должны быть реализованы в потомках
        }

        public void Init(string nameOfPlant, string colorOfPlant, string smellOfPlant)
        {
            //Все методы абстрактного должны быть реализованы в потомках
        }

        public void Init(string nameOfPlant, string colorOfPlant, string smellOfPlant, bool? hasThrons)
        {
            //Все методы абстрактного должны быть реализованы в потомках
        }

        public void Init(string nameOfPost, int viewsOfPost, int reactionsOfPost, int commentsOfPost)
        {
            //Все методы абстрактного должны быть реализованы в потомках
        }

        #endregion

        #region Методы Интерфейса IRandomInit

        public void RandomInit()//Случайные данные
        {
            Name = ARROFNAME[random.Next(ARROFNAME.Length - 1)];
            Color = ARROFCOLOR[random.Next(ARROFCOLOR.Length - 1)];
        }

        #endregion

        #region Методы Интерфейса IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Plant otherPlant = obj as Plant;
            if (otherPlant == null)
                throw new ArgumentException("Объект для сравнения должен быть типа Plant");
            string thisName = this.Name;
            string otherName = otherPlant.Name;
            if (thisName == otherName)
            {
                return 0;
            }
            int minLength = Math.Min(thisName.Length, otherName.Length);
            for (int i = 0; i < minLength; i++)
            {
                if (thisName[i] < otherName[i])
                {
                    return -1;
                }
                if (thisName[i] > otherName[i])
                {
                    return 1;
                }
            }
            return 0;
        }

        #endregion

        #region Методы Интерфейса IClonable

        public object Clone()//Глубокое копирование
        {
            return new Plant(this.Name, this.Color, this.idOfPlants.Number);
        }

        #endregion

        #region Методы Интерфейса IShow

        public virtual string[] Show()//Вывод данных объекта
        {
            return ["ID", idOfPlants.ToString(), "Name", Name.ToString(), "Color", Color.ToString()];
        }

        #endregion

        #endregion
    }
}

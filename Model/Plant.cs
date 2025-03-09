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
        #region Методы
        public virtual string[] Show()//Вывод данных объекта
        {
            return ["ID", idOfPlants.ToString(), "Name", Name.ToString(), "Color", Color.ToString()];
        }

        public string[] ShowNoVirtual()
        {
            return ["Name", Name.ToString(), "Color", Color.ToString()];
        }

        public void Init(string nameOfPlant, string colorOfPlant)//Изменение данных с клавиатуры
        {
            Name = nameOfPlant;
            Color = colorOfPlant;
        }

        public void RandomInit()//Лучше убрать и сделать не виртуальный с корректными случайными данными закинуть в Интерфйес легко
        {
            Name = ARROFNAME[random.Next(ARROFNAME.Length - 1)];
            Color = ARROFCOLOR[random.Next(ARROFCOLOR.Length - 1)];
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

        public static uint GetCountOfItem()
        {
            return countOfPlants;
        }

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

        public object Clone()
        {
            return new Plant(this.Name, this.Color, this.idOfPlants.Number);
        }

        public Plant ShallowCopy()
        {
            return (Plant)this.MemberwiseClone();
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
    }
}

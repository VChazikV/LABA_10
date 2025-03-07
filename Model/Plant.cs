using System.Xml.Linq;

namespace Model
{
    public class Plant
    {
        #region Поля
        protected static Random random = new Random();

        protected static readonly string[] ARROFNAME =
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
        private static uint countOfPlants = 0;
        /// <summary>
        /// Название Растения
        /// </summary>
        protected string nameOfPlant;  //Название Растения
        /// <summary>
        /// Цвет Растения
        /// </summary>
        protected string colorOfPlant; //Цвет Растения

        #endregion
        #region Свойства
        /// <summary>
        /// Свойство для обработки бизнес-правил для Название Растения
        /// </summary>
        public string Name
        {
            get => nameOfPlant;

            protected set
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

            protected set
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
            countOfPlants++;
        }

        /// <summary>
        /// Конструктор c параметрами
        /// </summary>
        public Plant(string nameOfPlant, string colorOfPlant)
        {
            Name = nameOfPlant;
            Color = colorOfPlant;
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
            return ["Name", Name.ToString(), "Color", Color.ToString()];
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

        public  void RandomInit()//Лучше убрать и сделать не виртуальный с корректными случайными данными закинуть в Интерфйес легко
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
        #endregion
    }
}

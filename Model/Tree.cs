using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Tree : Plant
    {
        protected static readonly string[] ARROFTREES = 
        {
            "Дуб","Сосна","Берёза","Клён",
            "Ель","Каштан","Тополь","Липа",
            "Ясень","Орех","Кедр","Ива",
            "Бук","Секвойя","Пальма"
        };
        public static uint countOfTree = 0;
        /// <summary>
        /// Высота Дерева
        /// </summary>
        protected int heightOfTree;

        public int Height
        {
            get => heightOfTree;

            protected set
            {
                if (value > 0 && value < 1001)
                {
                    heightOfTree = value;
                }
                else
                {
                    throw new ArgumentException(nameof(Height), "Высота может быть от 1 до 1000");
                }
            }
        }
        public Tree() : base()
        {
            Height = 100;
            countOfTree++;
        }

        public Tree(string nameOfPlant, string colorOfPlant, int heightOfTree) : base(nameOfPlant, colorOfPlant)
        {
            Height = heightOfTree;
            countOfTree++;
        }

        public Tree(Tree t) : base(t)
        {
            Height = 100;
            countOfTree++;
        }

        public override string[] Show()
        {
            string[] baseInfo = base.Show();
            string[] treeInfo = new string[baseInfo.Length + 2];
            Array.Copy(baseInfo, treeInfo, baseInfo.Length);
            treeInfo[treeInfo.Length - 2] = "Height";
            treeInfo[treeInfo.Length - 1] = Height.ToString();
            return treeInfo;
        }
        public new string[] ShowNoVirtual()
        {
            return ["Name", Name.ToString(), "Color", Color.ToString(), "Height", Height.ToString()];//Дублируем все что было
        }

        public void Init(string nameOfPlant, string colorOfPlant, int? heightOfTree)
        {
            Init(nameOfPlant, colorOfPlant);//Используем базовый метод
            Height = (int)heightOfTree;//Добавляем новое поле
        }

        public new void RandomInit()//Лучше убрать и сделать не виртуальный с корректными случайными данными закинуть в Интерфйес легко
        {
            Name = ARROFTREES[random.Next(ARROFTREES.Length-1)];
            Color = ARROFCOLOR[random.Next(ARROFCOLOR.Length-1)];
            Height = random.Next(1, 101);
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
            {
                return false;
            }
            Tree other = (Tree)obj;
            return Height == other.Height;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Height);
        }

        public new static uint GetCountOfItem()
        {
            return countOfTree;
        }
    }
}

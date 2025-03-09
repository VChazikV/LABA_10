using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model
{
    public class IdNumber
    {
        public static int countOfItem = 0;

        private int[] idOfItem = new int[10000];

        public int number;

        public int Number
        {
            get => number;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(IdNumber), "Id не может быть меньше 0");
                }
                //else if (idOfItem.Contains(value))
                //{
                //    throw new ArgumentException(nameof(IdNumber), "Такой id уже присутствует");
                //}
                else
                {
                    number = value;
                    idOfItem[countOfItem++] = number;
                }
            }
        }
        public IdNumber(int number)
        {
            Number = number;
        }
        public IdNumber()
        {
            Number = countOfItem;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            IdNumber other = (IdNumber)obj;
            return number == other.number;
        }

        public override int GetHashCode()
        {
            return number.GetHashCode();
        }

        public override string ToString()
        {
            return $"{number}";
        }
    }
}

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
        #region Поля

        public static int countOfItem = 0;

        public int number;

        #endregion

        #region Свойства

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
                    countOfItem++;
                }
            }
        }

        #endregion

        #region Конструкторы
        public IdNumber(int number)
        {
            Number = number;
        }
        public IdNumber()
        {
            Number = countOfItem;
        }

        #endregion

        #region Методы
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
        #endregion
    }
}

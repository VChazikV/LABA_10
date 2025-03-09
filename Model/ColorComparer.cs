using System;
using System.Collections;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ColorComparer: IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            Plant plantX = x as Plant;
            Plant plantY = y as Plant;

            if (plantX == null || plantY == null)
                throw new ArgumentException("Один из объектов не является Plant");

            string thisName = plantX.Color;
            string otherName = plantY.Color;
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
    }
}

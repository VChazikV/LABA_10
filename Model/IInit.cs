using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IInit
    {
        void Init(string nameOfPlant, string colorOfPlant);
        void Init(string nameOfPlant, string colorOfPlant, int? heightOfTree);
        void Init(string nameOfPlant, string colorOfPlant, string smellOfPlant);
        void Init(string nameOfPlant, string colorOfPlant, string smellOfPlant, bool? hasThrons);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_yoghurts
{
    public class Color
    {
        public string name { get; set; }
        public int firstPosition { get; set; }
        public int quantity { get; set; }

        public Color(string _name, int _firstPosition)
        {
            name = _name;
            firstPosition = _firstPosition;
            quantity = 0;
        }

        // constructeur pour les tests
        public Color(string _name, int _firstPosition, int _quantity)
        {
            name = _name;
            firstPosition = _firstPosition;
            quantity = _quantity;
        }
    }
}

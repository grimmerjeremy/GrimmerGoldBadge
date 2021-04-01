using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeClassLibrary
{

    public class CafeMenu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }

        public CafeMenu(int id, string name, string ingredients, double price)
        {
            ID = id;
            Name = name;
            Ingredients = ingredients;
            Price = price;
        }

        public CafeMenu()
        {

        }

    }

}

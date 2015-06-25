using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Models
{
    public class FoodMenu
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Ingredient { get; set; }

        public string Price { get; set; }


        //此段未發現用途
        public override string ToString()
        {
            return "FoodMenu: Id = " + Id + ", Name = " + Name + ".";
        }
    }
}

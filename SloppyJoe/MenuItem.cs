using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SloppyJoe
{
    internal class MenuItem
    {
        public string[] Proteins = [
                    "Roast beef", "Salami", "Turkey",
                    "Ham", "Pastrami", "Tofu"
        ];
        public string[] Condiments = [
                    "yellow mustard", "brown mustard",
                    "honey mustard", "mayo", "relish", "French dressing"
        ];
        public string[] Breads = ["rye", "white", "wheat", "pumpernickel", "a roll"];
        public string Description = "";
        public string Price = "";
        public void Generate()
        {
            // You'll fill in this method
        }
    }
}

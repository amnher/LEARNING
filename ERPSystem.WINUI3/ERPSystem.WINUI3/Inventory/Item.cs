using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.WINUI3.Inventory
{
    public class Item
    {
        public string ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
    }

}

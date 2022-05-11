using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double GetPrice(IClient client) {
            if (client.IsPremium)
            {
                return Price * .8;
            }

            return Price;
        }

    }
}

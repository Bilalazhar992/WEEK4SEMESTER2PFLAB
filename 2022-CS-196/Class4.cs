using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_CS_196
{
    public class BuyedProduct
    {
        public string item_name;
        public int quantity;
        public int price;
        public BuyedProduct(string name,int  quantity,int product_price)
        {
            item_name = name;
            this.quantity = quantity;
            price = product_price;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2022_CS_196
{
    public class Product
    {
        public string product_name;
        public string product_category;
        public int product_price;
        public int Stock_quantity;
        public int Minimum_quantity;
        public Product()
        {

        }
        public Product(string product_name,string product_category,int product_price,int Stock_quantity,int Minimum_quantity)
        {
            this.product_name = product_name;
            this.product_category = product_category;
            this.product_price = product_price;
            this.Stock_quantity = Stock_quantity;
            this.Minimum_quantity = Minimum_quantity;
        }
        public bool CheckValidity(List<Product> products)
        {
            foreach(Product product in products)
            {
                if(product.product_name==product_name)
                {
                    return false;
                }
            }
            
            return true;
        }
        public int ReturnIndex(List<Product> products)
        {
            for (int i=0;i< products.Count;i++)
            {
                if (products[i].product_name == product_name)
                {
                    return i;
                }
            }
            return 0;
        }
       
        public float CalculateTax()
        {
            float tax = 0.0F;
            if (product_category == "Grocery")
            {
                tax = product_price * 0.1F;
            }
            if (product_category == "Fruit")
            {
                tax = product_price * 0.05F;
            }
            else
            {
                tax = product_price * 0.15F;
            }
            return tax;
        }
        public bool Checking()
        {
            if(Stock_quantity<=Minimum_quantity)
            {
                return true;
            }
            return false;
        }
        public Product GiveProduct(int highest, List<Product> products)
        {
            foreach (Product product in products)
            {
                if (product.product_price == highest)
                {
                    return product;
                }

            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_CS_196
{
    
    public class Customer
    {
        public int no_of_items;
        public List<BuyedProduct> buyed_products = new List<BuyedProduct>();
        public int bill;
        public Customer ()
        {

        }
        public Customer(int number)
        {
            no_of_items = number;
        }
        public void BuyProducts(List<Product> products)
        {
           
            for(int i=0;i<no_of_items;i++)
            {
                int flag = 0;
                while(flag==0)
                {
                    Console.Write("Enter Product Name: ");
                    string name = Console.ReadLine();
                    foreach(Product product in products)
                    {
                        if(name==product.product_name)
                        {
                            Console.Write("Enter Product Quantity: ");
                            int quantity = int.Parse( Console.ReadLine());
                            product.Stock_quantity=product.Stock_quantity-quantity;
                            BuyedProduct buyed = new BuyedProduct(name,quantity,product.product_price);
                            buyed_products.Add(buyed);
                            flag = 1;
                        }
                        
                    }
                    if(flag==0)
                    {
                        Console.WriteLine("That Product Does not Available in Our Store ");
                    }
                }
                

            }
        }
        public void GenerateInvoice()
        {
            Console.WriteLine("Product Name                        Quantity                         Price");
            foreach (BuyedProduct buyedProduct in buyed_products)
            {
                Console.WriteLine(buyedProduct.item_name + "                        " + buyedProduct.quantity + "                           " + buyedProduct.price * buyedProduct.quantity);
                bill = bill + buyedProduct.price * buyedProduct.quantity;
            }
            Console.WriteLine();
            Console.WriteLine("                                                                                                     Balance= " + bill);       
        }
    }
    
}

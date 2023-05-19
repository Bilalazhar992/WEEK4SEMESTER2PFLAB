using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace _2022_CS_196
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValid;
            string admin_decision;
            List<MUser> users = new List<MUser>();
            List<Product> products = new List<Product>();
            string user_decision;
            string path = "Usersfile.txt";
            readfileofUsers(path,users);
            
            logo();
            welcome();
            loading();
            int highest;
            Product product1 = new Product();
            while(true)
            {
                Console.Clear();
                logo();
                string option = Menu();
                Console.Clear();
                if (option == "1")
                {
                    MUser user = takeInputWithRole();
                    isValid = user.isValidname(users);
                    if (isValid)
                    {
                        user.StoreInList(user, users);
                        Console.WriteLine("SignedUp Sucessfully ");
                        user.StoreInFile(path);
                    }
                    else
                    {
                        Console.WriteLine("User Already Exists ");
                    }
                }
                else if(option=="2")
                {
                    string role;
                    MUser user = takeInputWithoutRole();
                    if (user.SignIn(users))
                    {
                        user = user.ReturnObject(users);
                        role = user.CheckRole();
                        if (role == "admin" || role == "Admin" || role == "ADMIN")
                        {
                            while(true)
                            {
                                Console.Clear();
                                logo();
                                admin_decision = admin_menu();
                                Console.Clear();
                                logo();
                                if (admin_decision == "1")
                                {
                                    Product product = EnterProduct();
                                    isValid = product.CheckValidity(products);
                                    if (isValid)
                                    {
                                        products.Add(product);

                                    }
                                    else
                                    {
                                        string choice;
                                        int index;
                                        Console.WriteLine("That Product Already Exsists in Our Record");
                                        Console.WriteLine("If You Want To Change This Record From Previous One then Press " + "Y" + " from KeyBoard or Press Any Key to Discard that Entered Record");
                                        choice = Console.ReadLine();
                                        if (choice == "Y")
                                        {
                                            index = product.ReturnIndex(products);
                                            products.RemoveAt(index);
                                            products.Add(product);
                                        }
                                    }
                                }
                                else if (admin_decision == "2")
                                {
                                    ViewProducts(products, "");
                                }
                                else if (admin_decision == "3")
                                {
                                    highest = Highest(products);
                                    product1 = product1.GiveProduct(highest, products);

                                    Console.WriteLine("Highest price of any product in our shop is " + highest +"and that Product is "+product1.product_name);
                                }
                                else if (admin_decision == "4")
                                {
                                    Console.WriteLine("Product Name                                         Sales Tax");
                                    foreach(Product product in products)
                                    {
                                        Console.WriteLine(product.product_name + "                                        " + product.CalculateTax());          
                                    }
                                }
                                else if(admin_decision=="5")
                                {
                                    bool flag;
                                    foreach (Product product in products)
                                    {
                                        flag = product.Checking();
                                        if(flag)
                                        {
                                            Console.WriteLine(product.product_name + "      is needed to be ordered");
                                        }
                                    }
                                }
                                else if(admin_decision=="6")
                                {
                                    break;
                                }
                                else
                                {
                                    
                                    Console.WriteLine("Invalid Entry");
                                    
                                }
                                Console.WriteLine("Press any key to back on admin_menu interface ");
                                Console.ReadKey();
                            }
                        }
                        else if(role == "customer" || role == "CUSTOMER" || role == "Customer" )
                        {
                            Customer customer = new Customer();
                            string name = user.username;
                            while(true)
                            {
                                Console.Clear();
                                logo();
                                user_decision = customer_menu();
                                if(user_decision=="1")
                                {
                                    ViewProducts(products, "customer");
                                }
                                else if(user_decision=="2")
                                {
                                    customer = EnterNoOfTerms();
                                    customer.BuyProducts(products);
                                }
                                else if (user_decision == "3")
                                {
                                    logo();
                                    Console.WriteLine("Name: " + name);
                                    Console.WriteLine();
                                    customer.GenerateInvoice();
                                }
                                else if (user_decision=="4")
                                {
                                    break;
                                }
                                else
                                {

                                    Console.WriteLine("Invalid Entry");

                                }
                                Console.WriteLine("Press any key to back on user_menu interface ");
                                Console.ReadKey();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Credentials Added ");
                    }
                }
                else if (option == "3")
                {
                    Console.Write("                                            Exiting");
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(500);
                    }
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Entry");

                }
                Console.WriteLine("Press any key to back on menu interface ");
                Console.ReadKey();

            }
            
        }
        static void logo()
        {
            Console.WriteLine("***************************************************************");
            Console.WriteLine("*                                                             *");
            Console.WriteLine("*                                                             *");
            Console.WriteLine("*                                                             *");
            Console.WriteLine("*                     METRO SUPERMARKET                       *");
            Console.WriteLine("*                                                             *");
            Console.WriteLine("*                                                             *");
            Console.WriteLine("*                                                             *");
            Console.WriteLine("***************************************************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        static string Menu()
        {
            string choice;
            Console.WriteLine("1-SIGNUP");
            Console.WriteLine("2-SIGNIN");
            Console.WriteLine("3 - EXIT");
            Console.WriteLine("Press Respective Number For The Given Options: ");
            choice = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            return choice;
        }
        static void welcome()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                  *      * **** *      ****   *****  *    * ****                     ");
            Console.WriteLine("                                                  *   *  * **** *     *      *     * *  * * ****        ");
            Console.WriteLine("                                                  * *  * * *    *     *      *     * *    * *          ");
            Console.WriteLine("                                                  *      * **** *****  ****   *****  *    * ****       ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        static void loading()
        {
            int p = 0;
            for (int n = 0; p == 0; n++)
            {
                Console.Clear();
                logo();
                welcome();
                Console.WriteLine("Press Y or y to go on login menu ");
                string starter = Console.ReadLine();
                if (starter == "Y" || starter == "y")
                {
                    Console.Clear();
                    logo();
                    p++;
                    Console.Write("                                                               LOADING");
                    for (int x = 0; x < 5; x++)
                    {
                        Console.Write(".");
                        Thread.Sleep(150);
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("AN INVALID ENTERY");
                    Console.WriteLine();
                    Console.WriteLine(" Press any key from your keyboard to go back on welcome menu ");
                    Console.ReadKey();
                }
            }
        }
        static MUser takeInputWithRole()
        {
            int flag1 = 1;
            int flag2 = 1;
            int flag5 = 1;
            string username = "";
            string password = "";
            string role = "";
            logo();
            Console.WriteLine("-----------------------------------------------------------SIGN UP------------------------------------------------");
            Console.WriteLine();
            while (flag1 == 1)
            {
                Console.WriteLine("Enter User Name: ");
                username = Console.ReadLine();
                flag1 = 0;
                for (int i = 0; i < username.Length; i++)
                {
                    if (!((username[i] >= 65 && username[i] <= 90) || (username[i] >= 97 && username[i] <= 122) || username[i] == ' '))
                    {
                        Console.WriteLine("AN INVALID  NAME ENTER BY YOU ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag1++;
                        break;
                    }
                }
            }

            while (flag2 == 1)
            {
                Console.WriteLine("Enter User Password: ");
                password = Console.ReadLine();
                flag2 = 0;
                while (password.Length < 8)
                {
                    Console.WriteLine("AN INVALID  PASSWORD ENTER BY YOU ");
                    Console.WriteLine("Press any key from your keyboard for entering agian ");
                    Console.WriteLine("Note:Password must be of eight characters minimum");
                    Console.ReadKey();
                    flag2++;
                    break;
                }
            }

            while (flag5 == 1)
            {
                flag5 = 0;
                Console.WriteLine("Enter Role: ");
                role = Console.ReadLine();
                if (!((role == "coustomer") || (role == "CUSTOMER") || (role == "admin") || (role == "ADMIN") || (role == "Admin") || (role == "Customer")))
                {
                    flag5++;
                    Console.WriteLine("That Role does not exist ");
                    Console.WriteLine();
                    Console.WriteLine(" Press any key from your keyboard for entering identity again   ");
                    Console.ReadKey();
                }
            }
            if (username != null && password != null && role != null)
            {
                MUser user = new MUser(username, password, role);
                return user;
            }
            return null;
        }
        static MUser takeInputWithoutRole()
        {
            int flag1 = 1;
            int flag2 = 1;
            string username = "";
            string password = "";

            logo();
            Console.WriteLine("-----------------------------------------------------------SIGN IN------------------------------------------------");
            Console.WriteLine();
            while (flag1 == 1)
            {
                Console.WriteLine("Enter User Name: ");
                username = Console.ReadLine();
                flag1 = 0;
                for (int i = 0; i < username.Length; i++)
                {
                    if (!((username[i] >= 65 && username[i] <= 90) || (username[i] >= 97 && username[i] <= 122) || username[i] == ' '))
                    {
                        Console.WriteLine("AN INVALID  NAME ENTER BY YOU ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag1++;
                        break;
                    }
                }
            }

            while (flag2 == 1)
            {
                Console.WriteLine("Enter User Password: ");
                password = Console.ReadLine();
                flag2 = 0;
                while (password.Length < 8)
                {
                    Console.WriteLine("AN INVALID  PASSWORD ENTER BY YOU ");
                    Console.WriteLine("Press any key from your keyboard for entering agian ");
                    Console.WriteLine("Note:Password must be of eight characters minimum");
                    Console.ReadKey();
                    flag2++;
                    break;
                }
            }

            if (username != null && password != null)
            {
                MUser user = new MUser(username, password);
                return user;
            }
            return null;
        }
        static string admin_menu()
        {
            Console.Clear();
            logo();
            Console.WriteLine("-------------------------------------------------------------------------ADMIN MENU---------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1-AddProduct");
            Console.WriteLine("2-ViewProducts");
            Console.WriteLine("3-Find the Product with highest Price");
            Console.WriteLine("4-View Sales Tax of All Products");
            Console.WriteLine("5-Product to be ordered ");
            Console.WriteLine("6-Exit ");
            Console.WriteLine("Enter number between 1 to 6 to get respective functionalities");
            
            Console.Write("Enter Here: ");
            string choice = Console.ReadLine();
            return choice;
        }
        static string customer_menu()
        {
            Console.Clear();
            logo();
            Console.WriteLine("-------------------------------------------------------------------------CUSTOMER MENU---------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1-ViewProducts");
            Console.WriteLine("2-Buy The Product");
            Console.WriteLine("3-Generate Invoice");
            Console.WriteLine("4-Exit ");
            Console.WriteLine("Enter number between 1 to 4 to get respective functionalities");

            Console.Write("Enter Here: ");
            string choice = Console.ReadLine();
            return choice;
        }
        static Product EnterProduct()
        {
            Console.WriteLine("Enter Product Name: ");
            string product_name = Console.ReadLine();
            Console.WriteLine("Note: Category Starts with Capital Letter");
            Console.WriteLine("Enter Product Category: ");
            string product_category = Console.ReadLine();
            Console.WriteLine("Enter Product Price: ");
            int product_price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Product Stock: ");
            int Stock_quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Minimum Quantity");
            int Minimum_quantity = int.Parse(Console.ReadLine());
            Product product = new Product(product_name, product_category, product_price, Stock_quantity, Minimum_quantity);
            return product;
        }
        static void ViewProducts(List<Product> products,string userType)
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.Write("Product Name: ");
                Console.WriteLine(products[i].product_name);
                Console.Write("Stock Quantity: ");
                Console.WriteLine(products[i].Stock_quantity);
                if (userType!="customer")
                {
                    
                    Console.Write("Product Category: ");
                    Console.WriteLine(products[i].product_category);
                    Console.Write("Product Price: ");
                    Console.WriteLine(products[i].product_price);
                    
                    Console.Write("Minimum Quantity: ");
                    Console.WriteLine(products[i].Minimum_quantity);
                    Console.WriteLine();
                }
                
            }
        }
        static int Highest(List<Product> array)
        {
            int highest = array[0].product_price;
            for (int i = 1; i < array.Count; i++)
            {
                if (highest < array[i].product_price)
                {
                    highest = array[i].product_price;
                }
            }
            return highest;
        }
        static Customer EnterNoOfTerms()
        {
            Console.WriteLine("Enter Number Of item You Want to Buy");
            int number = int.Parse(Console.ReadLine());
            Customer customer = new Customer(number);
            return customer;
        }
        static void readfileofUsers(string path,List<MUser> users)
        {
            string line;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {

                    string username = getfield(line, 1);
                    string password = getfield(line, 2);
                    string role = getfield(line, 3);
                    MUser info = new MUser(username, password, role);
                    users.Add(info);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");

            }
        }
        static string getfield(string line, int field)
        {
            int commacount = 1;
            string item = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    commacount++;
                }
                else if (commacount == field)
                {
                    item = item + line[i];
                }
            }
            return item;
        }
    }
}

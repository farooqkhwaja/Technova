namespace Project_Technova
{

    internal class Program
    {
        // Ik heb mijn best gedaan om ervoor te zorgen dat mijn programma niet crasht bij foutieve invoer.

        static private string shopName = "Technova";
        static private string clientName;
        static private bool isClient;
        static private string choice;
        static private int itemNumber;
        static private int amountToBuy;
        static private int numberInStock;
        static private decimal taxRate;
        static private decimal priceExTax;
        static private decimal priceIncTax;
        static private int stockUpdate;
        static private bool loggedAsAdmin;
        static private int stockCount;
        static private string _username;
        static private string _password;

        static string[] productNames =
        {
        "Razer BlackWidow V4 Pro",
        "Sony WH-1000XM5",
        "Logitech MX Master 3S",
        "ASUS ZenScreen MB16ACV",
        "Anker PowerExpand+ 7-in-1 USB-C Hub"
    };
        static decimal[] productPrices =
        {
        199.99m,
        349.99m,
        99.99m,
        229.99m,
        49.99m
    };
        static string[] productDescriptions =
        {
        "A premium mechanical keyboard with Razer’s iconic Green Switches for tactile feedback and RGB backlighting.",
        "Top-tier noise-canceling wireless headphones with crystal-clear sound and superior comfort.",
        "An ergonomic wireless mouse designed for productivity with ultra-precise tracking and customizable buttons.",
        "A 15.6-inch portable monitor with a slim design and Full HD resolution for work or entertainment on the go.",
        "A versatile USB-C hub offering 7 ports including HDMI, USB-A, USB-C, and SD card reader for connecting multiple devices."
    };
        static DateTime[] releaseDates =
        {
        new DateTime(2023, 2, 1),
        new DateTime(2022, 5, 1),
        new DateTime(2022, 6, 1),
        new DateTime(2021, 4, 1),
        new DateTime(2021, 9, 1)
    };
        static int[] stockCounts =
        {
        150,
        200,
        0,
        120,
        500
    };
        private static void Main(string[] args)
        {
            ShowMenu();
        }
        public static void ShowMenu()
        {
            Logo();
            Console.WriteLine($"Welcome to {shopName}");
            Console.WriteLine("-------------------");

            Console.Write("What's your name: ");
            clientName = Console.ReadLine();

            while (clientName.Any(char.IsDigit))
            {
                Console.WriteLine("Your name shouldn't contain numbers.");
                Console.Write("What's your name: ");
                clientName = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(clientName))
            {
                Console.WriteLine("Please give us your name.");
                Console.Write("What's your name: ");
                clientName = Console.ReadLine();
            }

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Hi {clientName}, welcome to {shopName}! Here you can find the newest tech gadgets at a very reasonable price.");
            Console.ResetColor();
            Console.WriteLine("Go on and tell us what you are looking for");

            isClient = true;
            while (isClient)
            {
                Console.WriteLine("\n\n_____1. Look at items \n_____2. Buy items");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("_____3. Admin login");
                Console.ResetColor();
                Console.WriteLine("_____4. Show all items");
                Console.WriteLine("_____5. Stop\n");

                Console.Write("Enter your choice: ");
                choice = Console.ReadLine();

                Console.Clear();
                while (string.IsNullOrEmpty(choice))
                {
                    Console.WriteLine("wrong input, give a number in first!");
                    Console.Write("Enter your choice: ");
                    choice = Console.ReadLine();
                }
                if (choice == "1") ShowItem(itemNumber);
                else if (choice == "2") BuyItem(itemNumber, amountToBuy);
                else if (choice == "3") AdminLogin(_username, _password);
                else if (choice == "4") ShowAllItems();
                else if (choice == "5") Stop();
                else
                {
                    Console.WriteLine("Wrong input!!!");
                }
                ReviewGenerator();
            }
        }
        public static void ReviewGenerator()
        {
            string[] reviews = new string[]
            {
            "Anna Verbeek: Great website! Very user-friendly and well-organized.",
            "Tom Janssen: Top-quality products and fast delivery!",
            "Sophie de Vries: Excellent customer service; all my questions were answered quickly.",
            "Lars de Boer: I'm very satisfied with my purchase, great value for money.",
            "Emma van Dijk: Easy to navigate the website, and a beautiful layout.",
            "Daan Visser: Fast shipping and well-packaged. Will definitely order here again!",
            "Lisa Bakker: Friendly customer service and detailed product information.",
            "Milan van Leeuwen: I found exactly what I was looking for, and the ordering process was very easy.",
            "Eva van Dam: The responsive design works perfectly on my smartphone!",
            "Nick van der Meer: Professional look and very reliable service."
            };

            Random rnd = new Random();
            var randomReview = reviews[rnd.Next(reviews.Length)];
            Console.WriteLine(randomReview);
        }
        public static void Logo()
        {

            string[,] logo = new string[,]
            {
            { "╔════════════════════════════════════════════╗" },
            { "║      ███████████████████████████████       ║" },
            { "║      ████                       ████       ║" },
            { "║      ████    T E C H N O V A    ████       ║" },
            { "║      ████                       ████       ║" },
            { "║      ███████████████████████████████       ║" },
            { "╚════════════════════════════════════════════╝" }
            };

            for (int i = 0; i < logo.GetLength(0); i++)
            {
                for (int j = 0; j < logo.GetLength(1); j++)
                {
                    Console.Write($"{logo[i, j]}");
                }
                Console.WriteLine();
            }
        }
        public static int ShowItem(int itemnumber)
        {
            Console.WriteLine();
            Console.WriteLine("Down here you can see all of our available products\n------------------------------------------------");

            ShowItemList();

            do
            {
                Console.WriteLine();
                Console.Write("Give the item number that you want to look into (1-5): ");
                while (!int.TryParse(Console.ReadLine(), out itemNumber))
                {
                    Console.WriteLine("Wrong input. Please enter a valid number!");
                }

                if (itemNumber < 1 || itemNumber > 5)
                {
                    Console.WriteLine("Please enter a number between 1 and 5.");
                }
            } while (itemNumber < 1 || itemNumber > 5);

            Console.Clear();

            Console.WriteLine("====================================\n\n");
            Console.WriteLine($"Product name: {productNames[itemNumber - 1]}");
            Console.WriteLine($"Product price: {productPrices[itemNumber - 1]}");
            Console.WriteLine($"Description: {productDescriptions[itemNumber - 1]}");
            Console.WriteLine($"Release date: {releaseDates[itemNumber - 1]:dd/MM/yyyy}");
            Console.WriteLine($"Left in stock: {stockCounts[itemNumber - 1]}");

            CheckSoldOutItem();// checken of een item uitverkocht is of niet.

            Console.WriteLine();
            Console.WriteLine();
            ReviewGenerator();

            return itemNumber;

        }
        public static void ShowItemList()
        {
            for (int i = 0; i < productNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}.Products: {productNames[i]} Stockcount: {stockCounts[i]}");
            }
        }
        public static string BuyItem(int item, int itemamount)
        {
            Console.WriteLine();
            if (itemNumber > 0 && itemNumber < 6)
            {
                if (string.IsNullOrEmpty(itemNumber.ToString()))
                {
                    Console.WriteLine("Give a number in first!");
                }

                ShowItemList();
                CheckSoldOutItem(); // checken of een item uitverkocht is of niet.

                Console.WriteLine();
                Console.Write("Give the item number that you wanna buy: ");
                itemNumber = int.Parse(Console.ReadLine());

                Console.Write("How many of this item you want to buy? ");
                amountToBuy = int.Parse(Console.ReadLine());

                numberInStock = stockCounts[itemNumber - 1];

                if (numberInStock < amountToBuy)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sorry, we dont have {amountToBuy} items left in the stock for product number {itemNumber}.");
                    Console.ResetColor();
                    Console.WriteLine("We will keep you updated when we refill our stock!");
                    Console.Write("Would you like to buy another product (yes/no)?");
                    string buyAnotherProduct = Console.ReadLine();

                    if (buyAnotherProduct.ToLower() == "yes")
                    {
                        Console.Clear();
                        BuyItem(itemNumber, amountToBuy);

                    }
                    else
                    {
                        Console.WriteLine("Let us know when you need anything😊.");
                    }
                }
                else
                {
                    stockUpdate = numberInStock - amountToBuy;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You succefully bought {amountToBuy} items!");
                    Console.ResetColor();
                    Console.WriteLine($"We still have {stockUpdate} of item number {itemNumber} left in stock!");

                    taxRate = 0.21m;
                    priceExTax = productPrices[0] * amountToBuy;
                    priceIncTax = priceExTax + (priceExTax * taxRate);
                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                    Console.Write($"Total price(tax inclusive): €{priceExTax:0.00} => ");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("€{priceIncTax:0.00}\n\n\n");
                    Console.ResetColor();
                }

                Console.WriteLine();
                Console.WriteLine();
                ReviewGenerator();
            }
            return $"{itemNumber} {amountToBuy}";

        }
        public static void CheckSoldOutItem()
        {
            for (int i = 0; i < stockCounts.Length; i++)
            {
                if (stockCounts[i] == 0)
                {
                    Console.Write($"We also checked the stock, unfortunatlly our item number {i + 1} is ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SOLD OUT");
                    Console.ResetColor();
                }
            }
            ReviewGenerator();

        }
        public static string AdminLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(choice))
            {
                Console.WriteLine("Give a number in first!");
            }
            string[] adminUsernames =
            {
            "admin",
            "farooq",
            "vincent"
        };

            string[] adminPasswords =
            {
            "admin",
            "aaaa",
            "1111"
        };
            Console.Write("Give in your username: ");
            _username = Console.ReadLine();
            Console.Write("Give in a password: ");
            _password = Console.ReadLine();

            Console.WriteLine();

            if (adminUsernames.Contains(_username) && adminPasswords.Contains(_password))
            {
                loggedAsAdmin = true;
                Console.WriteLine("You are logged in as admin.");

                Console.WriteLine("\n_____1. Look at items \n_____2. Buy items");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("_____3. Admin login");
                Console.ResetColor();
                Console.WriteLine("_____4. Stop");
                Console.WriteLine("_____5. Update Stock\n");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                Console.Clear();

                if (choice == 1) ShowItem(itemNumber);
                else if (choice == 2) BuyItem(itemNumber, amountToBuy);
                else if (choice == 3) AdminLogin(_username, _password);
                else if (choice == 4) ShowAllItems();
                else if (choice == 5) // nieuwe funtionalitiet voor admins om de stock aan te passen
                {
                    Console.Clear();
                    Console.WriteLine("YOUR ARE LOGGED IN AS ADMIN");

                    ShowAllItems();

                    if (choice > 0 && choice < 6)
                    {
                        if (string.IsNullOrEmpty(stockCount.ToString()))
                        {
                            Console.WriteLine("Give a number in first!");
                        }
                        else
                        {
                            Console.Write("Give in the product number that you wanna change the stock count of: ");
                            stockCount = int.Parse(Console.ReadLine());

                            Console.Write("\nGive in the amount that you wanna add to it's stock: ");
                            stockUpdate = int.Parse(Console.ReadLine());

                            stockUpdate = stockUpdate + stockCounts[stockCount - 1];
                            Console.WriteLine("STOCK UPDATED!");
                            Console.WriteLine($"{stockUpdate} is the new stock count");
                            Console.WriteLine();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Please select a valid number!");

                    }
                }

                else
                {
                    Console.WriteLine("Wrong password!");
                }
            }
            else
            {
                Console.WriteLine("You have entered the wrong password!");
            }

            ReviewGenerator();

            return $"{_username}{_password}";
        }
        public static void Stop()
        {
            if (string.IsNullOrEmpty(choice))
            {
                Console.WriteLine("Give a number in first!");
            }
            Console.WriteLine("See you later alligator.");
            isClient = false;
            ReviewGenerator();

        }
        public static void ShowAllItems()
        {
            for (int i = 0; i < productNames.Length; i++)
            {
                Console.WriteLine($"=======================================");
                Console.WriteLine($"{i + 1}. Product name: {productNames[i]}");
                Console.WriteLine($"   Product price: {productPrices[i]}");
                Console.WriteLine($"   Description: {productDescriptions[i]}");
                Console.WriteLine($"   Release date: {releaseDates[i]}");
                Console.WriteLine($"   Left in stock: {stockCounts[i]}\n");
            }

            Console.WriteLine();
            Console.WriteLine();
            ReviewGenerator();
        }
    }

}

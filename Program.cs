// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Gambison of Minor Discord",
        Price = 239.99M,
        Sold = false,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "Bracers of Somewhat Fresh Breath",
        Price = 29.99M,
        Sold = false,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "Draught of Small-Space-Squeezing",
        Price = 60.00M,
        Sold = false,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Vial of Unknown Liquid",
        Price = 59.99M,
        Sold = false,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Wispy Tunic",
        Price = 10.99M,
        Sold = false,
        ProductTypeId = 0
    },
    new Product()
    {
        Name = "Frumpy Hat",
        Price = 6.99M,
        Sold = false,
        ProductTypeId = 0
    },
    new Product()
    {
        Name = "Wand of Vape-Finding",
        Price = 400.00M,
        Sold = false,
        ProductTypeId = 3
    },
    new Product()
    {
        Name = "Wand of To Smithereens",
        Price = 1000.00M,
        Sold = false,
        ProductTypeId = 3
    },
    new Product()
    {
        Name = "Shield of Silent-Sneeze",
        Price = 550.00M,
        Sold = false,
        ProductTypeId = 2
    }
};

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Id = 0,
        Name = "Apparel"
    },
    new ProductType()
    {
        Id = 1,
        Name = "Potions"
    },
    new ProductType()
    {
        Id = 2,
        Name = "Enchanted Objects"
    },
    new ProductType()
    {
        Id = 3,
        Name = "Wands"
    },

};
string greeting = @"Welcome to Reductio & Absurdium
The Magic Store Inside Sandra Bullock's Computer from The Net.";
Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"
    ,.   .                 .                      .-,--.       .         .        
   / |   |-. ,-. . . ,-. ,-| . . . ,-,-.   ,.      `|__/ ,-. ,-| . . ,-. |- . ,-. 
  /~~|-. | | `-. | | |   | | | | | | | |   >-:,     | \  |-' | | | | |   |  | | | 
,'   `-' `-' `-' `-' '   `-' ' `-' ' ' '   `-'`   `-'  ` `-' `-' `-' `-' `' ' `-' 
                                                                                  
                                                                                  

Intention is everything.
Choose an Option:
0. Exit
1. Display Items
2. Add An Item
3. Delete An Item
4. Update An Item
");

    choice = Console.ReadLine().Trim();

    switch (choice)
    {
        case "0":
            Console.Clear();
            Console.WriteLine(@"May the wind bless and carry you...
Far From Here!
        
Press Any Key To Return To Your Realm");
            Console.ReadKey();
            Console.Clear();
            break;
        case "1":
            Console.Clear();
            ListAllItems();
            break;
        case "2":
            Console.Clear();
            PostItem();
            break;
        case "3":
            Console.Clear();
            DeleteItem();
            break;
        case "4":
            Console.Clear();
            throw new NotImplementedException("Update Item");
            break;
        default:
            Console.WriteLine("You Should Not Have Done That. Try Again.");
            break;

    }
}
void ListAllItems()
{
    Console.Clear();
    int counter = 0;
    Console.WriteLine("These are the items currently in the shop:");
    foreach (Product product in products)
    {
        counter++;
        string result = ProductDetails(product, counter);
        Console.WriteLine(result);
    }
        Console.WriteLine("Press Any Key To Continue");
        Console.ReadKey();
        Console.Clear();
}

void PostItem()
{
    string ProductName = null;
    decimal ProductPrice = 0.0M;



    string exitReminder = "Remember, You can return to the main menu by typing 'nope'";
    string userInput = null;
    int exitOption = 0;

    // 1st Step
    while (exitOption == 0)
    {
        Console.WriteLine(@$"You will now embark on a journey to add an item.
{exitReminder}

Press Any Key To Continue");

        Console.ReadKey();
        Console.Clear();

        //step 2 - item name
        Console.WriteLine("Please tell me the name of your item:");
        while (true)
        {   //read the input
            userInput = Console.ReadLine().Trim();
            if (userInput == "nope")
            {
                exitOption = 3;
                Console.Clear();
                Console.WriteLine(@"You have chosen to end this creation spell.
Press Any Key To Be Whisked Away...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else if (userInput == "")
            {
                Console.WriteLine("Valid responses only!");
            }
            else if (int.TryParse(userInput, out _))
            {
                Console.WriteLine("This should not be number. Get Right!");
            }
            else
            {
                ProductName = userInput;
                break;
            }

        }

        Console.Clear();

        //Step 3 - Price
        // ask your question
        Console.WriteLine("Tell me how much your item costs:");
        while (true)
        {
            //read the input
            userInput = Console.ReadLine().Trim();
            if (userInput == "nope")
            {
                exitOption = 3;
                Console.Clear();
                Console.WriteLine(@"You have chosen to end this creation spell.
Press Any Key To Be Whisked Away...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else if (userInput == "" || !decimal.TryParse(userInput, out _))
            {
                Console.WriteLine("Stop! Valid inputs only. Enter price like '9.99'");
            }
            else if (decimal.Parse(userInput) < 0)
            {
                Console.WriteLine(@"Prices may NOT be subzero.
                Who do you think you are?");
            }
            else
            {
                ProductPrice = decimal.Parse(userInput);
                Console.WriteLine(ProductPrice);
                break;
            }
        }
        //step 4 - Type
        Console.Clear();
        int chosenType = 0;
        Console.WriteLine(@"I will display some options for categories
Choose the one that suits your item.");
        for (int i = 0; i < productTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productTypes[i].Name}");
        }
        while (true)
        {
            //read the input
            userInput = Console.ReadLine().Trim();
            if (userInput == "nope")
            {
                exitOption = 3;
                Console.Clear();
                Console.WriteLine(@"You have chosen to end this creation spell.
Press Any Key To Be Whisked Away...");
                Console.ReadKey();
                Console.Clear();
                return;
            }// tests the input to be a number and saves output in new variable
            else if (int.TryParse(userInput, out int inputNumber) && inputNumber > 0 && inputNumber <= productTypes.Count)
            {
                chosenType = inputNumber - 1;
                break;
            }
            else
            {
                Console.WriteLine("Please only input a number from the list");
            }





        }
        //Verification
        Console.Clear();
        Console.WriteLine(@$"Please check and make sure your item info is coherent.
                            
Name: {ProductName}
Price: {ProductPrice}
Category: {productTypes[chosenType].Name} 

Please Select An Option to Proceed:
1. Post Item for Sale
2. Make Some Changes
3. Cancel Post");

        exitOption = int.Parse(Console.ReadLine().Trim());
        Console.Clear();

        switch (exitOption)
        {
            //this will post
            case 1:
                Console.Clear();
                Console.WriteLine(@"Your item has been rendered unto the Arcanum for sale.
            
Press Any Key To Continue");
                Product newProduct = new Product()
                {
                    Name = ProductName,
                    Price = ProductPrice,
                    Sold = false,
                    ProductTypeId = chosenType
                };
                products.Add(newProduct);
                Console.ReadKey();
                Console.Clear();
                break;
            //will set exit option to 0 which runs the script again
            case 2:
                Console.Clear();
                Console.WriteLine(@"So you want to make some changes.
Press Any Key To Continue");
                exitOption = 0;
                Console.ReadKey();
                Console.Clear();
                break;
            case 3:
                Console.Clear();
                Console.WriteLine(@"You have decided to abandon creation.
            
            Press Any Key And Bear The Consequences.");
                Console.ReadKey();
                Console.Clear();
                break;

            default:
                Console.WriteLine("This was not a valid choice, fool.");
                break;

        }

    }//end of 1st while loop

}

void DeleteItem()
{
    string exitReminder = "Remember, You can return to the main menu by typing 'nope'";
    string userInput = null;
    int ProductIndexToDelete = 0;
    Product DeletedProduct;
    int exitOption = 0;
    int counter = 0;
    int DeleteCategoryID;

    List<int> productIDs = new List<int>();

    while (exitOption == 0)
    {
        Console.WriteLine(@$"So You have decided to delete an item.
{exitReminder}

Press Any Key To Continue");

        Console.ReadKey();
        Console.Clear();

        //display items
        Console.WriteLine("These are items eligible for deletion:");
        foreach (Product product in products)
        {
            counter = products.IndexOf(product) + 1;
            productIDs.Add(products.IndexOf(product) + 1);
            Console.WriteLine(ProductDetails(product, counter));
        }

        //user chooses product

        Console.WriteLine(@"Please provide number of product to delete.
You can also type 'nope' to exit to the main menu.");

        //validation
        while (true)
        {
            userInput = Console.ReadLine().Trim();
            if (userInput.ToLower() == "nope")
            {
                exitOption = 3;
                Console.Clear();
                Console.WriteLine(@"You have decided to cancel.
Press Any Key To Return To The Main Menu");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else if (userInput == "")
            {
                Console.WriteLine("Valid Responses Only");
            }
            else if (!int.TryParse(userInput, out _))
            {
                Console.WriteLine("Only Input Item ID's");
            }
            else if (productIDs.Contains(int.Parse(userInput)))
            {
                ProductIndexToDelete = int.Parse(userInput) - 1;
                DeletedProduct = products[ProductIndexToDelete];
                DeleteCategoryID = DeletedProduct.ProductTypeId;
                break;
            }
            else
            {
                Console.WriteLine("Please Only Give Valid Inputs");
            }
        }
        Console.Clear();

        //Verify Deletion

        Console.WriteLine(@$"You will delete this item if you continue:
Name: {DeletedProduct.Name}
Price: {DeletedProduct.Price}
Category: {productTypes[DeleteCategoryID].Name}

Please Choose An Option:
1. Delete Item
2. Delete Another Item
3. Cancel Deletion");

        exitOption = int.Parse(Console.ReadLine().Trim());
        switch (exitOption)
        {//Product removed
            case 1:
                Console.Clear();
                Console.WriteLine(@"This product has ben insubstantiated
Press Any Key To Continue");
                
                Console.ReadKey();
                Console.Clear();
                break;

            //delete another product
            case 2:
                Console.Clear();
                Console.WriteLine(@"You want to delete a different item?
        
        Press Any Key To Continue");
                exitOption = 0;
                Console.ReadKey();
                Console.Clear();
                break;

            //cancel it 
            case 3:
                Console.Clear();
                Console.WriteLine(@"You have canceled this Deletion spell
Press Any Key To Continue");
                Console.ReadKey();
                Console.Clear();
                break;

            default:
                Console.WriteLine("You Made An Invalid Choice.");
                break;
                {

                }


        }



    }
}

string ProductDetails(Product product, int counter)
{
    string productString = $"{counter}. {product.Name} {(product.Sold ? $" was sold for {product.Price}" : $"is available for ${product.Price}")}";
    return productString;
}
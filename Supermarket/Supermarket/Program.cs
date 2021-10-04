using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    class Program
    {
        class Supermarket
        {
            Dictionary<string, int> storeItems = new Dictionary<string, int>();
            public static void SupermarketCaller()
            {
                try
                {
                    Supermarket superMarket = new Supermarket();
                    superMarket.AddItem();
                    superMarket.StockInSupermarket();
                    superMarket.PurchaseItem();
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            private void AddItem()
            {
                try
                {
                    Console.Write("Enter the Number of Items to added : ");
                    int numberOfItem = Convert.ToInt32(Console.ReadLine());
                    string item;
                    int quantity;
                    for (int i = 0; i < numberOfItem; i++)
                    {
                        Console.Write("Enter the Item Name : ");
                        item = Console.ReadLine();
                        Console.Write("Enter the Quantity  ");
                        quantity = Convert.ToInt32(Console.ReadLine());
                        storeItems.Add(item, quantity);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            private void StockInSupermarket()
            {
                try
                {
                    Console.WriteLine("List of available stocks in supermarket.");
                    foreach (KeyValuePair<string, int> item in storeItems)
                    {
                        Console.WriteLine($"{item.Key}:{item.Value}");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            private void PurchaseItem()
            {
                try
                {
                    Console.Write("Enter name of item to be purchase  : ");
                    string puschaseItemName = Console.ReadLine();
                    Console.Write("Enter number of item to be purchase: ");
                    int purchaseQuantity = Convert.ToInt32(Console.ReadLine());
                    if (storeItems.ContainsKey(puschaseItemName))
                    {
                        if (storeItems[puschaseItemName] == 0)
                        {
                            storeItems.Remove(puschaseItemName);
                            Console.WriteLine("Item can't be sold! Item is out of stock.");
                        }
                        else if (purchaseQuantity <= storeItems[puschaseItemName] && storeItems[puschaseItemName] != 0)
                        {
                            storeItems[puschaseItemName] -= purchaseQuantity;
                            Console.WriteLine($"{purchaseQuantity} {puschaseItemName} purchased successfully!");
                        }
                        else
                        {
                            Console.WriteLine($"Item running low on stock! Only '{storeItems[puschaseItemName]}' quantity is available.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Item can't be sold! Item is out of stock.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
        static void Main(string[] args)
        {
            Supermarket.SupermarketCaller();
            Console.ReadLine();
        }
    }
}

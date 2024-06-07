using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaishnavi_Dere_Assignment_no_2
{
public class Item
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Item(int id, string name, double price, int quantity)
    {
        ID = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

public class Inventory
{
    private List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void DisplayItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine($"\nID: {item.ID} \nName: {item.Name} \nPrice: {item.Price} \nQuantity: {item.Quantity}\n");
        }
    }

    public Item FindItemByID(int id)
    {
        return items.Find(item => item.ID == id);
    }

    public void UpdateItem(int id)
    {
        var item = FindItemByID(id);
        if (item != null)
        {
            Console.WriteLine("What do you want to update?");
            Console.WriteLine("1. ID");
            Console.WriteLine("2. Name");
            Console.WriteLine("3. Price");
            Console.WriteLine("4. Quantity");
            Console.Write("\nEnter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("\nEnter new ID: ");
                    item.ID = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("\nEnter new Name: ");
                    item.Name = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("\nEnter new Price: ");
                    item.Price = Convert.ToDouble(Console.ReadLine());
                    break;
                case 4:
                    Console.Write("\nEnter new Quantity: ");
                    item.Quantity = Convert.ToInt32(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    public void DeleteItem(int id)
    {
        var item = FindItemByID(id);
        if (item != null)
        {
            items.Remove(item);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Inventory inventory = new Inventory();
        int choice;

        Console.WriteLine("Inventory System");

        do
        {
            Console.WriteLine("\n1. Add item");
            Console.WriteLine("2. Display items");
            Console.WriteLine("3. Find item by ID");
            Console.WriteLine("4. Update item");
            Console.WriteLine("5. Delete item");
            Console.WriteLine("6. Exit");
            Console.Write("\nEnter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("\nEnter ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Price: ");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter Quantity: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    inventory.AddItem(new Item(id, name, price, quantity));
                    break;

                case 2:
                    inventory.DisplayItems();
                    break;

                case 3:
                    Console.Write("Enter ID: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Item item = inventory.FindItemByID(id);

                    if (item != null)
                    {
                        Console.WriteLine($"Found item: {item.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Item not found");
                    }
                    break;

                case 4:
                    Console.Write("Enter ID of the item to update: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    inventory.UpdateItem(id);
                    break;
                case 5:
                    Console.Write("Enter ID of the item to delete: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    inventory.DeleteItem(id);
                    break;
                case 6:
                    Console.WriteLine("\nExiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        } while (choice != 6);
            Console.WriteLine("Project Designed and Developed by Vaishnavi Dere - Nashik");
      }
}
}
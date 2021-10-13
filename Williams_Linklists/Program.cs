using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Williams_Linklists
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkLists ll = new LinkLists();

            string choice = "";

            while (choice != "6")
            {
                Console.WriteLine("What would you like to do?: ");
                Console.WriteLine("");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. Search for Item");
                Console.WriteLine("4. Print");
                Console.WriteLine("5. Exit");
                choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                   
                    case "1":
                        Console.WriteLine("What are we adding: ");
                        string add = Console.ReadLine();
                        ll.add(add);
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine("What are we removing: ");
                        string remove = Console.ReadLine();
                        if (ll.Contains(remove) == null)
                        {
                            Console.WriteLine("No matching words, not Removed.\n");
                        }
                        else
                        {
                            ll.Remove(remove);
                            Console.WriteLine("Removed \"" + remove + "\"\n");
                        }
                        break;
                    case "3":
                        Console.WriteLine("What are we looking for: ");
                        string find = Console.ReadLine();
                        Console.WriteLine();

                        if (ll.Contains(find) == null)
                        {
                            Console.WriteLine("Does not contain the word \"" + find + "\"\n");
                        }
                        else
                        {
                            Console.WriteLine("Contains the word \"" + find + "\"\n");
                        }
                        break;
                    case "4":
                        Console.WriteLine(ll.PrintAllNodes());
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option: Try Again");
                        break;

                }
            }
        }
    }

    public class Node
    {
        public string data;
        public Node next;

        public Node(string data)
        {
            this.data = data;
            next = null;
        }
    }

    public class LinkLists
    {
        Node head;
        //Add a new node to the front of the list
        public void add(string data)
        {
            Node newData = new Node(data);
            newData.next = head;
            head = newData;
        }
        //Returns a node with a matching item; if no match, return null
        public Node Contains(string item)
        {
            Node current = head;
            if (head == null)
            {
                return null;
            }
            while (current != null)
            {
                if (current.data == item)
                {
                    return current;
                }
                if (current.next == null)
                {
                    return null;
                }
                current = current.next;
            }
            return null;
        }
        //Removes node containing the item and links the two adjacent nodes together
        public void Remove(string item)
        {
            Node current = head;
            while (current != null)
            {
                Node next = current.next;
                if (current.data == item)
                {
                    head = next;
                    break;
                }
                if (next.data == item)
                {
                    current.next = next.next;
                    break;
                }
                current = current.next;
            }
        }
        //Prints the entire list front to back. Breaking encapsulation here is permitted
        public string PrintAllNodes()
        {
            Node current = head;
            string list = "";
            if (head == null)
            {
                return "This list empty! Crazy dawg!\n";
            }
            else
            {
                while (current != null)
                {
                    list += current.data + "\n";
                    current = current.next;
                }
                return list;
            }
        }
    }
}
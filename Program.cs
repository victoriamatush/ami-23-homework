using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicts_task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter filename: ");
            string filename = Console.ReadLine();
            Collection goods = new Collection();
            goods.ReadFile(filename);

            Console.WriteLine(goods.size());

            while (true)
            {
                Console.WriteLine("\n1.Show list\n2.Search sth\n3.Sort by attribute\n4.Delete an object\n" +
                    "5.Add an object\n6.Update an object\n7.Write to file\n8.End testing\n");

                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    goods.Print();
                }
                else if (choice == 2)
                {
                    Console.Write("Enter smth to find: ");
                    string locate = Console.ReadLine();
                    goods.Search(locate);
                }
                else if (choice == 3)
                {
                    Console.Write("Enter attribute: ");
                    string attr = Console.ReadLine();
                    goods.Sort(attr);
                }
                else if (choice == 4)
                {
                    Console.Write("Enter id: ");
                    int id = int.Parse(Console.ReadLine());
                    goods.Remove(id);
                }
                else if (choice == 5)
                {
                    Good g = new Good();
                    g = g.Input();
                    goods.Add(g);
                }
                else if (choice == 6)
                {
                    Console.Write("Enter id: ");
                    int id = int.Parse(Console.ReadLine());
                    goods.Update(id);
                }
                else if (choice == 7)
                {
                    Console.Write("Enter file path: ");
                    string path = Console.ReadLine();
                    goods.WriteFile(path);
                }
                else if (choice == 8)
                {
                    break;
                }
                
            }
          

            Console.ReadKey();
        }
    }
}

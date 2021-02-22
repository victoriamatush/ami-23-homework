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
            Collection goods = new Collection();
            while (true)
            {
                Console.WriteLine("\n1.Read from json file" +
                    "\n2.Show list" +
                    "\n3.Search sth" +
                    "\n4.Sort by attribute" +
                    "\n5.Delete an object\n" +
                    "6.Add an object" +
                    "\n7.Update an object" +
                    "\n8.Write to file" +
                    "\n9.End testing\n");

                int choice = int.Parse(Console.ReadLine());
                try {
                    if (Validation.CheckChoice(choice))
                    {
                        if (choice == 1)
                        {
                            Console.WriteLine("----------- READ FROM FILE ------------");
                            Console.WriteLine("Enter filename: ");
                            string filename = Console.ReadLine();

                            goods.ReadFile(filename);
                        }
                        else if (choice == 2)
                        {
                            Console.WriteLine("----------- COLLECTION ------------");
                            goods.Print();
                        }
                        else if (choice == 3)
                        {
                            Console.WriteLine("----------- SEARCH ------------");
                            Console.Write("Enter smth to find: ");
                            string locate = Console.ReadLine();
                            goods.Search(locate);
                        }
                        else if (choice == 4)
                        {
                            Console.WriteLine("----------- SORT ------------");
                            Console.Write("Enter attribute: ");
                            string attr = Console.ReadLine();
                            goods.Sort(attr);
                        }
                        else if (choice == 5)
                        {
                            Console.WriteLine("----------- DELETE ------------");
                            Console.Write("Enter id: ");
                            int id = int.Parse(Console.ReadLine());
                            goods.Remove(id);
                        }
                        else if (choice == 6)
                        {
                            Console.WriteLine("----------- ADD NEW OBGECT ------------");
                            Good g = new Good();
                            g = g.Input();
                            goods.Add(g);
                           

                        }
                        else if (choice == 7)
                        {
                            Console.WriteLine("----------- UPDATE ------------");
                            Console.Write("Enter id: ");
                            int id = int.Parse(Console.ReadLine());
                            goods.Update(id);
                        }
                        else if (choice == 8)
                        {
                            Console.WriteLine("----------- WRITE TO FILE ------------");
                            Console.Write("Enter file path: ");
                            string path = Console.ReadLine();
                            goods.WriteFile(path);
                        }
                        else if (choice == 9)
                        {
                            break;
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("bad values");

                }
            }

          

            Console.ReadKey();
        }
    }
}

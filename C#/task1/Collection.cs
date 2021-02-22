using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace practicts_task_1
{
    class Collection
    {
        List<Good> arr = new List<Good>();


        public Collection ReadFile(string filename)
        {
            using(StreamReader f = new StreamReader(filename))
            {
                string json = f.ReadToEnd();
                var dicts = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
                foreach(var s in dicts)
                {
                    try
                    {
                        Good g = JsonConvert.DeserializeObject<Good>(JsonConvert.SerializeObject(s));
                        arr.Add(g);   
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"{e.Message}");
                    }

                }
            }
            return this;
        }

        public long size()
        {
           return arr.LongCount();
        }

        public void Print()
        {

            foreach(Good g in arr)
            {
                Type thisType = g.GetType();
                MethodInfo Output = thisType.GetMethod("Output");
                Output.Invoke(g, null);
            }
        }

        public void Add(Good g)
        {
            if( g != null)
            {
                arr.Add(g);
            }
        }

        public void Remove(int id)
        {
            arr.RemoveAll(x => x.Id == id);
        }

        public void Update(int id)
        {
            var indexOf = arr.IndexOf(arr.Find(g => g.Id == id));
            if (arr[indexOf] != null)
            {
                arr[indexOf] = arr[indexOf].Input();
            }
        }

        public void Sort(string attr)
        {
            arr = arr.OrderBy(atr => atr.GetType().GetProperty(attr).GetValue(atr)).ToList();
        }

        public void WriteFile(string filename)
        {
            string json = JsonConvert.SerializeObject(this.arr.ToArray());
            System.IO.File.WriteAllText(filename, json);
        }

        public void Search(string pattern)
        {
            foreach (Good g in arr)
            {
                if (g.locate(pattern))
                {
                    g.Output();
                }
            }
        }

    }
}

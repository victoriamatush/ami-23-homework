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
    class Collection<T>
    {
        List<T> arr = new List<T>();


        public Collection<T> ReadFile(string filename)
        {
            using(StreamReader f = new StreamReader(filename))
            {
                string json = f.ReadToEnd();
                var dicts = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
                foreach(var s in dicts)
                {
                    try
                    {
                        T g = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(s));
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

            foreach(T g in arr)
            {
                Type thisType = g.GetType();
                MethodInfo Output = thisType.GetMethod("Output");
                Output.Invoke(g, null);
            }
        }

        public void Add(T g)
        {
            if( g != null)
            {
                arr.Add(g);
            }
        }

        public void Remove(int id)
        {
            arr.RemoveAll(x => (int)x.GetType().GetProperty("Id").GetValue(x) == id);
        }

        public void Update(int id)
        {
            var n = arr.IndexOf(arr.Find(x => (int)x.GetType().GetProperty("Id").GetValue(x) == id));
            Type type = typeof(T);
            Type[] emptyArgumentTypes = Type.EmptyTypes;
            ConstructorInfo emptyConstructor = type.GetConstructor(emptyArgumentTypes);
            object g = emptyConstructor.Invoke(new object[] { });
            MethodInfo Input = type.GetMethod("Input");
            g = (T)Input.Invoke(g, null);        
            if (g != null)
            {
                arr[n] = (T)g;
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
            foreach (T g in arr)
            {
                Type thisType = g.GetType();
                MethodInfo locate = thisType.GetMethod("locate");
                MethodInfo Output = thisType.GetMethod("Output");
                if ((bool)locate.Invoke(g, new object[] {pattern}))
                {
                    Output.Invoke(g, null);
                }
            }
        }

    }
}

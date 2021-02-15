using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicts_task_1
{
    class Collection
    {
        [JsonProperty(PropertyName = "Goods")]
        List<Good> arr = new List<Good>();

        public Collection ReadFile(string filename)
        {
            string json = File.ReadAllText(filename);
            Collection goods = JsonConvert.DeserializeObject<Collection>(json);
            return goods;
        }

        public long size()
        {
           return arr.LongCount();
        }

        public void Print()
        {
            foreach(Good g in arr)
            {
                g.Output();
            }
        }

        public void Add(Good g)
        {
            arr.Add(g);
        }

        public void Remove(int id)
        {
            arr.RemoveAll(x => x.Id == id);
        }

        public void Update(int id)
        {
            var indexOf = arr.IndexOf(arr.Find(g => g.Id == id));
            arr[indexOf] = arr[indexOf].Input();
        }
        
        public void Sort(string attr)
        {
            arr = arr.OrderBy(atr => atr.GetType().GetProperty(attr).GetValue(atr)).ToList();
        }

        public void WriteFile(string filename)
        {
            var tojson = new Dictionary<string, List<Good>;
            tojson["Goods"] = arr;
            File.WriteAllText(filename, JsonConvert.SerializeObject(tojson));
            
        }

        public void Search(string pattern)
        {
            foreach(Good g in arr)
            {
                if (g.locate(pattern))
                {
                    g.Output();
                }
            }
        }

    }
}

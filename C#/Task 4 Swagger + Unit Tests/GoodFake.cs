using RESTAPI.Models;
using RESTAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestsApi
{
    public class GoodFake: IGoodService
    {
        public List<Good> goods;

        public GoodFake()
        {
            goods = new List<Good>()
            {
                new Good
                {
                    Id = 1,
                    Code = "333-458-585",
                    Title = "Pillow",
                    Type = "box",
                    Amount = 140,
                    Price = 190,
                    Data = "Very soft"
                },
                new Good
                {
                    Id = 2,
                    Code = "908-458-585",
                    Title = "Glass",
                    Type = "box",
                    Amount = 40,
                    Price = 90.8,
                    Data = "Safe transporting"
                },
                new Good
                {
                    Id = 3,
                    Code = "908-338-585",
                    Title = "Paper",
                    Type = "letter",
                    Amount = 33,
                    Price = 1.7,
                    Data = "Good quality"
                }
            };
        }

        public bool Exist(int id)
        {
            if (goods.FirstOrDefault(c => c.Id == id) == null)
            {
                return false;
            }
            return true;
        }

        public void Delete(int id)
        {
            Good good = goods.FirstOrDefault(c => c.Id == id);
            goods.Remove(good);
        }

        public IEnumerable<Good> GetAll(string search,
                                             string sort_by, string sort_type,
                                             int offset, int limit)
        {


            List<Good> searchGood = new();
            PropertyInfo[] attributes = typeof(Good).GetProperties();
            if (!string.IsNullOrEmpty(search))
            {
                foreach (Good good in goods)
                {
                    foreach (PropertyInfo attr in attributes)
                    {
                        if (Convert.ToString(attr.GetValue(good, null)).ToLower().Contains(search.ToLower()))
                            if (!searchGood.Contains(good))
                                searchGood.Add(good);
                    }
                }
                goods = searchGood;
            }

            if (!string.IsNullOrEmpty(sort_by))
            {
                foreach (var item in typeof(Good).GetProperties())
                {
                    if (item.Name == sort_by && sort_type == "desc")
                    {
                        goods = goods.OrderByDescending(c =>
                            c.GetType().GetProperty(sort_by).GetValue(c, null))
                            .ToList();
                    }
                    else if (item.Name == sort_by)
                    {
                        goods = goods.OrderBy(c =>
                            c.GetType().GetProperty(sort_by).GetValue(c, null))
                            .ToList();
                    }
                }
            }

            if (limit < 1)
                limit = 10;
            if (offset != 0)
                goods = goods
                    .Skip((offset - 1) * limit)
                    .Take(limit).ToList();

            return goods;
        }

        public Good GetById(int id)
        {
            Good g = goods.FirstOrDefault(x => x.Id == id);
            return g;
        }

        public void Post(Good g)
        {
            goods.Add(g);
        }

        public void Put(Good g)
        {
            goods[goods.FindIndex(c => c.Id == g.Id)] = g;
        }

        public int Count()
        {
            return goods.Count();
        }

    }
}

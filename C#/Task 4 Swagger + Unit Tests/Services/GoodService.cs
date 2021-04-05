using RESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RESTAPI.Services
{
    public class GoodService : IGoodService
    {
        private readonly GoodContext context = new();

        public GoodService(GoodContext _context)
        {
            context = _context;
        }
        public bool Exist(int id)
        {
            Good g = context.Goods.Find(id);
            if (g == null)
            {
                return false;
            }
            return true;
        }

        public void Delete(int id)
        {
            Good good = context.Goods.FirstOrDefault(c => c.Id == id);
            context.Goods.Remove(good);
            context.SaveChanges();
        }

        public IEnumerable<Good> GetAll(string search,
                                             string sort_by,string sort_type, 
                                             int offset, int limit)
        {

            List<Good> goods = context.Goods.ToList();

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
            Good g = context.Goods.FirstOrDefault(x => x.Id == id);
            return g;
        }

        public void Post(Good g)
        {
            context.Goods.Add(g);
            context.SaveChanges();
        }

        public void Put(Good g)
        {
            context.Goods.Update(g);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Goods.Count();
        }
    }
}

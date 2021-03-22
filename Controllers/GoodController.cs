using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RESTAPI.Controllers
{
    [ApiController]
    public class GoodController : ControllerBase
    {
        GoodContext context = new();

        public GoodController(GoodContext _context)
        {
            context = _context;
        }

            [HttpGet]
        [Route("get/")]
        public IActionResult Get(string sort_by, string sort_type,
            string search, int offset, int limit)
        {
            List<Good> goods = context.Goods.ToList();

            if (limit == 0)
                limit = 10;
            if (offset != 0)
                goods = goods
                    .Skip((offset - 1) * limit)
                    .Take(limit).ToList();

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

            List<Good> searchGood = new();
            PropertyInfo[] attributes = typeof(Good).GetProperties();
            if (!string.IsNullOrEmpty(search))
            {
                foreach (Good good in goods)
                {
                    foreach (PropertyInfo attr in attributes)
                    {
                        if (Convert.ToString(attr.GetValue(good, null)).ToLower().Contains(search.ToLower()))
                        {
                            if (!searchGood.Contains(good))
                                searchGood.Add(good);
                        }
                    }
                }
                goods = searchGood;
            }      

            return Ok(new { goods = goods, count = goods.Count() });
        }

        [HttpPost]
        [Route("post/")]
        public IActionResult Post(Good good)
        {
            if (ModelState.IsValid)
            {
                context.Goods.Add(good);
                context.SaveChanges();
                return Ok(new { status = Ok().StatusCode, massage = "Good has been successfully created" });
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("get/{id}/")]
        public IActionResult GetById(int id)
        {
            Good good = context.Goods.Find(id);
            if (good == null)
            {
                return NotFound(new
                {
                    status = NotFound().StatusCode,
                    message = "Good is not found"
                });
            }
            return Ok(good);
        }

        [HttpDelete]
        [Route("delete/{id}/")]
        public IActionResult Delete(int id)
        {
            Good good = context.Goods.FirstOrDefault(c => c.Id == id);
            if (good == null)
            {
                return NotFound(new
                {
                    status = NotFound().StatusCode,
                    message = "Good is not found"
                });
            }
            context.Goods.Remove(good);
            context.SaveChanges();
            return Ok(new 
                { 
                status = Ok().StatusCode,
                message = "Good has been successfully deleted"
                });
        }

        
        [HttpPut]
        [Route("put/")]
        public IActionResult Put(Good good)
        {
            if (good == null || !context.Goods.Any(x => x.Id == good.Id))
            {
                return NotFound(new
                {
                    status = NotFound().StatusCode,
                    message = "Good is not found"
                });
            }
            if (ModelState.IsValid)
            {
                context.Goods.Update(good);
                context.SaveChanges();
                return Ok(new { status = Ok().StatusCode, 
                    massage = "Good has been successfully updated",
                    good });
            }
            return BadRequest();
        }
    }
}

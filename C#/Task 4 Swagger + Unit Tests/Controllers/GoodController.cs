using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;
using RESTAPI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace RESTAPI.Controllers
{
    [ApiController]
    public class GoodController : ControllerBase
    {
        private readonly IGoodService goods;

        public GoodController(IGoodService _goods)
        {
            goods = _goods;
        }

        /// <summary>
        /// Return all goods 
        /// </summary>
        /// <param name="sort_by">Property name to sort by</param>
        /// <param name="sort_type">Decsending or ascending type of sorting</param>
        /// <param name="search">Any string to search</param>
        /// <param name="offset">Number of page, start from 1</param>
        /// <param name="limit">Amount of the goods on the page</param>
        [HttpGet]
        [Route("get/")]
        public IActionResult Get(string sort_by, string sort_type,
            string search, int offset, int limit)
        {
            return Ok(new { goods = goods.GetAll(search, sort_by, sort_type, offset, limit), count = goods.Count() });
        }

        /// <summary>
        /// Creates new good 
        /// </summary>
        /// <response code="201">New good is successfully created</response>
        /// <response code="400">Invalid data to create a good</response>
        /// <param name="good">On object of Good type to post</param>
        [HttpPost]
        [Route("post/")]
        public IActionResult Post(Good good)
        {
            if (ModelState.IsValid)
            {
                goods.Post(good);
                return Ok(new { status = Ok().StatusCode, massage = "Good has been successfully created" });
            }
            else
            {
                var error = ModelState.Where(e => e.Value.Errors.Count > 0).Select(e => new { Name = e.Key, Message = e.Value.Errors.First().ErrorMessage }).ToList();
                return BadRequest(new
                {
                    HttpStatusCode.BadRequest,
                    errors = new Dictionary<string, object>()
                    {
                        { "ErrorList", error }
                    }});
            }
            
        }

        /// <summary>
        /// Return a good by it's id
        /// </summary>
        /// <response code="404">Good with such id is not found</response>
        /// <param name="id">Id of an existing item</param>
        [HttpGet]
        [Route("get/{id}/")]
        public IActionResult GetById(int id)
        {
            Good good = goods.GetById(id);
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

        /// <summary>
        /// Delete a good by id
        /// </summary>
        /// <returns>New created good</returns>
        /// <response code="404">Good with no existing id can not be deleted</response>
        /// <response code="200">Good was created successfully</response>
        /// <param name="id">Id of an existing item</param>
        [HttpDelete]
        [Route("delete/{id}/")]
        public IActionResult Delete(int id)
        {
            if (!goods.Exist(id))
            {
                return NotFound(new
                {
                    status = NotFound().StatusCode,
                    message = "Good is not found"
                });
            }
            goods.Delete(id);
            return Ok(new 
                { 
                status = Ok().StatusCode,
                message = "Good has been successfully deleted"
                });
        }

        /// <summary>
        /// Updates an existing good
        /// </summary>
        /// <returns>New created good</returns>
        /// <response code="404">Good with no existing id can not be updated</response>
        /// <response code="200">Good was updated successfully</response>
        /// <param name="good">On object with already existing id of Good type to update</param>
        [HttpPut]
        [Route("put/")]
        public IActionResult Put(Good good)
        {
            if (good == null || !goods.Exist(good.Id))
            {
                return NotFound(new
                {
                    status = NotFound().StatusCode,
                    message = "Good is not found"
                });
            }
            if (ModelState.IsValid)
            {
                goods.Put(good);
                return Ok(new { status = Ok().StatusCode, 
                    massage = "Good has been successfully updated",
                    good });
            }
            return BadRequest();
        }
    }
}

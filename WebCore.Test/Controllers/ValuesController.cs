﻿using System;
using System.Collections.Generic;
using CNSuny.Infrastructure.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebCore.Test.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCore.Test.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseApiController
    {
      
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //throw new Exception("测试异常");
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]User value)
        {
            Console.WriteLine(JsonConvert.SerializeObject(value));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

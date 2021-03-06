﻿using System;
using System.Collections.Generic;
using System.Fabric;
using Microsoft.AspNetCore.Mvc;

namespace SFTestStateless.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly StatelessServiceContext _serviceContext;
        
        public ValuesController(
            StatelessServiceContext context, 
            IQueueClient client)
        {
            _serviceContext = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            ServiceEventSource.Current.ServiceMessage(this._serviceContext, "Get values methos has been called");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System.Collections.Generic;
using Core.ApiSelectProperty.Sample.Models;
using Core.ApiSelectProperty.Sample.Results;
using Microsoft.AspNetCore.Mvc;

namespace Core.ApiSelectProperty.Sample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return new CustomContentResult(new List<Customer>
            {
                new Customer() {Name = "Jim", Title="Boss", Password="Password" }
            });
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infraestructure.data.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace rest_application.controllers
{
    [Route("api/Shopping")]
    public class ShoppingCardController : Controller
    {
        public readonly Iproducts_repository _repo;

        public ShoppingCardController(Iproducts_repository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("shopping/Home")]
        public IActionResult Home()
        {
            var response = _repo.List();
            return this.Ok(new  { sucess= "ok", data = response });
        }
    }
}
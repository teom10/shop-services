using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using domain.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using services.interfaces;

namespace shopping_ui.Controllers
{
    [Route("api/")]
    [ApiController]
    public class productsController : ControllerBase
    {
        private readonly Iproducts_services _productServices;
        public productsController(Iproducts_services productServices)
        {
            _productServices = productServices;
        }

        [Route("shopping")]
        [HttpPost]
        public IActionResult Home()
        {
            var c = _productServices.GetAllProducts();
            return this.Ok(new { sucess = "ok", data = c });
        }


        [Route("shopping")]
        [HttpPost]
        public IActionResult AddProducts(products products)
        {
            var response = new response<products>();
            try
            {
                response.Obj = products;
                response.Code = (int)HttpStatusCode.Accepted;
                response.Message = string.Empty;
            }
            catch (Exception ex)
            {
                response.Obj = null;
                response.Code = (int)HttpStatusCode.Conflict;
                response.Message = $"Error" + ex.InnerException.Message + ex.Message;
            }
            return this.Ok(response);
        }

    }
}
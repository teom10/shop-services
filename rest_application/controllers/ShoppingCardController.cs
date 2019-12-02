using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.entities;
using infraestructure.data.interfaces;
using infraestructure.interfaces;
using Microsoft.AspNetCore.Mvc;
using services.interfaces;

namespace rest_application.controllers
{
    [Route("api/")]
    public class ShoppingCardController : ControllerBase
    {
        private readonly Iproducts_services _productServices;


        public ShoppingCardController(Iproducts_services productServices)
        {
            _productServices = productServices;
        }


        [Route("shopping")]
        [HttpPost]
        public IActionResult Home()
        {
            var c = _productServices.GetAllProducts();
            return this.Ok(new  { sucess= "ok", data = c });
        }

        [Route("addproducts")]
        [HttpPost]
        public IActionResult AddProducts(products products)
        {
            var response = new response<products>();
             try{
                 response.Message=string.Empty;
                 response.Obj = products;
                 _productServices.AddProducts(products);
                 response.HttpStatusCode.Ok;

             }catch(Exception ex){
                response.Obj = null;
                response.Code = HttpStatusCode.Conflict;
                response.Message = $"Error" + ex.Message +  ex.InnerException.Message;
             }
        }

    }
}
using domain.entities;
using infraestructure.interfaces;
using services.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace services.classes
{
    public class products_services : Iproducts_services
    {
        private readonly Irepository<products>  _productRepo;

        public products_services(Irepository<products> productRepo)
        {
            _productRepo = productRepo;
        }

        public void AddProducts(products products)
        {
            try
            {
                _productRepo.Insert(products);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteProducts(products products)
        {
            try
            {
                _productRepo.Delete(products);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IList<products> GetAllProducts()
        {
            try
            {
                return _productRepo.List();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public products GetProducts(products products)
        {
            try
            {
                return _productRepo.Get((Guid)products.Id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateProducts(products products)
        {
            try
            {
                _productRepo.Update(products);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

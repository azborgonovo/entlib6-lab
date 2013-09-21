using EntLib6Lab.Application.Dtos;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLib6Lab.Application.Services
{
    public class ProductsService : IProductsService
    {
        ExceptionManager _exceptionManager;

        public ProductsService(ExceptionManager exceptionManager)
        {
            if (exceptionManager == null) throw new ArgumentNullException("exceptionManager");

            _exceptionManager = exceptionManager;
        }

        public void AddProduct(ProductDto product)
        {
            _exceptionManager.Process(() =>
            {
                Console.WriteLine(string.Format("The product {0} has been added!", product.Name));

            }, "ShieldingException");
        }
    }
}

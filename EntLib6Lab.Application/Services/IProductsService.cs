using EntLib6Lab.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLib6Lab.Application.Services
{
    public interface IProductsService
    {
        void AddProduct(ProductDto product);
    }
}

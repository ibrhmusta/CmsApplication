using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<ProductDetailDto>> GetAllProductDetails();
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
    }

}

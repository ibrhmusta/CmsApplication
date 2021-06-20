using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, CmsContext>, IProductDal
    {
        public List<ProductDetailDto> GetAllProductDetails(Expression<Func<Product, bool>> filter = null)
        {
            using (CmsContext context = new CmsContext())
            {
                var result = from product in filter == null ? context.Products : context.Products.Where(filter)
                             join category in context.Categories
                                on product.CategoryId equals category.Id                         
                             select new ProductDetailDto
                             {
                                 Product = product,
                                 CategoryName = category.Name,                             
                             };
                return result.ToList();
            }
        }
    }
}

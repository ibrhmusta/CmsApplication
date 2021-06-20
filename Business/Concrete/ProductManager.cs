using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
            //nullcheck eklenecek
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            product.CreatedDate = System.DateTime.Now;
            product.ModifiedDate = System.DateTime.Now;
            product.IsActive = true;
            product.IsDeleted = false;
            _productDal.Add(product);
            return new SuccessResult(SuccessMessages.PRODUCT_ADDED);
        }

        public IResult Delete(Product product)
        {
            product.ModifiedDate = System.DateTime.Now;
            product.IsActive = false;
            product.IsDeleted = true;
            _productDal.Update(product);
            return new SuccessResult(SuccessMessages.PRODUCT_DELETED);
        }

        public IDataResult<List<Product>> GetAll()
        {
            var result = _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(result,SuccessMessages.PRODUCTS_LISTED);
        }

        public IDataResult<List<ProductDetailDto>> GetAllProductDetails()
        {
            var result = _productDal.GetAllProductDetails();
            return new SuccessDataResult<List<ProductDetailDto>>(result, SuccessMessages.PRODUCT_DETAILS_LISTED);
        }

        public IResult Update(Product product)
        {
            return null;
        }
    }
}

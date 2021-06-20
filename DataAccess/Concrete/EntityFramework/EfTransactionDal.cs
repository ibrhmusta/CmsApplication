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
    public class EfTransactionDal : EfEntityRepositoryBase<Transaction, CmsContext>, ITransactionDal
    {
        public List<TransactionDetailDto> GetAllTransactionsDetails(Expression<Func<Transaction, bool>> filter = null)
        {
            using(CmsContext context = new CmsContext())
            {
                var result = from transaction in filter == null ? context.Transactions : context.Transactions.Where(filter)
                             join transactionProduct in context.TransactionProducts
                                on transaction.Id equals transactionProduct.TransactionId
                             join channel in context.Channels
                                on transaction.ChannelId equals channel.Id
                             join customer in context.Customers
                                on transaction.CustomerId equals customer.Id
                             join paymentType in context.PaymentTypes
                                on transaction.PaymentTypeId equals paymentType.Id
                             join product in context.Products
                                on transactionProduct.ProductId equals product.Id
                             join category in context.Categories
                                on product.CategoryId equals category.Id
                             select new TransactionDetailDto
                             {
                                 Transaction = transaction,
                                 TransactionProduct = transactionProduct,
                                 Channel = channel.Name,
                                 PaymentType = paymentType.Name,
                                 Product = product,
                                 Customer = customer,                                
                             };
                return result.ToList();
            }
        }
    }
}
